using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TaxApp.InterfacesAndConstants
{
    /// <summary>
    /// This class is used to indicate a node that is editable and is linked to a column of data - a grid column.  When it is edited and 
    /// a saved, a new row in the column is created, and any looping nodes (nodes that loop on the grid column's data) refresh.
    /// 
    /// </summary>
    public class NewEntryOnAGroupLoopNode
    {
        public NewEntryOnAGroupLoopNode(int PageID, int GraphicID, int RecordLineage, string NodeName, bool IsFirstEntry)
        {
            myPageID = PageID;
            myGraphicID = GraphicID;
            myRecordLineage = RecordLineage;
            myNodeName = NodeName;
            myIsFirstEntry = IsFirstEntry;
        }
        private int myNodeImage = 12;   //arbitrarily chosen
        private bool myIsFirstEntry;

        public bool IsFirstEntry
        {
            get { return myIsFirstEntry; }
            set { myIsFirstEntry = value; }
        }
	
        public int NodeImage
        {
            get { return myNodeImage; }
            set { myNodeImage = value; }
        }

        private int myRecordLineage;

	    public int RecordLineage
	    {
		    get { return myRecordLineage;}
		    set { myRecordLineage = value;}
	    }

        private int myGraphicID;

	    public int GraphicID
	    {
		    get { return myGraphicID;}
		    set { myGraphicID = value;}
	    }
        private int myPageID;

        public int PageID
        {
            get { return myPageID; }
            set { myPageID = value; }
        }
        private string myNodeName = "<<select to add a new one>>";
        public string NodeName { get { return myNodeName; } set { myNodeName = value; } }

    }
    namespace Tests
    {
        [TestFixture]
        public class NewEntryOnAGroupLoopNodeTests
        {
            [Test]
            public void ObjectCd()
            {
                NewEntryOnAGroupLoopNode o = new NewEntryOnAGroupLoopNode(1, 2, 3, "Test", false);
                Assert.AreEqual(1, o.PageID);
                Assert.AreEqual(2, o.GraphicID);
                Assert.AreEqual(3, o.RecordLineage);
                Assert.AreEqual("Test", o.NodeName);
                Assert.IsFalse(o.IsFirstEntry);
                Assert.AreEqual(12, o.NodeImage);
                o.PageID = 11;
                Assert.AreEqual(11, o.PageID);
                o.GraphicID = 12;
                Assert.AreEqual(12, o.GraphicID);
                o.RecordLineage = 13;
                Assert.AreEqual(13, o.RecordLineage);
                o.NodeName = "Test2";
                Assert.AreEqual("Test2", o.NodeName);
                o.NodeImage = 14;
                Assert.AreEqual(14, o.NodeImage);
                o.IsFirstEntry = true;
                Assert.IsTrue(o.IsFirstEntry);


            }
        }
    }
}
