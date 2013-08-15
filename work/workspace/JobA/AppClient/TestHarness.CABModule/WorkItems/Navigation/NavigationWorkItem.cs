using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.IO;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Utility;
using Thomson.CompositeUI.WinForms;
using Thomson.CompositeUI.WinForms.Services;
using Thomson.CompositeUI.WinForms.Controls;
using TaxApp.InterfacesAndConstants;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using log4net;
using System.Threading;
using System.ComponentModel;


namespace TestHarness.CABModule
{
    public class NavigationWorkItem : WorkItem
    {
        private IWorkspace mySidebarWorkspace;
        private IWorkspace myContentWorkspace;
        private NavigationView myNavigationView = null;
        private UserConfigurationItems myUserConfigOptions;
        private ITaxAppInfo myAppInfo;
        private ITaxAppData myLocatorImpl;
        private StatusBarService myStatusBarService;

        private IProgressDisplayer myProgressDisplay;
        private BackgroundWorker myFullCalcBackgroundWorker;

        [ServiceDependency]
        public UserConfigurationItems UserConfigOptions { set { myUserConfigOptions = value; } }
        [ServiceDependency]
        public ITaxAppInfo ApplicationInfoRetriever { set { myAppInfo = value; } }
        [ServiceDependency]
        public StatusBarService StatusBarService
        {
            set { myStatusBarService = value; }
        }

        [EventPublication("topic://FullComputeCompleted", PublicationScope.Descendants)]
        public event EventHandler<DataEventArgs<string>> FullComputeCompleted;

        private int myLocatorID;
        private string myLocatorName;
        private short myYear;

        public int LocatorID { get { return myLocatorID; } }
        public string LocatorName { get { return myLocatorName; } }
        public short Year { get { return myYear; } }

        public static readonly ILog theLog = LogManager.GetLogger("NavigationWorkItem");
        protected override void OnRunStarted()
        {
            theLog.Debug("Navigation Work Item Started");
            base.OnRunStarted();
            mySidebarWorkspace = Workspaces[ShellConstants.Workspaces.SIDEBAR];
            myContentWorkspace = Workspaces[ShellConstants.Workspaces.CONTENT];

            myLocatorID = Convert.ToInt32(this.State[Constants.State.LocatorID]);
            myLocatorName = this.State[Constants.State.LocatorName].ToString();
            myYear = Convert.ToInt16(this.State[Constants.State.Year]);
            
            
            //add the ITaxAppData for this particular Navigation tree- there should be multiple LocatorImpl's per LocatorID
            string DLLNameForTaxAppData = string.Empty;
            try
            {
                DLLNameForTaxAppData = ConfigurationManager.AppSettings["ITaxAppData.AssemblyFileName"];
            }
            catch (Exception ex)
            {
                theLog.Error("Error finding ITaxAppData information in App.Config file", ex);
                throw ex;
            }

            theLog.Debug("ITaxAppData configuration settings loaded from app.config.  Attempting load of dll.");
            string currentDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
            Assembly assemblyTAD = null;
            try
            {
                assemblyTAD = Assembly.LoadFile(Path.Combine(currentDir, DLLNameForTaxAppData));
            }
            catch (Exception ex)
            {
                theLog.Error("Error Loading ITaxAppData assembly.  ", ex);
                throw ex;
            }

            try
            {
                foreach (Type t in assemblyTAD.GetTypes())
                {
                    if (t.GetInterface("ITaxAppData", true) != null)
                    {
                        myLocatorImpl = (ITaxAppData)(assemblyTAD.CreateInstance(t.FullName, false, BindingFlags.CreateInstance, null, null, null, null));
                        myLocatorImpl.PageUpdatedEvent += new PageUpdatedEventHandler(myLocatorImpl_PageUpdatedEvent);

                        break;
                    }
                }
                if (myLocatorImpl != null)
                {
                    myLocatorImpl.Initialize(myLocatorName, myLocatorID, myYear, myUserConfigOptions);
                    this.Services.Add<TaxApp.InterfacesAndConstants.ITaxAppData>(myLocatorImpl);
                }
                else
                {
                    theLog.Error("ITaxAppData implementor not found in dll");
                }
            }
            catch (Exception ex)
            {
                theLog.Error("Error loading ITaxAppData class.  ", ex);
            }

            myNavigationView = Items.AddNew<NavigationView>();
            RIASmartPartInfo info = new RIASmartPartInfo();

            info.Title = myLocatorName;
            info.Image = Images.OpenFolder;
            info.Description = "The application tree of folders, organizers, workpapers, and tax forms.";
            mySidebarWorkspace.Show(myNavigationView, info);

            // Subscribe to the IWorkSpace.SmartPartActivated events
            // in order to implement syncronizing views.
            mySidebarWorkspace.SmartPartActivated += new EventHandler<WorkspaceEventArgs>(mySidebarWorkspace_SmartPartActivated);
            myContentWorkspace.SmartPartActivated += new EventHandler<WorkspaceEventArgs>(contentWorkspace_SmartPartActivated);

            myFullCalcBackgroundWorker = new BackgroundWorker();
            myFullCalcBackgroundWorker.WorkerSupportsCancellation = true;
            myFullCalcBackgroundWorker.DoWork += new DoWorkEventHandler(myFullCalcBackgroundWorker_DoWork);
            myFullCalcBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myFullCalcBackgroundWorker_RunWorkerCompleted);
        }

        void myLocatorImpl_PageUpdatedEvent(object sender, List<int> pageIDs)
        {
            theLog.Debug("Page Updated Event bubbled to Navigation Work Itme");
            foreach (PageView pv in myContentWorkspace.SmartParts)
            {
                foreach (RunTimeNode rtn in ((PageWorkItem)pv.WorkItem).RunTimeNodes)
                { 
                    if (pageIDs.Contains(rtn.PageID))
                        pv.RefreshLoopGraphicObjectData(0);
                }
            }
        }


        #region BackGround Worker:  Full Compute Code
        /// <summary>
        /// Asks this workitem to perform a full compute of its locator database.  This will display a Progress bar and should be cancelable.
        /// although I'm not sure about how to do progress at this point maybe just a timer to update it periodically?
        /// 
        /// Also, this is calling directly into the locatorimpl - shouldn't this in theory be calling the controller to do this work (which would call the locatorImpl...)
        /// </summary>
        public void RunFullComputeAsync()
        {
            myProgressDisplay = myStatusBarService.ShowProgressPanel("Full Compute", "Computing...", true);
            myProgressDisplay.SetPercentageComplete(5);
            myProgressDisplay.Cancel += new EventHandler(myProgressDisplay_Cancel);
            myFullCalcBackgroundWorker.RunWorkerAsync();
        }
       void myFullCalcBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (e.Error != null)
            {
                theLog.Error("Error performing full compute: ", e.Error);
            }
            else if (e.Cancelled)
            {
                theLog.Info("Navigation retrieval cancelled by user");
            }
            else
            {
                myProgressDisplay.Cancel -= myProgressDisplay_Cancel;
                myStatusBarService.RemoveProgressPanel(myProgressDisplay);
                myStatusBarService.TextPanel.Text = "Compute complete";
                theLog.Info("Compute process exiting...");
                FullComputeCompleted(this, new DataEventArgs<string>("Complete"));
            }
        }

        void myFullCalcBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            System.Threading.Thread.CurrentThread.Name = "FullComputeWorker";
            if (worker != null && worker == myFullCalcBackgroundWorker)
            {
                myStatusBarService.SetStatusText("Running full compute...");
                myLocatorImpl.PerformFullCompute();
            }
        }
        

        void myProgressDisplay_Cancel(object sender, EventArgs e)
        {
            theLog.Info("User cancelled compute");
            myFullCalcBackgroundWorker.CancelAsync();
        }
        #endregion BackGround Worker:  Full Compute Code
       

        /// <summary>
        /// Handles the event to syncronize views.
        /// </summary>
        void mySidebarWorkspace_SmartPartActivated(object sender, WorkspaceEventArgs e)
        {
            if (e.SmartPart as NavigationView == myNavigationView)
            {
                if (myNavigationView.SelectedNode != null)
                {
                    if (myNavigationView.SelectedNode.Tag != null)
                    {
                        if (((RunTimeNode)myNavigationView.SelectedNode.Tag).ShowTaxFormSurface)
                        {
                            ShowPage(myNavigationView.SelectedNode);
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// Event handler for when the user changes tabs in the content workspace.
        /// This handler is used to syncronize the navigation and page views.
        /// </summary>
        void contentWorkspace_SmartPartActivated(object sender, WorkspaceEventArgs e)
        {
            PageView view = e.SmartPart as PageView;
            if (view != null && view.WorkItem.Parent == this)
            {
                mySidebarWorkspace.SmartPartActivated -= mySidebarWorkspace_SmartPartActivated;
                mySidebarWorkspace.Show(myNavigationView);
                myNavigationView.EnsureNodeVisible(view.WorkItem.State[Constants.State.NodeKey].ToString());
                mySidebarWorkspace.SmartPartActivated += new EventHandler<WorkspaceEventArgs>(mySidebarWorkspace_SmartPartActivated);
            }
        }

        /// <summary>
        /// This will try to find the graphic id in the current smart part
        /// </summary>
        /// <param name="GraphicID"></param>
        public void SelectGraphic(int PageID, int GraphicID)
        {
            PageView pageView = myContentWorkspace.ActiveSmartPart as PageView;
            if (pageView != null)
            {
                pageView.Focus();
                pageView.SelectGraphic(PageID, GraphicID);
            }
        }


        /// <summary>
        /// Shows an existing or creates a new PageWorkItem for display in the Shell's content workspace.
        /// </summary>
        /// <param name="node">The <see cref="TreeNode"/> representing the page to show.</param>
        public void ShowPage(UltraTreeNode node)
        {
            if (null == node)
                return;

            PageView pageView = myContentWorkspace.ActiveSmartPart as PageView;

            string PageIDString = ((RunTimeNode)node.Tag).NodeID + "." + ((RunTimeNode)node.Tag).RecordLineage + "." + ((RunTimeNode)node.Tag).LoopRecordID;
            theLog.Debug("Showing page: NodeID.RecordLineage.LoopRecordID: " + PageIDString);
            PageWorkItem pageWorkItem = WorkItems.Get<PageWorkItem>(PageIDString);

            if (pageWorkItem == null)
            {
                if (((RunTimeNode)node.Tag).NodeType == TaxBuilder.GraphicObjects.NavigationNodeTypeEnum.TATabbedPageNode)
                {
                    try
                    {
                        pageWorkItem = WorkItems.AddNew<PageWorkItem>(PageIDString);
                        List<RunTimeNode> RTNodes = new List<RunTimeNode>();
                        foreach (UltraTreeNode childNode in node.Nodes)
                        {
                            RTNodes.Add((RunTimeNode)childNode.Tag);
                        }
                        pageWorkItem.State[Constants.State.RunTimeNodes] = RTNodes;
                        pageWorkItem.State[Constants.State.PageName] = ((RunTimeNode)node.Tag).Name;
                        //TODO: Add description to RunTimeNodes...
                        pageWorkItem.State[Constants.State.PageDescription] = ((RunTimeNode)node.Tag).ApplicationName;
                        pageWorkItem.State[Constants.State.NodeKey] = PageIDString;
                        pageWorkItem.Run();
                    }
                    catch (Exception ex)
                    {
                        theLog.Error("Show page call", ex);
                    }
                }
                else
                {
                    try
                    {
                        pageWorkItem = WorkItems.AddNew<PageWorkItem>(PageIDString);
                        List<RunTimeNode> RTNodes = new List<RunTimeNode>();
                        RTNodes.Add((RunTimeNode)node.Tag);
                        pageWorkItem.State[Constants.State.RunTimeNodes] = RTNodes;
                        pageWorkItem.State[Constants.State.PageName] = ((RunTimeNode)node.Tag).Name;
                        //TODO: Add description to RunTimeNodes...
                        pageWorkItem.State[Constants.State.PageDescription] = ((RunTimeNode)node.Tag).ApplicationName;
                        pageWorkItem.State[Constants.State.NodeKey] = PageIDString;
                        pageWorkItem.Run();
                    }
                    catch (Exception ex)
                    {
                        theLog.Error("Show page call", ex);
                    }
                }
            }
            pageWorkItem.Show(myContentWorkspace);
        }
        public void RefreshLoopGraphicObjectData(int graphicID)
        {
            foreach (PageView pageView in myContentWorkspace.SmartParts)
            {
                if (pageView != null)
                    pageView.RefreshLoopGraphicObjectData(graphicID);
            }
        }
        public void CloseDeletedPages()
        {
            foreach (PageView pageView in myContentWorkspace.SmartParts)
            {
                if (pageView != null)
                {
                    if (!myNavigationView.IsPageValid(pageView.WorkItem.NodeKey))
                        pageView.WorkItem.Terminate();
                }
            }
        }
    }
}
