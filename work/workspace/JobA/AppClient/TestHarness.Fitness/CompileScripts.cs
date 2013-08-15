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
    public class CompileScripts : ColumnFixture
    {
        private static readonly ILog theLogger = LogManager.GetLogger("CompileScripts");
        public string Result()
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            string filename = RunScript.ScriptFileName;
            string dir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "RunTimeBinaries");
            filename = Path.Combine(dir, filename);
            FileInfo fi = new FileInfo(filename);
            theLogger.Info("Compiling scripts: filename / exists: " + filename + " / " + fi.Exists.ToString());
            //ScriptBuilder.includeCompute = true;
            ScriptBuilder sb2 = new ScriptBuilder("", true);
            theLogger.Info("Compile Results: " + sb2.LogResults);
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return string.Empty;
        }
    }
}
