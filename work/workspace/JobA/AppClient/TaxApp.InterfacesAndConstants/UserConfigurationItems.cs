using System;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using TaxBuilder.GraphicObjects;
using NUnit.Framework;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace TaxApp.InterfacesAndConstants
{
	/// <summary>
	/// UserConfigurationItems represents a class of "Input" values - values that are configurable per
    /// session.  This class is serializable and is meant to be displayed in a property grid for configuration
    /// This represents the various pieces of information that the interfaces need to put together the application and the user interface,
    /// including connection strings, specific session information, whatever.    /// 
    /// Additional notes:
    ///     This class could be abstracted, and then the saveToXml's overwritten - so would the subdirectory that the config resides in
    ///     This class, or a sub-class, could implement IConfiguration (or whatever it is so that it plugs into the app.config file)
    ///     This class, should probably contain either specific sub items or a List< IConfigurable> so as a request 
    ///         object is being passed around, other config objects can be dropped into it
	/// </summary>
	public class UserConfigurationItems
	{
        /// <summary>
        /// ctor
        /// </summary>
		public UserConfigurationItems()
		{
			//add any initialization for new ones here
            myDatabaseAndBinaryPathSettings = new DatabaseAndBinaryPathSettings();
		}

        private string myLoginName = string.Empty;
		private string myFirmCode = "FirmCode";
		private string myFirmName = "FirmName";
		private string myClientName = "ClientName";
		private string myAccountCode = "XXXXXXXXXX";
		private string myProductLicense = "License";
		private short myYear = 2007;
		private string myLastOpenLocatorName = "";
        private int myLastOpenLocatorID = 0;

        private string myOrganizerPageColorName = Color.Wheat.Name;
		private string myWorkPaperPageColorName = Color.White.Name;
		private string myTaxFormPageColorName = Color.White.Name;
		private string myOrganizerBackGroundColorName = Color.White.Name;
		private string myWorkPaperBackGroundColorName = Color.White.Name;
		private string myTaxFormBackGroundColorName = Color.White.Name;
        private string myLoopingNodeBackGroudColorName = Color.LemonChiffon.Name;
        private string myLoopingNodeNewEntryColorName = Color.PeachPuff.Name;

		private Color myOrganizerPageColor = Color.Wheat;
		private Color myWorkpaperPageColor = Color.White;
		private Color myTaxFormPageColor = Color.White;
		private Color myOrganizerBackGroundColor = Color.White;
		private Color myWorkpaperBackGroundColor = Color.White;
		private Color myTaxFormBackGroundColor = Color.White;
        private Color myLoopingNodeBackGroundColor = Color.LemonChiffon;
        private Color myLoopingNodeNewEntryBackGroundColor = Color.PeachPuff;

        private FormWindowState myWindowState = FormWindowState.Maximized;
        private int myFormWindowSizeHeight = 600;
        private int myFormWindowSizeWidth = 800;
        private string myAppType;

        private DatabaseAndBinaryPathSettings myDatabaseAndBinaryPathSettings;
        [Browsable(false)]
        public DatabaseAndBinaryPathSettings DatabaseAndBinaryPathSettings
        {
            get { return myDatabaseAndBinaryPathSettings; }
            set { myDatabaseAndBinaryPathSettings = value; }
        }
        
        [Browsable(false)]
        public string AppType
        {
            get { return myAppType; }
            set { myAppType = value; }
        }

        [Browsable(false)]
        public int FormWindowSizeWidth
        {
            get { return myFormWindowSizeWidth; }
            set { myFormWindowSizeWidth = value; }
        }

        [Browsable(false)]
        public int FormWindowSizeHeight
        {
            get { return myFormWindowSizeHeight; }
            set { myFormWindowSizeHeight = value; }
        }

        [Browsable(false)]
        public FormWindowState WindowState
        {
            get { return myWindowState; }
            set { myWindowState = value; }
        }

		public string FirmCode
		{
			get{return myFirmCode;}
			set{myFirmCode = value;}
		}
		public string FirmName
		{
			get{return myFirmName;}
			set{myFirmName = value;}
		}
		public string ClientName
		{
			get{return myClientName;}
			set{myClientName = value;;}
		}
		public string AccountCode
		{
			get{return myAccountCode;}
			set{myAccountCode = value;}
		}
		public string ProductLicense
		{
			get{return myProductLicense;}
			set{myProductLicense = value;}
		}
		public short Year
		{
			get{return myYear;}
			set{myYear = value;}
		}


        [Browsable(false)]
        public string LoopingNodeNewEntryBackGroundColor
        {
            get { return myLoopingNodeNewEntryColorName; }
            set { myLoopingNodeNewEntryColorName = value; }
        }
        [Browsable(false)]
        public string LoopingNodeBackGroundColorName
        {
            get { return myLoopingNodeBackGroudColorName; }
            set { myLoopingNodeBackGroudColorName = value; }
        }
		[Browsable(false)]
		public string OrganizerPageColorName
		{
			get{return myOrganizerPageColorName;}
			set{myOrganizerPageColorName = value;}
		}
		[Browsable(false)]
		public string WorkpaperPageColorName
		{
			get{return myWorkPaperPageColorName;}
			set{myWorkPaperPageColorName = value;}
		}
		[Browsable(false)]
		public string TaxFormPageColorName
		{
			get{return myTaxFormPageColorName;}
			set{myTaxFormPageColorName = value;}
		}

		[Browsable(false)]
		public string OrganizerBackGroundColorName
		{
			get{return myOrganizerBackGroundColorName;}
			set{myOrganizerBackGroundColorName = value;}
		}
		[Browsable(false)]
		public string WorkpaperBackGroundColorName
		{
			get{return myWorkPaperBackGroundColorName;}
			set{myWorkPaperBackGroundColorName = value;}
		}
		[Browsable(false)]
		public string TaxFormBackGroundColorName
		{
			get{return myTaxFormBackGroundColorName;}
			set{myTaxFormBackGroundColorName = value;}
		}

		[Browsable(false)]
		public string LastOpenLocatorName
		{
			get{return myLastOpenLocatorName;}
			set{myLastOpenLocatorName = value;}
		}
        [Browsable(false)]
        public int LastOpenLocatorID
        {
            get { return myLastOpenLocatorID; }
            set { myLastOpenLocatorID = value; }
        }
        [XmlIgnore]
        public Color Looping_Node_New_Entry_Background_Color
        {
            get { return myLoopingNodeNewEntryBackGroundColor; }
            set
            {
                myLoopingNodeNewEntryBackGroundColor = value;
                myLoopingNodeNewEntryColorName = value.Name;
            }
        }
        [XmlIgnore]
        public Color Looping_Node_Background_Color
        {
            get { return myLoopingNodeBackGroundColor; }
            set
            {
                myLoopingNodeBackGroundColor = value;
                myLoopingNodeBackGroudColorName = value.Name;
            }
        }
		[XmlIgnore]
		public Color OrganizerPageColor
		{
			get{return myOrganizerPageColor;}
			set
			{
				myOrganizerPageColor = value;
				myOrganizerPageColorName = value.Name;
			}
		}
		[XmlIgnore]
		public Color WorkpaperPageColor
		{
			get{return myWorkpaperPageColor;}
			set
			{
				myWorkpaperPageColor = value;
				myWorkPaperPageColorName = value.Name;
			}
		}
		[XmlIgnore]
		public Color TaxFormPageColor
		{
			get{return myTaxFormPageColor;}
			set
			{
				myTaxFormPageColor = value;
				myTaxFormPageColorName = value.Name;
			}
		}
		[XmlIgnore]
		public Color OrganizerBackGroundColor
		{
			get{return myOrganizerBackGroundColor;}
			set
			{
				myOrganizerBackGroundColor = value;
				myOrganizerBackGroundColorName = value.Name;
			}
		}
		[XmlIgnore]
		public Color WorkpaperBackGroundColor
		{
			get{return myWorkpaperBackGroundColor;}
			set
			{
				myWorkpaperBackGroundColor = value;
				myWorkPaperBackGroundColorName = value.Name;
			}
		}
		[XmlIgnore]
		public Color TaxFormBackGroundColor
		{
			get{return myTaxFormBackGroundColor;}
			set
			{
				myTaxFormBackGroundColor = value;
				myTaxFormBackGroundColorName = value.Name;
			}
		}

	
	
		public void BuildColorFromNames()
		{
			myOrganizerPageColor = Color.FromName(myOrganizerPageColorName);
            myTaxFormBackGroundColor = Color.FromName(myTaxFormBackGroundColorName);
            myWorkpaperBackGroundColor = Color.FromName(myWorkPaperBackGroundColorName);
            myWorkpaperPageColor = Color.FromName(myWorkPaperPageColorName);
            myTaxFormPageColor = Color.FromName(myTaxFormPageColorName);
            myOrganizerBackGroundColor = Color.FromName(myOrganizerBackGroundColorName);
            myLoopingNodeNewEntryBackGroundColor = Color.FromName(myLoopingNodeNewEntryColorName);
            myLoopingNodeBackGroundColor = Color.FromName(myLoopingNodeBackGroudColorName);
		}

        public static UserConfigurationItems LoadFromXMLFile()
        {
            return LoadFromXMLFile("TestHarness");
        }
		public static UserConfigurationItems LoadFromXMLFile(string AppType)
		{
			UserConfigurationItems userconfigItems = null;
			try
			{
                Type[] types = new Type[1] { typeof(DatabaseAndBinaryPathSettings) };
				XmlSerializer xmlSer = new XmlSerializer(typeof(UserConfigurationItems), types);
                string strFileName = GetFileName(AppType);
				if (File.Exists(strFileName))
				{
					FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
					userconfigItems = (UserConfigurationItems)xmlSer.Deserialize(fs);
					userconfigItems.BuildColorFromNames();
                    userconfigItems.AppType = AppType;
					fs.Close();
				}
				else
				{
					userconfigItems = new UserConfigurationItems();
                    userconfigItems.AppType = AppType;
					userconfigItems.SaveToXMLFile();
				}
			}
			catch (Exception ex)
			{
                throw ex;
			}
			return userconfigItems;
		}
		private static string GetFileName(string AppType)
		{
			string strFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            strFile = Path.Combine(strFile, AppType);
			if (!Directory.Exists(strFile))
				Directory.CreateDirectory(strFile);
			strFile = Path.Combine(strFile , AppType + "UserConfig.xml");
			return strFile;
		}
		public void SaveToXMLFile()
		{
			try
			{
                Type[] types = new Type[1] { typeof(DatabaseAndBinaryPathSettings) };
				XmlSerializer xmlSer = new XmlSerializer(typeof(UserConfigurationItems), types);
				FileStream fs = new FileStream(GetFileName(this.AppType), FileMode.Create, FileAccess.Write);
				xmlSer.Serialize(fs, this);
				fs.Close();
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}
	}
	namespace Tests
	{
		[TestFixture]
		public class UserConfigurationItemsTests
		{
            [Test]
            public void ObjectCD()
            {
                UserConfigurationItems u = new UserConfigurationItems();
                Assert.AreEqual(800, u.FormWindowSizeWidth);
                Assert.AreEqual(600, u.FormWindowSizeHeight);
                Assert.AreEqual(FormWindowState.Maximized, u.WindowState);
                Assert.AreEqual("FirmCode", u.FirmCode);
                Assert.AreEqual("FirmName", u.FirmName);
                Assert.AreEqual("ClientName", u.ClientName);
                Assert.AreEqual("XXXXXXXXXX", u.AccountCode);
                Assert.AreEqual("License", u.ProductLicense);
                Assert.AreEqual(2007, u.Year);
                Assert.AreEqual(string.Empty, u.LastOpenLocatorName);
                Assert.AreEqual(0, u.LastOpenLocatorID);

                Assert.AreEqual(Color.Wheat.Name, u.OrganizerPageColorName);
                Assert.AreEqual(Color.White.Name, u.WorkpaperPageColorName);
                Assert.AreEqual(Color.White.Name, u.TaxFormPageColorName);
                Assert.AreEqual(Color.White.Name, u.OrganizerBackGroundColorName);
                Assert.AreEqual(Color.White.Name, u.WorkpaperBackGroundColorName);
                Assert.AreEqual(Color.White.Name, u.TaxFormBackGroundColorName);
                Assert.AreEqual(Color.LemonChiffon.Name, u.LoopingNodeBackGroundColorName);
                Assert.AreEqual(Color.PeachPuff.Name, u.LoopingNodeNewEntryBackGroundColor);
		
                Assert.AreEqual(Color.Wheat, u.OrganizerPageColor);
                Assert.AreEqual(Color.White, u.WorkpaperPageColor);
                Assert.AreEqual(Color.White, u.TaxFormPageColor);
                Assert.AreEqual(Color.White, u.OrganizerBackGroundColor);
                Assert.AreEqual(Color.White, u.WorkpaperBackGroundColor);
                Assert.AreEqual(Color.White, u.TaxFormBackGroundColor);
                Assert.AreEqual(Color.LemonChiffon, u.Looping_Node_Background_Color);
                Assert.AreEqual(Color.PeachPuff, u.Looping_Node_New_Entry_Background_Color);

            }
            [Test]
            public void TestDirectoryNotThereAndSaveException()
            {
                string strFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                strFile = Path.Combine(strFile, "TestHarness");
                DirectoryInfo di = new DirectoryInfo(strFile);
                if (di.Exists)
                {
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        fi.Delete();
                    }
                    di.Delete();
                }
                UserConfigurationItems u = UserConfigurationItems.LoadFromXMLFile();
                Assert.IsNotNull(u);
                DirectoryInfo di2 = new DirectoryInfo(strFile);
                Assert.IsTrue(di2.Exists);

                strFile = Path.Combine(strFile, "TestHarnessUserConfig.xml");
                FileStream fs = new FileStream(strFile, FileMode.Open, FileAccess.ReadWrite);
                bool exceptionCaught = false;
                try { u.SaveToXMLFile(); }
                catch (Exception)
                {
                    exceptionCaught = true;
                }
                Assert.IsTrue(exceptionCaught);
                exceptionCaught = false;
                try
                {
                    UserConfigurationItems u2 = UserConfigurationItems.LoadFromXMLFile();
                }
                catch (Exception)
                {
                    exceptionCaught = true;
                }
                Assert.IsTrue(exceptionCaught);

                fs.Close();
            }
			[Test]
			public void TestGetFromXML()
			{
				UserConfigurationItems u = UserConfigurationItems.LoadFromXMLFile();
				Assert.IsNotNull(u);
				string oldFirmName = u.FirmCode;
				u.FirmCode = "Changed";
				u.SaveToXMLFile();
				UserConfigurationItems u1 = UserConfigurationItems.LoadFromXMLFile();
				Assert.AreEqual("Changed", u1.FirmCode);
				u1.FirmCode = oldFirmName;
                u1.Looping_Node_Background_Color = Color.WhiteSmoke;
                u1.Looping_Node_New_Entry_Background_Color = Color.Yellow;
                u1.OrganizerBackGroundColor = Color.SteelBlue;
                u1.OrganizerPageColor = Color.Tan;
                u1.TaxFormBackGroundColor = Color.Teal;
                u1.TaxFormPageColor = Color.Thistle;
                u1.WorkpaperBackGroundColor = Color.Tomato;
                u1.WorkpaperPageColor = Color.Turquoise;

				u1.SaveToXMLFile();
				UserConfigurationItems u2 = UserConfigurationItems.LoadFromXMLFile();
				Assert.AreEqual(oldFirmName, u2.FirmCode);
                Assert.AreEqual(Color.WhiteSmoke, u1.Looping_Node_Background_Color);
                Assert.AreEqual(Color.Yellow, u1.Looping_Node_New_Entry_Background_Color);
                Assert.AreEqual(Color.SteelBlue, u1.OrganizerBackGroundColor);
                Assert.AreEqual(Color.Tan, u1.OrganizerPageColor);
                Assert.AreEqual(Color.Teal, u1.TaxFormBackGroundColor);
                Assert.AreEqual(Color.Thistle, u1.TaxFormPageColor);
                Assert.AreEqual(Color.Tomato, u1.WorkpaperBackGroundColor);
                Assert.AreEqual(Color.Turquoise, u1.WorkpaperPageColor);

			}
		}
		}
}
	

