using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using Thomson.CompositeUI.WinForms.Services;
using Thomson.CompositeUI.Services;
using Thomson.CompositeUI.WinForms;
using Thomson.CompositeUI.Commands;
using Thomson.CompositeUI;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using log4net;
using TaxApp.InterfacesAndConstants;
using System.Configuration;

namespace TestHarness.CABModule
{
    /// <summary>
    /// This is the main workitem for the test harness tax app module.  It will contain one navigation
    /// workitem for each tax application the user opens.  It also contains a view,
    /// used as a placeholder for UI elements to be merged with the shell application's
    /// menus and toolbars.
    /// </summary>
    public class MainWorkItem : WorkItem
    {
        public static readonly ILog theLog = LogManager.GetLogger("MainWorkItem");
        
        private StatusBarService myStatusBarService;
        private UltraMainMenuManagerService myMenuService;
        private IWorkspace sidebarWorkspace;
        private ShellClosingService myClosingService;
        private NavigationView myActiveNavView;

        private UserConfigurationItems myUserConfigurationItems;
        private ITaxAppInfo myApplicationInfoRetriever;
        private ITaxAppClientData myClientDataInterface;
        /// <summary>
        /// The main entrance for the TAX APP Module (TAM) - this is pluggable into either the 
        /// TestHarness Shell & the Tax App Client Shell - to get the same functionality, but with 
        /// the former using local test databases, and the later using Web services & local store if available.
        /// </summary>
        protected override void OnRunStarted()
        {
            theLog.Debug("OnRunStarted called for MainWorkItem");
            base.OnRunStarted();

            string AppType = string.Empty;
            try
            {
                AppType = ConfigurationManager.AppSettings["AppType"];
            }
            catch (Exception ex)
            {
                theLog.Error("Error finding AppType in App.Config file.  ", ex);
                throw ex;
            }

            myUserConfigurationItems = UserConfigurationItems.LoadFromXMLFile(AppType);
            RootWorkItem.Services.Add<TaxApp.InterfacesAndConstants.UserConfigurationItems>(myUserConfigurationItems);

            string DLLNameForTaxAppInfo = string.Empty;
            string DLLNameForTaxAppClientData = string.Empty;

            try
            {
                DLLNameForTaxAppInfo = ConfigurationManager.AppSettings["ITaxAppInfo.AssemblyFileName"];
                DLLNameForTaxAppClientData = ConfigurationManager.AppSettings["ITaxAppClientData.AssemblyFileName"];
            }
            catch(Exception ex)
            {
                theLog.Error("Error finding ITaxAppInfo and ITaxAppClientData information in App.Config file", ex);
                throw ex;
            }

            theLog.Debug("ITaxAppInfo and ITaxAppClientData configuration settings loaded from app.config.  Attempting load of dlls.");
            string currentDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
            Assembly assemblyTAI = null;
            Assembly assemblyTACD = null;
            try
            {
                assemblyTAI = Assembly.LoadFile(Path.Combine(currentDir, DLLNameForTaxAppInfo));
                assemblyTACD = Assembly.LoadFile(Path.Combine(currentDir, DLLNameForTaxAppClientData));
            }
            catch (Exception ex)
            {
                theLog.Error("Error Loading ITaxAppInfo and ITaxAppClientData assemblies.  ", ex);
                throw ex;
            }

            try
            {
                foreach (Type t in assemblyTAI.GetTypes())
                {
                    if (t.GetInterface("ITaxAppInfo", true) != null)
                    {
                        myApplicationInfoRetriever = (ITaxAppInfo)(assemblyTAI.CreateInstance(t.FullName, false, BindingFlags.CreateInstance, null, null, null, null));
                        break;
                    }
                }
                if (myApplicationInfoRetriever != null)
                {
                    myApplicationInfoRetriever.Initialize(myUserConfigurationItems);
                    RootWorkItem.Services.Add<TaxApp.InterfacesAndConstants.ITaxAppInfo>(myApplicationInfoRetriever);
                }
                else
                {
                    theLog.Error("ITaxAppInfo implementor not found in dll");
                }
            }
            catch (Exception ex)
            { 
                theLog.Error("Error loading ITaxAppInfo class.  ", ex);
            }

            try
            {
                foreach (Type t in assemblyTACD.GetTypes())
                {
                    if (t.GetInterface("ITaxAppClientData", true) != null)
                    {
                        myClientDataInterface = (ITaxAppClientData)assemblyTACD.CreateInstance(t.FullName, false, BindingFlags.CreateInstance, null, null, null, null);
                        break;
                    }
                }
                if (myClientDataInterface != null)
                {
                    myClientDataInterface.Initialize(myUserConfigurationItems);
                    RootWorkItem.Services.Add<TaxApp.InterfacesAndConstants.ITaxAppClientData>(myClientDataInterface);
                }
                else
                {
                    theLog.Error("ITaxAppClientData implementor not found in dll");
                }
            }
            catch (System.Reflection.ReflectionTypeLoadException exLoad)
            {
                theLog.Error("Error loading ITaxAppClientData", exLoad);
                foreach (Exception  exloadspec in exLoad.LoaderExceptions )
                {
                    theLog.Warn(exloadspec);
                }
                    
            }
            catch (Exception ex)
            {
                theLog.Error("Error loading ITaxAppClientData class.  ", ex);
            }

            PrepareUIElements();

            // Take action when different smartparts are activated in the sidebarWorkspace.
            sidebarWorkspace = Workspaces[ShellConstants.Workspaces.SIDEBAR];
            sidebarWorkspace.SmartPartActivated += new EventHandler<WorkspaceEventArgs>(sidebarWorkspace_SmartPartActivated);

            // Get access to the Shell's command line options
            // and check if new NavigationWorkItem(s) need to be created.
            CommandLineService cmdService = RootWorkItem.Services.Get<CommandLineService>();
            //string [] printDataFiles = cmdService[PDConstants.CommandLine.PrintDataFile];
            //string printDataServer = string.Empty;
            //if (cmdService[PDConstants.CommandLine.PrintDataServer].Length > 0)
            //    printDataServer = cmdService[PDConstants.CommandLine.PrintDataServer][0];

           
        }
  
        /// <summary>
        /// Overrides the default implementation of the <see cref="WorkItem.Commands"/> 
        /// ManagedObjectCollection's creation delegate in order to use
        /// the <see cref="UltraCommand"/>s which provide additional functionality
        /// for Infragistics UI elements (StateButtonTool) which have the Checked property.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override Command CreateCommand(Type t, string name)
        {
            return new UltraCommand();
        }

        [ServiceDependency]
        public StatusBarService StatusBarService
        {
            get { return myStatusBarService; }
            set { myStatusBarService = value; }
        }
        [ServiceDependency]
        public ShellClosingService ClosingService
        {
            get { return myClosingService; }
            set { myClosingService = value; }
        }

        public CommandStatus NavigationCommandStatus
        {
            get
            {
                return Commands[Constants.Tools.CloseKey].Status;
            }
            set
            {
                Commands[Constants.Tools.CloseKey].Status = value;
            }
        }

        /// <summary>
        /// Sets the status for all command UI elements based on the active navigation view.
        /// </summary>
        public void SetCommandStatus()
        {
            if (myActiveNavView != null)
            {
                NavigationCommandStatus = CommandStatus.Enabled;
                myActiveNavView.SetCommandStatus();
            }
            else
                NavigationCommandStatus = CommandStatus.Disabled;
        }


        private void OpenTAD(LocatorInfo LocatorIDNameYear)
        {
            // Create and run a new NavigationWorkItem.
            theLog.Info(string.Format("Opening Tax App Client Data...    \tID: {0} \tName: {1} \tYear: {2}", LocatorIDNameYear.LocatorID.ToString(), LocatorIDNameYear.Name, LocatorIDNameYear.Year));
            string workItemKey = LocatorIDNameYear.LocatorID.ToString() + "." + LocatorIDNameYear.Year;
            if (WorkItems.Contains(workItemKey))
            {
                //Activate it
                NavigationWorkItem navWIO = (NavigationWorkItem)WorkItems[workItemKey];
                navWIO.Activate();
            }
            else
	        {
                Cursor saveCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                NavigationWorkItem navWI = WorkItems.AddNew<NavigationWorkItem>(workItemKey);
                navWI.State[Constants.State.LocatorName] = LocatorIDNameYear.Name;
                navWI.State[Constants.State.LocatorID] = LocatorIDNameYear.LocatorID;
                navWI.State[Constants.State.Year] = LocatorIDNameYear.Year;
                navWI.Run();

                Cursor.Current = saveCursor;
	        }
        }

        /// <summary>
        /// Creates, adds and sets state of UI elements for this module.
        /// </summary>
        private void PrepareUIElements()
        {
            theLog.Debug("Prepare UI Elements called");

            myMenuService = RootWorkItem.Services.Get<UltraMainMenuManagerService>();
            UltraToolbarsManager shellManager = myMenuService.ShellManager;
            ((System.ComponentModel.ISupportInitialize)(shellManager)).BeginInit();

            // Root open button
            Infragistics.Win.Appearance appearanceOpen = new Infragistics.Win.Appearance();
            appearanceOpen.Image = Images.OpenFolder;
            ButtonTool buttonToolRootOpen = new ButtonTool(Constants.Tools.OpenKey);
            
            buttonToolRootOpen.SharedProps.AppearancesSmall.Appearance = appearanceOpen;
            buttonToolRootOpen.SharedProps.Caption = "&Open";
            buttonToolRootOpen.SharedProps.Category = "File";

            // Instance open buttons - one for the menu and one for the toolbar
            ButtonTool buttonToolInstOpen1 = new ButtonTool(Constants.Tools.OpenKey);
            ButtonTool buttonToolInstOpen2 = new ButtonTool(Constants.Tools.OpenKey);

            //Root Delete button
            Infragistics.Win.Appearance appearanceDelete = new Infragistics.Win.Appearance();
            appearanceDelete.Image = Images.Delete;
            ButtonTool buttonToolRootDelete = new ButtonTool(Constants.Tools.DeleteKey);

            buttonToolRootDelete.SharedProps.AppearancesSmall.Appearance = appearanceDelete;
            buttonToolRootDelete.SharedProps.Caption = "&Delete Locator";
            buttonToolRootDelete.SharedProps.Category = "File";

            // Instance delete buttons - one for the menu and one for the toolbar
            ButtonTool buttonToolInstDelete1 = new ButtonTool(Constants.Tools.DeleteKey);
            ButtonTool buttonToolInstDelete2 = new ButtonTool(Constants.Tools.DeleteKey);

            //Root new button
            Infragistics.Win.Appearance appearanceNew = new Infragistics.Win.Appearance();
            appearanceNew.Image = Images.document_new;
            ButtonTool buttonToolRootNew = new ButtonTool(Constants.Tools.NewKey);
            buttonToolRootNew.SharedProps.AppearancesSmall.Appearance = appearanceNew;
            buttonToolRootNew.SharedProps.Caption = "&New";
            buttonToolRootNew.SharedProps.Category = "File";

            // Instance new buttons - one for the menu
            ButtonTool buttonToolInstNew1 = new ButtonTool(Constants.Tools.NewKey);

            // Root close button
            Infragistics.Win.Appearance appearanceClose = new Infragistics.Win.Appearance();
            //appearanceClose.Image = Images.Close;
            ButtonTool buttonToolRootClose = new ButtonTool(Constants.Tools.CloseKey);
            buttonToolRootClose.SharedProps.AppearancesSmall.Appearance = appearanceClose;
            buttonToolRootClose.SharedProps.Caption = "&Close";
            buttonToolRootClose.SharedProps.Category = "File";

            // Instance close buttons
            ButtonTool buttonToolInstClose2 = new ButtonTool(Constants.Tools.CloseKey);

            //Root print button
            Infragistics.Win.Appearance appearancePrint = new Infragistics.Win.Appearance();
            appearancePrint.Image = Images.Print;
            ButtonTool buttonToolRootPrint = new ButtonTool(Constants.Tools.PrintKey);
            buttonToolRootPrint.SharedProps.AppearancesSmall.Appearance = appearancePrint;
            buttonToolRootPrint.SharedProps.Caption = "&Print";
            buttonToolRootPrint.SharedProps.Category = "File";
            buttonToolRootPrint.SharedProps.ToolTipText = "Print selected pages";

            // Instance print buttons
            ButtonTool buttonToolInstPrint1 = new ButtonTool(Constants.Tools.PrintKey);
            buttonToolInstPrint1.InstanceProps.IsFirstInGroup = true;
            ButtonTool buttonToolInstPrint2 = new ButtonTool(Constants.Tools.PrintKey);
            buttonToolInstPrint2.InstanceProps.IsFirstInGroup = true;

            //Root Options button
            Infragistics.Win.Appearance appearanceOptions = new Infragistics.Win.Appearance();
            appearanceOptions.Image = Images.preferences;
            ButtonTool buttonToolRootOptions = new ButtonTool(Constants.Tools.OptionsKey);
            buttonToolRootOptions.SharedProps.AppearancesSmall.Appearance = appearanceOptions;
            buttonToolRootOptions.SharedProps.Caption = "&Options";
            buttonToolRootOptions.SharedProps.Category = "File";
            buttonToolRootOptions.SharedProps.ToolTipText = "User Configuration Options";

            // Instance Options buttons
            ButtonTool buttonToolInstOption1 = new ButtonTool(Constants.Tools.OptionsKey);
            ButtonTool buttonToolInstOption2 = new ButtonTool(Constants.Tools.OptionsKey);

            ButtonTool buttonToolRootRefresh = new ButtonTool(Constants.Tools.Refresh);
            buttonToolRootRefresh.SharedProps.Caption = "Refresh";
            buttonToolRootRefresh.SharedProps.Category = "NavTreeContextMenu";
            buttonToolRootRefresh.SharedProps.ToolTipText = "Refresh the tree from this point down";

            ButtonTool buttonToolRefresh = new ButtonTool(Constants.Tools.Refresh);


            //Full Compute
            Infragistics.Win.Appearance appearanceFullCompute = new Infragistics.Win.Appearance();
            appearanceFullCompute.Image = Images.gear_run;
            ButtonTool buttonToolRootFullCompute = new ButtonTool(Constants.Tools.FullCompute);
            buttonToolRootFullCompute.SharedProps.AppearancesSmall.Appearance = appearanceFullCompute;
            buttonToolRootFullCompute.SharedProps.Caption = "Full &Compute";
            buttonToolRootFullCompute.SharedProps.Category = "File";
            buttonToolRootFullCompute.SharedProps.ToolTipText = "Run the full compute against the database";

            ButtonTool buttonToolFullCompute = new ButtonTool(Constants.Tools.FullCompute);
            ButtonTool buttonToolFullCompute2 = new ButtonTool(Constants.Tools.FullCompute);


            // Navigation Tree Context Menu
            PopupMenuTool NavTreeContextMenu = new PopupMenuTool(Constants.Tools.NavTreeContextMenuKey);
            NavTreeContextMenu.Tools.AddRange(new ToolBase[] 
            {
                buttonToolRefresh,
            });

            
            UltraToolbar toolBarPrintTools = new UltraToolbar(Constants.Tools.ToolBarKey);
            toolBarPrintTools.DockedColumn = 0;
            toolBarPrintTools.DockedRow = 1;
            toolBarPrintTools.Text = "Tax App Tools";
            toolBarPrintTools.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { 
                buttonToolInstOpen1,
                //buttonToolInstPrint1,  <-- not sure print should be here also
                //buttonToolInstOption1, <-- not sure config should be on the main line
                buttonToolFullCompute,
                buttonToolInstDelete1
            });

            // Add toolbar to managers' Toolbars collection
            shellManager.Toolbars.AddRange(new UltraToolbar[] { toolBarPrintTools });

            // Add all tools to managers' Root Tools colection
            shellManager.Tools.AddRange(new ToolBase[] { 
                buttonToolRootOpen, 
                buttonToolRootNew,
                buttonToolRootOptions,
                buttonToolRootClose,
                buttonToolRootDelete,
                buttonToolRootPrint,
                buttonToolRootRefresh,
                buttonToolRootFullCompute,
                NavTreeContextMenu
            });

            PopupMenuTool fileMenu = (PopupMenuTool)shellManager.Toolbars["MainMenuBar"].Tools["File"];
            fileMenu.Tools.Insert(0, buttonToolInstPrint2);
            fileMenu.Tools.Insert(0, buttonToolInstDelete2);
            fileMenu.Tools.Insert(0, buttonToolInstClose2);
            fileMenu.Tools.Insert(0, buttonToolInstNew1);
            fileMenu.Tools.Insert(0, buttonToolInstOpen2);
            fileMenu.Tools.Insert(0, buttonToolInstOption2);
            fileMenu.Tools.Insert(0, buttonToolFullCompute2);

            ((System.ComponentModel.ISupportInitialize)(shellManager)).EndInit();


            //
            // Create the CAB commands and Set Initial State
            Commands[Constants.Tools.OpenKey].AddInvoker(shellManager.Tools[Constants.Tools.OpenKey], "ToolClick");
            Commands[Constants.Tools.DeleteKey].AddInvoker(shellManager.Tools[Constants.Tools.DeleteKey], "ToolClick");
            Commands[Constants.Tools.CloseKey].AddInvoker(shellManager.Tools[Constants.Tools.CloseKey], "ToolClick");
            Commands[Constants.Tools.CloseKey].Status = CommandStatus.Disabled;
            Commands[Constants.Tools.NewKey].AddInvoker(shellManager.Tools[Constants.Tools.NewKey], "ToolClick");
            Commands[Constants.Tools.PrintKey].AddInvoker(shellManager.Tools[Constants.Tools.PrintKey], "ToolClick");
            Commands[Constants.Tools.PrintKey].Status = CommandStatus.Disabled;
            Commands[Constants.Tools.OptionsKey].AddInvoker(shellManager.Tools[Constants.Tools.OptionsKey], "ToolClick");
            Commands[Constants.Tools.FullCompute].AddInvoker(shellManager.Tools[Constants.Tools.FullCompute], "ToolClick");
            Commands[Constants.Tools.FullCompute].Status = CommandStatus.Disabled;
            Commands[Constants.Tools.Refresh].AddInvoker(shellManager.Tools[Constants.Tools.Refresh], "ToolClick");
        }


        /// <summary>
        /// Event handler for when selected tab changes in the sidebarWorkspace of the shell.
        /// This handler is used to manage this module's tool buttons.
        /// </summary>
        /// <param name="sender">The smart part that was activated.</param>
        /// <param name="e"></param>
        void sidebarWorkspace_SmartPartActivated(object sender, WorkspaceEventArgs e)
        {
            myActiveNavView = e.SmartPart as NavigationView;
            SetCommandStatus();
        }

        [CommandHandler(Constants.Tools.OpenKey)]
        public void Open(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_BEGIN:  MainWorkItem.Open");
            Cursor.Current = Cursors.WaitCursor;

            // The user wants to open / create a new Tax App Locator
            Controls.LocatorsTreeForm openForm = new TestHarness.CABModule.Controls.LocatorsTreeForm(myUserConfigurationItems, myClientDataInterface, false);
            if (openForm.ShowDialog() == DialogResult.OK)
            {
                List<LocatorInfo> locators = openForm.SelectedLocators;
                if (locators != null && locators.Count > 0)
                    OpenTAD(locators[0]);
            }
            openForm.Dispose();

            Cursor.Current = Cursors.Default;
            theLog.Debug("EVENT_End:  MainWorkItem.Open");

        }
        [CommandHandler(Constants.Tools.DeleteKey)]
        public void DeleteLocator(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_BEGIN:  MainWorkItem.DeleteLocator");
            Cursor.Current = Cursors.WaitCursor;

            // The user wants to delete Locator(s)
            Controls.LocatorsTreeForm locatorsForm = new TestHarness.CABModule.Controls.LocatorsTreeForm(myUserConfigurationItems, myClientDataInterface, true);
            if (locatorsForm.ShowDialog() == DialogResult.OK)
            {
                List<LocatorInfo> locators = locatorsForm.SelectedLocators;
                foreach (LocatorInfo locator in locators)
                {
                    string locatorKey = locator.LocatorID.ToString() + "." + locator.Year;
                    if (WorkItems.Contains(locatorKey))
                    {
                        NavigationWorkItem navWIO = (NavigationWorkItem)WorkItems[locatorKey];
                        MessageBox.Show(string.Format("Can not delete Locator \"{0}\". It is currently open.", navWIO.State[Constants.State.LocatorName]), "Delete Locator");
                        continue;
                    }
                    else
                        myClientDataInterface.DeleteLocator(locator.LocatorID, locator.Year);
                }
            }
            locatorsForm.Dispose();
            Cursor.Current = Cursors.Default;
            theLog.Debug("EVENT_End:  MainWorkItem.DeleteLocator");
        }
        [CommandHandler(Constants.Tools.NewKey)]
        public void New(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_BEGIN:  MainWorkItem.New");
            // The user wants to create a new Tax App Locator
            DialogNewLocator dianew = new DialogNewLocator(myUserConfigurationItems, myClientDataInterface);
            if (dianew.ShowDialog() == DialogResult.OK)
            {
                OpenTAD(dianew.NewTAD);
            }
            dianew.Dispose();
        
            theLog.Debug("EVENT_End:  MainWorkItem.Open");
        }
        [CommandHandler(Constants.Tools.OptionsKey)]
        public void Options(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_Begin:  MainWorkItem.Options");
            DialogUserConfigurationSettings d = new DialogUserConfigurationSettings();
            d.UserConfigItems = myUserConfigurationItems;
            string dbName = myUserConfigurationItems.DatabaseAndBinaryPathSettings.LocatorDatabaseName.ToLower();
            string dbSName = myUserConfigurationItems.DatabaseAndBinaryPathSettings.LocatorDatabaseServerName.ToLower();
            string dbDName = myUserConfigurationItems.DatabaseAndBinaryPathSettings.DesignDatabaseName.ToLower();
            string dbDSName = myUserConfigurationItems.DatabaseAndBinaryPathSettings.DesignDatabaseServerName.ToLower();
            bool connectionSettingsChanged = false;

            if (d.ShowDialog() == DialogResult.OK)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //TODO: figure out who needs to confirm these changes - seems like the config dialog should
                string MainConString = string.Empty;
                string MainDesignConString = string.Empty;
                if (ConfigurationManager.AppSettings["Main.ConnectionString"] != null)
                {
                    MainConString = ConfigurationManager.AppSettings["Main.ConnectionString"].ToString().ToLower();
                    MainDesignConString = ConfigurationManager.AppSettings["Main.ConnectionStringForDesignDatabase"].ToString().ToLower();

                    if (dbSName != d.UserConfigItems.DatabaseAndBinaryPathSettings.LocatorDatabaseServerName)
                    {
                        MainConString = MainConString.Replace(dbSName, d.UserConfigItems.DatabaseAndBinaryPathSettings.LocatorDatabaseServerName.ToLower());
                        connectionSettingsChanged = true;
                    }
                    if (dbName != d.UserConfigItems.DatabaseAndBinaryPathSettings.LocatorDatabaseName)
                    {
                        MainConString = MainConString.Replace(dbName, d.UserConfigItems.DatabaseAndBinaryPathSettings.LocatorDatabaseName.ToLower());
                        connectionSettingsChanged = true;
                    }
                    if (dbDSName != d.UserConfigItems.DatabaseAndBinaryPathSettings.DesignDatabaseServerName)
                    {
                        MainDesignConString = MainDesignConString.Replace(dbDSName, d.UserConfigItems.DatabaseAndBinaryPathSettings.DesignDatabaseServerName);
                        connectionSettingsChanged = true;
                    }
                    if (dbDName != d.UserConfigItems.DatabaseAndBinaryPathSettings.DesignDatabaseName)
                    {
                        MainDesignConString = MainDesignConString.Replace(dbDName, d.UserConfigItems.DatabaseAndBinaryPathSettings.DesignDatabaseName);
                        connectionSettingsChanged = true;
                    }
                }
                
                myUserConfigurationItems = d.UserConfigItems;
                myUserConfigurationItems.SaveToXMLFile();
                if (connectionSettingsChanged)
                {
                    config.AppSettings.Settings["Main.ConnectionString"].Value = MainConString;
                    config.AppSettings.Settings["Main.ConnectionStringForDesignDatabase"].Value = MainDesignConString;
                    config.Save(ConfigurationSaveMode.Minimal);
                    MessageBox.Show("Please restart for connection settings to take effect.", "Connection Settings Change");
                }

            }
            d.Dispose();
            StatusBarService.TextPanel.Text = "Ready";
            theLog.Debug("EVENT_End:  MainWorkItem.Open");
        }
        [CommandHandler(Constants.Tools.Refresh)]
        public void Refresh(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_Begin: Refresh node");
            //this is on the tree - refresh that node by simply expanding / collapsing.  The tree always refreshes (until it is decided that it doesn't need to)...
            if (myActiveNavView != null)
            {
                if (myActiveNavView.SelectedNode.Expanded)
                {
                    myActiveNavView.SelectedNode.Toggle();
                    myActiveNavView.SelectedNode.Toggle();
                }
                else
                {
                    myActiveNavView.SelectedNode.Toggle();
                }
            }

            theLog.Debug("EVENT_End: Refresh node");
        }
        [CommandHandler(Constants.Tools.FullCompute)]
        public void FullCompute(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_Begin: Full Compute");
            if (myActiveNavView != null)
            {
                myActiveNavView.WorkItem.RunFullComputeAsync();
            }

            theLog.Debug("EVENT_End: Full Compute");
        }
        [CommandHandler(Constants.Tools.PrintKey)]
        public void OutputCommandHandler(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_Begin:  MainWorkItem.OutputCommandHandler");
            //IOutputService outputService = null;
            //NavigationView navView = sidebarWorkspace.ActiveSmartPart as NavigationView;
            //Command cmd = sender as Command;

            //if (cmd == null || navView == null)
            //    return;

            //switch (cmd.Name)
            //{
            //    case PDConstants.Tools.AdobeKey:
            //        theLog.Info("Exporting " + navView.Locator + " to PDF.");
            //        outputService = this.Services.Get<CreatePDFService>();
            //        break;
            //    case PDConstants.Tools.PrintKey:
            //        theLog.Info("Printing " + navView.Locator + ".");
            //        //outputService = this.Services.Get<PrintService>();
            //        break;
            //    case PDConstants.Tools.FileCabinetKey:
            //        theLog.Info("Exporting " + navView.Locator + " to File Cabinet Solution.");
            //        outputService = this.Services.Get<ExportFileCabinetService>();
            //        break;
            //    default:
            //        return;
            //}

            //if (outputService == null)
            //{
            //    theLog.Warn("Output service not available for " + cmd.Name);
            //    return;
            //}

            //myExeContext = Thread.CurrentThread.ExecutionContext;

            //string batchId = GetNextBatchWorkItemId();
            //BatchOutputWorkItem outputWorkItem = WorkItems.AddNew<BatchOutputWorkItem>(batchId);
            //outputWorkItem.ID = batchId; // Set before setting State items.
            //outputWorkItem.State[PDConstants.State.NavigationView] = navView;
            //outputWorkItem.State[PDConstants.State.OutputService] = outputService;
            //outputWorkItem.Run();
            theLog.Debug("EVENT_End:  MainWorkItem.OutputCommandHandler");
        }
        [CommandHandler(Constants.Tools.CloseKey)]
        public void ClosePrintFile(object sender, EventArgs e)
        {
            theLog.Debug("EVENT_Begin:  MainWorkItem.ClosePrintFile");
            theLog.Debug("EVENT_End:  MainWorkItem.ClosePrintFile");
            NavigationView navView = sidebarWorkspace.ActiveSmartPart as NavigationView;
            if (navView != null)
            {
                theLog.Info("Closing " + (string)navView.WorkItem.State[Constants.State.LocatorName] + ".");
                myStatusBarService.SetStatusText("Freeing resources...");
                navView.WorkItem.Terminate();
                myStatusBarService.SetStatusText("Ready");
            }

            if (!(sidebarWorkspace.ActiveSmartPart is NavigationView))
                NavigationCommandStatus = CommandStatus.Disabled;
        }


    }
}
