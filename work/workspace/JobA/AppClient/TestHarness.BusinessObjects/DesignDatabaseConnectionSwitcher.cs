using System;
using NUnit.Framework;
using System.Configuration;
using TaxBuilder.BusinessObjects;
using TaxBuilder.DataObjects.HelperClasses;
using log4net;

namespace TestHarness.BusinessObjects
{
	/// <summary>
	/// Summary description for DesginDatabaseConnectionSwitcher.
	/// </summary>
	public class DesignDatabaseConnectionSwitcher
	{
        private static readonly ILog theLogger = LogManager.GetLogger("DesignDBConnSwitcher");
		private static string myDesignDatabaseConnectionString = string.Empty;
		public static string DesignDatabaseConnectionString
		{
			get
			{
				if (myDesignDatabaseConnectionString.Length == 0)
				{
					AppSettingsReader configReader = new AppSettingsReader();
					try
					{
						myDesignDatabaseConnectionString = configReader.GetValue("Main.ConnectionStringForDesignDatabase", typeof(string)).ToString();
					}
					catch (System.InvalidOperationException)
					{
						//no firm name - probably nothing else either, default?
						throw new NullReferenceException("Invalid Main.ConnectionStringForDesignDatabase in config file");

					}
				}
				return myDesignDatabaseConnectionString;
			}
		}
        public static void SetServerAndDatabase(string ServerName, string DatabaseName)
        {
            try
            {
                if (ServerName.Equals(string.Empty) || DatabaseName.Equals(string.Empty))
                    myDesignDatabaseConnectionString = string.Empty;
                else
                {
                    string tempconnstring = "data source=" + ServerName + ";initial catalog=" + DatabaseName + ";integrated security=SSPI;persist security info=False;packet size=4096";
                    DbUtils.ActualConnectionString = tempconnstring;
                    TaxBuilder.BusinessObjects.DatabaseInitializer di = TaxBuilder.BusinessObjects.DatabaseInitializer.GetInstance();
                    if (di.DatabaseInitialized)
                    {
                        myDesignDatabaseConnectionString = tempconnstring;
                    }
                }
            }
            catch 
            {
                myDesignDatabaseConnectionString = string.Empty;
            }
        }
        public static string SchemaVersion()
        {
            TaxBuilder.BusinessObjects.DatabaseInitializer di = TaxBuilder.BusinessObjects.DatabaseInitializer.GetInstance();
            if (di.DatabaseInitialized)
                return di.DatabaseVersion;
            else
                return string.Empty;

        }
		public static void SetConnectionToDesignDatabase()
		{
            //if (theLogger.IsDebugEnabled)
            //    theLogger.Debug("Setting Connection to Design Database");
			DbUtils.ActualConnectionString = DesignDatabaseConnectionString;
            //theLogger.Debug("Design database initialized: " + DatabaseInitializer.GetInstance().DatabaseInitialized);
		}
		public static void ResetConnectionBackToMainConnectionString()
		{
            //if (theLogger.IsDebugEnabled)
            //    theLogger.Debug("Resetting Connection to Runtime Database");
			DbUtils.ActualConnectionString = string.Empty;
		}
		public DesignDatabaseConnectionSwitcher(){}
	}
	namespace Tests
	{
		[TestFixture] public class DesignDBConnSwithTester
		{
			[Test] public void ObjectCD()
			{
				DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
                TaxBuilder.BusinessObjects.DatabaseInitializer di = TaxBuilder.BusinessObjects.DatabaseInitializer.GetInstance();
				Console.WriteLine("Design Product Year: " + di.ProductYear.ToString());
				DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
			}
		}
	}
}
