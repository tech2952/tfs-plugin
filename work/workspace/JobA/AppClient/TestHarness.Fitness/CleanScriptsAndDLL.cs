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
    public class CleanScriptsAndDLL : ColumnFixture
    {
        private static readonly ILog theLogger = LogManager.GetLogger("CleanScriptsAndDll");
        public string Result()
        {
            string filename = RunScript.ScriptFileName;
            string dir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "RunTimeBinaries");
            filename = Path.Combine(dir, filename);
            FileInfo fi = new FileInfo(filename);
            try
            {
                if (fi.Exists)
                {
                    fi.Delete();
                    theLogger.Info("File Deleted: " + filename);
                }
            }
            catch (Exception ex)
            {
                theLogger.Error("Error trying to delete DLL - possibly locked, and we might be able to catch that one");

                return ex.ToString();
            }
            string csFilename = RunScript.csFileName;
            csFilename = Path.Combine(dir, csFilename);
            FileInfo fi2 = new FileInfo(csFilename);
            try
            {
                if (fi2.Exists)
                {
                    fi2.Delete();
                    theLogger.Info("File Deleted: " + csFilename);
                }
            }
            catch (Exception ex3)
            {
                theLogger.Error("Error trying to delete cs file");
                return ex3.ToString();
            }
            string resultstring = "Code scripts and DLL deleted if found, Design CodeScripts Deleted";
            try
            {
                int i = 0;
                DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
                //get rid of all the CSAs
                ComputedObjectDependencyCollection codc = new ComputedObjectDependencyCollection();
                codc.GetMulti(null);
                i = codc.DeleteMulti();
                theLogger.Info("ComputedObjectDependency deleted record count: " + i);
                FADSConstraintDependencyCollection fcdc = new FADSConstraintDependencyCollection();
                fcdc.GetMulti(null);
                i = fcdc.DeleteMulti();
                theLogger.Info("FADSConstraintDependency deleted record count: " + i);
                CodeScriptAssignmentCollection csac = new CodeScriptAssignmentCollection();
                csac.GetMulti(null);
                i = csac.DeleteMulti();
                theLogger.Info("CodeScriptAssignment deleted record count: " + i);

                //now clean the code scripts from the design database

                CodeScriptTestCaseValuesCollection cstcvc = new CodeScriptTestCaseValuesCollection();
                cstcvc.GetMulti(null);
                i = cstcvc.DeleteMulti();
                theLogger.Info("CodeScriptTestCaseValue deleted record count: " + i);
                CodeScriptTestCaseCollection cstcc = new CodeScriptTestCaseCollection();
                cstcc.GetMulti(null);
                i = cstcc.DeleteMulti();
                theLogger.Info("CodeScriptTestCase deleted record count: " + i);
                CodeScriptParametersCollection cspc = new CodeScriptParametersCollection();
                cspc.GetMulti(null);
                i = cspc.DeleteMulti();
                theLogger.Info("CodeScriptParameters deleted record count: " + i);
                CodeScriptCollection csc = new CodeScriptCollection();
                csc.GetMulti(null);
                i = csc.DeleteMulti();
                theLogger.Info("CodeScript deleted record count: " + i);
            }
            catch (Exception ex2)
            {
                resultstring = ex2.ToString();
            }
            finally
            {
                DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            }
            return resultstring;

        }
    }
}
