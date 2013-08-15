namespace TestHarness.CABModule
{
    partial class NavigationView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationView));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.UltraTreeNavigation = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraLabelLoading = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTreeNavigation)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2.bmp");
            this.imageList1.Images.SetKeyName(3, "3.bmp");
            this.imageList1.Images.SetKeyName(4, "4.bmp");
            this.imageList1.Images.SetKeyName(5, "5.bmp");
            this.imageList1.Images.SetKeyName(6, "6.bmp");
            this.imageList1.Images.SetKeyName(7, "7.bmp");
            this.imageList1.Images.SetKeyName(8, "8.bmp");
            this.imageList1.Images.SetKeyName(9, "9.bmp");
            this.imageList1.Images.SetKeyName(10, "10.bmp");
            this.imageList1.Images.SetKeyName(11, "11.bmp");
            this.imageList1.Images.SetKeyName(12, "12.bmp");
            this.imageList1.Images.SetKeyName(13, "13.bmp");
            this.imageList1.Images.SetKeyName(14, "14.bmp");
            this.imageList1.Images.SetKeyName(15, "15.bmp");
            this.imageList1.Images.SetKeyName(16, "16.bmp");
            this.imageList1.Images.SetKeyName(17, "17.bmp");
            this.imageList1.Images.SetKeyName(18, "18.bmp");
            this.imageList1.Images.SetKeyName(19, "19.bmp");
            this.imageList1.Images.SetKeyName(20, "20.bmp");
            this.imageList1.Images.SetKeyName(21, "21.bmp");
            this.imageList1.Images.SetKeyName(22, "22.bmp");
            this.imageList1.Images.SetKeyName(23, "23.bmp");
            this.imageList1.Images.SetKeyName(24, "cube_green.png");
            this.imageList1.Images.SetKeyName(25, "cube_yellow.png");
            // 
            // UltraTreeNavigation
            // 
            this.UltraTreeNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraTreeNavigation.FullRowSelect = true;
            this.UltraTreeNavigation.HideSelection = false;
            this.UltraTreeNavigation.Location = new System.Drawing.Point(0, 0);
            this.UltraTreeNavigation.Name = "UltraTreeNavigation";
            this.UltraTreeNavigation.Size = new System.Drawing.Size(261, 543);
            this.UltraTreeNavigation.TabIndex = 0;
            this.UltraTreeNavigation.Visible = false;
            this.UltraTreeNavigation.MouseHover += new System.EventHandler(this.UltraTreeNavigation_MouseHover);
            this.UltraTreeNavigation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UltraTreeNavigation_MouseDoubleClick);
            // 
            // ultraLabelLoading
            // 
            this.ultraLabelLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.DarkGray;
            appearance1.TextHAlignAsString = "Center";
            this.ultraLabelLoading.Appearance = appearance1;
            this.ultraLabelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabelLoading.Location = new System.Drawing.Point(3, 224);
            this.ultraLabelLoading.Name = "ultraLabelLoading";
            this.ultraLabelLoading.Size = new System.Drawing.Size(255, 28);
            this.ultraLabelLoading.TabIndex = 1;
            this.ultraLabelLoading.Text = "Loading...";
            // 
            // NavigationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraLabelLoading);
            this.Controls.Add(this.UltraTreeNavigation);
            this.Name = "NavigationView";
            this.Size = new System.Drawing.Size(261, 543);
            ((System.ComponentModel.ISupportInitialize)(this.UltraTreeNavigation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private Infragistics.Win.UltraWinTree.UltraTree UltraTreeNavigation;
        private Infragistics.Win.Misc.UltraLabel ultraLabelLoading;
    }
}
