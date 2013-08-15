using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;
using System.Net;
using System.Drawing.Printing;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI.EventBroker;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.GraphicObjects;
using TaxApp.IntrinsicFunctions;
using Infragistics.Win.UltraWinTree;
using log4net;

namespace TestHarness.CABModule
{
    public class NavigationController : Controller
    {
        public new NavigationWorkItem WorkItem
        {
            get { return base.WorkItem as NavigationWorkItem; }
        }
        public static readonly ILog theLog = LogManager.GetLogger("NavigationController");

        [ServiceDependency]
        public ITaxAppInfo ApplicationInfoRetriever { set { myApplicationInfoRetriever = value; } }
        [ServiceDependency]
        public UserConfigurationItems UserConfiguration { set { myUserConfigurationItems = value; } }
        [ServiceDependency]
        public ITaxAppData LocatorImpl { set { myLocatorImpl = value; } }

        private ITaxAppInfo myApplicationInfoRetriever;
        private ITaxAppData myLocatorImpl;
        private UserConfigurationItems myUserConfigurationItems;
        private Dictionary<int, List<string>> myLoopNodeParentKeys = new Dictionary<int, List<string>>();

        private Random myRandom;

        public List<UltraTreeNode> GetApplications()
        {
            myRandom = new Random();

            List<UltraTreeNode> applicationNodes = new List<UltraTreeNode>();

            List<string> appNames = myApplicationInfoRetriever.GetApplicationNamesCurrentlyAvailable();
            foreach (string s in appNames)
            {
                UltraTreeNode utn = new UltraTreeNode(s, s);
                applicationNodes.Add(utn);
                AddPrintAndTaxAppNodes(utn);
            }
            return applicationNodes;

        }
        private void AddPrintAndTaxAppNodes(UltraTreeNode AppNode)
        {
            UltraTreeNode taxAppNode = new UltraTreeNode(AppNode.Text + "/TaxApp", "Tax App");
            taxAppNode.Override.NodeAppearance.Image = 24;
            RunTimeNode root = myApplicationInfoRetriever.GetApplicationRootRunTimeNode(AppNode.Text, AppTypeEnum.TaxApp, WorkItem.Year);
            UltraTreeNode taxAppRootNode = new UltraTreeNode(root.NodeID.ToString(), root.Name);
            taxAppRootNode.Tag = root;
            taxAppRootNode.Override.NodeAppearance.Image = root.ImageIndex;
            if (root.HasChildren)
            {
                taxAppRootNode.Nodes.Add(new UltraTreeNode("dummyfor" + root.NodeID, "dummy"));
            }
            taxAppNode.Nodes.Add(taxAppRootNode);

            UltraTreeNode printNode = new UltraTreeNode(AppNode.Text + "/Print", "Print");
            printNode.Override.NodeAppearance.Image = 25;
            RunTimeNode rootP = myApplicationInfoRetriever.GetApplicationRootRunTimeNode(AppNode.Text, AppTypeEnum.Print, WorkItem.Year);
            UltraTreeNode printRootNode = new UltraTreeNode(rootP.NodeID.ToString(), rootP.Name);
            printRootNode.Tag = rootP;
            printRootNode.Override.NodeAppearance.Image = rootP.ImageIndex;
            if (rootP.HasChildren)
            {
                printRootNode.Nodes.Add(new UltraTreeNode("dummyfor" + rootP.NodeID, "dummy"));
            }
            printNode.Nodes.Add(printRootNode);

            AppNode.Nodes.Add(taxAppNode);
            AppNode.Nodes.Add(printNode);
        }

        public void ProcessNewNodeEntry(NewEntryOnAGroupLoopNode nodeinfo, string treeNodeText)
        { 
            //make a new one of these records...
            IBaseType bt = myLocatorImpl.GetValueAsBaseType(nodeinfo.PageID, nodeinfo.GraphicID, nodeinfo.RecordLineage);
            if (nodeinfo.IsFirstEntry)
            {
                bt.SetValue(1, treeNodeText);
            }
            else
            {
                bt.SetValue(bt.Rows + 1, treeNodeText);
            }
            myLocatorImpl.SetBasetypeValue(nodeinfo.PageID, nodeinfo.GraphicID, bt, DataSourceEnum.DataEntry, nodeinfo.RecordLineage);

        }
        /// <summary>
        /// A null selectedNode should throw a null reference exception.
        /// </summary>
        /// <param name="refresh"></param>
        /// <param name="selectedNode"></param>
        public List<string> GetLoopParentNodesKeys(int nLoopRuntimeID)
        {
            if (this.myLoopNodeParentKeys.ContainsKey(nLoopRuntimeID))
                return this.myLoopNodeParentKeys[nLoopRuntimeID];
            else
                return null;
        }
        public List<UltraTreeNode> ProcessSelectedNode(UltraTreeNode selectedNode)
        {
            List<UltraTreeNode> children = new List<UltraTreeNode>();
            RunTimeNode ActiveRunTimeNode = (RunTimeNode)selectedNode.Tag;

            bool VisibleOnTree = true;
            if (ActiveRunTimeNode.NodeType == NavigationNodeTypeEnum.TATabbedPageNode)
            {
                VisibleOnTree = false;
            }
            SortedList<int, RunTimeNode> designedRTNs = myApplicationInfoRetriever.GetRunTimeNodesChildren(ActiveRunTimeNode);
            theLog.Debug("Application RTN Collection returned record count: " + designedRTNs.Count.ToString());
            SortedList<int, RunTimeNode> rtns = myLocatorImpl.ProcessRunTimeNodeCollection(ActiveRunTimeNode, designedRTNs);
            theLog.Debug("Process RTN Collection returned record count: " + rtns.Count.ToString());
            bool processingALoop = false;
            bool isFirstEntryInLoop = false;
            int lastRunTimegraphicID = 0;
            RunTimeNode lastRTN = null;
            foreach (RunTimeNode rtn in rtns.Values)
            {
                if (processingALoop && rtn.LoopRuntimeGraphicID != lastRunTimegraphicID)
                {
                    //add another node for data entry
                    children.Add(GetNewEntryNodeForAGroupLoopForSelectEdit(lastRTN, VisibleOnTree, isFirstEntryInLoop));
                    processingALoop = false;
                }
                string PageIDString = rtn.NodeID + "." + rtn.RecordLineage + "." + rtn.LoopRecordID;

                //string key = rtn.NodeID.ToString()+ "." + myRandom.NextDouble().ToString();
                rtn.Key = PageIDString;
                UltraTreeNode newnode = new UltraTreeNode(PageIDString, rtn.Name);
                newnode.Override.NodeAppearance.Image = rtn.ImageIndex;
                if (rtn.LoopRuntimeGraphicID > 0)
                {
                    newnode.Override.NodeAppearance.BackColor = myUserConfigurationItems.Looping_Node_Background_Color;
                    if (!processingALoop)
                    {
                        if (this.myLoopNodeParentKeys.ContainsKey(rtn.LoopRuntimeGraphicID))
                        {
                            if (!this.myLoopNodeParentKeys[rtn.LoopRuntimeGraphicID].Contains(selectedNode.Key))
                                this.myLoopNodeParentKeys[rtn.LoopRuntimeGraphicID].Add(selectedNode.Key);
                        }
                        else
                        {
                            List<string> parentNodeKeys = new List<string>();
                            parentNodeKeys.Add(selectedNode.Key);
                            this.myLoopNodeParentKeys.Add(rtn.LoopRuntimeGraphicID, parentNodeKeys);
                        }
                    }
                    processingALoop = true;
                    lastRunTimegraphicID = rtn.LoopRuntimeGraphicID;
                    lastRTN = rtn;
                }
                newnode.Visible = VisibleOnTree;
                newnode.Tag = rtn;
                SetDummyNode(newnode);
                //if it isn't enabled - don't put it in the tree - the disabled node helps signify that there's no entries...
                if (rtn.Enabled)
                {
                    children.Add(newnode);
                    //TODO: The node constraints need to be hooked up.
                    newnode.Enabled = myLocatorImpl.GetNodeConstraintIsThisNodeIDEnabled(rtn.NodeID);
                }
                else
                {
                    newnode.Enabled = false;
                    isFirstEntryInLoop = true;
                }
            }
            if (processingALoop)
            {
                //this is for the case when there are no other nodes after a looping node
                children.Add(GetNewEntryNodeForAGroupLoopForSelectEdit(lastRTN, VisibleOnTree, isFirstEntryInLoop));
                processingALoop = false;
                isFirstEntryInLoop = false;
            }
            ActiveRunTimeNode.ChildrenAlreadyLoaded = true;
            theLog.Debug("Returning " + children.Count + " Nodes");
            return children;

        }
        private UltraTreeNode GetNewEntryNodeForAGroupLoopForSelectEdit(RunTimeNode lastRTN, bool visible, bool isFirstEntry)
        {
            string strTypeName = lastRTN.Name;
            int nInd = strTypeName.IndexOf(": ");
            if (nInd != -1)
                strTypeName = strTypeName.Substring(0, nInd);
            string strNewEntryName = "<select to add a new " + strTypeName + " >";
            NewEntryOnAGroupLoopNode tagobject = new NewEntryOnAGroupLoopNode(lastRTN.LoopRuntimePageID, lastRTN.LoopRuntimeGraphicID, Convert.ToInt32(lastRTN.RecordLineage), strNewEntryName, isFirstEntry);
            UltraTreeNode newnodeforedit = new UltraTreeNode(myRandom.NextDouble().ToString(), tagobject.NodeName);
            newnodeforedit.Override.NodeAppearance.Image = tagobject.NodeImage;
            newnodeforedit.Override.NodeAppearance.BackColor = myUserConfigurationItems.Looping_Node_New_Entry_Background_Color;
            newnodeforedit.Tag = tagobject;
            newnodeforedit.Visible = visible;
            return newnodeforedit;
        }
        private void SetDummyNode(UltraTreeNode node)
        {
            if (((RunTimeNode)node.Tag).HasChildren)
            {
                node.Nodes.Add("dummy node" + myRandom.NextDouble().ToString(), "dummy");
            }
        }

        public Stack<int> GetRecordLineageChainParentOnTop(TBLinkClickedEventArg e)
        {
            //TODO: refactor this code, or at least diagram the possibilities in a chart somewhere.
            theLog.Debug(string.Format("Link Clicked: LinkedPageID:{0} LinkedGraphicID:{1} RL:{2} IsDetail:{3} GraphicIDOfColumn:{4} PageIDofGraphic:{5} RowIndex:{6}",
                e.LinkedPageID, e.LinkedGraphicID, e.RecordLineage, e.IsDetail, e.GraphicIDOfColumn, e.PageIDOfGraphic, e.RowIndex));

            

            Stack<int> recordLineageChainParentOnTop = new Stack<int>();
            if (e.IsDetail)
            {
                //need to get the RecordID of the Row that is the binding column graphic...
                int DetailRecordID = myLocatorImpl.GetRecordIDForThisGraphicByDisplayOrder(e.PageIDOfGraphic, e.GraphicIDOfColumn, e.RecordLineage, e.RowIndex+1);
                recordLineageChainParentOnTop.Push(DetailRecordID);
            }

            //The RecordLineage is needed to keep the links in the same relative group.  But of course the RecordLineage passed in isn't necessarily the one that matches the parent...

            if (e.RecordLineage != 0)
            {
                recordLineageChainParentOnTop.Push(e.RecordLineage); //the "last one is the one sent in - might be of the page, or an individual row in a grid - going to detail
                int parentID = myLocatorImpl.GetRecordLineageForThisRecordID(e.RecordLineage);
                while (parentID != 0)
                {
                    recordLineageChainParentOnTop.Push(parentID);
                    parentID = myLocatorImpl.GetRecordLineageForThisRecordID(parentID);
                }
            }
            return recordLineageChainParentOnTop;
            
        }
        public Stack<int> GetParentNodeIDs(int LinkedPageID)
        { 
            return myApplicationInfoRetriever.GetParentNodeChainForPageID(LinkedPageID);
        }

    }
}