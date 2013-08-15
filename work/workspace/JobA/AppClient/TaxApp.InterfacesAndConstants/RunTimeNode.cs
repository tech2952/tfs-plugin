using System;
using NUnit.Framework;
using System.Collections.Generic;
using TaxBuilder.GraphicObjects;
using TaxApp.IntrinsicFunctions;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TaxApp.InterfacesAndConstants
{
	/// <summary>
	/// The RunTimeNode is the representation of the node for runtime use
	/// Each node on the tree needs to know:
	///		What kind of node it is - headers (group loop / entity loop) / organizers / workpapers / tax forms
	///		If it has a page, what pageID
	///		if it has a script - if nothing else it needs to know if it has one.
    ///           possibly what is the constraint script id and the parms' IDs & order.  
    ///           the calc engine will have to include a set of constraint graph trees or a seperate process itself to run constraint calcs, and dynamic is the key with 
    ///           maybe an async trigger from the sql database to clients that have registered for updates to those fields?
	///		the properties (nodesettable property values) - the imageinfoID is currently in here
	///		the security roles that can access it - or rather its namespace so it can be checked against security roles - this'll come from the locator database
    ///     If it has children and if they are already loaded
	/// </summary>
	public class RunTimeNode
	{
        /// <summary>
        /// ctor
        /// </summary>
		public RunTimeNode()
		{
		}
        private string myName;
		private NavigationNodeTypeEnum myNodeType;
		private int myPageID;
        private int myNodeID;
		private bool myShowTaxFormSurface;
        private bool myHasConstraint = false;
        private bool myHasChildren;
        private bool myChildrenAlreadyLoaded;
        private int myLoopRuntimeGraphicID;     //the graphic id that this RunTimeNode will loop on - ie produce one node for each one in the database
        private int myLoopRuntimePageID;        //the pageid that the looping graphic (column) is on.
        private int myLoopRecordID;             //the Record_ID of this looping node - only valid on the dynamically produced nodes
        private int myRecordLineage = 0;        //Used when a node is involved in a loop of a leveled page (a grid that doesn't exist at level 0)
        private string myRowLineage = string.Empty;
        private string myApplicationName;
        private int myImageIndex;
        private bool myEnabled = true;
        private string myKey;                   //The generated key on an ultra tree
        private int myAlternateActionNodeID;
        private int myShortcutNodeID;
        private short myProductYear;
        private AppTypeEnum myAppTypeEnum;
        
        /// <summary>
        /// the product year of the build application
        /// </summary>
        public short ProductYear
        {
            get { return myProductYear; }
            set { myProductYear = value; }
        }
        /// <summary>
        /// the application type (Print, TaxApp)
        /// </summary>
        public AppTypeEnum AppType
        {
            get { return myAppTypeEnum; }
            set { myAppTypeEnum = value; }
        }
        /// <summary>
        /// Node Name
        /// </summary>
        public string Name { get { return myName; } set { myName = value; } }
        /// <summary>
        /// bool indicating whether or not this node has any children.  Quick indicator to know whether or not you need to even 
        /// ask for a nodes children.  Good for setting dummy nodes under the current node to indicate the node is openable.
        /// </summary>
        public bool HasChildren { get { return myHasChildren; } set { myHasChildren = value; } }
        /// <summary>
        /// when the runtimenode is asked to load its children (via ITaxAppInfo.GetRunTimeNodesChildren()), this will be set
        /// so the client side can check whether or not it needs to get them.
        /// </summary>
        public bool ChildrenAlreadyLoaded { get { return myChildrenAlreadyLoaded; } set { myChildrenAlreadyLoaded = value; } }
        /// <summary>
        /// The graphic id of the grid column that this node loops on
        /// </summary>
        public int LoopRuntimeGraphicID { get { return myLoopRuntimeGraphicID; } set { myLoopRuntimeGraphicID = value; } }
        /// <summary>
        /// the page id of the grid column that this node loops on
        /// </summary>
        public int LoopRuntimePageID { get { return myLoopRuntimePageID; } set { myLoopRuntimePageID = value; } }
        /// <summary>
        /// nodes can loop on a grid column, with a specific graphicID/pageID key - which returns a set of values each with individual Record IDs.
        /// </summary>
        public int LoopRecordID { get { return myLoopRecordID; } set { myLoopRecordID = value; } }
        /// <summary>
        /// Application name of the built application for this node.
        /// </summary>
        public string ApplicationName
        {
            get { return myApplicationName; }
            set { myApplicationName = value; }
        }
        /// <summary>
        /// A index of the image for this particular node type.  there is a index index enum, and the actual images can be retrieved from SS & from inside TaxBuilder
        /// </summary>
        public int ImageIndex
        {
            get { return myImageIndex; }
            set { myImageIndex = value; }
        }
        /// <summary>
        /// Groups can be nested.  The record lineage of a node is used when a parent is a looping node.  This allows for values changed on that page
        /// to be given the record lineage of the holding group.  For instance:
        ///     (folder) Partners:
        ///         (Looping Node folder) Partner A:  --has a loopRecordID  ##
        ///             (page node) Form X:                 --\
        ///             (page node) Form Y:                    \  both these two have the same node ID, but their Record Lineage = the Record ID of their holding parent's LoopRecordID
        ///         (Looping Node folder) Partner B:           /
        ///             (page node) Form X:                 --/  
        ///             (page node) Form Y:
        /// </summary>
        public int RecordLineage { get { return myRecordLineage; } set { myRecordLineage = value; } }
        /// <summary>
        /// See record lineage - but this tracks the display row lineage from the top (eg 1.2.1 designates three lvls of detail, and 1.2.2 would be the second row with the same parents)
        /// </summary>
        public string RowLineage { get { return myRowLineage; } set { myRowLineage = value; } }
        /// <summary>
        /// whether or not the node is enabled due to logic constraints on the node.
        /// TODO: this needs to be hooked up to a calc engine with access to the constraint scripts and the backend database.
        /// </summary>
        public bool Enabled { get { return myEnabled; } set { myEnabled = value; } }
        /// <summary>
        /// if the node is not enabled due to a constraint, the alternate node id is one that possibly is.  not always used, and can be chained
        /// </summary>
        public int AlternateActionNodeID { get { return myAlternateActionNodeID; } set { myAlternateActionNodeID = value; } }
        /// <summary>
        /// if the page has been shortcutted, meaning dropped in one area of the tree, and then a copy made of that page in other parts of the tree via the create shortcut method
        /// </summary>
        public int ShortcutNodeID { get { return myShortcutNodeID; } set { myShortcutNodeID = value; } }
        /// <summary>
        /// The node type
        /// </summary>
        public NavigationNodeTypeEnum NodeType
		{
			get{return myNodeType;}
			set
			{
				myNodeType = value;
				switch (value)
				{
					case NavigationNodeTypeEnum.PRTAlternateNode:
					case NavigationNodeTypeEnum.PRTAttachmentNode:
					case NavigationNodeTypeEnum.PRTPageNode:
					case NavigationNodeTypeEnum.TAOrganizerNode:
					case NavigationNodeTypeEnum.TAWorkpaperNode:
						myShowTaxFormSurface = true;
						break;

					default:
						myShowTaxFormSurface = false;
						break;
				}
			}
		}
        /// <summary>
        /// The Page ID, if zero then it doesn't have a page
        /// </summary>
		public int PageID{get{return myPageID;}set{myPageID = value;}}
        /// <summary>
        /// The node ID
        /// </summary>
        public int NodeID
        {
            get { return myNodeID; }
            set { myNodeID = value; }
        }
        /// <summary>
        /// Indicates whether this node shows a page - or if it is just a container.
        /// </summary>
		public bool ShowTaxFormSurface
		{
			get{return myShowTaxFormSurface;}
			set{myShowTaxFormSurface = value;}
		}
        /// <summary>
        /// Indicates the key given to this node in the tree.  Set by the user of this interface
        /// </summary>
        public string Key
        {
            get { return myKey; }
            set { myKey = value; }
        }
        /// <summary>
        /// Indicates whether this node has a constraint associated with it.  If so it should monitor the tax app client data's locatorNodeComputedValue table.
        /// </summary>
        public bool HasConstraint { get { return myHasConstraint; } set { myHasConstraint = value; } }
        /// <summary>
        /// Method to get the page type from the node type 
        /// </summary>
        /// <returns></returns>
		public PageTypeEnum GetPageTypeBasedOnNodeType()
		{
			switch (myNodeType)
			{
				case NavigationNodeTypeEnum.PRTAlternateNode:
				case NavigationNodeTypeEnum.PRTAttachmentNode:
				case NavigationNodeTypeEnum.PRTPageNode:
					return PageTypeEnum.Form;

				case NavigationNodeTypeEnum.TAOrganizerNode:
					return PageTypeEnum.Organizer;

				case NavigationNodeTypeEnum.TAWorkpaperNode:
					return PageTypeEnum.Workpaper;

				default:
					throw new ArgumentNullException("this node doesn't have a page");
			}
		}
        /// <summary>
        /// create a copy of the node - for looping nodes
        /// </summary>
        /// <returns></returns>
        public RunTimeNode Copy()
        {
            return (RunTimeNode)this.MemberwiseClone();
        }
	}
	namespace Tests
	{
		[TestFixture] public class RunTimeNodeTests
		{
			[Test] public void ObjectCD()
			{
				RunTimeNode rtn = new RunTimeNode();
				Assert.IsNotNull(rtn);
				rtn.NodeType = NavigationNodeTypeEnum.DesignPageNode;
				Assert.AreEqual(NavigationNodeTypeEnum.DesignPageNode, rtn.NodeType);
                bool exceptionthrown = false;
                try { rtn.GetPageTypeBasedOnNodeType(); }
                catch(Exception)
                {
                    exceptionthrown = true;
                }
                Assert.IsTrue(exceptionthrown);
                Assert.IsTrue(!rtn.ShowTaxFormSurface);

                rtn.NodeType = NavigationNodeTypeEnum.PRTAlternateNode;
                Assert.AreEqual(PageTypeEnum.Form, rtn.GetPageTypeBasedOnNodeType());
                rtn.NodeType = NavigationNodeTypeEnum.TAOrganizerNode;
                Assert.AreEqual(PageTypeEnum.Organizer, rtn.GetPageTypeBasedOnNodeType());
                rtn.NodeType = NavigationNodeTypeEnum.TAWorkpaperNode;
                Assert.AreEqual(PageTypeEnum.Workpaper, rtn.GetPageTypeBasedOnNodeType());
                
				rtn.PageID = 5;
                Assert.IsFalse(rtn.HasConstraint);
                rtn.HasConstraint = true;
                Assert.IsTrue(rtn.HasConstraint);
				
				Assert.AreEqual(5, rtn.PageID);
				rtn.NodeType = NavigationNodeTypeEnum.TAWorkpaperNode;
				Assert.IsTrue(rtn.ShowTaxFormSurface);
                rtn.ShowTaxFormSurface = false;
                Assert.IsFalse(rtn.ShowTaxFormSurface);
                rtn.ChildrenAlreadyLoaded = true;
                Assert.AreEqual(true, rtn.ChildrenAlreadyLoaded);
                rtn.Enabled = false;
                Assert.IsFalse(rtn.Enabled);
                rtn.HasChildren = true;
                Assert.IsTrue(rtn.HasChildren);
                rtn.ImageIndex = 2;
                Assert.AreEqual(2, rtn.ImageIndex);
                rtn.LoopRecordID = 5;
                Assert.AreEqual(5, rtn.LoopRecordID);
                rtn.LoopRuntimeGraphicID = 6;
                rtn.LoopRuntimePageID = 7;
                Assert.AreEqual(6, rtn.LoopRuntimeGraphicID);
                Assert.AreEqual(7, rtn.LoopRuntimePageID);
                rtn.Name = "Name";
                rtn.NodeID = 1;
                rtn.RecordLineage = 88;
                Assert.AreEqual("Name", rtn.Name);
                Assert.AreEqual(1, rtn.NodeID);
                Assert.AreEqual(88, rtn.RecordLineage);
			}
            [Test]
            public void CopyTest()
            {
                RunTimeNode rtnoriginal = new RunTimeNode();
                rtnoriginal.ApplicationName = "Sample";
                RunTimeNode rtCopy = rtnoriginal.Copy();
                Assert.IsFalse(rtCopy == rtnoriginal);
                Assert.AreEqual(rtCopy.ApplicationName, rtnoriginal.ApplicationName);

            }
		}
	}

}

