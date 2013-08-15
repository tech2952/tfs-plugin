using System.Windows.Forms;

namespace TestHarness.ShellDirectToDB
{
    /// <summary>
    /// The <see cref="Form"/> for the shell.
    /// </summary>
    partial class ShellForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellForm));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, new System.Guid("64cd5a97-9f61-4e96-989b-75d8fdfbaec7"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("3978fd99-1826-4e23-8a06-9f80d269821c"), new System.Guid("efe2e7ca-df29-48c2-b53d-8229b2aa0ccf"), -1, new System.Guid("64cd5a97-9f61-4e96-989b-75d8fdfbaec7"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("62e57358-a35b-4a0f-92e8-8f59166593b0"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("4965d11f-94bc-425b-9081-5ef8328a1d5f"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("62e57358-a35b-4a0f-92e8-8f59166593b0"), -1);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("efe2e7ca-df29-48c2-b53d-8229b2aa0ccf"));
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenuBar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("View");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Help");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FileExit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FileExit");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("View");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ViewExplorer", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ViewLogWindow", "");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Help");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HelpTechnicalSupport");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HelpAbout");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HelpAbout");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HelpTechnicalSupport");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ViewExplorer", "");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ViewLogWindow", "");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            this.panelLog = new Thomson.WinForms.Controls.GradientPanel();
            this.RTBLog = new System.Windows.Forms.RichTextBox();
            this.gradientToolStrip1 = new Thomson.WinForms.Controls.GradientToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonLoggingLevel = new System.Windows.Forms.ToolStripDropDownButton();
            this.miDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.miInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miWarn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.dEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNFOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wARNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sidebarWorkspace = new Thomson.CompositeUI.WinForms.UltraTabWorkspace();
            this.sidebarSharedControls = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._ShellFormUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ShellFormUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ShellFormUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ShellFormUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ShellFormAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._ShellForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ShellForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ShellForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ShellForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.contentWorkspace = new Thomson.CompositeUI.WinForms.UltraTabWorkspace();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.panelLog.SuspendLayout();
            this.gradientToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarWorkspace)).BeginInit();
            this.sidebarWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this.windowDockingArea1.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentWorkspace)).BeginInit();
            this.contentWorkspace.SuspendLayout();
            this.windowDockingArea2.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.RTBLog);
            this.panelLog.Controls.Add(this.gradientToolStrip1);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Factors = new float[] {
        0F,
        0.075F,
        0.15F,
        0.225F,
        0.3F,
        0.475F,
        0.65F,
        0.825F,
        1F};
            this.panelLog.Location = new System.Drawing.Point(0, 20);
            this.panelLog.Name = "panelLog";
            this.panelLog.Positions = new float[] {
        0F,
        0.125F,
        0.25F,
        0.375F,
        0.5F,
        0.625F,
        0.75F,
        0.875F,
        1F};
            this.panelLog.Size = new System.Drawing.Size(1060, 120);
            this.panelLog.TabIndex = 0;
            // 
            // RTBLog
            // 
            this.RTBLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBLog.Location = new System.Drawing.Point(0, 25);
            this.RTBLog.Name = "RTBLog";
            this.RTBLog.Size = new System.Drawing.Size(1060, 95);
            this.RTBLog.TabIndex = 2;
            this.RTBLog.Text = "";
            this.RTBLog.Click += new System.EventHandler(this.RTBLog_Click);
            // 
            // gradientToolStrip1
            // 
            this.gradientToolStrip1.Factors = new float[] {
        0F,
        0.075F,
        0.15F,
        0.225F,
        0.3F,
        0.475F,
        0.65F,
        0.825F,
        1F};
            this.gradientToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripDropDownButtonLoggingLevel,
            this.toolStripDropDownButton2});
            this.gradientToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.gradientToolStrip1.Name = "gradientToolStrip1";
            this.gradientToolStrip1.Positions = new float[] {
        0F,
        0.125F,
        0.25F,
        0.375F,
        0.5F,
        0.625F,
        0.75F,
        0.875F,
        1F};
            this.gradientToolStrip1.Size = new System.Drawing.Size(1060, 25);
            this.gradientToolStrip1.TabIndex = 1;
            this.gradientToolStrip1.Text = "gradientToolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButtonLoggingLevel
            // 
            this.toolStripDropDownButtonLoggingLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDebug,
            this.miInfo,
            this.miWarn});
            this.toolStripDropDownButtonLoggingLevel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonLoggingLevel.Image")));
            this.toolStripDropDownButtonLoggingLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonLoggingLevel.Name = "toolStripDropDownButtonLoggingLevel";
            this.toolStripDropDownButtonLoggingLevel.Size = new System.Drawing.Size(105, 22);
            this.toolStripDropDownButtonLoggingLevel.Text = "Logging Level:";
            // 
            // miDebug
            // 
            this.miDebug.Image = ((System.Drawing.Image)(resources.GetObject("miDebug.Image")));
            this.miDebug.Name = "miDebug";
            this.miDebug.Size = new System.Drawing.Size(263, 22);
            this.miDebug.Text = "DEBUG (log all messages)";
            this.miDebug.Click += new System.EventHandler(this.miDebug_Click);
            // 
            // miInfo
            // 
            this.miInfo.Image = ((System.Drawing.Image)(resources.GetObject("miInfo.Image")));
            this.miInfo.Name = "miInfo";
            this.miInfo.Size = new System.Drawing.Size(263, 22);
            this.miInfo.Text = "INFO (log everything but debug)";
            this.miInfo.Click += new System.EventHandler(this.miInfo_Click);
            // 
            // miWarn
            // 
            this.miWarn.Image = ((System.Drawing.Image)(resources.GetObject("miWarn.Image")));
            this.miWarn.Name = "miWarn";
            this.miWarn.Size = new System.Drawing.Size(263, 22);
            this.miWarn.Text = "WARN (only log warnings and errors)";
            this.miWarn.Click += new System.EventHandler(this.miWarn_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dEBUGToolStripMenuItem,
            this.iNFOToolStripMenuItem,
            this.wARNToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(129, 22);
            this.toolStripDropDownButton2.Text = "Filter Display Level:";
            // 
            // dEBUGToolStripMenuItem
            // 
            this.dEBUGToolStripMenuItem.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_green;
            this.dEBUGToolStripMenuItem.Name = "dEBUGToolStripMenuItem";
            this.dEBUGToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.dEBUGToolStripMenuItem.Text = "DEBUG";
            this.dEBUGToolStripMenuItem.Click += new System.EventHandler(this.dEBUGToolStripMenuItem_Click);
            // 
            // iNFOToolStripMenuItem
            // 
            this.iNFOToolStripMenuItem.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_blue;
            this.iNFOToolStripMenuItem.Name = "iNFOToolStripMenuItem";
            this.iNFOToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.iNFOToolStripMenuItem.Text = "INFO";
            this.iNFOToolStripMenuItem.Click += new System.EventHandler(this.iNFOToolStripMenuItem_Click);
            // 
            // wARNToolStripMenuItem
            // 
            this.wARNToolStripMenuItem.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.nav_plain_red;
            this.wARNToolStripMenuItem.Name = "wARNToolStripMenuItem";
            this.wARNToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.wARNToolStripMenuItem.Text = "WARN";
            this.wARNToolStripMenuItem.Click += new System.EventHandler(this.wARNToolStripMenuItem_Click);
            // 
            // sidebarWorkspace
            // 
            this.sidebarWorkspace.AllowTabMoving = true;
            this.sidebarWorkspace.Controls.Add(this.sidebarSharedControls);
            this.sidebarWorkspace.Location = new System.Drawing.Point(0, 20);
            this.sidebarWorkspace.Name = "sidebarWorkspace";
            this.sidebarWorkspace.SharedControlsPage = this.sidebarSharedControls;
            this.sidebarWorkspace.Size = new System.Drawing.Size(304, 511);
            this.sidebarWorkspace.TabIndex = 0;
            this.sidebarWorkspace.TabSize = new System.Drawing.Size(0, 17);
            this.sidebarWorkspace.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005;
            // 
            // sidebarSharedControls
            // 
            this.sidebarSharedControls.Location = new System.Drawing.Point(2, 21);
            this.sidebarSharedControls.Name = "sidebarSharedControls";
            this.sidebarSharedControls.Size = new System.Drawing.Size(300, 488);
            // 
            // ultraDockManager1
            // 
            this.ultraDockManager1.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus3;
            this.ultraDockManager1.AutoHideDelay = 400;
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
            dockAreaPane1.DockedBefore = new System.Guid("62e57358-a35b-4a0f-92e8-8f59166593b0");
            dockAreaPane1.FloatingLocation = new System.Drawing.Point(504, 424);
            dockableControlPane1.Control = this.panelLog;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(271, 387, 200, 100);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Test Harness Log";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1060, 140);
            dockAreaPane1.Text = "Log";
            dockAreaPane1.TextTab = "Log";
            dockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
            dockAreaPane2.DockedBefore = new System.Guid("efe2e7ca-df29-48c2-b53d-8229b2aa0ccf");
            dockableControlPane2.Control = this.sidebarWorkspace;
            dockableControlPane2.Key = "Explorer";
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(56, 87, 200, 100);
            appearance1.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.text_tree;
            dockableControlPane2.Settings.Appearance = appearance1;
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Explorer";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(304, 531);
            dockAreaPane3.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
            dockAreaPane3.FloatingLocation = new System.Drawing.Point(504, 424);
            dockAreaPane3.Size = new System.Drawing.Size(597, 217);
            dockAreaPane3.Text = "Log";
            dockAreaPane3.TextTab = "Log";
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3});
            this.ultraDockManager1.HostControl = this;
            this.ultraDockManager1.UnpinnedTabStyle = Infragistics.Win.UltraWinTabs.TabStyle.VisualStudio;
            this.ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.VisualStudio2005;
            this.ultraDockManager1.PaneDeactivate += new Infragistics.Win.UltraWinDock.ControlPaneEventHandler(this.ultraDockManager1_PaneDeactivate);
            // 
            // _ShellFormUnpinnedTabAreaLeft
            // 
            this._ShellFormUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._ShellFormUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ShellFormUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 47);
            this._ShellFormUnpinnedTabAreaLeft.Name = "_ShellFormUnpinnedTabAreaLeft";
            this._ShellFormUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._ShellFormUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 676);
            this._ShellFormUnpinnedTabAreaLeft.TabIndex = 4;
            // 
            // _ShellFormUnpinnedTabAreaRight
            // 
            this._ShellFormUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._ShellFormUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ShellFormUnpinnedTabAreaRight.Location = new System.Drawing.Point(1060, 47);
            this._ShellFormUnpinnedTabAreaRight.Name = "_ShellFormUnpinnedTabAreaRight";
            this._ShellFormUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._ShellFormUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 676);
            this._ShellFormUnpinnedTabAreaRight.TabIndex = 5;
            // 
            // _ShellFormUnpinnedTabAreaTop
            // 
            this._ShellFormUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._ShellFormUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ShellFormUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 47);
            this._ShellFormUnpinnedTabAreaTop.Name = "_ShellFormUnpinnedTabAreaTop";
            this._ShellFormUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._ShellFormUnpinnedTabAreaTop.Size = new System.Drawing.Size(1060, 0);
            this._ShellFormUnpinnedTabAreaTop.TabIndex = 6;
            // 
            // _ShellFormUnpinnedTabAreaBottom
            // 
            this._ShellFormUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ShellFormUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ShellFormUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 723);
            this._ShellFormUnpinnedTabAreaBottom.Name = "_ShellFormUnpinnedTabAreaBottom";
            this._ShellFormUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._ShellFormUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1060, 0);
            this._ShellFormUnpinnedTabAreaBottom.TabIndex = 7;
            // 
            // _ShellFormAutoHideControl
            // 
            this._ShellFormAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ShellFormAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._ShellFormAutoHideControl.Name = "_ShellFormAutoHideControl";
            this._ShellFormAutoHideControl.Owner = this.ultraDockManager1;
            this._ShellFormAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._ShellFormAutoHideControl.TabIndex = 8;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Controls.Add(this.dockableWindow1);
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 578);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockManager1;
            this.windowDockingArea1.Size = new System.Drawing.Size(1060, 145);
            this.windowDockingArea1.TabIndex = 9;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.panelLog);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 5);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(1060, 140);
            this.dockableWindow1.TabIndex = 19;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.ImageTransparentColor = System.Drawing.Color.White;
            this.ultraToolbarsManager1.MdiMergeable = false;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 0;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.Settings.PaddingLeft = 5;
            ultraToolbar1.Settings.ToolSpacing = 5;
            ultraToolbar1.Text = "Main Menu";
            ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3});
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupMenuTool4.SharedProps.Caption = "&File";
            popupMenuTool4.SharedProps.Category = "File";
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            buttonTool2.SharedProps.Caption = "E&xit";
            buttonTool2.SharedProps.Category = "File";
            buttonTool2.SharedProps.MergeOrder = 20;
            popupMenuTool5.SharedProps.Caption = "&View";
            popupMenuTool5.SharedProps.Category = "View";
            stateButtonTool2.Checked = true;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1,
            stateButtonTool2});
            popupMenuTool6.SharedProps.Caption = "&Help";
            popupMenuTool6.SharedProps.Category = "Help";
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
            buttonTool5.SharedProps.Caption = "&About TaxClient";
            buttonTool5.SharedProps.Category = "Help";
            appearance2.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.user1_telephone16;
            buttonTool6.SharedProps.AppearancesSmall.Appearance = appearance2;
            buttonTool6.SharedProps.Caption = "&Technical Support";
            buttonTool6.SharedProps.Category = "Help";
            appearance3.Image = global::TestHarness.ShellDirectToDB.Properties.Resources.text_tree;
            stateButtonTool3.SharedProps.AppearancesSmall.Appearance = appearance3;
            stateButtonTool3.SharedProps.Caption = "Explorer";
            stateButtonTool3.SharedProps.Category = "View";
            stateButtonTool4.Checked = true;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            stateButtonTool4.SharedProps.AppearancesSmall.Appearance = appearance4;
            stateButtonTool4.SharedProps.Caption = "Log Panel";
            stateButtonTool4.SharedProps.Category = "View";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            buttonTool2,
            popupMenuTool5,
            popupMenuTool6,
            buttonTool5,
            buttonTool6,
            stateButtonTool3,
            stateButtonTool4});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _ShellForm_Toolbars_Dock_Area_Left
            // 
            this._ShellForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ShellForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._ShellForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ShellForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ShellForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 47);
            this._ShellForm_Toolbars_Dock_Area_Left.Name = "_ShellForm_Toolbars_Dock_Area_Left";
            this._ShellForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 676);
            this._ShellForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ShellForm_Toolbars_Dock_Area_Right
            // 
            this._ShellForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ShellForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._ShellForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ShellForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ShellForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1060, 47);
            this._ShellForm_Toolbars_Dock_Area_Right.Name = "_ShellForm_Toolbars_Dock_Area_Right";
            this._ShellForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 676);
            this._ShellForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ShellForm_Toolbars_Dock_Area_Top
            // 
            this._ShellForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ShellForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._ShellForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ShellForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ShellForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ShellForm_Toolbars_Dock_Area_Top.Name = "_ShellForm_Toolbars_Dock_Area_Top";
            this._ShellForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1060, 47);
            this._ShellForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ShellForm_Toolbars_Dock_Area_Bottom
            // 
            this._ShellForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ShellForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._ShellForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ShellForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ShellForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 723);
            this._ShellForm_Toolbars_Dock_Area_Bottom.Name = "_ShellForm_Toolbars_Dock_Area_Bottom";
            this._ShellForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1060, 0);
            this._ShellForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // contentWorkspace
            // 
            this.contentWorkspace.AllowTabMoving = true;
            this.contentWorkspace.Controls.Add(this.ultraTabSharedControlsPage1);
            this.contentWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentWorkspace.Location = new System.Drawing.Point(309, 47);
            this.contentWorkspace.Name = "contentWorkspace";
            this.contentWorkspace.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.contentWorkspace.Size = new System.Drawing.Size(751, 531);
            this.contentWorkspace.TabIndex = 14;
            this.contentWorkspace.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowAutoSize;
            this.contentWorkspace.TabSize = new System.Drawing.Size(0, 17);
            this.contentWorkspace.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(2, 21);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(747, 508);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 723);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            ultraStatusPanel1.Key = "Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel1.Text = "Welcome";
            ultraStatusPanel2.Key = "Progress";
            ultraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Adjustable;
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel2.Visible = false;
            ultraStatusPanel2.Width = 114;
            ultraStatusPanel3.Key = "Time";
            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel4.Key = "Date";
            ultraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4});
            this.ultraStatusBar1.Size = new System.Drawing.Size(1060, 23);
            this.ultraStatusBar1.TabIndex = 0;
            this.ultraStatusBar1.Text = "ultraStatusBar1";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 100;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Controls.Add(this.dockableWindow2);
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea2.Location = new System.Drawing.Point(0, 47);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.ultraDockManager1;
            this.windowDockingArea2.Size = new System.Drawing.Size(309, 531);
            this.windowDockingArea2.TabIndex = 0;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.sidebarWorkspace);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.ultraDockManager1;
            this.dockableWindow2.Size = new System.Drawing.Size(304, 531);
            this.dockableWindow2.TabIndex = 20;
            // 
            // windowDockingArea3
            // 
            this.windowDockingArea3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea3.Location = new System.Drawing.Point(0, 578);
            this.windowDockingArea3.Name = "windowDockingArea3";
            this.windowDockingArea3.Owner = this.ultraDockManager1;
            this.windowDockingArea3.Size = new System.Drawing.Size(597, 217);
            this.windowDockingArea3.TabIndex = 19;
            // 
            // ShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 746);
            this.Controls.Add(this._ShellFormAutoHideControl);
            this.Controls.Add(this.contentWorkspace);
            this.Controls.Add(this.windowDockingArea2);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._ShellFormUnpinnedTabAreaTop);
            this.Controls.Add(this._ShellFormUnpinnedTabAreaBottom);
            this.Controls.Add(this._ShellFormUnpinnedTabAreaLeft);
            this.Controls.Add(this._ShellFormUnpinnedTabAreaRight);
            this.Controls.Add(this._ShellForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ShellForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ShellForm_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._ShellForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax Builder Test Harness";
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.gradientToolStrip1.ResumeLayout(false);
            this.gradientToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarWorkspace)).EndInit();
            this.sidebarWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this.windowDockingArea1.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentWorkspace)).EndInit();
            this.contentWorkspace.ResumeLayout(false);
            this.windowDockingArea2.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
        private Infragistics.Win.UltraWinDock.AutoHideControl _ShellFormAutoHideControl;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ShellFormUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ShellFormUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ShellFormUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _ShellFormUnpinnedTabAreaRight;
        private Thomson.CompositeUI.WinForms.UltraTabWorkspace sidebarWorkspace;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage sidebarSharedControls;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ShellForm_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ShellForm_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ShellForm_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ShellForm_Toolbars_Dock_Area_Bottom;
        /// <summary>
        /// The <see cref="Infragistics.Win.UltraWinToolbars.UltraToolbarsManager"/> of the shell's form.
        /// </summary>
        public Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Thomson.CompositeUI.WinForms.UltraTabWorkspace contentWorkspace;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        /// <summary>
        /// The <see cref="Infragistics.Win.UltraWinStatusBar.UltraStatusBar"/> of the shell's form.
        /// </summary>
        public Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        /// <summary>
        /// The <see cref="Infragistics.Win.UltraWinToolTip.UltraToolTipManager"/> of the shell's form.
        /// </summary>
        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Thomson.WinForms.Controls.GradientPanel panelLog;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea3;
        private Thomson.WinForms.Controls.GradientToolStrip gradientToolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripDropDownButtonLoggingLevel;
        private ToolStripMenuItem miDebug;
        private ToolStripMenuItem miInfo;
        private ToolStripMenuItem miWarn;
        public RichTextBox RTBLog;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem dEBUGToolStripMenuItem;
        private ToolStripMenuItem iNFOToolStripMenuItem;
        private ToolStripMenuItem wARNToolStripMenuItem;


    }
}

