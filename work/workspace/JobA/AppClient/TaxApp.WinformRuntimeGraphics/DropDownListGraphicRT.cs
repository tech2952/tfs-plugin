using System;
using System.Windows.Forms;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
	/// <summary>
	/// Summary description for LabelGraphicRT.
	/// </summary>
	public class DropDownListGraphicRT : ComboBox, IAmARunTimeControl
	{
		private System.ComponentModel.Container components = null;
		private DropDownListGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;
		private bool mySettingValue = false;
        private bool myHasAComputeAssignment;

		public DropDownListGraphicRT()
		{
			InitializeComponent();
		}

		public DropDownListGraphicRT(DropDownListGraphic aDropDownListGraphic)
		{
			InitializeComponent();
			myGraphic = aDropDownListGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

            if (myGraphic.ComputeAssignmentID > 0)
            {
                myHasAComputeAssignment = true;
                this.BackColor = Color.LightGray;
            }

			//set any properties on the control that come from the GraphicObject
			this.Text = myGraphic.Text;
			this.Font = myGraphic.Font;
			this.TabIndex = myGraphic.TabIndex;
			this.Enabled = !myGraphic.ReadOnly;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Visible = myGraphic.Visible;
			this.SelectedIndexChanged +=new EventHandler(DropDownListGraphicRT_SelectedIndexChanged);
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
                //TODO: this isn't correct - make sure to update internal myCurrentValue on drop down events
				return myCurrentValue;
			}
			set
			{
                myCurrentValue = value;
				mySettingValue = true;
				this.SelectedItem = myCurrentValue.Value;
				mySettingValue = false;
                SetDisplayByDataSource();
			}
		}
		public void ResetCurrentValueToLastKnownGoodValue(){}
        public void SetBindingList()
		{
            

			this.mySettingValue = true;
            //List<ValueItem> l = new List<ValueItem>();
            //ValueList vl = new ValueList("temp", "temp", 1, l);
            //if (ListToBindTo.TryGetValue(this.RuntimeGraphicID, out vl))
            //{
            //    List<string> items = new List<string>();
            //    foreach (ValueItem vi in vl.Items)
            //    {
            //        items.Add(vi.ItemName);
            //    }
            //    this.DataSource = items;

            this.DataSource = myGraphic.ValueListItems;
            this.SelectedItem = myGraphic.DefaultValue;
            //}
			this.mySettingValue = false;
		}
		public event UpdatedValueEvent UpdatedValueEvent;
        public OverrideIndicatorEnum OverrideIndicator
        {
            get { return myGraphic.OverrideIndicator; }
        }
        public bool HasAComputeAssignment { get { return myHasAComputeAssignment; } }
        public bool IsShortcut { get { return myGraphic.IsShortCut && myGraphic.CanHaveShortCut; } }
        public int LinkedPageID { get { return myGraphic.LinkedPageID; } }
        public int LinkedGraphicID { get { return myGraphic.LinkedGraphicID; } }
        #endregion

		private void DropDownListGraphicRT_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (UpdatedValueEvent != null && !mySettingValue)
			{
                myCurrentValue.Value = this.SelectedItem;
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
                    this.ForeColor = SystemColors.WindowText;
                    break;
                default:
                    this.ForeColor = SystemColors.ActiveCaption;
                    break;
            }
        }
	}
}