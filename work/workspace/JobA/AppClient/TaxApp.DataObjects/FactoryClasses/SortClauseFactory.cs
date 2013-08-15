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
	/// <summary>Class which eases the creation of sort clauses used in a SortExpression, to sort resultsets on specified fields.</summary>
	public partial class SortClauseFactory
	{
		/// <summary>Static class, no CTor</summary>
		private SortClauseFactory()
		{
		}

		/// <summary>Creates a new sort clause for the ClientEntity field specified.</summary>
		public static ISortClause Create(ClientFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the ClientEntity field specified.</summary>
		public static ISortClause Create(ClientFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the ClientCustomerEntity field specified.</summary>
		public static ISortClause Create(ClientCustomerFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the ClientCustomerEntity field specified.</summary>
		public static ISortClause Create(ClientCustomerFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the ClientLocatorEntity field specified.</summary>
		public static ISortClause Create(ClientLocatorFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the ClientLocatorEntity field specified.</summary>
		public static ISortClause Create(ClientLocatorFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the CustomerLocatorAuthorizationEntity field specified.</summary>
		public static ISortClause Create(CustomerLocatorAuthorizationFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the CustomerLocatorAuthorizationEntity field specified.</summary>
		public static ISortClause Create(CustomerLocatorAuthorizationFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the CustomerNameEntity field specified.</summary>
		public static ISortClause Create(CustomerNameFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the CustomerNameEntity field specified.</summary>
		public static ISortClause Create(CustomerNameFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the CustomerNamespaceAuthorizationEntity field specified.</summary>
		public static ISortClause Create(CustomerNamespaceAuthorizationFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the CustomerNamespaceAuthorizationEntity field specified.</summary>
		public static ISortClause Create(CustomerNamespaceAuthorizationFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the Enterprise_InformationEntity field specified.</summary>
		public static ISortClause Create(Enterprise_InformationFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the Enterprise_InformationEntity field specified.</summary>
		public static ISortClause Create(Enterprise_InformationFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the Enum_AuthorizationTypeEntity field specified.</summary>
		public static ISortClause Create(Enum_AuthorizationTypeFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the Enum_AuthorizationTypeEntity field specified.</summary>
		public static ISortClause Create(Enum_AuthorizationTypeFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the Enum_DataSourceEntity field specified.</summary>
		public static ISortClause Create(Enum_DataSourceFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the Enum_DataSourceEntity field specified.</summary>
		public static ISortClause Create(Enum_DataSourceFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the Enum_DataTypeEntity field specified.</summary>
		public static ISortClause Create(Enum_DataTypeFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the Enum_DataTypeEntity field specified.</summary>
		public static ISortClause Create(Enum_DataTypeFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the FirmEntity field specified.</summary>
		public static ISortClause Create(FirmFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the FirmEntity field specified.</summary>
		public static ISortClause Create(FirmFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the LocatorEntity field specified.</summary>
		public static ISortClause Create(LocatorFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the LocatorEntity field specified.</summary>
		public static ISortClause Create(LocatorFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the LocatorGridRowEntity field specified.</summary>
		public static ISortClause Create(LocatorGridRowFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the LocatorGridRowEntity field specified.</summary>
		public static ISortClause Create(LocatorGridRowFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the LocatorNodeComputedValueEntity field specified.</summary>
		public static ISortClause Create(LocatorNodeComputedValueFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the LocatorNodeComputedValueEntity field specified.</summary>
		public static ISortClause Create(LocatorNodeComputedValueFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the LocatorObjectRecordEntity field specified.</summary>
		public static ISortClause Create(LocatorObjectRecordFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the LocatorObjectRecordEntity field specified.</summary>
		public static ISortClause Create(LocatorObjectRecordFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the LocatorObjectValueEntity field specified.</summary>
		public static ISortClause Create(LocatorObjectValueFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the LocatorObjectValueEntity field specified.</summary>
		public static ISortClause Create(LocatorObjectValueFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the LocatorRolloverEntity field specified.</summary>
		public static ISortClause Create(LocatorRolloverFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the LocatorRolloverEntity field specified.</summary>
		public static ISortClause Create(LocatorRolloverFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the TempComputedResultsEntity field specified.</summary>
		public static ISortClause Create(TempComputedResultsFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the TempComputedResultsEntity field specified.</summary>
		public static ISortClause Create(TempComputedResultsFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}

		/// <summary>Creates a new sort clause for the TempComputeFieldsEntity field specified.</summary>
		public static ISortClause Create(TempComputeFieldsFieldIndex fieldToSort, SortOperator operatorToUse)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse);
		}

		/// <summary>Creates a new sort clause for the TempComputeFieldsEntity field specified.</summary>
		public static ISortClause Create(TempComputeFieldsFieldIndex fieldToSort, SortOperator operatorToUse, string objectAlias)
		{
			return new SortClause(EntityFieldFactory.Create(fieldToSort), operatorToUse, objectAlias);
		}


		#region Included Code

		#endregion
	}
}
