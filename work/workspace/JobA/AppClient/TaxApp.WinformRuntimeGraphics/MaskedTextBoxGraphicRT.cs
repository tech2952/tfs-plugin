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
    public partial class MaskedTextBoxGraphicRT : MaskedTextBox, IAmARunTimeControl
    {
        private TextBoxGraphic myGraphic;
        private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;
        private bool mySettingValue = false;
        private bool myHasAComputeAssignment = false;

        public MaskedTextBoxGraphicRT()
        {
            InitializeComponent();
        }
        public MaskedTextBoxGraphicRT(TextBoxGraphic aTextBoxGraphic)
		{
			InitializeComponent();
			myGraphic = aTextBoxGraphic;
			
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

            if (myGraphic.ComputeAssignmentID > 0)
            {
                this.BackColor = Color.LightGray;
                myHasAComputeAssignment = true;
            }
			this.Visible = myGraphic.Visible;
			this.Font = myGraphic.Font;
			this.TabIndex = myGraphic.TabIndex;
			this.Enabled = !myGraphic.ReadOnly;
            this.BorderStyle = myGraphic.BorderStyle;
            this.TextAlign = (HorizontalAlignment)(myGraphic.TextAlign);

            this.CurrentValue = new ValueWithDataSources(myGraphic.DefaultValue, DataSourceEnum.SystemDefault, null);
            SetMask();

			myLastKnownGoodValue = this.CurrentValue;
            this.Leave += new EventHandler(TextBoxGraphicRT_Leave);
            this.KeyUp += new KeyEventHandler(TextBoxGraphicRT_KeyUp);
            this.KeyDown += new KeyEventHandler(MaskedTextBoxGraphicRT_KeyDown);
        }
        private void MaskedTextBoxGraphicRT_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.myGraphic.DataType == TextBoxFieldDataTypeEnum.Date && this.Mask.Length == 0)
            {
                this.Mask = "00/00/0000";
                try
                {
                    this.Text = Convert.ToDateTime(this.myGraphic.Text).ToShortDateString();
                }
                catch
                {
                }
            }
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
                try
                {
                    myCurrentValue = value;
                    myGraphic.Text = myCurrentValue.Value.ToString();
                    mySettingValue = true;
                    this.Text = this.myGraphic.FormattedText;
                    HandleAutoFit();
                    mySettingValue = false;
                    SetDisplayByDataSource();
                }
                catch
                {

                }
            }
        }
        private ValueWithDataSources myLastKnownGoodValue;
        public void ResetCurrentValueToLastKnownGoodValue()
        {
            CurrentValue = myLastKnownGoodValue;
        }
        public void SetBindingList() { }
        public event UpdatedValueEvent UpdatedValueEvent;
        private void FireUpdateEvent()
        {
            if (UpdatedValueEvent != null && !mySettingValue)
            {
                UpdatedValueEvent(this);
            }
        }
        public OverrideIndicatorEnum OverrideIndicator
        {
            get { return myGraphic.OverrideIndicator; }
        }
        public bool HasAComputeAssignment { get { return myHasAComputeAssignment; } }
        public bool IsShortcut { get { return myGraphic.IsShortCut && myGraphic.CanHaveShortCut; } }
        public int LinkedPageID { get { return myGraphic.LinkedPageID; } }
        public int LinkedGraphicID { get { return myGraphic.LinkedGraphicID; } }
        #endregion

        private void TextBoxGraphicRT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TextBoxGraphicRT_Leave(sender, e);
        }
 
        private void TextBoxGraphicRT_Leave(object sender, EventArgs e)
        {
            //this'll handle that tab key also
            this.mySettingValue = false;
            if (this.Text.EndsWith("\r\n"))
            {
                this.Text = this.Text.Substring(0, this.Text.Length - 2);
            }
            string strTemp = TextBoxDataUitl.RemoveMask(this.Text);
            if (this.myGraphic.FormattedText == this.Text || this.myGraphic.Text == strTemp ||
                this.myGraphic.FormattedText == strTemp)
                return;
            try
            {
                switch (myGraphic.DataType)
                {
                    case TextBoxFieldDataTypeEnum.Money:
                    case TextBoxFieldDataTypeEnum.Integer:
                    case TextBoxFieldDataTypeEnum.Ratio:
                        break;
                    case TextBoxFieldDataTypeEnum.Date:
                        DateTime date = Convert.ToDateTime(this.Text);
                        if (!TextBoxDataUitl.DataInRange(myGraphic, ref date))
                        {
                            this.Focus();
                            return;
                        }
                        myGraphic.Text = date.ToLongDateString();
                        break;
                    default:
                        myGraphic.Text = strTemp;
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Invalid data for " + myGraphic.DataType.ToString() + " format.", "Invalid Entry");
                this.Focus();
                return;
            }
            if (this.myGraphic.DataType == TextBoxFieldDataTypeEnum.Date)
                this.Mask = string.Empty;
            myCurrentValue.Value = myGraphic.Text;
            this.Text = myGraphic.FormattedText;
            HandleAutoFit();
            if (myCurrentValue.HasComputeDataSource())
                myCurrentValue.DataSource = DataSourceEnum.Override;
            else
                myCurrentValue.DataSource = DataSourceEnum.DataEntry;

            FireUpdateEvent();
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
        private void SetMask()
        {
            if (this.myGraphic.DataType != TextBoxFieldDataTypeEnum.String)
                return;
            switch (this.myGraphic.AlphaNumericMask)
            {
                case AlphaNumericMasksEnum.PhoneNumberHyphens:
                    this.Mask = "000-000-0000";
                    break;
                case AlphaNumericMasksEnum.PhoneNumberBraces:
                    this.Mask = "(000)000-0000";
                    break;
                case AlphaNumericMasksEnum.PhoneNumberSpaces:
                    this.Mask = "000 000 0000";
                    break;
                case AlphaNumericMasksEnum.PhoneNumberSpaceHyphen:
                    this.Mask = "000 000-0000";
                    break;
                case AlphaNumericMasksEnum.SSNAllNineDigits:
                    this.Mask = "000-00-0000";
                    break;
                case AlphaNumericMasksEnum.SSNLastFourOnly:
                    this.Mask = "XXX-XX-0000";
                    break;
                case AlphaNumericMasksEnum.EIN:
                    this.Mask = "00-0000000";
                    break;
                case AlphaNumericMasksEnum.ZipCodeHyphen:
                    this.Mask = "00000-0000";
                    break;
                case AlphaNumericMasksEnum.ZipCodeSpace:
                    this.Mask = "00000 0000";
                    break;
                case AlphaNumericMasksEnum.ZipCodeNumberOnly:
                    this.Mask = "000000000";
                    break;
            }
        }
        private void HandleAutoFit()
        {
            if (this.myGraphic.AutoFit)
            {
                Font fontDraw = FontHelpers.SetFontSize(this.Font, this.CreateGraphics(), 1, this.Text, this.Width);
                this.Font = fontDraw;
            }
        }
    }
}
