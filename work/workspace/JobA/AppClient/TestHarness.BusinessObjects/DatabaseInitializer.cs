using System;
using NUnit.Framework;
using TestHarness.DataObjects;
using TestHarness.DataObjects.CollectionClasses;
using TestHarness.DataObjects.EntityClasses;
using TestHarness.DataObjects.FactoryClasses;
using TestHarness.DataObjects.HelperClasses;
using TaxApp.IntrinsicFunctions;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.GraphicObjects;
using SD.LLBLGen.Pro.ORMSupportClasses;
using log4net;
using System.Reflection;
using System.Configuration;

namespace TestHarness.BusinessObjects
{
	/// <summary>
	/// Class to handle checking the PatrickHentry database for version (Enterprise_Information table)
	/// add enums to the database based on the enums in the product, and methods to clear the database.
	/// </summary>
	public class DatabaseInitializer
	{
		private static readonly ILog theLogger = LogManager.GetLogger("DatabaseInitializer");
        public static bool CheckedForThisExecution = false;
		public DatabaseInitializer(){}
        private static string myLocatorDatabaseConnectionString = string.Empty;

		
        /// <summary>
        /// NOT FOR USE IN PRODUCTION.  MOVE TO UNIT TEST CODE.  This is not the most efficient way to do this - this is actually loading in the entire set and then deleting them, instead could use a filter and delete all with IDs > 0 - but this is easier for now, and since only the unit tests should be calling these, it should be ok for now - NOT FOR USE IN PRODUCTION.
        /// </summary>
		public static void ClearDatabaseCompletely()
		{
			int numberDeleted = 0;
			theLogger.Warn("Clear Database Completely started");

			ClientCustomerCollection clientCustColl = new ClientCustomerCollection();
			clientCustColl.DeleteMulti(null);
			
			ClientLocatorCollection clloco = new ClientLocatorCollection();
            clloco.DeleteMulti(null);

            LocatorGridRowCollection lgrc = new LocatorGridRowCollection();
            lgrc.DeleteMulti(null);

			LocatorObjectValueCollection lovc = new LocatorObjectValueCollection();
            lovc.DeleteMulti(null);

			LocatorObjectRecordCollection lorc = new LocatorObjectRecordCollection();
            lorc.DeleteMulti(null);

			LocatorRolloverCollection lrc = new LocatorRolloverCollection();
            lrc.DeleteMulti(null);

			LocatorNodeComputedValueCollection lncvc = new LocatorNodeComputedValueCollection();
            lncvc.DeleteMulti(null);
            
			Enum_DataSourceCollection en = new Enum_DataSourceCollection();
            en.DeleteMulti(null);

			Enum_DataTypeCollection ed = new Enum_DataTypeCollection();
            ed.DeleteMulti(null);

			Enum_AuthorizationTypeCollection eatc = new Enum_AuthorizationTypeCollection();
            eatc.DeleteMulti(null);

			LocatorCollection lc = new LocatorCollection();
            lc.DeleteMulti(null);

			CustomerLocatorAuthorizationCollection clac = new CustomerLocatorAuthorizationCollection();
            clac.DeleteMulti(null);

			CustomerNamespaceAuthorizationCollection cnac = new CustomerNamespaceAuthorizationCollection();
            cnac.DeleteMulti(null);

			CustomerNameCollection custNameColl = new CustomerNameCollection();
            custNameColl.DeleteMulti(null);

			ClientCollection clientColl = new ClientCollection();
            clientColl.DeleteMulti(null);

			FirmCollection fc = new FirmCollection();
            fc.DeleteMulti(null);

			Enterprise_InformationCollection eic = new Enterprise_InformationCollection();
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(PredicateFactory.CompareValue(Enterprise_InformationFieldIndex.DB_Version, ComparisonOperator.GreaterThan, "0.00"));
			numberDeleted = eic.DeleteMulti(filter);

            DatabaseInitializer.CheckedForThisExecution = false;

		}
		
        public static bool CheckEnterpriseTableAndEnums()
		{
            if (CheckedForThisExecution)
                return true;
            try
            {
                if (!IsEnterpriseTableInitialized())
                {
                    CheckAllEnums();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                theLogger.Warn("Error checking Enterprise Table and Enums.  Possibly login error");
                return false;
            }
            catch (Exception ex)
            {
                theLogger.Error("Unknown error checking database enterprise table and enums", ex);
            }
            DatabaseInitializer.CheckedForThisExecution = true;
			return true;

		}
		private static bool IsEnterpriseTableInitialized()
		{
			Enterprise_InformationCollection eic = new Enterprise_InformationCollection();
			eic.GetMulti(null);
			Enterprise_InformationEntity eie = null;
			bool initialized = false;
			//if there are no EnterpriseInformation entities then the database is brand new - initialize them
			if (eic.Count == 0)
			{
				eie = new Enterprise_InformationEntity();
				//TODO: get the various versioning assembly information pieces
				//for now have a Enterprise_InformationEntity is enough to designate that the database has been init'd.
				eie.DB_Version = ConstantsInInterface.CurrentSchemaVersion;
				eie.Save();
			}
			else
			{
				//TODO: process the eie
				//TODO:  this is where an update to the database should be checked - if the version doesn't match the dataobject version...
				eie = eic[eic.Count - 1];		//anyupdates to this table just go at the end, kind of history...
				if (eie.DB_Version != ConstantsInInterface.CurrentSchemaVersion)    //replace with the value gleaned from the businessojbects...
				{
					initialized = false;
					theLogger.Error("database version mismatch - expected version: " + eie.DB_Version.ToString());
					throw new InvalidOperationException("database version mismatch - please reinstall database");
				}
				else
				{
					initialized = true;
				}
			}
			return initialized;

		}
		private static void CheckAllEnums()
		{
			//there is only 3 of them so far - just do them manually
			Enum_DataTypeCollection edtc = new Enum_DataTypeCollection();
			if (edtc.GetDbCount() != Enum.GetNames(typeof (EnumKeyDataType)).Length)
			{
				if (edtc.GetDbCount() == 0)
				{
					foreach (int i in Enum.GetValues(typeof (EnumKeyDataType)))
					{
						Enum_DataTypeEntity edte = new Enum_DataTypeEntity();
						edte.Enum_Value = Convert.ToByte(i);
						edte.Enum_Description = Enum.GetName(typeof (EnumKeyDataType), i);
						edte.Save();
					}
					theLogger.Debug("Enum_DataType DB Count: " + edtc.GetDbCount());
				}
			}
			Enum_DataSourceCollection edsc = new Enum_DataSourceCollection();
			if (edsc.GetDbCount() != Enum.GetNames(typeof(DataSourceEnum)).Length)
			{
				if (edsc.GetDbCount() == 0)
				{
					foreach (int i in Enum.GetValues(typeof (DataSourceEnum)))
					{
						Enum_DataSourceEntity edse = new Enum_DataSourceEntity();
						edse.Enum_Value = Convert.ToByte(i);
						edse.Enum_Description = Enum.GetName(typeof (DataSourceEnum), i);
						edse.Save();
					}
					theLogger.Debug("Enum_DataSource DB Count: " + edsc.GetDbCount());
				}
			}
			Enum_AuthorizationTypeCollection eatc = new Enum_AuthorizationTypeCollection();
			if (eatc.GetDbCount() != Enum.GetNames(typeof(AuthorizationTypeEnum)).Length)
			{
				if (eatc.GetDbCount() == 0)
				{
					foreach (int i in Enum.GetValues(typeof (AuthorizationTypeEnum)))
					{
						Enum_AuthorizationTypeEntity eae = new Enum_AuthorizationTypeEntity();
						eae.Enum_Value = Convert.ToByte(i);
						eae.Enum_Description = Enum.GetName(typeof(AuthorizationTypeEnum), i);
						eae.Save();
					}
					theLogger.Debug("Enum_AuthorizationType DB Count: " + eatc.GetDbCount());
				}
			}
		}
	}

	namespace Tests
	{
		[TestFixture] public class DatabaseInitializerTests
		{
			[Test] public void EnterpriseCheck()
			{
				DatabaseInitializer.ClearDatabaseCompletely();
				Enterprise_InformationCollection eic = new Enterprise_InformationCollection();
                Assert.AreEqual(0, eic.GetDbCount());

				DatabaseInitializer.CheckEnterpriseTableAndEnums();
				
				Assert.IsTrue(eic.GetDbCount() == 1);
				
				Enum_DataTypeCollection edc = new Enum_DataTypeCollection();
				Assert.AreEqual(edc.GetDbCount(), Enum.GetNames(typeof(EnumKeyDataType)).Length);

				Enum_AuthorizationTypeCollection aet = new Enum_AuthorizationTypeCollection();
				Assert.AreEqual(aet.GetDbCount(), Enum.GetNames(typeof(AuthorizationTypeEnum)).Length);

				Enum_DataSourceCollection eds = new Enum_DataSourceCollection();
				Assert.AreEqual(eds.GetDbCount(), Enum.GetNames(typeof(DataSourceEnum)).Length);

                Assert.IsTrue(DatabaseInitializer.CheckEnterpriseTableAndEnums());
			}
			[Test] public void ClearTest()
			{
				//TODO: finish this test to test all tables adds & interactions plus clear
				DatabaseInitializer.ClearDatabaseCompletely();

				UserConfigurationItems config = new UserConfigurationItems();

				CustomerNameEntity cn = new CustomerNameEntity();
				cn.FirstName = "First";
				cn.LastName = "Last";
				cn.WindowsDomainLogin = "login";
				cn.IsAdministrator = false;
				cn.Save();
				Console.WriteLine("CustomerName.Customer_ID " + cn.Customer_ID);

				ClientEntity c = new ClientEntity();
				c.Product_Year = 2004;
				c.Firm_Code = "FC";
				c.Client_Name = "Name";
				c.Save();

				ClientCustomerEntity cc = new ClientCustomerEntity();
				cc.Product_Year = 2004;
				cc.Client_ID = c.Client_ID;
				cc.Customer_ID = cn.Customer_ID;
				cc.Save();

				FirmEntity fe = new FirmEntity();
				fe.Product_Year = 2004;
				fe.Firm_Code = "FC";
				fe.Firm_Name = "Firm Name";
				fe.Save();

				CustomerNameCollection cnc = new CustomerNameCollection();
				Assert.IsTrue(cnc.GetDbCount() > 0);

				ClientCollection ccoll = new ClientCollection();
				Assert.IsTrue(ccoll.GetDbCount() > 0);

				ClientCustomerCollection cccoll = new ClientCustomerCollection();
				Assert.IsTrue(cccoll.GetDbCount() > 0);

				FirmCollection fc = new FirmCollection();
				Assert.IsTrue(fc.GetDbCount() > 0);

				DatabaseInitializer.ClearDatabaseCompletely();

				Assert.IsTrue(cnc.GetDbCount() == 0);
				Assert.IsTrue(ccoll.GetDbCount() == 0);
				Assert.IsTrue(cccoll.GetDbCount() == 0);
				Assert.IsTrue(fc.GetDbCount() == 0);

				Enterprise_InformationCollection eic = new Enterprise_InformationCollection();
				Assert.IsTrue(eic.GetDbCount() == 0);
			}
		}

	}
}
