using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
    public partial class OptionButtonGraphicRT : RadioButton, IAmARunTimeControl
    {
        private OptionButtonGraphic myGraphic;
        private bool mySettingValue = false;
        private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;
        private bool myHasAComputeAssignment = false;

        public bool SettingValue { get { return mySettingValue; } set { mySettingValue = value; } }

        public OptionButtonGraphicRT()
        {
            InitializeComponent();
        }
        public OptionButtonGraphicRT(OptionButtonGraphic aOptionButtonGraphic)
        {
            InitializeComponent();
            myGraphic = aOptionButtonGraphic;
            RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);
            this.Font = myGraphic.Font;
            this.Text = myGraphic.Text;
            mySettingValue = true;
            this.Checked = aOptionButtonGraphic.Checked;
            this.CurrentValue = new ValueWithDataSources(this.Checked, DataSourceEnum.SystemDefault, null);
            mySettingValue = false;
            if (myGraphic.Direction == CheckBoxDirectionEnum.RightToLeft)
                this.CheckAlign = ContentAlignment.MiddleRight;
            this.Visible = myGraphic.Visible;
            if (myGraphic.ComputeAssignmentID > 0)
            {
                myHasAComputeAssignment = true;
                this.BackColor = Color.Gray;
            }
            this.CheckedChanged += new EventHandler(OptionButtonGraphicRT_CheckedChanged);
        }
        #region IAmARunTimeControl Members
        public int RuntimeGraphicID
        {
            get { return myRunTimeID; }
            set { myRunTimeID = value; }
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
                SetSettingValueFlag(true);
                this.Checked = Convert.ToBoolean(myCurrentValue.Value);
                SetSettingValueFlag(false);
                SetDisplayByDataSource();
            }
        }
        public void ResetCurrentValueToLastKnownGoodValue()
        {
        }
        public void SetBindingList() { }
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
        private void OptionButtonGraphicRT_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatedValueEvent != null && !mySettingValue)
            {
                if ((bool)myCurrentValue.Value == this.Checked)
                    return;
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
        private void SetSettingValueFlag(bool bSetting)
        {
            if (this.Parent == null)
                return;

            foreach (Control c in this.Parent.Controls)
            {
                OptionButtonGraphicRT button = c as OptionButtonGraphicRT;
                if (button != null)
                    button.SettingValue = bSetting;
            }
        }
    }
}
