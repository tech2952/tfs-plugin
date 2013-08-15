using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using Thomson.CompositeUI.Commands;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Thomson.CompositeUI.WinForms;
using log4net;
using System.Configuration;

namespace TestHarness.ShellDirectToDB
{
    [SmartPart]
    public partial class ShellForm : Form
    {
        /// <summary>
        /// The <see cref="ILog"/> reference to the shell applications's logger.
        /// </summary>
        static ILog theLog = LogManager.GetLogger("ShellForm");

        /// <summary>
        /// Reference to the application's root work item.
        /// </summary>
        WorkItem myWorkItem = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellForm"/> class.
        /// </summary>
        public ShellForm()
        {
            InitializeComponent();
            StartLogger();
        }

        /// <summary>
        /// Gets or sets a reference to the application's root work item. 
        /// This property is dependency injected.
        /// </summary>
        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            get { return myWorkItem; }
            set { myWorkItem = value; }
        }

        /// <summary>
        /// Fires the <see cref="Form.Load"/> event and loads the shell's settings.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            

            //throw new Exception("Simulated Form_Load exception.");

            // Ensure the sidebarWorkspace is visible when smartparts are added.
            sidebarWorkspace.ControlAdded += delegate { ultraDockManager1.PaneFromControl(sidebarWorkspace).Closed = false;
                                                        ultraDockManager1.PaneFromControl(sidebarWorkspace).Activate();
                                                        ((StateButtonTool)ultraToolbarsManager1.Tools["ViewExplorer"]).Checked = true;
                                                       };

            // Bring focus to the sidebar workspace for a nicer presentation
            // on application startup.
            // ultraDockManager1.PaneFromControl(sidebarWorkspace).Activate();

            // Instead of above, hide the sidebarWorkspace on startup for 
            // a cleaner presentation at startup.
            ultraDockManager1.PaneFromControl(sidebarWorkspace).Closed = true;

            //
            // Form Settings
            LoadFormSettings();
        }

        private TextBoxWriter myTextBoxWriterFromConsoleToLog;
        private void StartLogger()
        {
            this.RTBLog.Text = string.Empty;
            myTextBoxWriterFromConsoleToLog = new TextBoxWriter(this.RTBLog);
            Console.SetOut(myTextBoxWriterFromConsoleToLog);
            SetLogLevelIndicators();
            theLog.Info("TestHarness for Taxbuilder Initialized at " + DateTime.Now);
        }

        /// <summary>
        /// Overrides the base class and if the user did not cancel the close,
        /// SaveFormSettings() is called.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel)
                SaveFormSettings();
        }

        /// <summary>
        /// Loads the forms settings, checking screen resolution and boundaries
        /// to enuure the shell's form is visible.
        /// </summary>
        private void LoadFormSettings()
        {
            try
            {
                if (Properties.Settings.Default.ScreenResolution == Screen.PrimaryScreen.Bounds)
                {
                    // The resolution, monitor, or desktop remoting should work.
                    this.StartPosition = FormStartPosition.Manual;
                    if (Properties.Settings.Default.WindowState == FormWindowState.Minimized)
                        this.WindowState = FormWindowState.Normal;
                    else
                        this.WindowState = Properties.Settings.Default.WindowState;

                    this.Size = Properties.Settings.Default.WindowSize;
                    this.Location = Properties.Settings.Default.WindowLocation;
                }
                else
                {
                    // Manually deterine where to put the shell's form.
                    // There could be desktop remote issues, dual monitors, different
                    // resolutions, etc.
                    this.StartPosition = FormStartPosition.Manual;
                    this.WindowState = FormWindowState.Normal;

                    // Set the size to about 85% of available desktop area.
                    this.Size = new Size((int)((float)Screen.GetWorkingArea(this).Width * .85),
                                         (int)((float)Screen.GetWorkingArea(this).Height * .85));

                    // Set location.  NOTE:  Setting StartPosition to FormStartPosition.CenterScreen
                    // was supposed to work but the location comes out to 0,0.
                    this.Location = new Point((Screen.GetWorkingArea(this).Width - this.Width) / 2,
                                              (Screen.GetWorkingArea(this).Height - this.Height) / 2);
                }
            }
            catch (Exception ex)
            {
                theLog.Error("LoadFormSettings:  Unable to load settings.", ex);
            }

        }

        /// <summary>
        /// Saves the forms' settings for use upon next launch.
        /// </summary>
        private void SaveFormSettings()
        {
            try
            {
                Properties.Settings.Default.WindowState = this.WindowState;
                Properties.Settings.Default.ScreenResolution = Screen.PrimaryScreen.Bounds;

                if (this.WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.WindowSize = this.Size;
                    Properties.Settings.Default.WindowLocation = this.Location;
                }
                else
                {
                    Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
                    Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                }

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                theLog.Error("SaveFormSettings:  Unable to save settings.", ex);
            }
        }

        /// <summary>
        /// Handles the ToolClick event of the tool bar manager and acts upon clicks
        /// of buttons which belong to the shell.
        /// NOTE:  Future updates will include transitioning to the use of <see cref="UltraCommand"/>s.
        /// </summary>
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //throw new Exception("Simulated event handler throwing an exception.");

            switch (e.Tool.Key)
            {
                case "FileExit":
                    Close();
                    break;
                
                case "ViewExplorer":
                    if (((StateButtonTool)e.Tool).Checked)
                    {
                        ultraDockManager1.PaneFromControl(sidebarWorkspace).Closed = false;
                        ultraDockManager1.PaneFromControl(sidebarWorkspace).Activate();
                    }
                    else
                        ultraDockManager1.PaneFromControl(sidebarWorkspace).Closed = true;

                    break;
                
                case "ViewLogWindow":
                    if (((StateButtonTool)e.Tool).Checked)
                    {
                        this.ultraDockManager1.PaneFromControl(panelLog).Closed = false;
                        this.ultraDockManager1.PaneFromControl(panelLog).Activate();
                        theLog.Info("Log Window Opened");
                    }
                    else
                    {
                        this.ultraDockManager1.PaneFromControl(panelLog).Closed = true;
                        theLog.Info("Log Window Closed");
                    }
                    break;

                case "AppDomainBaseDirectory":
                    MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
                    break;

                case "HelpAbout":
                    AboutBox1 ab = new AboutBox1();
                    ab.Show();
                    break;
            }
        }

        private void ultraDockManager1_PaneDeactivate(object sender, ControlPaneEventArgs e)
        {
            this.ultraToolbarsManager1.ToolClick -= ultraToolbarsManager1_ToolClick;
            if (e.Pane.Closed)
            {
                if (e.Pane.Text == "Test Harness Log")
                {
                    ((StateButtonTool)this.ultraToolbarsManager1.Tools["ViewLogWindow"]).Checked = false;
                }
                else
                {

                    ((StateButtonTool)this.ultraToolbarsManager1.Tools["ViewExplorer"]).Checked = false;
                }
            }
            this.ultraToolbarsManager1.ToolClick +=new ToolClickEventHandler(ultraToolbarsManager1_ToolClick);

        }
        #region Log Panel Code - to be moved to its own control

        private void SetLogLevelIndicators()
        {
            if (theLog.IsDebugEnabled)
            {
                this.toolStripDropDownButtonLoggingLevel.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_green;
                this.toolStripDropDownButton2.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_green;
                return;
            }
            if (theLog.IsInfoEnabled)
            {
                this.toolStripDropDownButtonLoggingLevel.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_blue;
                this.toolStripDropDownButton2.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_blue;
                return;
            } 

            this.toolStripDropDownButtonLoggingLevel.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_red;
            this.toolStripDropDownButton2.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_red;
        }

        private void miDebug_Click(object sender, EventArgs e)
        {
            SetLogFileLevel("DEBUG");
            this.toolStripDropDownButtonLoggingLevel.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_green;
        }

        private void miInfo_Click(object sender, EventArgs e)
        {
            SetLogFileLevel("INFO");
            this.toolStripDropDownButtonLoggingLevel.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_blue;
        }

        private void miWarn_Click(object sender, EventArgs e)
        {
            SetLogFileLevel("WARN");
            this.toolStripDropDownButtonLoggingLevel.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_red;
        }
        private void dEBUGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFilterLevel("DEBUG");
        }

        private void iNFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFilterLevel("INFO");
        }

        private void wARNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFilterLevel("WARN");
        }
        //this is just setting the "current level" of both loggers
        private void SetLogFileLevel(string Level)
        {
            foreach( log4net.Appender.IAppender appenders in theLog.Logger.Repository.GetAppenders())
            {
                if (appenders.Name == "Console")
                {
                    
                    log4net.Appender.ConsoleAppender myCA = appenders as log4net.Appender.ConsoleAppender;
                    if (Level == "DEBUG")
                        myCA.Threshold = log4net.Core.Level.Debug;
                    else if (Level == "INFO")
                        myCA.Threshold = log4net.Core.Level.Info;
                    else
                        myCA.Threshold = log4net.Core.Level.Warn;

                }
                if (appenders.Name == "RollingFile")
                {
                    log4net.Appender.RollingFileAppender myRFA = appenders as log4net.Appender.RollingFileAppender;
                    if (Level == "DEBUG")
                        myRFA.Threshold = log4net.Core.Level.Debug;
                    else if (Level == "INFO")
                        myRFA.Threshold = log4net.Core.Level.Info;
                    else
                        myRFA.Threshold = log4net.Core.Level.Warn;
                }
            }

        }
        private void SetFilterLevel(string Level)
        {
            theLog.Debug("Sorry filtering currently disabled");
        }
        #endregion Log Panel Code - to be moved to its own control

        private void RTBLog_Click(object sender, EventArgs e)
        {
            myTextBoxWriterFromConsoleToLog.UpdateRTFOnMainThread();
        }



    }
}