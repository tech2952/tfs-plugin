using System;
using System.Collections.Generic;
using System.Text;
using TaxBuilder.GraphicObjects;
using TaxApp.IntrinsicFunctions;
using NUnit.Framework;

namespace TaxApp.InterfacesAndConstants
{
    /// <summary>
    /// Testing implementor of the ITaxAppInfo interface.
    /// </summary>
    public class TIApplicationInfo : ITaxAppInfo
    {
        #region IRetrieveApplicationInformation Members
        private UserConfigurationItems myUserConfigItems = null;
        private DatabaseAndBinaryPathSettings myDatabaseandBinaryPathSettings = null;
        

        public void Initialize(UserConfigurationItems userConfigurationItems) 
        {
            myDatabaseandBinaryPathSettings = userConfigurationItems.DatabaseAndBinaryPathSettings;
            myUserConfigItems = userConfigurationItems;
            
           

        }
        public List<string> GetApplicationNamesCurrentlyAvailable()
        {
            List<string> l = new List<string>();
            l.Add("Sample Application");
            return l;
        }

        public RunTimeNode GetApplicationRootRunTimeNode(string ApplicationName, AppTypeEnum TreeType, short Year)
        {
            RunTimeNode rtn = new RunTimeNode();
            rtn.ApplicationName = ApplicationName;
            rtn.ChildrenAlreadyLoaded = false;
            rtn.HasChildren = true;
            rtn.ImageIndex = 2;
            if (TreeType == AppTypeEnum.Print)
            {
                rtn.NodeType = TaxBuilder.GraphicObjects.NavigationNodeTypeEnum.PRTRootNode;
                rtn.Name = "Sample Application Root Node";
                rtn.NodeID = 1;
            }
            else
            {
                rtn.NodeType = TaxBuilder.GraphicObjects.NavigationNodeTypeEnum.TARootNode;
                rtn.Name = "Sample Application Root Node";
                rtn.NodeID = 2;
            }
            rtn.ShowTaxFormSurface = false;

            return rtn;
        }

        public SortedList<int, RunTimeNode> GetRunTimeNodesChildren(RunTimeNode RunTimeNode)
        {
            SortedList<int, RunTimeNode> rtns = new SortedList<int, RunTimeNode>();
            switch (RunTimeNode.NodeID)
            { 
                case 1:
                    rtns.Add(1, GetRunTimeNode(3, NavigationNodeTypeEnum.PRTPageNode, new NSPRunTimePage(), 1));
                    rtns.Add(2, GetRunTimeNode(4, NavigationNodeTypeEnum.PRTPageNode, new NSPRunTimePage(), 2));
                    rtns.Add(3, GetRunTimeNode(5, NavigationNodeTypeEnum.PRTPageNode, new NSPRunTimePage(), 3));
                    rtns.Add(4, GetRunTimeNode(6, NavigationNodeTypeEnum.PRTPageNode, new NSPRunTimePage(), 4));
                    rtns.Add(5, GetRunTimeNode(7, NavigationNodeTypeEnum.PRTPageNode, new NSPRunTimePage(), 5));
                    break;
                case 2:
                    rtns.Add(1, GetRunTimeNode(8, NavigationNodeTypeEnum.TAOrganizerNode, new NSPRunTimeTAOrganizer(), 11));
                    rtns.Add(2, GetRunTimeNode(9, NavigationNodeTypeEnum.TAOrganizerNode, new NSPRunTimeTAOrganizer(), 12));
                    rtns.Add(3, GetRunTimeNode(10, NavigationNodeTypeEnum.TAOrganizerNode, new NSPRunTimeTAOrganizer(), 13));
                    rtns.Add(4, GetRunTimeNode(11, NavigationNodeTypeEnum.TAOrganizerNode, new NSPRunTimeTAOrganizer(), 14));
                    rtns.Add(5, GetRunTimeNode(12, NavigationNodeTypeEnum.TAOrganizerNode, new NSPRunTimeTAOrganizer(), 15));
                    break;
                default:
                    break;
            }
            return rtns;
        }
        private RunTimeNode GetRunTimeNode(int id, NavigationNodeTypeEnum type, NodeSetablePropertiesBase nsp, int pageid)
        {
            RunTimeNode rtn = new RunTimeNode();
            rtn.NodeID = id;
            rtn.NodeType = type;
            rtn.Name = "Node: " + id.ToString();
            rtn.HasChildren = false;
            rtn.ChildrenAlreadyLoaded = false;
            rtn.ImageIndex = 4;
            rtn.ShowTaxFormSurface = true;
            rtn.PageID = pageid;
            return rtn;
        }

        public RunTimePage GetPage(RunTimeNode RunTimeNode)
        {
            if (RunTimeNode.ShowTaxFormSurface)
            {
                //this is where the fun comes in - generate a runtimepage that is properly setup with a set of GraphicObjects
                RunTimePage rtp = new RunTimePage();
                rtp.PageID = RunTimeNode.PageID;
                rtp.PageProperties = new PageProperties();
                rtp.PageType = PageTypeEnum.Organizer;
                TextBoxGraphic tat = new TextBoxGraphic(10, 10, 200, 60);
                tat.Name = "Textbox1";
                tat.GraphicObjectID = 1001;                
                rtp.GraphicsCollection.Add(tat);

                GridGraphic gg = new GridGraphic(400, 10, 400, 400);
                gg.Name = "Grid";
                gg.GraphicObjectID = 2000;
                //TODO:setup grid
                rtp.GraphicsCollection.Add(gg);

                //TODO: add a drop down - and the DropDownGraphic's valueList (list<strings> needs to be set)
                return rtp;
            }
            else
                return null;
        }

        public System.Drawing.Image GetImage(int ImageID)
        {
            return null;
        }

        public Stack<int> GetParentNodeChainForPageID(int PageID)
        {
            Stack<int> list = new Stack<int>();
            return list;
        }
        //public ValueList GetValueListByID(int ValueListID)
        //{
        //    if (ValueListID == 1)
        //    {
        //        List<ValueItem> items = new List<ValueItem>();
        //        items.Add(new ValueItem("Red", "RedDescription"));
        //        items.Add(new ValueItem("Blue", "BlueDescription"));
        //        items.Add(new ValueItem("White", "WhiteDescription"));
        //        ValueList rtv = new ValueList("Colors", "RBW", 1, items);
        //        return rtv;
        //    }
        //    else if (ValueListID == 2)
        //    {
        //        List<ValueItem> items2 = new List<ValueItem>();
        //        items2.Add(new ValueItem("North", "NDescription"));
        //        items2.Add(new ValueItem("South", "SDescription"));
        //        items2.Add(new ValueItem("East", "EDescription"));
        //        items2.Add(new ValueItem("West", "WDescription"));
        //        ValueList rtv2 = new ValueList("Directions", "compass points", 2, items2);
        //        return rtv2;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        

        


        #endregion
    }
    namespace Tests
    {
        [TestFixture] public class TIAppInfoTests
        {
            [Test] public void ObjectCD()
            {
                UserConfigurationItems ucon = new UserConfigurationItems();
                TIApplicationInfo o = new TIApplicationInfo();
                Assert.IsNotNull(o);
                o.Initialize(ucon);
                List<string> apps = o.GetApplicationNamesCurrentlyAvailable();
                Assert.AreEqual(1, apps.Count);
                RunTimeNode prtn = o.GetApplicationRootRunTimeNode("Sample_Application", AppTypeEnum.Print, 2007);
                Assert.IsNotNull(prtn);
                Assert.IsNull(o.GetPage(prtn));
                SortedList<int, RunTimeNode> nodesP = o.GetRunTimeNodesChildren(prtn);
                Assert.IsNotNull(nodesP);
                RunTimePage rtp = o.GetPage(nodesP[1]);
                Assert.IsNotNull(rtp);
                RunTimeNode trtn = o.GetApplicationRootRunTimeNode("Sample_Application", AppTypeEnum.TaxApp, 2007);
                Assert.IsNotNull(trtn);
                SortedList<int, RunTimeNode> nodesT = o.GetRunTimeNodesChildren(trtn);
                Assert.IsNotNull(nodesT);

                System.Drawing.Image im = o.GetImage(1);
                Assert.IsNull(im);

                Stack<int> gg = o.GetParentNodeChainForPageID(1);
                Assert.IsNotNull(gg);

                KeyValuePair<int, int> g1 = new KeyValuePair<int, int>(1, 2);
                KeyValuePair<int, int> g2 = new KeyValuePair<int, int>(1, 2);
                Assert.AreEqual(g1, g2);

                

            }
        }
    }
}
