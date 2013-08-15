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

namespace TestHarness.DataObjects
{

	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Client.
	/// </summary>
	public enum ClientFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Client_ID. </summary>
		Client_ID,
		///<summary>Client_Name. </summary>
		Client_Name,
		///<summary>Firm_Code. </summary>
		Firm_Code,
		///<summary>Account_Code. </summary>
		Account_Code,
		///<summary>Product_License. </summary>
		Product_License,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ClientCustomer.
	/// </summary>
	public enum ClientCustomerFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Client_ID. </summary>
		Client_ID,
		///<summary>Customer_ID. </summary>
		Customer_ID,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ClientLocator.
	/// </summary>
	public enum ClientLocatorFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Client_ID. </summary>
		Client_ID,
		///<summary>Locator_ID. </summary>
		Locator_ID,
		///<summary>IsTaxDefault. </summary>
		IsTaxDefault,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerLocatorAuthorization.
	/// </summary>
	public enum CustomerLocatorAuthorizationFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Customer_ID. </summary>
		Customer_ID,
		///<summary>Authorized_Locator_ID. </summary>
		Authorized_Locator_ID,
		///<summary>AuthorizationType_EnumValue. </summary>
		AuthorizationType_EnumValue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerName.
	/// </summary>
	public enum CustomerNameFieldIndex:int
	{
		///<summary>Customer_ID. </summary>
		Customer_ID,
		///<summary>WindowsDomainLogin. </summary>
		WindowsDomainLogin,
		///<summary>AlternateLogin. </summary>
		AlternateLogin,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>IsAdministrator. </summary>
		IsAdministrator,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerNamespaceAuthorization.
	/// </summary>
	public enum CustomerNamespaceAuthorizationFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Customer_ID. </summary>
		Customer_ID,
		///<summary>Authorized_Namespace. </summary>
		Authorized_Namespace,
		///<summary>AuthorizationType_EnumValue. </summary>
		AuthorizationType_EnumValue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Enterprise_Information.
	/// </summary>
	public enum Enterprise_InformationFieldIndex:int
	{
		///<summary>DB_Version. </summary>
		DB_Version,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Enum_AuthorizationType.
	/// </summary>
	public enum Enum_AuthorizationTypeFieldIndex:int
	{
		///<summary>Enum_Value. </summary>
		Enum_Value,
		///<summary>Enum_Description. </summary>
		Enum_Description,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Enum_DataSource.
	/// </summary>
	public enum Enum_DataSourceFieldIndex:int
	{
		///<summary>Enum_Value. </summary>
		Enum_Value,
		///<summary>Enum_Description. </summary>
		Enum_Description,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Enum_DataType.
	/// </summary>
	public enum Enum_DataTypeFieldIndex:int
	{
		///<summary>Enum_Value. </summary>
		Enum_Value,
		///<summary>Enum_Description. </summary>
		Enum_Description,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Firm.
	/// </summary>
	public enum FirmFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Firm_Code. </summary>
		Firm_Code,
		///<summary>Firm_Name. </summary>
		Firm_Name,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Locator.
	/// </summary>
	public enum LocatorFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Locator_ID. </summary>
		Locator_ID,
		///<summary>Locator_Name. </summary>
		Locator_Name,
		///<summary>TaxPeriod. </summary>
		TaxPeriod,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LocatorGridRow.
	/// </summary>
	public enum LocatorGridRowFieldIndex:int
	{
		///<summary>GridRecord_ID. </summary>
		GridRecord_ID,
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Locator_ID. </summary>
		Locator_ID,
		///<summary>Page_ID. </summary>
		Page_ID,
		///<summary>GraphicObject_ID. </summary>
		GraphicObject_ID,
		///<summary>Record_Lineage. </summary>
		Record_Lineage,
		///<summary>Row_Count. </summary>
		Row_Count,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LocatorNodeComputedValue.
	/// </summary>
	public enum LocatorNodeComputedValueFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Locator_ID. </summary>
		Locator_ID,
		///<summary>Navigation_Node_ID. </summary>
		Navigation_Node_ID,
		///<summary>Constraint_Result. </summary>
		Constraint_Result,
		///<summary>Save_History. </summary>
		Save_History,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LocatorObjectRecord.
	/// </summary>
	public enum LocatorObjectRecordFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Locator_ID. </summary>
		Locator_ID,
		///<summary>Page_ID. </summary>
		Page_ID,
		///<summary>Record_ID. </summary>
		Record_ID,
		///<summary>GraphicObject_ID. </summary>
		GraphicObject_ID,
		///<summary>DataType_EnumValue. </summary>
		DataType_EnumValue,
		///<summary>Row_DisplayOrder. </summary>
		Row_DisplayOrder,
		///<summary>Record_Lineage. </summary>
		Record_Lineage,
		///<summary>DatasourceUsed. </summary>
		DatasourceUsed,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LocatorObjectValue.
	/// </summary>
	public enum LocatorObjectValueFieldIndex:int
	{
		///<summary>Record_ID. </summary>
		Record_ID,
		///<summary>DataSource_EnumValue. </summary>
		DataSource_EnumValue,
		///<summary>BooleanValue. </summary>
		BooleanValue,
		///<summary>StringValue. </summary>
		StringValue,
		///<summary>NumericValue. </summary>
		NumericValue,
		///<summary>DateValue. </summary>
		DateValue,
		///<summary>FractionValue. </summary>
		FractionValue,
		///<summary>LocatorImage_ID. </summary>
		LocatorImage_ID,
		///<summary>Save_History. </summary>
		Save_History,
		///<summary>DateLastSaved. </summary>
		DateLastSaved,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LocatorRollover.
	/// </summary>
	public enum LocatorRolloverFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Target_Locator_ID. </summary>
		Target_Locator_ID,
		///<summary>Rollover_Namespace. </summary>
		Rollover_Namespace,
		///<summary>Source_Locator_ID. </summary>
		Source_Locator_ID,
		///<summary>Rollover_History. </summary>
		Rollover_History,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TempComputedResults.
	/// </summary>
	public enum TempComputedResultsFieldIndex:int
	{
		///<summary>Product_Year. </summary>
		Product_Year,
		///<summary>Locator_ID. </summary>
		Locator_ID,
		///<summary>FullComputeStartTime. </summary>
		FullComputeStartTime,
		///<summary>Page_ID. </summary>
		Page_ID,
		///<summary>GraphicObject_ID. </summary>
		GraphicObject_ID,
		///<summary>Row_DisplayOrder. </summary>
		Row_DisplayOrder,
		///<summary>Record_Lineage. </summary>
		Record_Lineage,
		///<summary>DataType_EnumValue. </summary>
		DataType_EnumValue,
		///<summary>Computed_Value. </summary>
		Computed_Value,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TempComputeFields.
	/// </summary>
	public enum TempComputeFieldsFieldIndex:int
	{
		///<summary>FullComputeStartTime. </summary>
		FullComputeStartTime,
		///<summary>Page_ID. </summary>
		Page_ID,
		///<summary>GraphicObject_ID. </summary>
		GraphicObject_ID,
		///<summary>Parent_GraphicObject_ID. </summary>
		Parent_GraphicObject_ID,
		/// <summary></summary>
		AmountOfFields
	}





	/// <summary>
	/// Enum definition for all the entity types defined in this namespace. Used by the entityfields factory.
	/// </summary>
	public enum EntityType:int
	{
		///<summary>Client</summary>
		ClientEntity,
		///<summary>ClientCustomer</summary>
		ClientCustomerEntity,
		///<summary>ClientLocator</summary>
		ClientLocatorEntity,
		///<summary>CustomerLocatorAuthorization</summary>
		CustomerLocatorAuthorizationEntity,
		///<summary>CustomerName</summary>
		CustomerNameEntity,
		///<summary>CustomerNamespaceAuthorization</summary>
		CustomerNamespaceAuthorizationEntity,
		///<summary>Enterprise_Information</summary>
		Enterprise_InformationEntity,
		///<summary>Enum_AuthorizationType</summary>
		Enum_AuthorizationTypeEntity,
		///<summary>Enum_DataSource</summary>
		Enum_DataSourceEntity,
		///<summary>Enum_DataType</summary>
		Enum_DataTypeEntity,
		///<summary>Firm</summary>
		FirmEntity,
		///<summary>Locator</summary>
		LocatorEntity,
		///<summary>LocatorGridRow</summary>
		LocatorGridRowEntity,
		///<summary>LocatorNodeComputedValue</summary>
		LocatorNodeComputedValueEntity,
		///<summary>LocatorObjectRecord</summary>
		LocatorObjectRecordEntity,
		///<summary>LocatorObjectValue</summary>
		LocatorObjectValueEntity,
		///<summary>LocatorRollover</summary>
		LocatorRolloverEntity,
		///<summary>TempComputedResults</summary>
		TempComputedResultsEntity,
		///<summary>TempComputeFields</summary>
		TempComputeFieldsEntity
	}




	#region Custom ConstantsEnums Code
	
	// __LLBLGENPRO_USER_CODE_REGION_START CustomUserConstants
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	#endregion

	#region Included code

	#endregion
}


