using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using fit;
using fitnesse;
using TestHarness.BusinessObjects;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.DataObjects.EntityClasses;
using TaxBuilder.DataObjects;
using TaxBuilder.DataObjects.CollectionClasses;
using TaxBuilder.BusinessObjects;
using TaxBuilder.GraphicObjects;
using log4net;

namespace TestHarnessFitness
{
    //|!-TestHarnessFitness.RunScript-!|
    //|IDofFieldWithScript|Result?|
    public class RunScript : ColumnFixture
    {
        public static string csFileName = "Thomson.Ria.TaxApp.AllApplications.2005.Scripts.cs";
        public static string ScriptFileName = "Thomson.Ria.TaxApp.AllApplications.2005.Scripts.dll";
        public static string CalcInfoFileName = "CalcInfo.Bin";
        private static readonly ILog theLogger = LogManager.GetLogger("RunScript");
        public int IDofFieldWithScript;
        public string Result()
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            GraphicObjectEntity goe = new GraphicObjectEntity(IDofFieldWithScript);
            int pageID = goe.Page_ID;

            string filename = RunScript.ScriptFileName;
            string dir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "RunTimeBinaries");
            filename = Path.Combine(dir, filename);

            //TODO: move this function into the TB Biz Objects
            //CalcInfoBuilder cib = new CalcInfoBuilder();
            //List<CalcRecord> crl = cib.GenerateCalcRecords();
            //CalcInfoBuilder.WriteRecordsToFile("dotnet\\RunTimeBinaries\\" + CalcInfoFileName, crl);

            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();

            UserConfigurationItems con = new UserConfigurationItems();
            DatabaseAndBinaryPathSettings db = new DatabaseAndBinaryPathSettings();
            db.CodeScriptDLLPathAndName = filename;
            db.MappingInfoFilePathAndName = Path.Combine(dir, CalcInfoFileName);

            string name = string.Empty;
            int id = 0;
            short year = 1900;
            ClientImpl cli = new ClientImpl();
            foreach (ClientIDAndNameWithLocatorDictionary l in cli.GetAllClientNames())
            {
                foreach (LocatorInfo l2 in l.Locators)
                {
                    name = l2.Name;
                    id = l2.LocatorID;
                    year = l2.Year;
                    break;
                }
                if (id != 0)
                    break;
            }

            ITaxAppData li = new LocatorImpl();
            li.Initialize(name, id, year, con);
            li.PerformFullCompute();
            
            li.SelectDataSource(false, pageID, IDofFieldWithScript, DataSourceEnum.Compute, 0, 1);

            return li.GetSingleValue(pageID, IDofFieldWithScript, 0).ToString();
           
            
        }
    }
}
