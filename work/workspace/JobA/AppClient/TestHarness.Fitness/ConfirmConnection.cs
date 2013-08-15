using System;
using System.Collections.Generic;
using System.Text;
using fit;
using fitnesse;
using TestHarness.BusinessObjects;
using TaxApp.InterfacesAndConstants;
using NUnit.Framework;
using log4net;

namespace TestHarnessFitness
{
    public class ConfirmConnection : ColumnFixture
    {
        private static readonly ILog theLogger = LogManager.GetLogger("ConfirmConnection");
        public ConfirmConnection()
        {
            theLogger.Info("ConfirmConnection ctor");
        }

        private string myType = string.Empty;
        private string myServer = string.Empty;
        private string myDatabase = string.Empty;

        //|type|server|database|schema_version?|
        public string type { get { return myType; } set { myType = value; } }
        public string server { get { return myServer; } set { myServer = value; } }
        public string database { get { return myDatabase; } set { myDatabase = value; } }

        public string schemaversion()
        {
            if (myType.ToLower()  == "design")
            {
                DesignDatabaseConnectionSwitcher.SetServerAndDatabase(myServer, myDatabase);
                string ver = DesignDatabaseConnectionSwitcher.SchemaVersion();
                DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
                return ver;
            }
            else if (myType.ToLower() == "taxappdata")
            {
                if (DatabaseInitializer.CheckEnterpriseTableAndEnums())
                    return ConstantsInInterface.CurrentSchemaVersion;
            }
            return string.Empty;
        }
    }
    namespace Tests
    {
        [TestFixture]
        public class ConfirmconnectionTests
        {
            [Test]
            public void ObjectCd()
            {
                ConfirmConnection cc = new ConfirmConnection();
                cc.server = "(local)\\sqlexpress";
                cc.database = "PaulRevere";
                cc.type = "Design";
                //Console.WriteLine(cc.schema_version.ToString());

                fit.Fixture f = (Fixture)cc;
                Assert.IsNotNull(f);


            }
        }
    }
}
