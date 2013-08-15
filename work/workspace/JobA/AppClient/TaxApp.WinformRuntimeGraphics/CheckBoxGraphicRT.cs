using System;
using System.Windows.Forms;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using TaxBuilder.GraphicObjects;
using log4net;

namespace TaxApp.WinformRuntimeGraphics
{
	/// <summary>
	/// Summary description for LabelGraphicRT.
	/// </summary>
	public class CheckBoxGraphicRT : CheckBox, IAmARunTimeControl
	{
        private static readonly ILog theLogger = LogManager.GetLogger("CheckBoxGraphicRT");
		private System.ComponentModel.Container components = null;
		private CheckBoxGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;
		private bool mySettingValue = false;

		public CheckBoxGraphicRT()
		{
			InitializeComponent();
		}

		public CheckBoxGraphicRT(CheckBoxGraphic aCheckBoxGraphic)
		{
			InitializeComponent();
			myGraphic = aCheckBoxGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);
			//set any properties on the control that come from the GraphicObject
			this.Text = myGraphic.Text;
			this.Font = myGraphic.Font;
			mySettingValue = true;
			this.Checked = myGraphic.Checked;
			mySettingValue = false;
			this.Enabled = !myGraphic.ReadOnly;
			this.ThreeState = false;
			this.BackColor = System.Drawing.Color.Transparent;
			this.TabIndex = myGraphic.TabIndex;
			if (myGraphic.Direction == CheckBoxDirectionEnum.RightToLeft)
			{
				this.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			}
			this.CheckedChanged += new EventHandler(CheckBoxGraphicRT_CheckedChanged);
            this.Visible = myGraphic.Visible;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region IAmARunTimeControl Members

		public int RuntimeGraphicID
		{
			get{return myRunTimeID;}set{myRunTimeID = value;}
		}
        public int PageID
        {
            get { return myPageID; }
            set { myPageID = value; }
        }
        public int RecordLineage
        {
            get { return myRecordLineage; }
            set { myRecordLineage = value; }
        }
        public DataTable CurrentDataTable
        {
            get { return null; }
            set { }
        }
        private ValueWithDataSources myCurrentValue;
		public ValueWithDataSources CurrentValue
		{
			get
            {
                return myCurrentValue;
            }
			set
			{
                myCurrentValue = value;
				mySettingValue = true;
                bool tryCheckedStateRead = false;
                if (value.Value.ToString() == "1")
                    this.Checked = true;
                else if (value.Value.ToString() == "0")
                    this.Checked = false;
                else if (Boolean.TryParse(value.Value.ToString(), out tryCheckedStateRead))
                {
                    this.Checked = tryCheckedStateRead;
                }
                else
                {
                    //bad string
                    theLogger.Warn("Bad value passed to CheckBox CurrentValue: " + myCurrentValue.Value.ToString());
                }
				mySettingValue = false;
                SetDisplayByDataSource();
			}
		}
		public void ResetCurrentValueToLastKnownGoodValue(){}
		public void SetBindingList(){}
		public event UpdatedValueEvent UpdatedValueEvent;
        public OverrideIndicatorEnum OverrideIndicator
        {
            get { return myGraphic.OverrideIndicator; }
        }
        public bool HasAComputeAssignment { get { return false; } }
        public bool IsShortcut { get { return myGraphic.IsShortCut && myGraphic.CanHaveShortCut; } }
        public int LinkedPageID { get { return myGraphic.LinkedPageID; } }
        public int LinkedGraphicID { get { return myGraphic.LinkedGraphicID; } }
        #endregion

		private void CheckBoxGraphicRT_CheckedChanged(object sender, EventArgs e)
		{
			if (UpdatedValueEvent != null && !mySettingValue)
			{
                myCurrentValue.Value = this.Checked;
                if (myCurrentValue.HasComputeDataSource())
                    myCurrentValue.DataSource = DataSourceEnum.Override;
                else
                    myCurrentValue.DataSource = DataSourceEnum.DataEntry;
                UpdatedValueEvent(this);
			}
		}
        private void SetDisplayByDataSource()
        {
            switch (myCurrentValue.DataSource)
            {
                case DataSourceEnum.DataEntry:
                case DataSourceEnum.Override:
                case DataSourceEnum.SystemDefault:
                case DataSourceEnum.UserDefault:
                    this.FlatStyle = FlatStyle.Flat;
                    break;
                default:
                    this.FlatStyle = FlatStyle.Standard;
                    break;
            }
        }
	}
}

