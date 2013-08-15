using System;
using System.Drawing;
using NUnit.Framework;
using TaxBuilder.GraphicObjects;
using TaxBuilder.GraphicObjects.TaxAppRuntime;
using TaxApp.IntrinsicFunctions;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TaxApp.InterfacesAndConstants
{
	/// <summary>
	/// The RunTimePage is the page as it exists at runtime.  This represents all types of pages
	/// this class should serialize
	/// The RTPage needs to know:
	///		What graphics it has - these are essentially a group of controls - but if this is a Collection of Form.Controls
	///				then it really won't serialize that well
	///		What its Page Properties are
	///		What its page ID is
	///		What type of page (essentially nodetype) 
	/// </summary>
    [DataContract]
    public class RunTimePage
	{
        /// <summary>
        /// ctor.  Init GraphicObjectCollection = new() & myDataLinks = new()
        /// </summary>
        public RunTimePage()
		{
			myGraphicObjectCollection = new GraphicObjectCollection();
            myDataLinks = new Dictionary<int, Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>>();
		}
		private PageProperties myPageProperties;
		private GraphicObjectCollection myGraphicObjectCollection;
		private int myPageID;
		private PageTypeEnum myRunTimePageType;
        private int myRecordLineage = 0;
        private string myRowLineage;


        private int myPageLevel = 0;
        private Dictionary<int, Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>> myDataLinks;
        private Image myBackGroundImage;
        /// <summary>
        /// a page property object - from the graphic object namespace
        /// </summary>
        public PageProperties PageProperties{get{return myPageProperties;}set{myPageProperties = value;}}
        /// <summary>
        /// the image of the background - the currently assigned wmf
        /// </summary>
        public Image BackGroundImage { get { return myBackGroundImage; } set { myBackGroundImage = value; } }
        /// <summary>
        /// the page's collection of graphic objects from the graphic object namespace.
        /// </summary>
		public GraphicObjectCollection GraphicsCollection{get{return myGraphicObjectCollection;}}
        /// <summary>
        /// the page ID
        /// </summary>
		public int PageID{get{return myPageID;}set{myPageID = value;}}
        /// <summary>
        /// the page type
        /// </summary>
		public PageTypeEnum PageType{get{return myRunTimePageType;}set{myRunTimePageType = value;}}
        /// <summary>
        /// the loop record ID of the holding node.
        /// </summary>
        public int RecordLineage { get { return myRecordLineage; } set { myRecordLineage = value; } }
        /// <summary>
        /// Row lineage  For detail data off of a column, the details' page's display row lineage, thru multiple levels.  eg 1.2.1, 2.4, etc
        /// </summary>
        public string RowLineage
        {
            get { return myRowLineage; }
            set { myRowLineage = value; }
        }
        /// <summary>
        /// what level down from the root is the page
        /// </summary>
        public int PageLevel { get { return myPageLevel; } set { myPageLevel = value; } }
        /// <summary>
        /// A dictionary of GraphicDataLinks by graphic ID
        /// </summary>
        public Dictionary<int, Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>> DataLinks { get { return myDataLinks; } set { myDataLinks = value; } }

	}
    //just put this here for future ref
    /*
namespace TaxApp.IntrinsicFunctions
{
public enum EnumKeyDataType
{
Boolean = 0,
Integer = 1,
String = 2,
DateTime = 3,
Ratio = 7,
Money = 8,
DataTable = 9,
Image = 10
}
}
 * */
    
	namespace Tests
	{
		[TestFixture] public class RunTimePageTests
		{
			[Test] public void ObjectCD()
			{
				RunTimePage rtp = new RunTimePage();
				Assert.IsNotNull(rtp);
				rtp.PageProperties = new PageProperties();
				Assert.IsNotNull(rtp.PageProperties);
				Assert.IsNotNull(rtp.GraphicsCollection);
				rtp.PageID = 7;
				Assert.AreEqual(7, rtp.PageID);
                rtp.PageLevel = 3;
                rtp.PageType = PageTypeEnum.Form;
                rtp.RecordLineage = 4454;

                Assert.AreEqual(3, rtp.PageLevel);
                Assert.AreEqual(PageTypeEnum.Form, rtp.PageType);
                Assert.AreEqual(4454, rtp.RecordLineage);

                GraphicObject go = new TextBoxGraphic();
                rtp.GraphicsCollection.Add(go);
                Assert.AreEqual(1, rtp.GraphicsCollection.Count);
                Dictionary<KeyValuePair<int, int>,GraphicDataLinkRecord> links = new Dictionary<KeyValuePair<int, int>, GraphicDataLinkRecord>();
                GraphicDataLinkRecord gDL = new GraphicDataLinkRecord();
                gDL.DisplayGraphicName = "name";
                gDL.DisplayPageName = "pageName";
                links.Add(new KeyValuePair<int, int>(3, 4), gDL);
                rtp.DataLinks.Add(1, links);
                Assert.AreEqual(1, rtp.DataLinks.Count);
			}

		}
	}

}
