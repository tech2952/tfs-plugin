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
using SD.LLBLGen.Pro.ORMSupportClasses;
using TestHarness.DataObjects.FactoryClasses;
using TestHarness.DataObjects;

namespace TestHarness.DataObjects.HelperClasses
{
	/// <summary>Field Creation Class for entity ClientEntity</summary>
	public partial class ClientFields
	{
		/// <summary>Creates a new ClientEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new ClientEntity.Client_ID field instance</summary>
		public static EntityField Client_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientFieldIndex.Client_ID);}
		}
		/// <summary>Creates a new ClientEntity.Client_Name field instance</summary>
		public static EntityField Client_Name
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientFieldIndex.Client_Name);}
		}
		/// <summary>Creates a new ClientEntity.Firm_Code field instance</summary>
		public static EntityField Firm_Code
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientFieldIndex.Firm_Code);}
		}
		/// <summary>Creates a new ClientEntity.Account_Code field instance</summary>
		public static EntityField Account_Code
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientFieldIndex.Account_Code);}
		}
		/// <summary>Creates a new ClientEntity.Product_License field instance</summary>
		public static EntityField Product_License
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientFieldIndex.Product_License);}
		}
	}

	/// <summary>Field Creation Class for entity ClientCustomerEntity</summary>
	public partial class ClientCustomerFields
	{
		/// <summary>Creates a new ClientCustomerEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientCustomerFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new ClientCustomerEntity.Client_ID field instance</summary>
		public static EntityField Client_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientCustomerFieldIndex.Client_ID);}
		}
		/// <summary>Creates a new ClientCustomerEntity.Customer_ID field instance</summary>
		public static EntityField Customer_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientCustomerFieldIndex.Customer_ID);}
		}
	}

	/// <summary>Field Creation Class for entity ClientLocatorEntity</summary>
	public partial class ClientLocatorFields
	{
		/// <summary>Creates a new ClientLocatorEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientLocatorFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new ClientLocatorEntity.Client_ID field instance</summary>
		public static EntityField Client_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientLocatorFieldIndex.Client_ID);}
		}
		/// <summary>Creates a new ClientLocatorEntity.Locator_ID field instance</summary>
		public static EntityField Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientLocatorFieldIndex.Locator_ID);}
		}
		/// <summary>Creates a new ClientLocatorEntity.IsTaxDefault field instance</summary>
		public static EntityField IsTaxDefault
		{
			get { return (EntityField)EntityFieldFactory.Create(ClientLocatorFieldIndex.IsTaxDefault);}
		}
	}

	/// <summary>Field Creation Class for entity CustomerLocatorAuthorizationEntity</summary>
	public partial class CustomerLocatorAuthorizationFields
	{
		/// <summary>Creates a new CustomerLocatorAuthorizationEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerLocatorAuthorizationFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new CustomerLocatorAuthorizationEntity.Customer_ID field instance</summary>
		public static EntityField Customer_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerLocatorAuthorizationFieldIndex.Customer_ID);}
		}
		/// <summary>Creates a new CustomerLocatorAuthorizationEntity.Authorized_Locator_ID field instance</summary>
		public static EntityField Authorized_Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerLocatorAuthorizationFieldIndex.Authorized_Locator_ID);}
		}
		/// <summary>Creates a new CustomerLocatorAuthorizationEntity.AuthorizationType_EnumValue field instance</summary>
		public static EntityField AuthorizationType_EnumValue
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerLocatorAuthorizationFieldIndex.AuthorizationType_EnumValue);}
		}
	}

	/// <summary>Field Creation Class for entity CustomerNameEntity</summary>
	public partial class CustomerNameFields
	{
		/// <summary>Creates a new CustomerNameEntity.Customer_ID field instance</summary>
		public static EntityField Customer_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNameFieldIndex.Customer_ID);}
		}
		/// <summary>Creates a new CustomerNameEntity.WindowsDomainLogin field instance</summary>
		public static EntityField WindowsDomainLogin
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNameFieldIndex.WindowsDomainLogin);}
		}
		/// <summary>Creates a new CustomerNameEntity.AlternateLogin field instance</summary>
		public static EntityField AlternateLogin
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNameFieldIndex.AlternateLogin);}
		}
		/// <summary>Creates a new CustomerNameEntity.FirstName field instance</summary>
		public static EntityField FirstName
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNameFieldIndex.FirstName);}
		}
		/// <summary>Creates a new CustomerNameEntity.LastName field instance</summary>
		public static EntityField LastName
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNameFieldIndex.LastName);}
		}
		/// <summary>Creates a new CustomerNameEntity.IsAdministrator field instance</summary>
		public static EntityField IsAdministrator
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNameFieldIndex.IsAdministrator);}
		}
	}

	/// <summary>Field Creation Class for entity CustomerNamespaceAuthorizationEntity</summary>
	public partial class CustomerNamespaceAuthorizationFields
	{
		/// <summary>Creates a new CustomerNamespaceAuthorizationEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNamespaceAuthorizationFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new CustomerNamespaceAuthorizationEntity.Customer_ID field instance</summary>
		public static EntityField Customer_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNamespaceAuthorizationFieldIndex.Customer_ID);}
		}
		/// <summary>Creates a new CustomerNamespaceAuthorizationEntity.Authorized_Namespace field instance</summary>
		public static EntityField Authorized_Namespace
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNamespaceAuthorizationFieldIndex.Authorized_Namespace);}
		}
		/// <summary>Creates a new CustomerNamespaceAuthorizationEntity.AuthorizationType_EnumValue field instance</summary>
		public static EntityField AuthorizationType_EnumValue
		{
			get { return (EntityField)EntityFieldFactory.Create(CustomerNamespaceAuthorizationFieldIndex.AuthorizationType_EnumValue);}
		}
	}

	/// <summary>Field Creation Class for entity Enterprise_InformationEntity</summary>
	public partial class Enterprise_InformationFields
	{
		/// <summary>Creates a new Enterprise_InformationEntity.DB_Version field instance</summary>
		public static EntityField DB_Version
		{
			get { return (EntityField)EntityFieldFactory.Create(Enterprise_InformationFieldIndex.DB_Version);}
		}
	}

	/// <summary>Field Creation Class for entity Enum_AuthorizationTypeEntity</summary>
	public partial class Enum_AuthorizationTypeFields
	{
		/// <summary>Creates a new Enum_AuthorizationTypeEntity.Enum_Value field instance</summary>
		public static EntityField Enum_Value
		{
			get { return (EntityField)EntityFieldFactory.Create(Enum_AuthorizationTypeFieldIndex.Enum_Value);}
		}
		/// <summary>Creates a new Enum_AuthorizationTypeEntity.Enum_Description field instance</summary>
		public static EntityField Enum_Description
		{
			get { return (EntityField)EntityFieldFactory.Create(Enum_AuthorizationTypeFieldIndex.Enum_Description);}
		}
	}

	/// <summary>Field Creation Class for entity Enum_DataSourceEntity</summary>
	public partial class Enum_DataSourceFields
	{
		/// <summary>Creates a new Enum_DataSourceEntity.Enum_Value field instance</summary>
		public static EntityField Enum_Value
		{
			get { return (EntityField)EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Value);}
		}
		/// <summary>Creates a new Enum_DataSourceEntity.Enum_Description field instance</summary>
		public static EntityField Enum_Description
		{
			get { return (EntityField)EntityFieldFactory.Create(Enum_DataSourceFieldIndex.Enum_Description);}
		}
	}

	/// <summary>Field Creation Class for entity Enum_DataTypeEntity</summary>
	public partial class Enum_DataTypeFields
	{
		/// <summary>Creates a new Enum_DataTypeEntity.Enum_Value field instance</summary>
		public static EntityField Enum_Value
		{
			get { return (EntityField)EntityFieldFactory.Create(Enum_DataTypeFieldIndex.Enum_Value);}
		}
		/// <summary>Creates a new Enum_DataTypeEntity.Enum_Description field instance</summary>
		public static EntityField Enum_Description
		{
			get { return (EntityField)EntityFieldFactory.Create(Enum_DataTypeFieldIndex.Enum_Description);}
		}
	}

	/// <summary>Field Creation Class for entity FirmEntity</summary>
	public partial class FirmFields
	{
		/// <summary>Creates a new FirmEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(FirmFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new FirmEntity.Firm_Code field instance</summary>
		public static EntityField Firm_Code
		{
			get { return (EntityField)EntityFieldFactory.Create(FirmFieldIndex.Firm_Code);}
		}
		/// <summary>Creates a new FirmEntity.Firm_Name field instance</summary>
		public static EntityField Firm_Name
		{
			get { return (EntityField)EntityFieldFactory.Create(FirmFieldIndex.Firm_Name);}
		}
	}

	/// <summary>Field Creation Class for entity LocatorEntity</summary>
	public partial class LocatorFields
	{
		/// <summary>Creates a new LocatorEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new LocatorEntity.Locator_ID field instance</summary>
		public static EntityField Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorFieldIndex.Locator_ID);}
		}
		/// <summary>Creates a new LocatorEntity.Locator_Name field instance</summary>
		public static EntityField Locator_Name
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorFieldIndex.Locator_Name);}
		}
		/// <summary>Creates a new LocatorEntity.TaxPeriod field instance</summary>
		public static EntityField TaxPeriod
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorFieldIndex.TaxPeriod);}
		}
	}

	/// <summary>Field Creation Class for entity LocatorGridRowEntity</summary>
	public partial class LocatorGridRowFields
	{
		/// <summary>Creates a new LocatorGridRowEntity.GridRecord_ID field instance</summary>
		public static EntityField GridRecord_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorGridRowFieldIndex.GridRecord_ID);}
		}
		/// <summary>Creates a new LocatorGridRowEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorGridRowFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new LocatorGridRowEntity.Locator_ID field instance</summary>
		public static EntityField Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorGridRowFieldIndex.Locator_ID);}
		}
		/// <summary>Creates a new LocatorGridRowEntity.Page_ID field instance</summary>
		public static EntityField Page_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorGridRowFieldIndex.Page_ID);}
		}
		/// <summary>Creates a new LocatorGridRowEntity.GraphicObject_ID field instance</summary>
		public static EntityField GraphicObject_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorGridRowFieldIndex.GraphicObject_ID);}
		}
		/// <summary>Creates a new LocatorGridRowEntity.Record_Lineage field instance</summary>
		public static EntityField Record_Lineage
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorGridRowFieldIndex.Record_Lineage);}
		}
		/// <summary>Creates a new LocatorGridRowEntity.Row_Count field instance</summary>
		public static EntityField Row_Count
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorGridRowFieldIndex.Row_Count);}
		}
	}

	/// <summary>Field Creation Class for entity LocatorNodeComputedValueEntity</summary>
	public partial class LocatorNodeComputedValueFields
	{
		/// <summary>Creates a new LocatorNodeComputedValueEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new LocatorNodeComputedValueEntity.Locator_ID field instance</summary>
		public static EntityField Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Locator_ID);}
		}
		/// <summary>Creates a new LocatorNodeComputedValueEntity.Navigation_Node_ID field instance</summary>
		public static EntityField Navigation_Node_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Navigation_Node_ID);}
		}
		/// <summary>Creates a new LocatorNodeComputedValueEntity.Constraint_Result field instance</summary>
		public static EntityField Constraint_Result
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Constraint_Result);}
		}
		/// <summary>Creates a new LocatorNodeComputedValueEntity.Save_History field instance</summary>
		public static EntityField Save_History
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorNodeComputedValueFieldIndex.Save_History);}
		}
	}

	/// <summary>Field Creation Class for entity LocatorObjectRecordEntity</summary>
	public partial class LocatorObjectRecordFields
	{
		/// <summary>Creates a new LocatorObjectRecordEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.Locator_ID field instance</summary>
		public static EntityField Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Locator_ID);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.Page_ID field instance</summary>
		public static EntityField Page_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Page_ID);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.Record_ID field instance</summary>
		public static EntityField Record_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Record_ID);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.GraphicObject_ID field instance</summary>
		public static EntityField GraphicObject_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.GraphicObject_ID);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.DataType_EnumValue field instance</summary>
		public static EntityField DataType_EnumValue
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.DataType_EnumValue);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.Row_DisplayOrder field instance</summary>
		public static EntityField Row_DisplayOrder
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Row_DisplayOrder);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.Record_Lineage field instance</summary>
		public static EntityField Record_Lineage
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.Record_Lineage);}
		}
		/// <summary>Creates a new LocatorObjectRecordEntity.DatasourceUsed field instance</summary>
		public static EntityField DatasourceUsed
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectRecordFieldIndex.DatasourceUsed);}
		}
	}

	/// <summary>Field Creation Class for entity LocatorObjectValueEntity</summary>
	public partial class LocatorObjectValueFields
	{
		/// <summary>Creates a new LocatorObjectValueEntity.Record_ID field instance</summary>
		public static EntityField Record_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.Record_ID);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.DataSource_EnumValue field instance</summary>
		public static EntityField DataSource_EnumValue
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.DataSource_EnumValue);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.BooleanValue field instance</summary>
		public static EntityField BooleanValue
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.BooleanValue);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.StringValue field instance</summary>
		public static EntityField StringValue
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.StringValue);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.NumericValue field instance</summary>
		public static EntityField NumericValue
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.NumericValue);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.DateValue field instance</summary>
		public static EntityField DateValue
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.DateValue);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.FractionValue field instance</summary>
		public static EntityField FractionValue
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.FractionValue);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.LocatorImage_ID field instance</summary>
		public static EntityField LocatorImage_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.LocatorImage_ID);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.Save_History field instance</summary>
		public static EntityField Save_History
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.Save_History);}
		}
		/// <summary>Creates a new LocatorObjectValueEntity.DateLastSaved field instance</summary>
		public static EntityField DateLastSaved
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorObjectValueFieldIndex.DateLastSaved);}
		}
	}

	/// <summary>Field Creation Class for entity LocatorRolloverEntity</summary>
	public partial class LocatorRolloverFields
	{
		/// <summary>Creates a new LocatorRolloverEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorRolloverFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new LocatorRolloverEntity.Target_Locator_ID field instance</summary>
		public static EntityField Target_Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorRolloverFieldIndex.Target_Locator_ID);}
		}
		/// <summary>Creates a new LocatorRolloverEntity.Rollover_Namespace field instance</summary>
		public static EntityField Rollover_Namespace
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorRolloverFieldIndex.Rollover_Namespace);}
		}
		/// <summary>Creates a new LocatorRolloverEntity.Source_Locator_ID field instance</summary>
		public static EntityField Source_Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorRolloverFieldIndex.Source_Locator_ID);}
		}
		/// <summary>Creates a new LocatorRolloverEntity.Rollover_History field instance</summary>
		public static EntityField Rollover_History
		{
			get { return (EntityField)EntityFieldFactory.Create(LocatorRolloverFieldIndex.Rollover_History);}
		}
	}

	/// <summary>Field Creation Class for entity TempComputedResultsEntity</summary>
	public partial class TempComputedResultsFields
	{
		/// <summary>Creates a new TempComputedResultsEntity.Product_Year field instance</summary>
		public static EntityField Product_Year
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.Product_Year);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.Locator_ID field instance</summary>
		public static EntityField Locator_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.Locator_ID);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.FullComputeStartTime field instance</summary>
		public static EntityField FullComputeStartTime
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.FullComputeStartTime);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.Page_ID field instance</summary>
		public static EntityField Page_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.Page_ID);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.GraphicObject_ID field instance</summary>
		public static EntityField GraphicObject_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.GraphicObject_ID);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.Row_DisplayOrder field instance</summary>
		public static EntityField Row_DisplayOrder
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.Row_DisplayOrder);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.Record_Lineage field instance</summary>
		public static EntityField Record_Lineage
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.Record_Lineage);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.DataType_EnumValue field instance</summary>
		public static EntityField DataType_EnumValue
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.DataType_EnumValue);}
		}
		/// <summary>Creates a new TempComputedResultsEntity.Computed_Value field instance</summary>
		public static EntityField Computed_Value
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputedResultsFieldIndex.Computed_Value);}
		}
	}

	/// <summary>Field Creation Class for entity TempComputeFieldsEntity</summary>
	public partial class TempComputeFieldsFields
	{
		/// <summary>Creates a new TempComputeFieldsEntity.FullComputeStartTime field instance</summary>
		public static EntityField FullComputeStartTime
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputeFieldsFieldIndex.FullComputeStartTime);}
		}
		/// <summary>Creates a new TempComputeFieldsEntity.Page_ID field instance</summary>
		public static EntityField Page_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputeFieldsFieldIndex.Page_ID);}
		}
		/// <summary>Creates a new TempComputeFieldsEntity.GraphicObject_ID field instance</summary>
		public static EntityField GraphicObject_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputeFieldsFieldIndex.GraphicObject_ID);}
		}
		/// <summary>Creates a new TempComputeFieldsEntity.Parent_GraphicObject_ID field instance</summary>
		public static EntityField Parent_GraphicObject_ID
		{
			get { return (EntityField)EntityFieldFactory.Create(TempComputeFieldsFieldIndex.Parent_GraphicObject_ID);}
		}
	}
	

}