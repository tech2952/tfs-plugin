namespace TestHarness.CABModule
{
    partial class PageView
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageView));
            this.pnlPreviewContainer = new System.Windows.Forms.Panel();
            this.ultraLabelLoading = new Infragistics.Win.Misc.UltraLabel();
            this.ultraFlowLayoutManager1 = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
            this.riaToolStrip1 = new Thomson.WinForms.Controls.GradientToolStrip();
            this.butXML = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.butZoomIn = new System.Windows.Forms.ToolStripButton();
            this.cmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.butZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.butExportAdobe = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.butPrint = new System.Windows.Forms.ToolStripButton();
            this.butPaperClip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.butClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pnlPreviewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).BeginInit();
            this.riaToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPreviewContainer
            // 
            this.pnlPreviewContainer.AutoScroll = true;
            this.pnlPreviewContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPreviewContainer.Controls.Add(this.ultraLabelLoading);
            this.pnlPreviewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreviewContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlPreviewContainer.Name = "pnlPreviewContainer";
            this.pnlPreviewContainer.Size = new System.Drawing.Size(551, 533);
            this.pnlPreviewContainer.TabIndex = 3;
            // 
            // ultraLabelLoading
            // 
            appearance1.ForeColor = System.Drawing.Color.DarkGray;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabelLoading.Appearance = appearance1;
            this.ultraLabelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabelLoading.Location = new System.Drawing.Point(0, 0);
            this.ultraLabelLoading.Name = "ultraLabelLoading";
            this.ultraLabelLoading.Size = new System.Drawing.Size(551, 533);
            this.ultraLabelLoading.TabIndex = 0;
            this.ultraLabelLoading.Text = "Loading Page...";
            // 
            // ultraFlowLayoutManager1
            // 
            this.ultraFlowLayoutManager1.ContainerControl = this.pnlPreviewContainer;
            // 
            // riaToolStrip1
            // 
            this.riaToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(250)))), ((int)(((byte)(246)))));
            this.riaToolStrip1.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.riaToolStrip1.Factors = new float[] {
        0F,
        0.075F,
        0.15F,
        0.225F,
        0.3F,
        0.475F,
        0.65F,
        0.825F,
        1F};
            this.riaToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.riaToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butXML,
            this.toolStripSeparator1,
            this.butZoomIn,
            this.cmbZoom,
            this.butZoomOut,
            this.toolStripSeparator2,
            this.butExportAdobe,
            this.toolStripLabel1,
            this.butPrint,
            this.butPaperClip,
            this.toolStripSeparator3,
            this.butClose,
            this.toolStripButton1});
            this.riaToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.riaToolStrip1.Name = "riaToolStrip1";
            this.riaToolStrip1.Positions = new float[] {
        0F,
        0.125F,
        0.25F,
        0.375F,
        0.5F,
        0.625F,
        0.75F,
        0.875F,
        1F};
            this.riaToolStrip1.Size = new System.Drawing.Size(551, 25);
            this.riaToolStrip1.TabIndex = 1;
            this.riaToolStrip1.Text = "riaToolStrip1";
            // 
            // butXML
            // 
            this.butXML.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butXML.Name = "butXML";
            this.butXML.Size = new System.Drawing.Size(30, 22);
            this.butXML.Text = "XML";
            this.butXML.ToolTipText = "Show Source XML";
            this.butXML.Visible = false;
            this.butXML.Click += new System.EventHandler(this.butXML_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // butZoomIn
            // 
            this.butZoomIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butZoomIn.Image = global::TestHarness.CABModule.Images.ZoomIn;
            this.butZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butZoomIn.Name = "butZoomIn";
            this.butZoomIn.Size = new System.Drawing.Size(23, 22);
            this.butZoomIn.ToolTipText = "Zoom In";
            this.butZoomIn.Visible = false;
            this.butZoomIn.Click += new System.EventHandler(this.butZoomIn_Click);
            // 
            // cmbZoom
            // 
            this.cmbZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbZoom.AutoSize = false;
            this.cmbZoom.Items.AddRange(new object[] {
            "200%",
            "150%",
            "100%",
            "75%",
            "60%",
            "50%",
            "25%",
            "10%"});
            this.cmbZoom.Name = "cmbZoom";
            this.cmbZoom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cmbZoom.Size = new System.Drawing.Size(60, 21);
            this.cmbZoom.Visible = false;
            this.cmbZoom.TextChanged += new System.EventHandler(this.cmbZoom_TextChanged);
            // 
            // butZoomOut
            // 
            this.butZoomOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butZoomOut.BackColor = System.Drawing.Color.Magenta;
            this.butZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butZoomOut.Image = global::TestHarness.CABModule.Images.ZoomOut;
            this.butZoomOut.Name = "butZoomOut";
            this.butZoomOut.Size = new System.Drawing.Size(23, 22);
            this.butZoomOut.ToolTipText = "Zoom Out";
            this.butZoomOut.Visible = false;
            this.butZoomOut.Click += new System.EventHandler(this.butZoomOut_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // butExportAdobe
            // 
            this.butExportAdobe.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butExportAdobe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butExportAdobe.Enabled = false;
            this.butExportAdobe.Name = "butExportAdobe";
            this.butExportAdobe.Size = new System.Drawing.Size(23, 22);
            this.butExportAdobe.ToolTipText = "Export To Adobe Acrobat";
            this.butExportAdobe.Click += new System.EventHandler(this.butExportAdobe_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(118, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // butPrint
            // 
            this.butPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butPrint.Enabled = false;
            this.butPrint.Image = global::TestHarness.CABModule.Images.Print;
            this.butPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(23, 22);
            this.butPrint.Text = "toolStripButton1";
            this.butPrint.ToolTipText = "Print this page";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butPaperClip
            // 
            this.butPaperClip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butPaperClip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butPaperClip.Image = global::TestHarness.CABModule.Images.paperclip;
            this.butPaperClip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butPaperClip.Name = "butPaperClip";
            this.butPaperClip.Size = new System.Drawing.Size(23, 22);
            this.butPaperClip.Text = "toolStripButton1";
            this.butPaperClip.ToolTipText = "Clip new forms to this view";
            this.butPaperClip.Visible = false;
            this.butPaperClip.Click += new System.EventHandler(this.butPaperClip_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // butClose
            // 
            this.butClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.butClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.butClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(37, 22);
            this.butClose.Text = "Close";
            this.butClose.ToolTipText = "Close";
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // PageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.pnlPreviewContainer);
            this.Controls.Add(this.riaToolStrip1);
            this.Name = "PageView";
            this.Size = new System.Drawing.Size(551, 558);
            this.pnlPreviewContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).EndInit();
            this.riaToolStrip1.ResumeLayout(false);
            this.riaToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPreviewContainer;
        private Infragistics.Win.Misc.UltraFlowLayoutManager ultraFlowLayoutManager1;
        private Thomson.WinForms.Controls.GradientToolStrip riaToolStrip1;
        private System.Windows.Forms.ToolStripButton butXML;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton butZoomIn;
        private System.Windows.Forms.ToolStripComboBox cmbZoom;
        private System.Windows.Forms.ToolStripButton butZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton butExportAdobe;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton butPrint;
        private System.Windows.Forms.ToolStripButton butClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton butPaperClip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Infragistics.Win.Misc.UltraLabel ultraLabelLoading;

    }
}
