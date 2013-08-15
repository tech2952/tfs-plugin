namespace TestHarness.CABModule.Controls
{
    partial class LocatorsTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocatorsTreeForm));
            this.treeViewLocators = new System.Windows.Forms.TreeView();
            this.imageListTreeNode = new System.Windows.Forms.ImageList(this.components);
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewLocators
            // 
            this.treeViewLocators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewLocators.ImageIndex = 0;
            this.treeViewLocators.ImageList = this.imageListTreeNode;
            this.treeViewLocators.Location = new System.Drawing.Point(0, 0);
            this.treeViewLocators.Name = "treeViewLocators";
            this.treeViewLocators.SelectedImageIndex = 0;
            this.treeViewLocators.Size = new System.Drawing.Size(581, 431);
            this.treeViewLocators.TabIndex = 0;
            this.treeViewLocators.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLocators_AfterCheck);
            this.treeViewLocators.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLocators_AfterSelect);
            // 
            // imageListTreeNode
            // 
            this.imageListTreeNode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeNode.ImageStream")));
            this.imageListTreeNode.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeNode.Images.SetKeyName(0, "businessmen.ico");
            this.imageListTreeNode.Images.SetKeyName(1, "books.ico");
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.buttonOK);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 380);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(581, 51);
            this.panelButtons.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(430, 16);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(63, 16);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // LocatorsTreeForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(581, 431);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.treeViewLocators);
            this.MinimumSize = new System.Drawing.Size(300, 160);
            this.Name = "LocatorsTreeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LocatorsTreeForm";
            this.Load += new System.EventHandler(this.LocatorsTreeForm_Load);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewLocators;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ImageList imageListTreeNode;
    }
}