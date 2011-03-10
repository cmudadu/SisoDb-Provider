﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SisoDb.Annotations;
using SisoDb.Reflections;
using SisoDb.Resources;

namespace SisoDb.Structures.Schemas
{
    [Serializable]
    public class Property : IProperty
    {
        private Delegate _idGetter;
        private Delegate _idSetter;

        private static readonly Type UniqueAttributeType = typeof(UniqueAttribute);

        private List<PropertyInfo> Callstack { get; set; }

        public PropertyInfo Member { get; set; }

        public string Name
        {
            get { return Member.Name; }
        }

        public string Path { get; private set; }

        public Type PropertyType
        {
            get { return Member.PropertyType; }
        }

        public int Level { get; private set; }

        public IProperty Parent { get; private set; }

        public bool IsSimpleType { get; private set; }

        public bool IsUnique { get; private set; }

        public bool IsValueType { get; private set; }

        public bool IsNullableValueType { get; private set; }

        public bool IsEnumerable { get; private set; }

        public bool IsElement { get; private set; }

        public Type ElementType { get; private set; }

        public Property(PropertyInfo member)
            : this(0, null, member)
        {
        }

        public Property(int level, IProperty parent, PropertyInfo member)
        {
            Member = member;
            Level = level;
            Parent = parent;

            IsSimpleType = Member.PropertyType.IsSimpleType();
            IsValueType = Member.PropertyType.IsValueType;
            IsNullableValueType = IsValueType && Member.PropertyType.IsNullableValueType();
            IsEnumerable = !IsSimpleType && Member.PropertyType.IsEnumerableType();
            ElementType = IsEnumerable ? Member.PropertyType.GetEnumerableElementType() : null;
            IsElement = Parent != null && (Parent.IsElement || Parent.IsEnumerable);
            
            var uniqueAttribute = (UniqueAttribute)Member.GetCustomAttributes(UniqueAttributeType, true).FirstOrDefault();
            if (uniqueAttribute != null && !IsSimpleType)
                throw new SisoDbException(ExceptionMessages.Property_Ctor_UniqueOnNonSimpleType);

            IsUnique = uniqueAttribute == null ? false : true;

            Path = PropertyPathBuilder.BuildPath(this);

            Callstack = GetCallstack(this);
            Callstack.Reverse();

            InitializeIdGetter();
            InitializeIdSetter();
        }

        private void InitializeIdGetter()
        {
            if (Member.Name != StructureSchema.IdMemberName)
                return;

            var type = Member.DeclaringType;
            var factoryClassType = typeof (Reflect);

            if(!IsNullableValueType)
            {
                var getterFactory = factoryClassType.GetMethod("GetterFor").MakeGenericMethod(type, Member.PropertyType);
                _idGetter = (Delegate)getterFactory.Invoke(null, new object[] { Member });    
            }
            else
            {
                var getterFactory = factoryClassType.GetMethod("GetterForNullable").MakeGenericMethod(type, Member.PropertyType.GetGenericArguments()[0]);
                _idGetter = (Delegate)getterFactory.Invoke(null, new object[] { Member });   
            }
        }

        private void InitializeIdSetter()
        {
            if (Member.Name !=  StructureSchema.IdMemberName)
                return;

            var type = Member.DeclaringType;
            var factoryClassType = typeof(Reflect);

            if (!IsNullableValueType)
            {
                var setterFactory = factoryClassType.GetMethod("SetterFor").MakeGenericMethod(type, Member.PropertyType);
                _idSetter = (Delegate)setterFactory.Invoke(null, new object[] { Member });
            }
            else
            {
                var setterFactory = factoryClassType.GetMethod("SetterForNullable").MakeGenericMethod(type, Member.PropertyType.GetGenericArguments()[0]);
                _idSetter = (Delegate)setterFactory.Invoke(null, new object[] { Member });
            }
        }

        private static List<PropertyInfo> GetCallstack(IProperty property)
        {
            if (property.Level == 0)
                return new List<PropertyInfo> { property.Member };

            var props = new List<PropertyInfo> { property.Member };
            var tmp = GetCallstack(property.Parent);
            props.AddRange(tmp);

            return props;
        }

        public TOut? GetIdValue<TRoot, TOut>(TRoot root)
            where TRoot : class
            where TOut : struct
        {
            if (Level != 0)
                throw new SisoDbException(ExceptionMessages.Property_GetIdValue_InvalidLevel);

            return !Member.PropertyType.IsNullableValueType()
                       ? ((Func<TRoot, TOut>)_idGetter).Invoke(root)
                       : ((Func<TRoot, TOut?>)_idGetter).Invoke(root);
        }

        public void SetIdValue<TRoot, TIn>(TRoot root, TIn value)
            where TRoot : class
            where TIn : struct
        {
            if (Level != 0)
                throw new SisoDbException(ExceptionMessages.Property_SetIdValue_InvalidLevel);

            if (!Member.PropertyType.IsNullableValueType())
                ((Action<TRoot, TIn>)_idSetter).Invoke(root, value);
            else
                ((Action<TRoot, TIn?>)_idSetter).Invoke(root, value);
        }

        public IList<object> GetValues<TRoot>(TRoot item)
            where TRoot : class 
        {
            if (Level == 0)
            {
                var firstLevelPropValue = Member.GetValue(item, null);
                if (firstLevelPropValue == null)
                    return null;

                if (!IsEnumerable)
                    return new List<object> { firstLevelPropValue };

                var values = new List<object>();
                foreach (var value in (ICollection)firstLevelPropValue)
                    values.Add(value);

                return values;
            }

            return TraverseCallstack(item, 0);
        }
        
        private IList<object> TraverseCallstack<T>(T startNode, int startIndex)
        {
            object currentNode = startNode;
            for (var c = startIndex; c < Callstack.Count; c++)
            {
                if (currentNode == null)
                    return new object[] { null };

                var currentPropertyInfo = Callstack[c];
                var isLastPropertyInfo = c == (Callstack.Count - 1);
                if (isLastPropertyInfo)
                {
                    if (!(currentNode is ICollection))
                    {
                        var currentValue = currentPropertyInfo.GetValue(currentNode, null);
                        return new[] { currentValue };
                    }

                    var currentNodes = (ICollection)currentNode;
                    return ExtractValuesForEnumerableOfComplex(currentNodes, currentPropertyInfo);
                }

                if (!(currentNode is ICollection))
                    currentNode = currentPropertyInfo.GetValue(currentNode, null);
                else
                {
                    var currentNodes = (ICollection)currentNode;
                    var values = new List<object>();
                    foreach (var node in currentNodes)
                    {
                        var nodeValue = currentPropertyInfo.GetValue(node, null);
                        var tmp = TraverseCallstack(nodeValue, c + 1);
                        values.AddRange(tmp);
                    }
                    return values;
                }
            }

            return null;
        }

        private static IList<object> ExtractValuesForEnumerableOfComplex(ICollection nodes, PropertyInfo propertyAccessor)
        {
            var values = new List<object>();
            foreach (var node in nodes)
            {
                if (node == null)
                {
                    values.Add(null);
                    continue;
                }

                var nodeValue = propertyAccessor.GetValue(node, null);

                if (nodeValue == null || !(nodeValue is ICollection))
                    values.Add(nodeValue);
                else
                    foreach (var nodeValueElement in (ICollection)nodeValue)
                        values.Add(nodeValueElement);
            }

            return values;
        }
    }
}