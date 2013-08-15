using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using fit;
using fitnesse;
using TestHarness.BusinessObjects;
using TaxApp.IntrinsicFunctions;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.DataObjects.EntityClasses;
using TaxBuilder.DataObjects;
using TaxBuilder.DataObjects.CollectionClasses;
using log4net;

namespace TestHarnessFitness
{
    /// <summary>
    /// Setup the fields
    ///|!-TestHarnessFitness.CreateField-!|
    ///|id|name|graphictype|datatype|value|saved?
    /// </summary>
    public class CreateField : ColumnFixture
    {
        private static readonly ILog theLogger = LogManager.GetLogger("CreateField");
        public int id;
        public string name;
        public string graphictype;
        public string datatype;
        public string value;
        public bool isComputed = false;
        public bool saved()
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            GraphicObjectEntity goe = new GraphicObjectEntity(id);
            int pageid = FitnessHelpers.GetValidOrganizerPageID();
            if (goe.IsNew)
            {
                goe.Page_ID = FitnessHelpers.GetValidOrganizerPageID();
                goe.GraphicObject_ID = id;
                goe.GraphicObject_Name = name;
                goe.GraphicObjectType_EnumValue = FitnessHelpers.GetGraphicTypeByString(graphictype);
                goe.DataType_EnumValue = FitnessHelpers.GetDataTypeByString(datatype);
                goe.PositionX = 10;
                goe.PositionY = 10;
                goe.Width = 80;
                goe.Height = 40;
                goe.DateLastSaved = DateTime.Now;
                goe.DateCreated = DateTime.Now;
                
                if (graphictype.ToLower().StartsWith("gridcolumn"))
                { 
                    //the type = gridcolumn.ParentID.textbox
                    string[] gtypes = graphictype.Split(new string[1]{"."}, 3, StringSplitOptions.None);
                    goe.Parent_GraphicObject_ID = Convert.ToInt32(gtypes[1]);
                }
                goe.Save();
            }
            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();

            //now set the value in a locator db
            if (graphictype.ToLower().Equals("grid"))
                return true;

            UserConfigurationItems con = new UserConfigurationItems();
            DatabaseAndBinaryPathSettings db = new DatabaseAndBinaryPathSettings();
            string dir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "RunTimeBinaries");
            string filename = Path.Combine(dir, RunScript.ScriptFileName);
            db.CodeScriptDLLPathAndName = filename;
            db.MappingInfoFilePathAndName = Path.Combine(dir, RunScript.CalcInfoFileName);


            string name2 = string.Empty;
            int id2 = 0;
            short year2 = 1900;
            ClientImpl cli = new ClientImpl();
            foreach (ClientIDAndNameWithLocatorDictionary l in cli.GetAllClientNames())
            {
                foreach (LocatorInfo l2 in l.Locators)
                {
                    name2 = l2.Name;
                    id2 = l2.LocatorID;
                    year2 = l2.Year;
                    break;
                }
                if (id2 != 0)
                    break;
            }


            ITaxAppData li = new LocatorImpl();
            li.Initialize(name2, id2, year2, con);


            if (graphictype.ToLower().StartsWith("gridcolumn"))
            {
                string[] vals = value.Split(new char[1] { Convert.ToChar(",") });
                theLogger.Debug("values count: " + vals.Length + " : " + value);
                STRING newString = vals;
                if (isComputed)
                {
                    li.SetBasetypeValue(pageid, id, newString, TaxBuilder.GraphicObjects.DataSourceEnum.Compute, 0);
                }
                else
                {
                    li.SetBasetypeValue(pageid, id, newString, TaxBuilder.GraphicObjects.DataSourceEnum.DataEntry, 0);
                }
            }
            else
            {
                object valob = (object)value;
                if (isComputed)
                {
                    li.SetValue(pageid, id, valob, TaxBuilder.GraphicObjects.DataSourceEnum.Compute, 0);
                }
                else
                {
                    li.SetValue(pageid, id, valob, TaxBuilder.GraphicObjects.DataSourceEnum.DataEntry, 0);
                }
            }

            
            

            return true;
        }
    }
}
