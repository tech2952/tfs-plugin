namespace TaxAppClient.Shell
{
    /// <summary>
    /// The smart part used by the shell to provide technical support to the user.
    /// </summary>
    partial class SupportView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.SupportView_Fill_Panel = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.ultraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.thomsonPanel1 = new Thomson.WinForms.Controls.GradientPanel();
            this.lblClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._SupportView_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SupportView_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SupportView_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SupportView_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SupportView_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).BeginInit();
            this.thomsonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            // 
            // SupportView_Fill_Panel
            // 
            this.SupportView_Fill_Panel.Controls.Add(this.webBrowser1);
            this.SupportView_Fill_Panel.Controls.Add(this.ultraExplorerBar1);
            this.SupportView_Fill_Panel.Controls.Add(this.thomsonPanel1);
            this.SupportView_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SupportView_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupportView_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.SupportView_Fill_Panel.Name = "SupportView_Fill_Panel";
            this.SupportView_Fill_Panel.Size = new System.Drawing.Size(545, 426);
            this.SupportView_Fill_Panel.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(153, 61);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(392, 365);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("http://www.thomson.com/taxacct/taxacct_contact_taxacct.jsp", System.UriKind.Absolute);
            // 
            // ultraExplorerBar1
            // 
            this.ultraExplorerBar1.Dock = System.Windows.Forms.DockStyle.Left;
            ultraExplorerBarItem1.Text = "Email log file";
            ultraExplorerBarItem2.Text = "View log file";
            ultraExplorerBarGroup1.Items.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem[] {
            ultraExplorerBarItem1,
            ultraExplorerBarItem2});
            ultraExplorerBarGroup1.Text = "Support Tools";
            this.ultraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.ultraExplorerBar1.Location = new System.Drawing.Point(0, 61);
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.Size = new System.Drawing.Size(153, 365);
            this.ultraExplorerBar1.TabIndex = 2;
            // 
            // thomsonPanel1
            // 
            this.thomsonPanel1.Controls.Add(this.lblClose);
            this.thomsonPanel1.Controls.Add(this.label1);
            this.thomsonPanel1.Controls.Add(this.pictureBox1);
            this.thomsonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.thomsonPanel1.Factors = new float[] {
        0F,
        0.075F,
        0.15F,
        0.225F,
        0.3F,
        0.475F,
        0.65F,
        0.825F,
        1F};
            this.thomsonPanel1.Location = new System.Drawing.Point(0, 0);
            this.thomsonPanel1.Name = "thomsonPanel1";
            this.thomsonPanel1.Positions = new float[] {
        0F,
        0.125F,
        0.25F,
        0.375F,
        0.5F,
        0.625F,
        0.75F,
        0.875F,
        1F};
            this.thomsonPanel1.Size = new System.Drawing.Size(545, 61);
            this.thomsonPanel1.TabIndex = 0;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(504, 45);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(39, 14);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "Close";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(118, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Technical Support";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = TaxAppClient.Shell.Properties.Resources.user1_telephone48;
            this.pictureBox1.Location = new System.Drawing.Point(27, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // _SupportView_Toolbars_Dock_Area_Left
            // 
            this._SupportView_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SupportView_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._SupportView_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SupportView_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SupportView_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._SupportView_Toolbars_Dock_Area_Left.Name = "_SupportView_Toolbars_Dock_Area_Left";
            this._SupportView_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 426);
            this._SupportView_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SupportView_Toolbars_Dock_Area_Right
            // 
            this._SupportView_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SupportView_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._SupportView_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SupportView_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SupportView_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(545, 0);
            this._SupportView_Toolbars_Dock_Area_Right.Name = "_SupportView_Toolbars_Dock_Area_Right";
            this._SupportView_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 426);
            this._SupportView_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SupportView_Toolbars_Dock_Area_Top
            // 
            this._SupportView_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SupportView_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._SupportView_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SupportView_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SupportView_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SupportView_Toolbars_Dock_Area_Top.Name = "_SupportView_Toolbars_Dock_Area_Top";
            this._SupportView_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(545, 0);
            this._SupportView_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SupportView_Toolbars_Dock_Area_Bottom
            // 
            this._SupportView_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SupportView_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._SupportView_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SupportView_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SupportView_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 426);
            this._SupportView_Toolbars_Dock_Area_Bottom.Name = "_SupportView_Toolbars_Dock_Area_Bottom";
            this._SupportView_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(545, 0);
            this._SupportView_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // SupportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SupportView_Fill_Panel);
            this.Controls.Add(this._SupportView_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SupportView_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SupportView_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SupportView_Toolbars_Dock_Area_Bottom);
            this.Name = "SupportView";
            this.Size = new System.Drawing.Size(545, 426);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.SupportView_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).EndInit();
            this.thomsonPanel1.ResumeLayout(false);
            this.thomsonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private System.Windows.Forms.Panel SupportView_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SupportView_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SupportView_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SupportView_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SupportView_Toolbars_Dock_Area_Bottom;
        private Thomson.WinForms.Controls.GradientPanel thomsonPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ultraExplorerBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
    }
}
