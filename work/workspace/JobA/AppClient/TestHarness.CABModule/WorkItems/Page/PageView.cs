using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.ObjectBuilder;
using Infragistics.Win.UltraWinTabControl;
using Thomson.CompositeUI.WinForms.Services;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.GraphicObjects;
using TaxApp.WinformRuntimeGraphics;
using log4net;


namespace TestHarness.CABModule
{
    /// <summary>
    /// A smart part which contains one or more <see cref="PageSurfaceView"/>s and toolbar.
    /// </summary>
    [SmartPart]
    public partial class PageView : UserControl
    {
        private static ILog theLog = LogManager.GetLogger("PageView");

        private PageController myController;
        private PageWorkItem myWorkItem;
        private UserConfigurationItems myUserConfigItems;
        private StatusBarService myStatusBarService;
        private BackgroundWorker myBackgroundWorker;
        private BackgroundWorker myWorkerForFieldUpdates;
        private List<PageSurfaceView> myPageSurfaceViews;
        private int myGraphicIDToBeSelected = 0;
        private int myPageIDToBeSelected = 0;
        List<int> myLoopDataUpdatedIDs = new List<int>();

        [ServiceDependency]
        public StatusBarService StatusBarService
        {
            set { myStatusBarService = value; }
        }
        
        [ServiceDependency]
        public UserConfigurationItems UserConfigItems { set { myUserConfigItems = value; } }
        
        [Dependency]
        public PageWorkItem WorkItem
        {
            get { return myWorkItem; }
            set { myWorkItem = value; }
        }

        [EventPublication("topic://LinkClicked", PublicationScope.Global)]
        public event EventHandler<DataEventArgs<TBLinkClickedEventArg>> TBLinkClicked;

        [EventPublication("topic://LoopDataUpdated", PublicationScope.Global)]
        public event EventHandler<DataEventArgs<int>> LoopDataUpdated;

        [EventSubscription("topic://FullComputeCompleted")]
        public void FullComputeCompletedEvent(object sender, DataEventArgs<string> e)
        {
            //request that all pages request updates on their computed fields
            theLog.Debug("Full Compute Completed Event Activated on PageView");
            //once the at elast one request has been run, a group of controls that compute should be populated.
            foreach (PageSurfaceView psv in myPageSurfaceViews)
            {
                psv.RequestComputedValueBeUpdated();
            }
        }
        /// <summary>
        /// Initializes a new instance of the PageView class, retrieving 
        /// the run time page, and creating its graphic objects based 
        /// on the Locator, Server, and NavID values persisted in the containing 
        /// WorkItem.
        /// </summary>
        /// <param name="controller">A new PageController created by the CAB.</param>
        /// <param name="imageService">A new reference to the ImageService injected by the CAB.</param>
        public PageView([CreateNew] PageController controller)
        {
            InitializeComponent();
            myController = controller;
            this.Load += new EventHandler(PageView_Load);
            //this.cmbZoom.SelectedIndex = 2; // 100%

            myPageSurfaceViews = new List<PageSurfaceView>();

            //BackGroundWorkers
            myBackgroundWorker = new BackgroundWorker();
            myBackgroundWorker.DoWork += new DoWorkEventHandler(myBackgroundWorker_DoWork);
            myBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundWorker_RunWorkerCompleted);

            myWorkerForFieldUpdates = new BackgroundWorker();
            myWorkerForFieldUpdates.DoWork += new DoWorkEventHandler(myWorkerForFieldUpdates_DoWork);
            myWorkerForFieldUpdates.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorkerForFieldUpdates_RunWorkerCompleted);
        }

        #region Field Update Background Worker
        void myWorkerForFieldUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            //Update fields
            BackgroundWorker worker = sender as BackgroundWorker;
            System.Threading.Thread.CurrentThread.Name = "pageUpdateWorker";
            if (worker != null && worker == myWorkerForFieldUpdates)
            {
                myStatusBarService.SetStatusText("Saving Field...");
                if (e.Argument != null)
                {
                    IAmARunTimeControl control = (IAmARunTimeControl)e.Argument;
                    if (control.GetType() == typeof(GridGraphicRT))
                    {
                        e.Result = myController.SetValue(true,
                            control.PageID, control.RuntimeGraphicID, control.CurrentDataTable,
                            null, DataSourceEnum.DataEntry, control.RecordLineage);
                    }
                    else 
                    {
                        e.Result = myController.SetValue(false,
                            control.PageID, control.RuntimeGraphicID, null,
                            control.CurrentValue.Value, DataSourceEnum.DataEntry, control.RecordLineage);
                    }
                    
                }
                else
                {
                    theLog.Error("Unknown sender for Field Update");
                    e.Cancel = true;
                }
            }
        }

        void myWorkerForFieldUpdates_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (e.Error != null)
            {
                theLog.Error("Error on field update: ", e.Error);
            }
            else if (e.Cancelled)
            {
                theLog.Info("Update cancelled by user");
            }
            else
            {
                bool UpdateRequest = (bool)e.Result;
                if (UpdateRequest)
                {
                    foreach (PageSurfaceView psv in myPageSurfaceViews)
                    {
                        psv.RequestComputedValueBeUpdated();
                    }
                }
            }
            if (LoopDataUpdated != null)
            {
                for (int n = 0; n < myLoopDataUpdatedIDs.Count; n++)
                {
                    LoopDataUpdated(this, new DataEventArgs<int>(myLoopDataUpdatedIDs[n]));
                }
                myLoopDataUpdatedIDs.Clear();
            }
        }
        #endregion Field Update Background Worker

        #region Page Retrieval Background Worker
        void myBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //get the page inside here.
            BackgroundWorker worker = sender as BackgroundWorker;
            System.Threading.Thread.CurrentThread.Name = "pageWorker";
            if (worker != null && worker == myBackgroundWorker)
            {
                if (e.Argument == null)
                {
                    //if null is passed - what are we asking the page getter to get? maybe something else
                }
                else
                {
                    myStatusBarService.SetStatusText("Getting page information and data...");
                    e.Result = myController.GetPage((List<RunTimeNode>)e.Argument);
                }
            }
        }
        
        void myBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (e.Error != null)
            {
                theLog.Error("Error processing page Tree: ", e.Error);
                //myWorkItem.Terminate();
            }
            else if (e.Cancelled)
            {
                theLog.Info("Navigation retrieval cancelled by user");
                //myWorkItem.Terminate();
            }
            else
            {
                List<RunTimePage> runTimePages = e.Result as List<RunTimePage>;
                if (runTimePages != null)
                {
                    bool AddToTabControl = false;
                    UltraTabControl utc = null;
                    if (runTimePages.Count > 1)
                    {
                        utc = new UltraTabControl();
                        utc.Dock = DockStyle.Fill;
                        utc.Style = UltraTabControlStyle.Excel;
                        utc.MinTabWidth = 110;
                        utc.ViewStyle = ViewStyle.Office2007;
                        utc.Parent = this.pnlPreviewContainer;
                        AddToTabControl = true;
                    }
                    foreach (RunTimePage rtp in runTimePages)
                    {
                        theLog.Debug(string.Format("RunTimePage Retrieved.  [ID] - [GraphicCount] - [RecordLineage] :: [{0}] - [{1}] - [{2}]", rtp.PageID, rtp.GraphicsCollection.Count, rtp.RecordLineage));
                        PageSurfaceView surfaceView = new PageSurfaceView();
                        surfaceView.ShadowDepth = 2;
                        surfaceView.OutlineColor = Color.Black;
                        foreach (RunTimeNode rtn in myWorkItem.RunTimeNodes)
                        {
                            if (rtn.PageID == rtp.PageID)
                            {
                                surfaceView.RunTimeNode = rtn;
                            }
                        }
                        
                        surfaceView.UserConfigItems = myUserConfigItems;

                        //this event call should be the handler for saves / gets
                        surfaceView.updatedValue += new PageSurfaceView.UpdatedValue(surfaceView_updatedValue);
                        surfaceView.requestSetValues += new PageSurfaceView.RequestSetValues(surfaceView_requestSetValues);
                        //surfaceView.requestSetBindingList += new PageSurfaceView.RequestSetBindingList(surfaceView_requestSetBindingList);
                        surfaceView.linkClicked += new PageSurfaceView.LinkClickEvent(surfaceView_linkClicked);
                        surfaceView.selectDataSource += new PageSurfaceView.SelectDataSource(surfaceView_selectDataSource);
                        surfaceView.loopDataUpdated += new PageSurfaceView.LoopDataUpdated(surfaceView_loopDataUpdated);


                        surfaceView.BuildGraphics(rtp);  //BuildGraphics calls the HookupRTGraphics - which after it is set calls the RequestSetValues event.
  
                        surfaceView.Dock = DockStyle.Fill;
                        pnlPreviewContainer.Dock = DockStyle.Fill;
                        if (!AddToTabControl)
                        {
                            surfaceView.Parent = this.pnlPreviewContainer;
                        }
                        else 
                        { 
                            UltraTab ut = utc.Tabs.Add();
                            ut.Text = surfaceView.RunTimeNode.Name;
                            surfaceView.Parent = ut.TabPage;
                            ut.Selected = true;
                        }
                        if (myPageIDToBeSelected != 0 && myPageIDToBeSelected == surfaceView.RunTimePage.PageID)
                        {
                            if (myGraphicIDToBeSelected != 0)
                                surfaceView.SelectGraphic(myGraphicIDToBeSelected);
                        }

                        this.ultraLabelLoading.Visible = false;
                        myPageSurfaceViews.Add(surfaceView);
                        //surfaceView.Focus();
                    }

                    //this.Invalidate();
                }
            }
        }
        
        #endregion Page Retrieval Background Worker

        #region Public Methods

        /// <summary>
        /// Adds another <see cref="PageSurfaceView"/> to the view async by calling Backgroundworker with the passed in RunTimeNode
        /// </summary>
        public void AddPage(List<RunTimeNode> runTimeNodes)
        {

            myBackgroundWorker.RunWorkerAsync(runTimeNodes);
            
            
        }


        public void SelectGraphic(int PageID, int GraphicID)
        {
            //this is for pages that haven't been loaded yet (the foreach won't catch it - cause it won't be there yet)
            myGraphicIDToBeSelected = GraphicID;
            myPageIDToBeSelected = PageID;

            //if it is loaded, this should catch it.
            foreach (PageSurfaceView psv in myPageSurfaceViews)
            {
                if (psv.SelectGraphic(GraphicID))
                {
                    theLog.Debug("Graphic found and selected");
                    return;
                }
            }
        }

        #endregion Public Methods

        #region Event Handlers

        void PageView_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = myWorkItem.PageName;
            try
            {
                AddPage(myWorkItem.RunTimeNodes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting runtimepage/r/n" + ex.ToString());
            }
        }
        void surfaceView_selectDataSource(IAmARunTimeControl sender, bool bClearOverride, int gridRowInd, int gridColInd)
        {
            int runTimeGraphicID = sender.RuntimeGraphicID;
            DataSourceEnum dataSource;
            if (sender is GridGraphicRT)
            {
                GridGraphicRT grid = sender as GridGraphicRT;
                runTimeGraphicID = ((GraphicObject)grid.Columns[gridColInd].Tag).GraphicObjectID;
                object objCell = grid.CurrentDataTable.Rows[gridRowInd][gridColInd];
                if (objCell == DBNull.Value)
                    return;
                ValueWithDataSources cellVal = objCell as ValueWithDataSources;
                dataSource = cellVal.DataSource;
            }
            else
                dataSource = sender.CurrentValue.DataSource;
            myController.SelectDataSource(bClearOverride, sender.PageID, runTimeGraphicID, dataSource, sender.RecordLineage, gridRowInd+1);
        }

        void surfaceView_linkClicked(int LinkedPageID, int LinkedGraphicID, int RecordLineage, bool IsDetail, int GraphicIDOfColumn, int PageIDOfGraphic, int RowIndex)
        {
            try
            {
                this.TBLinkClicked(this, new DataEventArgs<TBLinkClickedEventArg>(new TBLinkClickedEventArg(LinkedPageID, LinkedGraphicID, RecordLineage, IsDetail, GraphicIDOfColumn, PageIDOfGraphic, RowIndex)));
            }
            catch (Exception ex)
            {
                theLog.Error("Error during link clicked event", ex);
            }
        }

        void surfaceView_requestSetValues(ControlCollection controlsToBeUpdated)
        {
            UpdateFields(controlsToBeUpdated);
        }

        void surfaceView_updatedValue(IAmARunTimeControl sender)
        {
            try
            {
                if (sender.RuntimeGraphicID != 0)
                {
                    myWorkerForFieldUpdates.RunWorkerAsync(sender);
                }
            }
            catch (Exception ex)
            {
                theLog.Error("Error updating values.  /r/n", ex);
            }
        }

        void surfaceView_loopDataUpdated(int graphicRunTimeID)
        {
            if (graphicRunTimeID > 0)
                this.myLoopDataUpdatedIDs.Add(graphicRunTimeID);
        }

        void cmbZoom_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    myZoom = float.Parse(cmbZoom.Text.TrimEnd(new char[] { '%' }));
            //    myZoom /= 100F;
            //}
            //catch (Exception ex)
            //{
            //    theLog.Error("Zoom error", ex);
            //}

            //foreach (PageSurfaceView pageSurface in pnlPreviewContainer.Controls)
            //    pageSurface.Zoom = myZoom;
                    
            //pageSurfaceView1.Zoom = zoom / 100F;
        }

        private void butPaperClip_Click(object sender, EventArgs e)
        {
            butPaperClip.Checked = !butPaperClip.Checked;
        }

        void butXML_Click(object sender, EventArgs e)
        {
            //butXML.Checked = !butXML.Checked;
            //txtXML.Visible = butXML.Checked;
        }

        private void butZoomOut_Click(object sender, EventArgs e)
        {
            if (cmbZoom.SelectedIndex < cmbZoom.Items.Count - 1)
                cmbZoom.SelectedIndex++;
        }

        private void butZoomIn_Click(object sender, EventArgs e)
        {
            if (cmbZoom.SelectedIndex > 0)
                cmbZoom.SelectedIndex--;
        }

        private void butExportAdobe_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.Filter = "Adobe Acrobat (*.pdf)|*.pdf";
            //dlg.Title = "Export to Adobe Acrobat (PDF)";
            //dlg.FileName = PageName + ".pdf";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //    myController.ExportToPDF(dlg.FileName, pnlPreviewContainer.Controls[0]);
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            //myController.SendPageToPrinter(pnlPreviewContainer.Controls[0]);
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            myWorkItem.Terminate();
        }

        #endregion Event Handlers

        /// <summary>
        /// Given a collection of Controls, it finds any that implement the IAmARunTimeControl interface
        /// and requests the value for that control from the LocatorImpl (via the controller).
        /// </summary>
        /// <param name="controlsToBeUpdated"></param>
        public void UpdateFields(ControlCollection controlsToBeUpdated)
        {
            //this is assuming that the control itself holds everything it needs to in order to update itself.
            //also, if there is a Graphic ID to be selected, have it focus in here
            foreach (Control c in controlsToBeUpdated)
            {
                IAmARunTimeControl irt = c as IAmARunTimeControl;
                if (irt == null)
                    continue;
                if (irt.RuntimeGraphicID != 0)
                {
                    try
                    {
                        theLog.Debug("Requesting value for: " + irt.RuntimeGraphicID.ToString());
                        if (irt.GetType() == typeof(GridGraphicRT))
                        {
                            irt.CurrentDataTable = myController.GetGridDataTable(irt);
                        }
                        else
                        {
                            if (irt.GetType() == typeof(OptionGroupGraphicRT))
                            {

                                foreach (Control button in c.Controls)
                                {
                                    IAmARunTimeControl buttonRT = button as IAmARunTimeControl;
                                    if (buttonRT == null)
                                        continue;
                                    buttonRT.CurrentValue = myController.GetSingleValue(buttonRT);
                                }
                            }
                            else
                            {
                                irt.CurrentValue = myController.GetSingleValue(irt);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        theLog.Error("Error Updating Fields", ex);
                    }
                }
            }
        }
       
        public void RefreshLoopGraphicObjectData(int graphicID)
        {
            foreach (PageSurfaceView psv in myPageSurfaceViews)
            {
                psv.RefreshLoopGraphicObjectData(graphicID);
            }
        }
    }
}

