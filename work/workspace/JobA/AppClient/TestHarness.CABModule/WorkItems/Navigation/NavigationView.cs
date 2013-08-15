using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Printing;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Collections;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.ObjectBuilder;
using Thomson.CompositeUI.WinForms.Services;
using Thomson.CompositeUI.WinForms;
using Thomson.CompositeUI.Commands;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinStatusBar;
using TaxApp.InterfacesAndConstants;
using log4net;
using Infragistics.Win.UltraWinTree;
using TaxBuilder.GraphicObjects;

namespace TestHarness.CABModule
{
    /// <summary>
    /// The view used to display the navigation tree of a print data file.
    /// Upon loading, the view will spawn a background thread to retrieve and 
    /// populate the navigation tree.
    /// </summary>
    [SmartPart]
    public partial class NavigationView : UserControl
    {
        public static readonly ILog theLog = LogManager.GetLogger("NavigationView");
        private NavigationWorkItem myWorkItem;
        private NavigationController myController;
        private StatusBarService myStatusBarService;
        private BackgroundWorker onLoadWorker;
        private List<RunTimeNode> myNodeInfos = new List<RunTimeNode>();
        private UltraTreeNode myExpandingNode;

        public NavigationView()
        {
            InitializeComponent();

            UltraTreeNavigation.ImageList = this.imageList1;
            UltraTreeNavigation.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(UltraTreeNavigation_AfterSelect);
            UltraTreeNavigation.BeforeExpand += new BeforeNodeChangedEventHandler(UltraTreeNavigation_BeforeExpand);
            UltraTreeNavigation.AfterLabelEdit += new AfterNodeChangedEventHandler(UltraTreeNavigation_AfterLabelEdit);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            
            // Context Menu - tools setup in the MainWorkItem are bound here to the tree.
            UltraMainMenuManagerService svc = myWorkItem.RootWorkItem.Services.Get<UltraMainMenuManagerService>();
            svc.ShellManager.SetContextMenuUltra(this.UltraTreeNavigation , Constants.Tools.NavTreeContextMenuKey);

            GetNodeAsync(null);
        }

        [CreateNew]
        public NavigationController Controller
        {
            get { return myController; }
            set { myController = value; }
        }
        [ServiceDependency]
        public StatusBarService StatusBarService
        {
            set { myStatusBarService = value; }
        }
        [Dependency]
        public NavigationWorkItem WorkItem
        {
            get { return myWorkItem; }
            set { myWorkItem = value; }
        }
        public string LocatorName
        {
            get { return (string)myWorkItem.State[Constants.State.LocatorName ]; }
            set { myWorkItem.State[Constants.State.LocatorName] = value; }
        }

        public UltraTreeNode SelectedNode
        {
            get 
            {
                if (UltraTreeNavigation.SelectedNodes.Count > 0)
                {
                    UltraTreeNavigation.ActiveNode = UltraTreeNavigation.SelectedNodes[0];
                    return UltraTreeNavigation.ActiveNode;
                }
                else
                    return null;
            }
            set 
            {
                UltraTreeNavigation.AfterSelect -= UltraTreeNavigation_AfterSelect;
                UltraTreeNavigation.SelectedNodes.Clear();
                value.Selected = true;
                UltraTreeNavigation.ActiveNode = value;
                UltraTreeNavigation.AfterSelect +=new AfterNodeSelectEventHandler(UltraTreeNavigation_AfterSelect);
            }
        }
        [EventSubscription("topic://LinkClicked")]
        public void SelectPageByLinkClicked(object sender, DataEventArgs<TBLinkClickedEventArg> e)
        {
            try
            {
                Stack<int> recordLineageChainParentOnTop = myController.GetRecordLineageChainParentOnTop(e.Data);
                if (recordLineageChainParentOnTop.Count == 0)
                {
                    theLog.Debug("No recordLineage returned from GetRecordLineageChainParentOnTop in NavigationController");
                }
                Stack<int> parentNodes = myController.GetParentNodeIDs(e.Data.LinkedPageID);
                if (parentNodes.Count == 0)
                {
                    theLog.Warn("No parent nodes returned from GetParentNodeIDs in Navigation Controller");
                    return;
                }

                UltraTreeNode rootnode = UltraTreeNavigation.GetNodeByKey(parentNodes.Pop().ToString());
                UltraTreeNavigation.SelectedNodes.Clear();
                UltraTreeNavigation.ActiveNode = rootnode;
                bool parentisTabbedPage = false;
                int recordLineageID = 0;
                if (recordLineageChainParentOnTop.Count > 0)
                {
                    recordLineageID = recordLineageChainParentOnTop.Pop();
                }
                //disable the before expand event so it doesn't try to load the tree.
                UltraTreeNavigation.BeforeExpand -= UltraTreeNavigation_BeforeExpand;
                do
                {
                    int nodeid = parentNodes.Pop();
                    int displayInd = 0;
                    foreach (UltraTreeNode childnode in UltraTreeNavigation.ActiveNode.Nodes)
                    {
                        if (childnode.Tag.GetType() == typeof(RunTimeNode))
                        {
                            if (((RunTimeNode)childnode.Tag).NodeID == nodeid & !parentisTabbedPage)
                            {
                                if (((RunTimeNode)childnode.Tag).LoopRecordID != 0)
                                {
                                    if (recordLineageID != 0)
                                    {
                                        if (((RunTimeNode)childnode.Tag).LoopRecordID != recordLineageID)
                                            continue;
                                    }
                                    else
                                    {
                                        if (displayInd != e.Data.RowIndex)
                                        {
                                            displayInd++;
                                            continue;
                                        }
                                    }
                                    //set to the next one as this is the correct node and will be selected
                                    if (recordLineageChainParentOnTop.Count > 0)
                                        recordLineageID = recordLineageChainParentOnTop.Pop();
                                    else
                                        recordLineageID = 0;
                                }
                                //this is the right one - select it and proceed to the next one if it exists.
                                UltraTreeNavigation.ActiveNode = childnode;
                                if (childnode.Nodes.Count != 0 && childnode.Nodes[0].Tag == null)
                                {
                                    childnode.Nodes.Clear();
                                    List<UltraTreeNode> childNodes = Controller.ProcessSelectedNode(childnode);
                                    foreach (UltraTreeNode utn in childNodes)
                                    {
                                        childnode.Nodes.Add(utn);
                                    }
                                }

                                if (((RunTimeNode)childnode.Tag).NodeType == NavigationNodeTypeEnum.TATabbedPageNode)
                                {
                                    parentisTabbedPage = true;
                                    UltraTreeNavigation.ActiveNode.Selected = true;
                                    int throwaway = parentNodes.Pop();
                                }
                                if (!UltraTreeNavigation.ActiveNode.Expanded)
                                {
                                    UltraTreeNavigation.ActiveNode.Toggle();
                                }
                                break;
                            }
                        }
                    }
                } while (parentNodes.Count > 0);

                UltraTreeNavigation.BeforeExpand += new BeforeNodeChangedEventHandler(UltraTreeNavigation_BeforeExpand);

                UltraTreeNavigation.ActiveNode.Selected = true;
                myWorkItem.SelectGraphic(e.Data.LinkedPageID, e.Data.LinkedGraphicID);
            }
            catch (Exception ex)
            {
                theLog.Error("Error processing link. ", ex);
                throw ex;
            }
        }
        [EventSubscription("topic://LoopDataUpdated")]
        public void ReLoadLoopNodes(object sender, DataEventArgs<int> e)
        {
            List<string> parentNodeKeys = myController.GetLoopParentNodesKeys(e.Data);
            if (parentNodeKeys == null)
                return;

            //save the current selected node
            string currentSelNodeKey = string.Empty;
            if (UltraTreeNavigation.SelectedNodes.Count > 0)
                currentSelNodeKey = UltraTreeNavigation.SelectedNodes[0].Key;

            foreach (string parentNodeKey in parentNodeKeys)
            {
                UltraTreeNode parentNode = UltraTreeNavigation.GetNodeByKey(parentNodeKey);
                if (parentNode != null)
                {
                    List<UltraTreeNode> nodes = myController.ProcessSelectedNode(parentNode);
                    parentNode.Nodes.Clear();
                    foreach (UltraTreeNode node in nodes)
                        parentNode.Nodes.Add(node);
                }
            }
            //select the orginal node
            if (currentSelNodeKey != string.Empty)
            {
                UltraTreeNavigation.SelectedNodes.Clear();
                UltraTreeNode origNode = UltraTreeNavigation.GetNodeByKey(currentSelNodeKey);
                if (origNode != null)
                {
                    UltraTreeNavigation.ActiveNode = origNode;
                    UltraTreeNavigation.ActiveNode.Selected = true;
                }
            }
            //close the pages if the opened pages have been removed as the result of deleting the ancestor node
            this.WorkItem.CloseDeletedPages();
        }
        public bool IsPageValid(string nodeKey)
        {
            UltraTreeNode node = UltraTreeNavigation.GetNodeByKey(nodeKey);
            return (node != null);
        }
        /// <summary>
        /// Selects the specified TreeNode and ensures its' visibility without 
        /// triggering a new PageWorkItem.
        /// </summary>
        /// <param name="Node">The TreeNode to select.</param>
        public void EnsureNodeVisible(string NodeKey)
        {
            if (NodeKey != string.Empty)
            {
                try
                {
                    theLog.Debug("Ensure Node Visible: NodeKey: (NodeID/RecordLineage/RecordID): " + NodeKey);
                    UltraTreeNode utn = UltraTreeNavigation.GetNodeByKey(NodeKey);
                    if (utn != null)
                    {
                        utn.Visible = true;
                        utn.Selected = true;
                    }
                    else
                    {
                        theLog.Warn("Node key not found during EnsureNodeVisible call.  NodeKey: " + NodeKey);
                    }
                }
                catch (Exception ex)
                {
                    theLog.Error("Error ensuring node visibility", ex);
                }
            }
        }
        /// <summary>
        /// Sets the status for command UI elements which have state
        /// based on checked nodes and the currently selected node.
        /// </summary>
        public void SetCommandStatus()
        {
            ManagedObjectCollection<Command> Commands = WorkItem.Parent.Commands;
            Commands[Constants.Tools.FullCompute].Status = CommandStatus.Enabled;
        }
        #region Navigation Tree Retrieving Background Worker
        void onLoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                System.Threading.Thread.CurrentThread.Name = "onLoadWorker";
                if (worker != null && worker == onLoadWorker)
                {
                    myStatusBarService.SetStatusText("Getting navigation tree...");
                    if (e.Argument == null)
                    {
                        e.Result = myController.GetApplications();
                    }
                    else
                    {
                        e.Result = myController.ProcessSelectedNode((UltraTreeNode)e.Argument);
                    }
                }
            }
            catch (Exception ex)
            {
                theLog.Error("Error processing selected node", ex);
            }
        }
        void onLoadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (e.Error != null)
            {
                theLog.Error("Error processing Navigation Tree: ", e.Error);
                myStatusBarService.SetStatusText("Error getting node");
                myWorkItem.Terminate();
            }
            else if (e.Cancelled)
            {
                theLog.Info("Navigation retrieval cancelled by user");
                myStatusBarService.SetStatusText("Ready");
            }
            else
            {
                try
                {
                    if (e.Result != null)
                    {
                        if (null != myExpandingNode)
                        {
                            myExpandingNode.Nodes.Clear();
                            UltraTreeNavigation.Refresh();
                            List<UltraTreeNode> nodes = (List<UltraTreeNode>)e.Result;
                            foreach (UltraTreeNode utn in nodes)
                            {
                                myExpandingNode.Nodes.Add(utn);
                            }
                        }
                        else  //this is the first time in - loading up the applications
                        {
                            ultraLabelLoading.Text = "Updating display...";
                            
                            Cursor saveCursor = Cursor;
                            Cursor = Cursors.WaitCursor;
                            myStatusBarService.SetStatusText("Updating Display");
                            Application.DoEvents();

                            List<UltraTreeNode> nodes = (List<UltraTreeNode>)e.Result;
                            foreach (UltraTreeNode utn in nodes)
                            {
                                try
                                {
                                    UltraTreeNavigation.Nodes.Add(utn);
                                }
                                catch (ArgumentException aex)
                                {
                                    theLog.Error("Argument exception adding node to TreeNavigation.  Possible duplicate key. ", aex);
                                }
                            }
                            theLog.Info(nodes.Count.ToString() + " applications found and loaded.");
                            this.UltraTreeNavigation.Visible = true;
                            ultraLabelLoading.Visible = false;
                            Cursor = saveCursor;
                        }
                    }
                }
                catch (Exception ex)
                {
                    theLog.Error("Error processing returned tree", ex);
                    myWorkItem.Terminate();
                }
            }

            if (worker != null)
            {
                worker.Dispose();
            }

            myStatusBarService.SetStatusText("Ready");
            UltraTreeNavigation.Refresh();
            Cursor.Current = Cursors.Default;
        }

        void GetNodeAsync(UltraTreeNode node)
        {
            if (onLoadWorker == null)
            {
                onLoadWorker = new BackgroundWorker();
                onLoadWorker.DoWork += new DoWorkEventHandler(onLoadWorker_DoWork);
                onLoadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(onLoadWorker_RunWorkerCompleted);
            }
            onLoadWorker.RunWorkerAsync(node);
        }
        

        #endregion Navigation Tree Retrieving Background Worker
        

        void UltraTreeNavigation_BeforeExpand(object sender, CancelableNodeEventArgs e)
        {
            if (e.TreeNode.Text == "Loading...")
            {
                return;
            }
            
            Cursor incomingCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            myExpandingNode = e.TreeNode;
            
            if (myExpandingNode.Tag != null & myExpandingNode.Nodes.Count > 0)
            {
                myStatusBarService.SetStatusText("Expanding Node...");
                if (myExpandingNode.Nodes.Count != 1)
                {
                    myExpandingNode.Nodes.Clear();
                    myExpandingNode.Nodes.Add("dummy", "Loading...");
                }
                else
                {
                    myExpandingNode.Nodes[0].Text = "Loading...";
                }
                GetNodeAsync(myExpandingNode);
            }
            else if (myExpandingNode.Level == 0)
            {
                foreach (UltraTreeNode subnode1 in myExpandingNode.Nodes)
                {
                    subnode1.Expanded = true;
                }
            }
 
            Cursor.Current = incomingCursor;
        }
        void UltraTreeNavigation_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            theLog.Debug("EVENT_Begin:  NavigationView.AfterSelect");
            Cursor incomingCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if (e.NewSelections.Count == 1)
            {
                if (e.NewSelections[0].Text == "Loading...")
                {
                    UltraTreeNavigation.SelectedNodes.Clear();

                }
                UltraTreeNode selNode = (UltraTreeNode)e.NewSelections[0];
                if (selNode.Tag != null)
                {
                    if (selNode.Tag.GetType() == typeof(NewEntryOnAGroupLoopNode))
                    {
                        selNode.Text = "";
                        UltraTreeNavigation.Refresh();
                        selNode.BeginEdit();
                        return;
                    }
                    //this will catch all but TabbedPageNodes - which do not show tax form surfaces
                    if (((RunTimeNode)selNode.Tag).ShowTaxFormSurface)
                    {
                        myWorkItem.ShowPage(selNode);
                    }
                    if (((RunTimeNode)selNode.Tag).NodeType == NavigationNodeTypeEnum.TATabbedPageNode)
                    {
                        if (!((RunTimeNode)selNode.Tag).ChildrenAlreadyLoaded)
                        {
                            List<UltraTreeNode> nodes = myController.ProcessSelectedNode(selNode);
                            selNode.Nodes.Clear();
                            foreach (UltraTreeNode node in nodes)
                            {
                                selNode.Nodes.Add(node);
                            }
                        }
                        myWorkItem.ShowPage(selNode);
                    }
                }
            }
            ((MainWorkItem)myWorkItem.Parent).SetCommandStatus();
            SetCommandStatus();
            Cursor.Current = incomingCursor;


            theLog.Debug("EVENT_End:  NavigationView.AfterSelect");
        }
        void UltraTreeNavigation_AfterLabelEdit(object sender, NodeEventArgs e)
        {
            theLog.Debug("EVENT_Begin:  NavigationView.AfterLabelEdit");
            if (e.TreeNode.Text.Trim() == string.Empty)
            {
                //set back the original text
                e.TreeNode.Text = ((NewEntryOnAGroupLoopNode)e.TreeNode.Tag).NodeName;
                return;
            }

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            NewEntryOnAGroupLoopNode nodeinfo = (NewEntryOnAGroupLoopNode)e.TreeNode.Tag;
            myController.ProcessNewNodeEntry(nodeinfo, e.TreeNode.Text);

            UltraTreeNode parentNode = UltraTreeNavigation.SelectedNodes[0].Parent;
            List<UltraTreeNode> nodes = myController.ProcessSelectedNode(parentNode);
            parentNode.Nodes.Clear();
            foreach (UltraTreeNode node in nodes)
                parentNode.Nodes.Add(node);

            //if the page has the graphic object that runtime id is this loop id, need to reload the data of the graphic object
            this.WorkItem.RefreshLoopGraphicObjectData(nodeinfo.GraphicID);

            Cursor.Current = currentCursor;
            theLog.Debug("EVENT_End:  NavigationView.AfterLabelEdit");
        }

        private void UltraTreeNavigation_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (theLog.IsDebugEnabled)
                {
                    if (UltraTreeNavigation.SelectedNodes.Count > 0)
                    {
                        RunTimeNode rtn = (RunTimeNode)UltraTreeNavigation.SelectedNodes[0].Tag;
                        theLog.Debug(string.Format("Debug Mouse Over Info. NodeID: {0}  PageID: {1}  RecordLineage: {2}  LoopRecordID: {3}  Key: {4}", rtn.NodeID, rtn.PageID, rtn.RecordLineage, rtn.LoopRecordID, rtn.Key));
                    }
                }
            }
            catch (Exception)
            { 
                //throw this one away - not sure why it would ever fail, but it does sometimes...
            }

        }

        private void UltraTreeNavigation_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        //TODO: Brian:  Lineage Selector
        // private void SetLineageSelectorToolbar(UltraTreeNode nodeOnTree)
        //{ 
        //    UltraToolbar lineageToolbar = this.ultraToolbarsManager1.Toolbars["LineageSelector"];
        //    lineageToolbar.Tools.Clear();
        //    int RecordLineage = GetRecordLineage(nodeOnTree);
        //    if (RecordLineage == 0)
        //    {
        //        lineageToolbar.Visible = false;
        //        return;
        //    }
        //    Stack<int> stackofRecordLineages = new Stack<int>();
        //    UltraTreeNode currentNode = nodeOnTree;
        //    do
        //    {
        //        stackofRecordLineages.Push(RecordLineage);
        //        do
        //        {
        //            currentNode = currentNode.Parent;
        //        } while (((RunTimeNode)currentNode.Tag).LoopRecordID == RecordLineage);
        //        RecordLineage = GetRecordLineage(currentNode);
        //    } while (RecordLineage != 0);

        //    int i = 0;
        //    int countOfLevels = stackofRecordLineages.Count;
        //    do
        //    {
        //        int RecordID = (int)stackofRecordLineages.Pop();
        //        ComboBoxTool dropdown = null;
        //        try
        //        {
        //            dropdown = (ComboBoxTool)this.ultraToolbarsManager1.Tools["LineageSelector:" + i.ToString()];
        //        }
        //        catch { }
        //        if (dropdown == null)
        //        { 
        //            dropdown = new ComboBoxTool("LineageSelector:" + i.ToString());
        //            dropdown.ToolValueChanged += new ToolEventHandler(dropdown_ToolValueChanged);
        //            dropdown.AfterToolCloseup += new ToolDropdownEventHandler(dropdown_AfterToolCloseup);
        //            ultraToolbarsManager1.Tools.Add(dropdown);
        //        }
        //        IDictionary<int, string> list = myLocatorImpl.GetSetofRecordIDandValueForSameGraphicAndLineage(RecordID);
        //        Infragistics.Win.ValueList valueL = new Infragistics.Win.ValueList();
        //        string selectedText = string.Empty;
        //        int j = 0;
        //        int rowindex = 0;
        //        foreach (KeyValuePair<int, string> items in list)
        //        {
        //            Infragistics.Win.ValueListItem vi = new Infragistics.Win.ValueListItem();
        //            vi.DisplayText = items.Value;
        //            vi.DataValue = items.Key;
        //            valueL.ValueListItems.Add(vi);
        //            if (items.Key == RecordID)
        //            {
        //                rowindex = j;
        //            }
        //            j++;
        //        }
        //        mySettingDropDownToolValueForLineage = true;
        //        dropdown.ValueList = valueL;
        //        dropdown.SelectedIndex = rowindex;
        //        mySettingDropDownToolValueForLineage = false;
        //        lineageToolbar.Tools.AddTool("LineageSelector:" + i.ToString());
        //        i++;
        //    } while (stackofRecordLineages.Count > 0);

        //    if (lineageToolbar.Tools.Count == 0)
        //    {
        //        lineageToolbar.Visible = false;
        //    }
        //    else
        //    {
        //        lineageToolbar.Visible = true;
        //    }
        //}
    
    }
}
