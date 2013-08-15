using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TaxApp.InterfacesAndConstants;

namespace TestHarness.CABModule
{
	/// <summary>
	/// Dialog box to allow for a name to be entered and a locator created.
	/// </summary>
	public class DialogNewLocator : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxLocator;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
        private Label label3;
        private ComboBox comboBoxYear;
        public LocatorInfo NewTAD { get { return myLocatorIDNameYear; } }
        private LocatorInfo myLocatorIDNameYear;
        private Label label4;
        private TextBox textBox1;
        private ITaxAppClientData myTaxAppClientData;

		public DialogNewLocator(UserConfigurationItems UserConfigOptions, ITaxAppClientData taxAppClientData)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            myTaxAppClientData = taxAppClientData;
            myLocatorIDNameYear = new LocatorInfo(0, string.Empty, 1900);
            this.textBox1.Text = UserConfigOptions.ClientName;
            this.textBoxLocator.Text = "";
            this.textBoxLocator.Focus();
            this.comboBoxYear.SelectedItem = UserConfigOptions.Year.ToString();
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogNewLocator));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLocator = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // textBoxLocator
            // 
            this.textBoxLocator.Location = new System.Drawing.Point(12, 30);
            this.textBoxLocator.Name = "textBoxLocator";
            this.textBoxLocator.Size = new System.Drawing.Size(299, 20);
            this.textBoxLocator.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(155, 182);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(235, 182);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(67, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 23);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Year";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008"});
            this.comboBoxYear.Location = new System.Drawing.Point(11, 147);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(95, 21);
            this.comboBoxYear.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Client";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 20);
            this.textBox1.TabIndex = 1;
            // 
            // DialogNewLocator
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(322, 217);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxLocator);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogNewLocator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Tax App Client Data";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			if (this.textBoxLocator.Text.Length > 0)
			{
                if (this.textBox1.Text.Length > 0)
                {
                    int ClientID = myTaxAppClientData.GetClientByNameAddIfNew(this.textBox1.Text, Convert.ToInt16(this.comboBoxYear.SelectedItem.ToString()));
                    int newLocID = 0;
                    if (ClientID != 0)
                    {
                        newLocID = myTaxAppClientData.AddNewLocatorToListForClient(ClientID, this.textBoxLocator.Text, Convert.ToInt16(this.comboBoxYear.SelectedItem.ToString()));
                    }
                    if (newLocID > 0)
                    {
                        myLocatorIDNameYear = new LocatorInfo(newLocID, this.textBoxLocator.Text, Convert.ToInt16(this.comboBoxYear.SelectedItem.ToString()));
                       
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                    }
                    else
                    {
                        label2.Text = "New Name Not Unique";
                        label2.Visible = true;
                        this.DialogResult = DialogResult.None;
                    }
                }
			}
		}
	}
}
