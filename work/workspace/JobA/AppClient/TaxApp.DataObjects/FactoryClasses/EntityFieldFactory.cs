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
using System.Data;

using TestHarness.DataObjects;
using TestHarness.DataObjects.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.FactoryClasses
{
	/// <summary>
	/// Factory class for IEntityField instances, used in IEntityFields instances.
	/// </summary>
	public partial class EntityFieldFactory
	{
		/// <summary>
		/// Private CTor, no instantiation possible.
		/// </summary>
		private EntityFieldFactory()
		{
		}

	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the ClientEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(ClientFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case ClientFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "ClientEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "Client", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", false, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case ClientFieldIndex.Client_ID:
					fieldToReturn = new EntityField("Client_ID", typeof(System.Int32), "ClientEntity", true, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "Client", "Client_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, true, "SCOPE_IDENTITY()", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case ClientFieldIndex.Client_Name:
					fieldToReturn = new EntityField("Client_Name", typeof(System.String), "ClientEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Client", "Client_Name", false, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case ClientFieldIndex.Firm_Code:
					fieldToReturn = new EntityField("Firm_Code", typeof(System.String), "ClientEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Client", "Firm_Code", false, (int)SqlDbType.VarChar, 10, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case ClientFieldIndex.Account_Code:
					fieldToReturn = new EntityField("Account_Code", typeof(System.String), "ClientEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Client", "Account_Code", true, (int)SqlDbType.NVarChar, 10, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case ClientFieldIndex.Product_License:
					fieldToReturn = new EntityField("Product_License", typeof(System.String), "ClientEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Client", "Product_License", true, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the ClientCustomerEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(ClientCustomerFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case ClientCustomerFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "ClientCustomerEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "ClientCustomer", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", true, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case ClientCustomerFieldIndex.Client_ID:
					fieldToReturn = new EntityField("Client_ID", typeof(System.Int32), "ClientCustomerEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "ClientCustomer", "Client_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case ClientCustomerFieldIndex.Customer_ID:
					fieldToReturn = new EntityField("Customer_ID", typeof(System.Int32), "ClientCustomerEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "ClientCustomer", "Customer_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the ClientLocatorEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(ClientLocatorFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case ClientLocatorFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "ClientLocatorEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "ClientLocator", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", true, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case ClientLocatorFieldIndex.Client_ID:
					fieldToReturn = new EntityField("Client_ID", typeof(System.Int32), "ClientLocatorEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "ClientLocator", "Client_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case ClientLocatorFieldIndex.Locator_ID:
					fieldToReturn = new EntityField("Locator_ID", typeof(System.Int32), "ClientLocatorEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "ClientLocator", "Locator_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case ClientLocatorFieldIndex.IsTaxDefault:
					fieldToReturn = new EntityField("IsTaxDefault", typeof(System.Boolean), "ClientLocatorEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Boolean)), @"dbo", "ClientLocator", "IsTaxDefault", true, (int)SqlDbType.Bit, 0, 0, 0, false, false, "", false, null, typeof(System.Boolean), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the CustomerLocatorAuthorizationEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(CustomerLocatorAuthorizationFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case CustomerLocatorAuthorizationFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "CustomerLocatorAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "CustomerLocatorAuthorization", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", false, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case CustomerLocatorAuthorizationFieldIndex.Customer_ID:
					fieldToReturn = new EntityField("Customer_ID", typeof(System.Int32), "CustomerLocatorAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "CustomerLocatorAuthorization", "Customer_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case CustomerLocatorAuthorizationFieldIndex.Authorized_Locator_ID:
					fieldToReturn = new EntityField("Authorized_Locator_ID", typeof(System.Int32), "CustomerLocatorAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "CustomerLocatorAuthorization", "Authorized_Locator_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case CustomerLocatorAuthorizationFieldIndex.AuthorizationType_EnumValue:
					fieldToReturn = new EntityField("AuthorizationType_EnumValue", typeof(System.Byte), "CustomerLocatorAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "CustomerLocatorAuthorization", "AuthorizationType_EnumValue", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, false, "", true, null, typeof(System.Byte), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the CustomerNameEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(CustomerNameFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case CustomerNameFieldIndex.Customer_ID:
					fieldToReturn = new EntityField("Customer_ID", typeof(System.Int32), "CustomerNameEntity", true, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "CustomerName", "Customer_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, true, "SCOPE_IDENTITY()", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case CustomerNameFieldIndex.WindowsDomainLogin:
					fieldToReturn = new EntityField("WindowsDomainLogin", typeof(System.String), "CustomerNameEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "CustomerName", "WindowsDomainLogin", true, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case CustomerNameFieldIndex.AlternateLogin:
					fieldToReturn = new EntityField("AlternateLogin", typeof(System.String), "CustomerNameEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "CustomerName", "AlternateLogin", true, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case CustomerNameFieldIndex.FirstName:
					fieldToReturn = new EntityField("FirstName", typeof(System.String), "CustomerNameEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "CustomerName", "FirstName", true, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case CustomerNameFieldIndex.LastName:
					fieldToReturn = new EntityField("LastName", typeof(System.String), "CustomerNameEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "CustomerName", "LastName", true, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case CustomerNameFieldIndex.IsAdministrator:
					fieldToReturn = new EntityField("IsAdministrator", typeof(System.Boolean), "CustomerNameEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Boolean)), @"dbo", "CustomerName", "IsAdministrator", true, (int)SqlDbType.Bit, 0, 0, 0, false, false, "", false, null, typeof(System.Boolean), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the CustomerNamespaceAuthorizationEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(CustomerNamespaceAuthorizationFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case CustomerNamespaceAuthorizationFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "CustomerNamespaceAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "CustomerNamespaceAuthorization", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", false, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case CustomerNamespaceAuthorizationFieldIndex.Customer_ID:
					fieldToReturn = new EntityField("Customer_ID", typeof(System.Int32), "CustomerNamespaceAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "CustomerNamespaceAuthorization", "Customer_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case CustomerNamespaceAuthorizationFieldIndex.Authorized_Namespace:
					fieldToReturn = new EntityField("Authorized_Namespace", typeof(System.String), "CustomerNamespaceAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "CustomerNamespaceAuthorization", "Authorized_Namespace", false, (int)SqlDbType.VarChar, 500, 0, 0, true, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case CustomerNamespaceAuthorizationFieldIndex.AuthorizationType_EnumValue:
					fieldToReturn = new EntityField("AuthorizationType_EnumValue", typeof(System.Byte), "CustomerNamespaceAuthorizationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "CustomerNamespaceAuthorization", "AuthorizationType_EnumValue", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, false, "", true, null, typeof(System.Byte), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the Enterprise_InformationEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(Enterprise_InformationFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case Enterprise_InformationFieldIndex.DB_Version:
					fieldToReturn = new EntityField("DB_Version", typeof(System.String), "Enterprise_InformationEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Enterprise_Information", "DB_Version", false, (int)SqlDbType.VarChar, 50, 0, 0, true, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the Enum_AuthorizationTypeEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(Enum_AuthorizationTypeFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case Enum_AuthorizationTypeFieldIndex.Enum_Value:
					fieldToReturn = new EntityField("Enum_Value", typeof(System.Byte), "Enum_AuthorizationTypeEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "Enum_AuthorizationType", "Enum_Value", false, (int)SqlDbType.TinyInt, 0, 0, 3, true, false, "", false, null, typeof(System.Byte), (int)fieldIndex);
					break;
				case Enum_AuthorizationTypeFieldIndex.Enum_Description:
					fieldToReturn = new EntityField("Enum_Description", typeof(System.String), "Enum_AuthorizationTypeEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Enum_AuthorizationType", "Enum_Description", false, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the Enum_DataSourceEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(Enum_DataSourceFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case Enum_DataSourceFieldIndex.Enum_Value:
					fieldToReturn = new EntityField("Enum_Value", typeof(System.Byte), "Enum_DataSourceEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "Enum_DataSource", "Enum_Value", false, (int)SqlDbType.TinyInt, 0, 0, 3, true, false, "", false, null, typeof(System.Byte), (int)fieldIndex);
					break;
				case Enum_DataSourceFieldIndex.Enum_Description:
					fieldToReturn = new EntityField("Enum_Description", typeof(System.String), "Enum_DataSourceEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Enum_DataSource", "Enum_Description", false, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the Enum_DataTypeEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(Enum_DataTypeFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case Enum_DataTypeFieldIndex.Enum_Value:
					fieldToReturn = new EntityField("Enum_Value", typeof(System.Byte), "Enum_DataTypeEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "Enum_DataType", "Enum_Value", false, (int)SqlDbType.TinyInt, 0, 0, 3, true, false, "", false, null, typeof(System.Byte), (int)fieldIndex);
					break;
				case Enum_DataTypeFieldIndex.Enum_Description:
					fieldToReturn = new EntityField("Enum_Description", typeof(System.String), "Enum_DataTypeEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Enum_DataType", "Enum_Description", true, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the FirmEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(FirmFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case FirmFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "FirmEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "Firm", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", false, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case FirmFieldIndex.Firm_Code:
					fieldToReturn = new EntityField("Firm_Code", typeof(System.String), "FirmEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Firm", "Firm_Code", false, (int)SqlDbType.VarChar, 10, 0, 0, true, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case FirmFieldIndex.Firm_Name:
					fieldToReturn = new EntityField("Firm_Name", typeof(System.String), "FirmEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Firm", "Firm_Name", true, (int)SqlDbType.VarChar, 50, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the LocatorEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(LocatorFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case LocatorFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "LocatorEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "Locator", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", false, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case LocatorFieldIndex.Locator_ID:
					fieldToReturn = new EntityField("Locator_ID", typeof(System.Int32), "LocatorEntity", true, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "Locator", "Locator_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, true, "SCOPE_IDENTITY()", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorFieldIndex.Locator_Name:
					fieldToReturn = new EntityField("Locator_Name", typeof(System.String), "LocatorEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Locator", "Locator_Name", false, (int)SqlDbType.VarChar, 250, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case LocatorFieldIndex.TaxPeriod:
					fieldToReturn = new EntityField("TaxPeriod", typeof(System.String), "LocatorEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "Locator", "TaxPeriod", true, (int)SqlDbType.VarChar, 25, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the LocatorGridRowEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(LocatorGridRowFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case LocatorGridRowFieldIndex.GridRecord_ID:
					fieldToReturn = new EntityField("GridRecord_ID", typeof(System.Int32), "LocatorGridRowEntity", true, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorGridRow", "GridRecord_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, true, "SCOPE_IDENTITY()", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorGridRowFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "LocatorGridRowEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "LocatorGridRow", "Product_Year", true, (int)SqlDbType.SmallInt, 0, 0, 5, false, false, "", false, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case LocatorGridRowFieldIndex.Locator_ID:
					fieldToReturn = new EntityField("Locator_ID", typeof(System.Int32), "LocatorGridRowEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorGridRow", "Locator_ID", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorGridRowFieldIndex.Page_ID:
					fieldToReturn = new EntityField("Page_ID", typeof(System.Int32), "LocatorGridRowEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorGridRow", "Page_ID", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorGridRowFieldIndex.GraphicObject_ID:
					fieldToReturn = new EntityField("GraphicObject_ID", typeof(System.Int32), "LocatorGridRowEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorGridRow", "GraphicObject_ID", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorGridRowFieldIndex.Record_Lineage:
					fieldToReturn = new EntityField("Record_Lineage", typeof(System.Int32), "LocatorGridRowEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorGridRow", "Record_Lineage", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorGridRowFieldIndex.Row_Count:
					fieldToReturn = new EntityField("Row_Count", typeof(System.Int32), "LocatorGridRowEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorGridRow", "Row_Count", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the LocatorNodeComputedValueEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(LocatorNodeComputedValueFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case LocatorNodeComputedValueFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "LocatorNodeComputedValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "LocatorNodeComputedValue", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", true, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case LocatorNodeComputedValueFieldIndex.Locator_ID:
					fieldToReturn = new EntityField("Locator_ID", typeof(System.Int32), "LocatorNodeComputedValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorNodeComputedValue", "Locator_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorNodeComputedValueFieldIndex.Navigation_Node_ID:
					fieldToReturn = new EntityField("Navigation_Node_ID", typeof(System.Int32), "LocatorNodeComputedValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorNodeComputedValue", "Navigation_Node_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorNodeComputedValueFieldIndex.Constraint_Result:
					fieldToReturn = new EntityField("Constraint_Result", typeof(System.Boolean), "LocatorNodeComputedValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Boolean)), @"dbo", "LocatorNodeComputedValue", "Constraint_Result", true, (int)SqlDbType.Bit, 0, 0, 0, false, false, "", false, null, typeof(System.Boolean), (int)fieldIndex);
					break;
				case LocatorNodeComputedValueFieldIndex.Save_History:
					fieldToReturn = new EntityField("Save_History", typeof(System.String), "LocatorNodeComputedValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "LocatorNodeComputedValue", "Save_History", true, (int)SqlDbType.Text, 2147483647, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the LocatorObjectRecordEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(LocatorObjectRecordFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case LocatorObjectRecordFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "LocatorObjectRecord", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, false, false, "", true, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.Locator_ID:
					fieldToReturn = new EntityField("Locator_ID", typeof(System.Int32), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectRecord", "Locator_ID", false, (int)SqlDbType.Int, 0, 0, 10, false, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.Page_ID:
					fieldToReturn = new EntityField("Page_ID", typeof(System.Int32), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectRecord", "Page_ID", false, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.Record_ID:
					fieldToReturn = new EntityField("Record_ID", typeof(System.Int32), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectRecord", "Record_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, true, "SCOPE_IDENTITY()", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.GraphicObject_ID:
					fieldToReturn = new EntityField("GraphicObject_ID", typeof(System.Int32), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectRecord", "GraphicObject_ID", false, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.DataType_EnumValue:
					fieldToReturn = new EntityField("DataType_EnumValue", typeof(System.Byte), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "LocatorObjectRecord", "DataType_EnumValue", false, (int)SqlDbType.TinyInt, 0, 0, 3, false, false, "", true, null, typeof(System.Byte), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.Row_DisplayOrder:
					fieldToReturn = new EntityField("Row_DisplayOrder", typeof(System.Int32), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectRecord", "Row_DisplayOrder", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.Record_Lineage:
					fieldToReturn = new EntityField("Record_Lineage", typeof(System.Int32), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectRecord", "Record_Lineage", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectRecordFieldIndex.DatasourceUsed:
					fieldToReturn = new EntityField("DatasourceUsed", typeof(System.Byte), "LocatorObjectRecordEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "LocatorObjectRecord", "DatasourceUsed", true, (int)SqlDbType.TinyInt, 0, 0, 3, false, false, "", true, null, typeof(System.Byte), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the LocatorObjectValueEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(LocatorObjectValueFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case LocatorObjectValueFieldIndex.Record_ID:
					fieldToReturn = new EntityField("Record_ID", typeof(System.Int32), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectValue", "Record_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.DataSource_EnumValue:
					fieldToReturn = new EntityField("DataSource_EnumValue", typeof(System.Byte), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "LocatorObjectValue", "DataSource_EnumValue", false, (int)SqlDbType.TinyInt, 0, 0, 3, true, false, "", true, null, typeof(System.Byte), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.BooleanValue:
					fieldToReturn = new EntityField("BooleanValue", typeof(System.Boolean), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Boolean)), @"dbo", "LocatorObjectValue", "BooleanValue", true, (int)SqlDbType.Bit, 0, 0, 0, false, false, "", false, null, typeof(System.Boolean), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.StringValue:
					fieldToReturn = new EntityField("StringValue", typeof(System.String), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "LocatorObjectValue", "StringValue", true, (int)SqlDbType.VarChar, 500, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.NumericValue:
					fieldToReturn = new EntityField("NumericValue", typeof(System.Decimal), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Decimal)), @"dbo", "LocatorObjectValue", "NumericValue", true, (int)SqlDbType.Decimal, 0, 2, 22, false, false, "", false, null, typeof(System.Decimal), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.DateValue:
					fieldToReturn = new EntityField("DateValue", typeof(System.DateTime), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)), @"dbo", "LocatorObjectValue", "DateValue", true, (int)SqlDbType.DateTime, 0, 0, 0, false, false, "", false, null, typeof(System.DateTime), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.FractionValue:
					fieldToReturn = new EntityField("FractionValue", typeof(System.Decimal), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Decimal)), @"dbo", "LocatorObjectValue", "FractionValue", true, (int)SqlDbType.Decimal, 0, 9, 20, false, false, "", false, null, typeof(System.Decimal), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.LocatorImage_ID:
					fieldToReturn = new EntityField("LocatorImage_ID", typeof(System.Int32), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorObjectValue", "LocatorImage_ID", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.Save_History:
					fieldToReturn = new EntityField("Save_History", typeof(System.String), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "LocatorObjectValue", "Save_History", true, (int)SqlDbType.Text, 2147483647, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case LocatorObjectValueFieldIndex.DateLastSaved:
					fieldToReturn = new EntityField("DateLastSaved", typeof(System.DateTime), "LocatorObjectValueEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)), @"dbo", "LocatorObjectValue", "DateLastSaved", true, (int)SqlDbType.DateTime, 0, 0, 0, false, false, "", false, null, typeof(System.DateTime), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the LocatorRolloverEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(LocatorRolloverFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case LocatorRolloverFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "LocatorRolloverEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "LocatorRollover", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", true, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case LocatorRolloverFieldIndex.Target_Locator_ID:
					fieldToReturn = new EntityField("Target_Locator_ID", typeof(System.Int32), "LocatorRolloverEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorRollover", "Target_Locator_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorRolloverFieldIndex.Rollover_Namespace:
					fieldToReturn = new EntityField("Rollover_Namespace", typeof(System.String), "LocatorRolloverEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "LocatorRollover", "Rollover_Namespace", false, (int)SqlDbType.VarChar, 500, 0, 0, true, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
				case LocatorRolloverFieldIndex.Source_Locator_ID:
					fieldToReturn = new EntityField("Source_Locator_ID", typeof(System.Int32), "LocatorRolloverEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "LocatorRollover", "Source_Locator_ID", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", true, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case LocatorRolloverFieldIndex.Rollover_History:
					fieldToReturn = new EntityField("Rollover_History", typeof(System.String), "LocatorRolloverEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "LocatorRollover", "Rollover_History", true, (int)SqlDbType.Text, 2147483647, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the TempComputedResultsEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(TempComputedResultsFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case TempComputedResultsFieldIndex.Product_Year:
					fieldToReturn = new EntityField("Product_Year", typeof(System.Int16), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int16)), @"dbo", "TempComputedResults", "Product_Year", false, (int)SqlDbType.SmallInt, 0, 0, 5, true, false, "", false, null, typeof(System.Int16), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.Locator_ID:
					fieldToReturn = new EntityField("Locator_ID", typeof(System.Int32), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputedResults", "Locator_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.FullComputeStartTime:
					fieldToReturn = new EntityField("FullComputeStartTime", typeof(System.DateTime), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)), @"dbo", "TempComputedResults", "FullComputeStartTime", false, (int)SqlDbType.DateTime, 0, 0, 0, true, false, "", false, null, typeof(System.DateTime), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.Page_ID:
					fieldToReturn = new EntityField("Page_ID", typeof(System.Int32), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputedResults", "Page_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.GraphicObject_ID:
					fieldToReturn = new EntityField("GraphicObject_ID", typeof(System.Int32), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputedResults", "GraphicObject_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.Row_DisplayOrder:
					fieldToReturn = new EntityField("Row_DisplayOrder", typeof(System.Int32), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputedResults", "Row_DisplayOrder", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.Record_Lineage:
					fieldToReturn = new EntityField("Record_Lineage", typeof(System.Int32), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputedResults", "Record_Lineage", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.DataType_EnumValue:
					fieldToReturn = new EntityField("DataType_EnumValue", typeof(System.Byte), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Byte)), @"dbo", "TempComputedResults", "DataType_EnumValue", true, (int)SqlDbType.TinyInt, 0, 0, 3, false, false, "", false, null, typeof(System.Byte), (int)fieldIndex);
					break;
				case TempComputedResultsFieldIndex.Computed_Value:
					fieldToReturn = new EntityField("Computed_Value", typeof(System.String), "TempComputedResultsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.String)), @"dbo", "TempComputedResults", "Computed_Value", true, (int)SqlDbType.NVarChar, 500, 0, 0, false, false, "", false, null, typeof(System.String), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
		/// <summary>
		/// Creates a new IEntityField instance for usage in the EntityFields object for the TempComputeFieldsEntity. 
		/// Which EntityField is created is specified by fieldIndex
		/// </summary>
		/// <param name="fieldIndex">The field which IEntityField instance should be created</param>
		/// <returns>The IEntityField instance for the field specified in fieldIndex</returns>
		public static IEntityField Create(TempComputeFieldsFieldIndex fieldIndex)
		{
			IEntityField fieldToReturn = null;
			switch(fieldIndex)
			{
				case TempComputeFieldsFieldIndex.FullComputeStartTime:
					fieldToReturn = new EntityField("FullComputeStartTime", typeof(System.DateTime), "TempComputeFieldsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)), @"dbo", "TempComputeFields", "FullComputeStartTime", false, (int)SqlDbType.DateTime, 0, 0, 0, true, false, "", false, null, typeof(System.DateTime), (int)fieldIndex);
					break;
				case TempComputeFieldsFieldIndex.Page_ID:
					fieldToReturn = new EntityField("Page_ID", typeof(System.Int32), "TempComputeFieldsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputeFields", "Page_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case TempComputeFieldsFieldIndex.GraphicObject_ID:
					fieldToReturn = new EntityField("GraphicObject_ID", typeof(System.Int32), "TempComputeFieldsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputeFields", "GraphicObject_ID", false, (int)SqlDbType.Int, 0, 0, 10, true, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
				case TempComputeFieldsFieldIndex.Parent_GraphicObject_ID:
					fieldToReturn = new EntityField("Parent_GraphicObject_ID", typeof(System.Int32), "TempComputeFieldsEntity", false, TypeDefaultValue.GetDefaultValue(typeof(System.Int32)), @"dbo", "TempComputeFields", "Parent_GraphicObject_ID", true, (int)SqlDbType.Int, 0, 0, 10, false, false, "", false, null, typeof(System.Int32), (int)fieldIndex);
					break;
			}

			return fieldToReturn;
		}
	
	


		#region Included Code

		#endregion
	}
}
