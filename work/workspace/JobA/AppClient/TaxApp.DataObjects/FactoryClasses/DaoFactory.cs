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

using TestHarness.DataObjects.DaoClasses;
using TestHarness.DataObjects.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace TestHarness.DataObjects.FactoryClasses
{
	/// <summary>
	/// Generic factory for DAO objects. 
	/// </summary>
	public partial class DAOFactory
	{
		/// <summary>
		/// Private CTor, no instantiation possible.
		/// </summary>
		private DAOFactory()
		{
		}

		/// <summary>Creates a new ClientDAO object</summary>
		/// <returns>the new DAO object ready to use for Client Entities</returns>
		public static ClientDAO CreateClientDAO()
		{
			return new ClientDAO();
		}

		/// <summary>Creates a new ClientCustomerDAO object</summary>
		/// <returns>the new DAO object ready to use for ClientCustomer Entities</returns>
		public static ClientCustomerDAO CreateClientCustomerDAO()
		{
			return new ClientCustomerDAO();
		}

		/// <summary>Creates a new ClientLocatorDAO object</summary>
		/// <returns>the new DAO object ready to use for ClientLocator Entities</returns>
		public static ClientLocatorDAO CreateClientLocatorDAO()
		{
			return new ClientLocatorDAO();
		}

		/// <summary>Creates a new CustomerLocatorAuthorizationDAO object</summary>
		/// <returns>the new DAO object ready to use for CustomerLocatorAuthorization Entities</returns>
		public static CustomerLocatorAuthorizationDAO CreateCustomerLocatorAuthorizationDAO()
		{
			return new CustomerLocatorAuthorizationDAO();
		}

		/// <summary>Creates a new CustomerNameDAO object</summary>
		/// <returns>the new DAO object ready to use for CustomerName Entities</returns>
		public static CustomerNameDAO CreateCustomerNameDAO()
		{
			return new CustomerNameDAO();
		}

		/// <summary>Creates a new CustomerNamespaceAuthorizationDAO object</summary>
		/// <returns>the new DAO object ready to use for CustomerNamespaceAuthorization Entities</returns>
		public static CustomerNamespaceAuthorizationDAO CreateCustomerNamespaceAuthorizationDAO()
		{
			return new CustomerNamespaceAuthorizationDAO();
		}

		/// <summary>Creates a new Enterprise_InformationDAO object</summary>
		/// <returns>the new DAO object ready to use for Enterprise_Information Entities</returns>
		public static Enterprise_InformationDAO CreateEnterprise_InformationDAO()
		{
			return new Enterprise_InformationDAO();
		}

		/// <summary>Creates a new Enum_AuthorizationTypeDAO object</summary>
		/// <returns>the new DAO object ready to use for Enum_AuthorizationType Entities</returns>
		public static Enum_AuthorizationTypeDAO CreateEnum_AuthorizationTypeDAO()
		{
			return new Enum_AuthorizationTypeDAO();
		}

		/// <summary>Creates a new Enum_DataSourceDAO object</summary>
		/// <returns>the new DAO object ready to use for Enum_DataSource Entities</returns>
		public static Enum_DataSourceDAO CreateEnum_DataSourceDAO()
		{
			return new Enum_DataSourceDAO();
		}

		/// <summary>Creates a new Enum_DataTypeDAO object</summary>
		/// <returns>the new DAO object ready to use for Enum_DataType Entities</returns>
		public static Enum_DataTypeDAO CreateEnum_DataTypeDAO()
		{
			return new Enum_DataTypeDAO();
		}

		/// <summary>Creates a new FirmDAO object</summary>
		/// <returns>the new DAO object ready to use for Firm Entities</returns>
		public static FirmDAO CreateFirmDAO()
		{
			return new FirmDAO();
		}

		/// <summary>Creates a new LocatorDAO object</summary>
		/// <returns>the new DAO object ready to use for Locator Entities</returns>
		public static LocatorDAO CreateLocatorDAO()
		{
			return new LocatorDAO();
		}

		/// <summary>Creates a new LocatorGridRowDAO object</summary>
		/// <returns>the new DAO object ready to use for LocatorGridRow Entities</returns>
		public static LocatorGridRowDAO CreateLocatorGridRowDAO()
		{
			return new LocatorGridRowDAO();
		}

		/// <summary>Creates a new LocatorNodeComputedValueDAO object</summary>
		/// <returns>the new DAO object ready to use for LocatorNodeComputedValue Entities</returns>
		public static LocatorNodeComputedValueDAO CreateLocatorNodeComputedValueDAO()
		{
			return new LocatorNodeComputedValueDAO();
		}

		/// <summary>Creates a new LocatorObjectRecordDAO object</summary>
		/// <returns>the new DAO object ready to use for LocatorObjectRecord Entities</returns>
		public static LocatorObjectRecordDAO CreateLocatorObjectRecordDAO()
		{
			return new LocatorObjectRecordDAO();
		}

		/// <summary>Creates a new LocatorObjectValueDAO object</summary>
		/// <returns>the new DAO object ready to use for LocatorObjectValue Entities</returns>
		public static LocatorObjectValueDAO CreateLocatorObjectValueDAO()
		{
			return new LocatorObjectValueDAO();
		}

		/// <summary>Creates a new LocatorRolloverDAO object</summary>
		/// <returns>the new DAO object ready to use for LocatorRollover Entities</returns>
		public static LocatorRolloverDAO CreateLocatorRolloverDAO()
		{
			return new LocatorRolloverDAO();
		}

		/// <summary>Creates a new TempComputedResultsDAO object</summary>
		/// <returns>the new DAO object ready to use for TempComputedResults Entities</returns>
		public static TempComputedResultsDAO CreateTempComputedResultsDAO()
		{
			return new TempComputedResultsDAO();
		}

		/// <summary>Creates a new TempComputeFieldsDAO object</summary>
		/// <returns>the new DAO object ready to use for TempComputeFields Entities</returns>
		public static TempComputeFieldsDAO CreateTempComputeFieldsDAO()
		{
			return new TempComputeFieldsDAO();
		}

		/// <summary>Creates a new TypedListDAO object</summary>
		/// <returns>The new DAO object ready to use for Typed Lists</returns>
		public static TypedListDAO CreateTypedListDAO()
		{
			return new TypedListDAO();
		}

		#region Included Code

		#endregion
	}
}
