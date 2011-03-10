﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace SisoDb.Structures.Schemas
{
    public interface IProperty
    {
        PropertyInfo Member { get; }

        string Name { get; }

        string Path { get; }

        Type PropertyType { get; }

        int Level { get; }

        IProperty Parent { get; }
        
        bool IsSimpleType { get; }

        bool IsUnique { get; }

        bool IsValueType { get; }

        bool IsNullableValueType { get; }
       
        bool IsEnumerable { get; }

        bool IsElement { get; }
        
        Type ElementType { get; }

        TOut? GetIdValue<TRoot, TOut>(TRoot root)
            where TRoot : class 
            where TOut : struct;

        void SetIdValue<TRoot, TIn>(TRoot root, TIn value)
            where TRoot : class
            where TIn : struct;

        IList<object> GetValues<TRoot>(TRoot root)
            where TRoot : class;
    }
}