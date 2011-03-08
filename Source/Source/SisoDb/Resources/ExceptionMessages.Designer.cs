﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SisoDb.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SisoDb.Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Item of type &apos;{0}&apos; has no Id member specified. A Guid or Int property named &apos;Id&apos; was expected..
        /// </summary>
        internal static string AutoSchemaBuilder_MissingIdMember {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_MissingIdMember", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Item of type &apos;{0}&apos; has no members that are indexable. There&apos;s no point in storing items that has nothing to index..
        /// </summary>
        internal static string AutoSchemaBuilder_MissingIndexableMembers {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_MissingIndexableMembers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The id property: &apos;{0}&apos;; is not of suported type. Only Guid and Int is accepted..
        /// </summary>
        internal static string AutoSchemaBuilder_UnsupportedIdAccessorType {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_UnsupportedIdAccessorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Storageprovider &apos;{0}&apos; is unsupported. When consuming an Azure-database the storageprovider should be: &apos;{1}&apos;..
        /// </summary>
        internal static string AzureDatabase_UnsupportedProviderSpecified {
            get {
                return ResourceManager.GetString("AzureDatabase_UnsupportedProviderSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The IdType &apos;{0}&apos; is not supported when upserting tables!.
        /// </summary>
        internal static string DbSchemaUpserter_Upsert_IdTypeNotSupported {
            get {
                return ResourceManager.GetString("DbSchemaUpserter_Upsert_IdTypeNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Direct memberaccess of node: &apos;{0}&apos;; with with membertype: &apos;{1}&apos;; is not supported!.
        /// </summary>
        internal static string ExpressionEvaluator_EvaluateMemberExpression_NotSupported {
            get {
                return ResourceManager.GetString("ExpressionEvaluator_EvaluateMemberExpression_NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No MemberExpression found in expression: &apos;{0}&apos;..
        /// </summary>
        internal static string ExpressionUtils_GetRightMostMember_NoMemberFound {
            get {
                return ResourceManager.GetString("ExpressionUtils_GetRightMostMember_NoMemberFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Sortings has allready been initialized..
        /// </summary>
        internal static string GetCommand_SortingsAllreadyInitialized {
            get {
                return ResourceManager.GetString("GetCommand_SortingsAllreadyInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must provide an unique guid to the GuidId..
        /// </summary>
        internal static string Id_GuidIsMissingValue {
            get {
                return ResourceManager.GetString("Id_GuidIsMissingValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must provide a positive identity..
        /// </summary>
        internal static string Id_IdentityIsOutOfRange {
            get {
                return ResourceManager.GetString("Id_IdentityIsOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Property.PropertyType &apos;{0}&apos; is not supported by the IdAccessor..
        /// </summary>
        internal static string IdAccessor_UnsupportedPropertyType {
            get {
                return ResourceManager.GetString("IdAccessor_UnsupportedPropertyType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An Index-instance must be provided with a name..
        /// </summary>
        internal static string Index_IsMissingName {
            get {
                return ResourceManager.GetString("Index_IsMissingName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operator type &apos;{0}&apos; can not be converted to &apos;IsNotNullOperatpr&apos; or &apos;NullOperator&apos;..
        /// </summary>
        internal static string LambdaOperator_IsOrIsNot_NotSupported {
            get {
                return ResourceManager.GetString("LambdaOperator_IsOrIsNot_NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operator &apos;{0}&apos; is not supported!.
        /// </summary>
        internal static string LambdaOperator_OperatorTypeIsNotSupported {
            get {
                return ResourceManager.GetString("LambdaOperator_OperatorTypeIsNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Byte arrays are not supported for member: &apos;{0}&apos;..
        /// </summary>
        internal static string LambdaParser_MemberIsBytes {
            get {
                return ResourceManager.GetString("LambdaParser_MemberIsBytes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You cant only access a member in a query expression, you need to compare it against something. Eg. (x =&gt; x.HasItems) should be (x =&gt; x.HasItems == true).
        /// </summary>
        internal static string LambdaParser_NoMemberExpressions {
            get {
                return ResourceManager.GetString("LambdaParser_NoMemberExpressions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not evaluate the method call: &apos;{0}&apos;.
        ///Specific supported method exists as extensionmethods and are prefixed with &apos;Qx&apos;. Import namespace &apos;SisoDb.Querying&apos; to enable them..
        /// </summary>
        internal static string LambdaParser_UnsupportedMethodCall {
            get {
                return ResourceManager.GetString("LambdaParser_UnsupportedMethodCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conversion of values in expression is only allowed for nullable valuetypes..
        /// </summary>
        internal static string LambdaParser_VisitUnary_InvalidConvert {
            get {
                return ResourceManager.GetString("LambdaParser_VisitUnary_InvalidConvert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The unary operator &apos;{0}&apos; is not supported..
        /// </summary>
        internal static string LambdaParser_VisitUnary_NotSupported {
            get {
                return ResourceManager.GetString("LambdaParser_VisitUnary_NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The node of type: &apos;{0}&apos; is not supported!.
        /// </summary>
        internal static string ParsedSortingLambdaSqlProcessor_NotSupportedNodeType {
            get {
                return ResourceManager.GetString("ParsedSortingLambdaSqlProcessor_NotSupportedNodeType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You cant apply Unique on a member that is not of a simple type e.g. (int, string, bool) etc..
        /// </summary>
        internal static string Property_Ctor_UniqueOnNonSimpleType {
            get {
                return ResourceManager.GetString("Property_Ctor_UniqueOnNonSimpleType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id values must lie on the root object..
        /// </summary>
        internal static string Property_GetIdValue_InvalidLevel {
            get {
                return ResourceManager.GetString("Property_GetIdValue_InvalidLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id values must lie on the root object..
        /// </summary>
        internal static string Property_SetIdValue_InvalidLevel {
            get {
                return ResourceManager.GetString("Property_SetIdValue_InvalidLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Sortings has allready been initialized..
        /// </summary>
        internal static string QueryCommandBuilder_SortingsAllreadyInitialized {
            get {
                return ResourceManager.GetString("QueryCommandBuilder_SortingsAllreadyInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Where expression has allready been initialized..
        /// </summary>
        internal static string QueryCommandBuilder_WhereAllreadyInitialized {
            get {
                return ResourceManager.GetString("QueryCommandBuilder_WhereAllreadyInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A connectionstring or connectionstring name needs to be passed to the constructor..
        /// </summary>
        internal static string SisoConnectionInfo_MissingConnectionStringOrNameArg {
            get {
                return ResourceManager.GetString("SisoConnectionInfo_MissingConnectionStringOrNameArg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided StorageProvider &apos;{0}&apos; is not supported..
        /// </summary>
        internal static string SisoDbFactory_UnknownStorageProvider {
            get {
                return ResourceManager.GetString("SisoDbFactory_UnknownStorageProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The only supported methods for marking sortings are Asc() and Desc()..
        /// </summary>
        internal static string SortingParser_UnsupportedMethodForSortingDirection {
            get {
                return ResourceManager.GetString("SortingParser_UnsupportedMethodForSortingDirection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The name of the database could not be extracted from the connection-info..
        /// </summary>
        internal static string SqlDatabase_ConnectionInfo_MissingName {
            get {
                return ResourceManager.GetString("SqlDatabase_ConnectionInfo_MissingName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The database &apos;{0}&apos; doesn&apos;t exist..
        /// </summary>
        internal static string SqlDatabase_InitializeExisting_DbDoesNotExist {
            get {
                return ResourceManager.GetString("SqlDatabase_InitializeExisting_DbDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Storageprovider &apos;{0}&apos; is unsupported. When consuming an Sql-database the storageprovider should be: &apos;{1}&apos;..
        /// </summary>
        internal static string SqlDatabase_UnsupportedProviderSpecified {
            get {
                return ResourceManager.GetString("SqlDatabase_UnsupportedProviderSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can not flush a non transational DbClient..
        /// </summary>
        internal static string SqlDbClient_Flus_NonTransactional {
            get {
                return ResourceManager.GetString("SqlDbClient_Flus_NonTransactional", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Byte arrays are not supported for storage in the Indexes-table since they should not be queryable. Index name: &apos;{0}&apos;..
        /// </summary>
        internal static string SqlDbDataTypeTranslator_ByteArraysAreNotSupported {
            get {
                return ResourceManager.GetString("SqlDbDataTypeTranslator_ByteArraysAreNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The datatype &apos;{0}&apos; is not supported!.
        /// </summary>
        internal static string SqlDbDataTypeTranslator_UnsupportedDataType {
            get {
                return ResourceManager.GetString("SqlDbDataTypeTranslator_UnsupportedDataType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A where clause can not be generated if the query command doesn&apos;t contain a selector..
        /// </summary>
        internal static string SqlQueryGenerator_GenerateWhere {
            get {
                return ResourceManager.GetString("SqlQueryGenerator_GenerateWhere", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Id could be extracted from the new structure..
        /// </summary>
        internal static string SqlStructureSetUpdater_NewIdDoesNotExist {
            get {
                return ResourceManager.GetString("SqlStructureSetUpdater_NewIdDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Id of the new structure &apos;{0}&apos; does not match the Id of the old structure &apos;{1}&apos;..
        /// </summary>
        internal static string SqlStructureSetUpdater_NewIdDoesNotMatchOldId {
            get {
                return ResourceManager.GetString("SqlStructureSetUpdater_NewIdDoesNotMatchOldId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Id could be extracted from the old structure..
        /// </summary>
        internal static string SqlStructureSetUpdater_OldIdDoesNotExist {
            get {
                return ResourceManager.GetString("SqlStructureSetUpdater_OldIdDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The number of passed root items is not equal to the number of inserted root items!.
        /// </summary>
        internal static string SqlUnitOfWork_DoIdentityInsert_RootItemsMissmatch {
            get {
                return ResourceManager.GetString("SqlUnitOfWork_DoIdentityInsert_RootItemsMissmatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no &apos;{0}&apos;-structure to update matching the sent Id &apos;{1}&apos;..
        /// </summary>
        internal static string SqlUnitOfWork_NoItemExistsForUpdate {
            get {
                return ResourceManager.GetString("SqlUnitOfWork_NoItemExistsForUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value being retrieved is not of supported type. It must either be a string or the type needs to implement IConvertible or if Nullable&lt;T&gt;, then T needs to implement it..
        /// </summary>
        internal static string StringConverter_AsString_TypeOfValueIsNotSupported {
            get {
                return ResourceManager.GetString("StringConverter_AsString_TypeOfValueIsNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate Unique-index found for &apos;{0}&apos;.\r\nStructureId: &apos;{1}&apos;;Name: &apos;{2}&apos;;Value: &apos;{3}&apos;;.
        /// </summary>
        internal static string Structure_DuplicateUniques {
            get {
                return ResourceManager.GetString("Structure_DuplicateUniques", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When using identities the Id-property of the entity must be assigned before structure is created..
        /// </summary>
        internal static string StructureIdFactory_MissingIdentityValue {
            get {
                return ResourceManager.GetString("StructureIdFactory_MissingIdentityValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The identity type: &apos;{0}&apos; is not supported..
        /// </summary>
        internal static string StructureIdFactory_UnSupportedIdentityType {
            get {
                return ResourceManager.GetString("StructureIdFactory_UnSupportedIdentityType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only strings and valuetypes can be stored as indexes..
        /// </summary>
        internal static string StructureIndex_ValueArgument_IncorrectType {
            get {
                return ResourceManager.GetString("StructureIndex_ValueArgument_IncorrectType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Unique index &apos;{0}&apos;:&apos;{1}&apos; is evaluated to Null. This is not alowed..
        /// </summary>
        internal static string StructureIndexesFactory_UniqueIndex_IsNull {
            get {
                return ResourceManager.GetString("StructureIndexesFactory_UniqueIndex_IsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Supported generic collections on model are: implementations of either IEnumerable&lt;T&gt; or IList&lt;T&gt;..
        /// </summary>
        internal static string TypeExtensions_ExtractGenericType {
            get {
                return ResourceManager.GetString("TypeExtensions_ExtractGenericType", resourceCulture);
            }
        }
    }
}
