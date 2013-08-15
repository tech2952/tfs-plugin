///////////////////////////////////////////////////////////////
// This is generated code. If you modify this code, be aware
// of the fact that when you re-generate the code, your changes
// are lost. If you want to keep your changes, make this file read-only
// when you have finished your changes, however it is recommended that
// you inherit from this class to extend the functionality of this generated
// class or you modify / extend the templates used to generate this code.
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 1.0.2005.1
// Code is generated on: Wednesday, August 13, 2008 10:50:44 AM
// Code is generated using templates: C# template set for SqlServer (1.0.2005.1)
// Templates vendor: Solutions Design.
// Templates version: 1.0.2005.1.102305
//////////////////////////////////////////////////////////////
using System;

using TestHarness.DataObjects;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.FactoryClasses
{
	/// <summary>
	/// Class which eases the creation of the different predicate clauses defined in the ORM support classes. 
	/// Use these methods to create predicate clauses for filters without a lot of code.
	/// </summary>
	public partial class PredicateFactory
	{
		/// <summary>
		/// Static class, no CTor
		/// </summary>
		private PredicateFactory()
		{
		}

		#region FieldCompareValuePredicate creators (4 per entity type)

		/// <summary>FieldCompareValuePredicate factory for ClientEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for ClientEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for FirmEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for FirmEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for FirmEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for FirmEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for LocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for LocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		/// <summary>FieldCompareValuePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, negate);
		}

		/// <summary>FieldCompareValuePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareValuePredicate CompareValue(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, object value, string objectAlias, bool negate)
		{
			return new FieldCompareValuePredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, value, objectAlias, negate);
		}
		#endregion

		#region FieldCompareValuePredicate creators (4 per typed view type)

		#endregion

		#region FieldCompareNullPredicate creators (4 per entity type)

		/// <summary>FieldCompareNullPredicate factory for ClientEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for ClientEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for ClientEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for ClientEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientCustomerFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientCustomerFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientCustomerFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientCustomerFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientLocatorFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientLocatorFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientLocatorFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(ClientLocatorFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerLocatorAuthorizationFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerLocatorAuthorizationFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerLocatorAuthorizationFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerLocatorAuthorizationFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNameFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNameFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNameFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNameFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNamespaceAuthorizationFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNamespaceAuthorizationFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNamespaceAuthorizationFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(CustomerNamespaceAuthorizationFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enterprise_InformationFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enterprise_InformationFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enterprise_InformationFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enterprise_InformationFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_AuthorizationTypeFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_AuthorizationTypeFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_AuthorizationTypeFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_AuthorizationTypeFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataSourceFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataSourceFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataSourceFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataSourceFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataTypeFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataTypeFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataTypeFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(Enum_DataTypeFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for FirmEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(FirmFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for FirmEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(FirmFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for FirmEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(FirmFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for FirmEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(FirmFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for LocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorGridRowFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorGridRowFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorGridRowFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorGridRowFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorNodeComputedValueFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorNodeComputedValueFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorNodeComputedValueFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorNodeComputedValueFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectRecordFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectRecordFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectRecordFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectRecordFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectValueFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectValueFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectValueFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorObjectValueFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorRolloverFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorRolloverFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorRolloverFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(LocatorRolloverFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputedResultsFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputedResultsFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputedResultsFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputedResultsFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		/// <summary>FieldCompareNullPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputeFieldsFieldIndex indexOfField)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField));
		}

		/// <summary>FieldCompareNullPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputeFieldsFieldIndex indexOfField, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), negate);
		}

		/// <summary>FieldCompareNullPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputeFieldsFieldIndex indexOfField, string objectAlias)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias);
		}

		/// <summary>FieldCompareNullPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareNullPredicate CompareNull(TempComputeFieldsFieldIndex indexOfField, string objectAlias, bool negate)
		{
			return new FieldCompareNullPredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate);
		}
		#endregion

		#region FieldCompareNullPredicate creators (4 per typed view type)

		#endregion

		#region FieldBetweenPredicate creators (4 per entity type)

		/// <summary>FieldBetweenPredicate factory for ClientEntity.</summary>
		public static FieldBetweenPredicate Between(ClientFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for ClientEntity.</summary>
		public static FieldBetweenPredicate Between(ClientFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for ClientEntity.</summary>
		public static FieldBetweenPredicate Between(ClientFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for ClientEntity.</summary>
		public static FieldBetweenPredicate Between(ClientFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for ClientCustomerEntity.</summary>
		public static FieldBetweenPredicate Between(ClientCustomerFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for ClientCustomerEntity.</summary>
		public static FieldBetweenPredicate Between(ClientCustomerFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for ClientCustomerEntity.</summary>
		public static FieldBetweenPredicate Between(ClientCustomerFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for ClientCustomerEntity.</summary>
		public static FieldBetweenPredicate Between(ClientCustomerFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for ClientLocatorEntity.</summary>
		public static FieldBetweenPredicate Between(ClientLocatorFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for ClientLocatorEntity.</summary>
		public static FieldBetweenPredicate Between(ClientLocatorFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for ClientLocatorEntity.</summary>
		public static FieldBetweenPredicate Between(ClientLocatorFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for ClientLocatorEntity.</summary>
		public static FieldBetweenPredicate Between(ClientLocatorFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerLocatorAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerLocatorAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerLocatorAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerLocatorAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for CustomerNameEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNameFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerNameEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNameFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerNameEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNameFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerNameEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNameFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNamespaceAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNamespaceAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNamespaceAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldBetweenPredicate Between(CustomerNamespaceAuthorizationFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldBetweenPredicate Between(Enterprise_InformationFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldBetweenPredicate Between(Enterprise_InformationFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldBetweenPredicate Between(Enterprise_InformationFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldBetweenPredicate Between(Enterprise_InformationFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_AuthorizationTypeFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_AuthorizationTypeFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_AuthorizationTypeFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_AuthorizationTypeFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataSourceFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataSourceFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataSourceFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataSourceFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataTypeFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataTypeFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataTypeFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldBetweenPredicate Between(Enum_DataTypeFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for FirmEntity.</summary>
		public static FieldBetweenPredicate Between(FirmFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for FirmEntity.</summary>
		public static FieldBetweenPredicate Between(FirmFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for FirmEntity.</summary>
		public static FieldBetweenPredicate Between(FirmFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for FirmEntity.</summary>
		public static FieldBetweenPredicate Between(FirmFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for LocatorEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorGridRowFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorGridRowFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorGridRowFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorGridRowFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorNodeComputedValueFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorNodeComputedValueFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorNodeComputedValueFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorNodeComputedValueFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectRecordFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectRecordFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectRecordFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectRecordFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectValueFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectValueFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectValueFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorObjectValueFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorRolloverFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorRolloverFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorRolloverFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldBetweenPredicate Between(LocatorRolloverFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputedResultsFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputedResultsFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputedResultsFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputedResultsFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		/// <summary>FieldBetweenPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputeFieldsFieldIndex indexOfField, object valueBegin, object valueEnd)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd);
		}

		/// <summary>FieldBetweenPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputeFieldsFieldIndex indexOfField, object valueBegin, object valueEnd, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, negate);
		}

		/// <summary>FieldBetweenPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputeFieldsFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias);
		}

		/// <summary>FieldBetweenPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldBetweenPredicate Between(TempComputeFieldsFieldIndex indexOfField, object valueBegin, object valueEnd, string objectAlias, bool negate)
		{
			return new FieldBetweenPredicate(EntityFieldFactory.Create(indexOfField), valueBegin, valueEnd, objectAlias, negate);
		}
		#endregion

		#region FieldBetweenPredicate creators (4 per typed view type)

		#endregion

		#region FieldLikePredicate creators (4 per entity type)

		/// <summary>FieldLikePredicate factory for ClientEntity.</summary>
		public static FieldLikePredicate Like(ClientFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for ClientEntity.</summary>
		public static FieldLikePredicate Like(ClientFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for ClientEntity.</summary>
		public static FieldLikePredicate Like(ClientFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for ClientEntity.</summary>
		public static FieldLikePredicate Like(ClientFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for ClientCustomerEntity.</summary>
		public static FieldLikePredicate Like(ClientCustomerFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for ClientCustomerEntity.</summary>
		public static FieldLikePredicate Like(ClientCustomerFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for ClientCustomerEntity.</summary>
		public static FieldLikePredicate Like(ClientCustomerFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for ClientCustomerEntity.</summary>
		public static FieldLikePredicate Like(ClientCustomerFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for ClientLocatorEntity.</summary>
		public static FieldLikePredicate Like(ClientLocatorFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for ClientLocatorEntity.</summary>
		public static FieldLikePredicate Like(ClientLocatorFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for ClientLocatorEntity.</summary>
		public static FieldLikePredicate Like(ClientLocatorFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for ClientLocatorEntity.</summary>
		public static FieldLikePredicate Like(ClientLocatorFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerLocatorAuthorizationFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerLocatorAuthorizationFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerLocatorAuthorizationFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerLocatorAuthorizationFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for CustomerNameEntity.</summary>
		public static FieldLikePredicate Like(CustomerNameFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for CustomerNameEntity.</summary>
		public static FieldLikePredicate Like(CustomerNameFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for CustomerNameEntity.</summary>
		public static FieldLikePredicate Like(CustomerNameFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for CustomerNameEntity.</summary>
		public static FieldLikePredicate Like(CustomerNameFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerNamespaceAuthorizationFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerNamespaceAuthorizationFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerNamespaceAuthorizationFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldLikePredicate Like(CustomerNamespaceAuthorizationFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldLikePredicate Like(Enterprise_InformationFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldLikePredicate Like(Enterprise_InformationFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldLikePredicate Like(Enterprise_InformationFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldLikePredicate Like(Enterprise_InformationFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_AuthorizationTypeFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_AuthorizationTypeFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_AuthorizationTypeFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_AuthorizationTypeFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataSourceFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataSourceFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataSourceFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataSourceFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataTypeFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataTypeFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataTypeFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldLikePredicate Like(Enum_DataTypeFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for FirmEntity.</summary>
		public static FieldLikePredicate Like(FirmFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for FirmEntity.</summary>
		public static FieldLikePredicate Like(FirmFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for FirmEntity.</summary>
		public static FieldLikePredicate Like(FirmFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for FirmEntity.</summary>
		public static FieldLikePredicate Like(FirmFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for LocatorEntity.</summary>
		public static FieldLikePredicate Like(LocatorFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorEntity.</summary>
		public static FieldLikePredicate Like(LocatorFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for LocatorEntity.</summary>
		public static FieldLikePredicate Like(LocatorFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorEntity.</summary>
		public static FieldLikePredicate Like(LocatorFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldLikePredicate Like(LocatorGridRowFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldLikePredicate Like(LocatorGridRowFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldLikePredicate Like(LocatorGridRowFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldLikePredicate Like(LocatorGridRowFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorNodeComputedValueFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorNodeComputedValueFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorNodeComputedValueFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorNodeComputedValueFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectRecordFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectRecordFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectRecordFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectRecordFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectValueFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectValueFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectValueFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldLikePredicate Like(LocatorObjectValueFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldLikePredicate Like(LocatorRolloverFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldLikePredicate Like(LocatorRolloverFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldLikePredicate Like(LocatorRolloverFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldLikePredicate Like(LocatorRolloverFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldLikePredicate Like(TempComputedResultsFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldLikePredicate Like(TempComputedResultsFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldLikePredicate Like(TempComputedResultsFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldLikePredicate Like(TempComputedResultsFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		/// <summary>FieldLikePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldLikePredicate Like(TempComputeFieldsFieldIndex indexOfField, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern);
		}

		/// <summary>FieldLikePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldLikePredicate Like(TempComputeFieldsFieldIndex indexOfField, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), pattern, negate);
		}

		/// <summary>FieldLikePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldLikePredicate Like(TempComputeFieldsFieldIndex indexOfField, string objectAlias, string pattern)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern);
		}

		/// <summary>FieldLikePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldLikePredicate Like(TempComputeFieldsFieldIndex indexOfField, string objectAlias, string pattern, bool negate)
		{
			return new FieldLikePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, pattern, negate);
		}
		#endregion

		#region FieldLikePredicate creators (4 per typed view type)

		#endregion
		
		
		#region FieldCompareRangePredicate creators (4 per entity type)

		/// <summary>FieldCompareRangePredicate factory for ClientEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for ClientEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientCustomerFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientCustomerFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientCustomerFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientCustomerFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientLocatorFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientLocatorFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientLocatorFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(ClientLocatorFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerLocatorAuthorizationFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerLocatorAuthorizationFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerLocatorAuthorizationFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerLocatorAuthorizationFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNameFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNameFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNameFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNameFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNamespaceAuthorizationFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNamespaceAuthorizationFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNamespaceAuthorizationFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(CustomerNamespaceAuthorizationFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enterprise_InformationFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enterprise_InformationFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enterprise_InformationFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enterprise_InformationFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_AuthorizationTypeFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_AuthorizationTypeFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_AuthorizationTypeFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_AuthorizationTypeFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataSourceFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataSourceFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataSourceFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataSourceFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataTypeFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataTypeFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataTypeFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(Enum_DataTypeFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for FirmEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(FirmFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for FirmEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(FirmFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for FirmEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(FirmFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for FirmEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(FirmFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for LocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for LocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorGridRowFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorGridRowFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorGridRowFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorGridRowFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorNodeComputedValueFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorNodeComputedValueFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorNodeComputedValueFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorNodeComputedValueFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectRecordFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectRecordFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectRecordFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectRecordFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectValueFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectValueFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectValueFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorObjectValueFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorRolloverFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorRolloverFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorRolloverFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(LocatorRolloverFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputedResultsFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputedResultsFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputedResultsFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputedResultsFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		/// <summary>FieldCompareRangePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputeFieldsFieldIndex indexOfField, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputeFieldsFieldIndex indexOfField, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), negate, values);
		}

		/// <summary>FieldCompareRangePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputeFieldsFieldIndex indexOfField, string objectAlias, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, values);
		}
		
		/// <summary>FieldCompareValuePredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareRangePredicate CompareRange(TempComputeFieldsFieldIndex indexOfField, string objectAlias, bool negate, params object[] values)
		{
			return new FieldCompareRangePredicate(EntityFieldFactory.Create(indexOfField), objectAlias, negate, values);
		}
		#endregion

		#region FieldCompareRangePredicate creators (4 per typed view type)

		#endregion

		#region FieldCompareExpressionPredicate creators (4 per entity type)

		/// <summary>FieldCompareExpressionPredicate factory for ClientEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for ClientEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for ClientEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for ClientEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for ClientCustomerEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientCustomerFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for ClientLocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(ClientLocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for CustomerLocatorAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerLocatorAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for CustomerNameEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNameFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for CustomerNamespaceAuthorizationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(CustomerNamespaceAuthorizationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enterprise_InformationEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enterprise_InformationFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enum_AuthorizationTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_AuthorizationTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataSourceEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataSourceFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for Enum_DataTypeEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(Enum_DataTypeFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for FirmEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for FirmEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for FirmEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for FirmEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(FirmFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for LocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for LocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorGridRowEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorGridRowFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorNodeComputedValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorNodeComputedValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectRecordEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectRecordFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorObjectValueEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorObjectValueFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for LocatorRolloverEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(LocatorRolloverFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for TempComputedResultsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputedResultsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		/// <summary>FieldCompareExpressionPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, negate);
		}

		/// <summary>FieldCompareExpressionPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias);
		}
		
		/// <summary>FieldCompareExpressionPredicate factory for TempComputeFieldsEntity.</summary>
		public static FieldCompareExpressionPredicate CompareExpression(TempComputeFieldsFieldIndex indexOfField, ComparisonOperator operatorToUse, IExpression expressionToCompareWith, string objectAlias, bool negate)
		{
			return new FieldCompareExpressionPredicate(EntityFieldFactory.Create(indexOfField), operatorToUse, expressionToCompareWith, objectAlias, negate);
		}
		#endregion

		#region FieldCompareExpressionPredicate creators (4 per typed view type)

		#endregion

		#region Included Code

		#endregion
	}
}
