using System;
using System.Windows.Forms;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
	/// <summary>
	/// Summary description for TextBoxGraphicRT.
	/// </summary>
	public class TextBoxGraphicRT : TextBox, IAmARunTimeControl
	{
		private System.ComponentModel.Container components = null;
		private TextBoxGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID; 
        private int myRecordLineage;
		private bool mySettingValue = false;
        private bool myHasAComputeAssignment = false;

		public TextBoxGraphicRT()
		{
			InitializeComponent();
		}
		public TextBoxGraphicRT(TextBoxGraphic aTextBoxGraphic)
		{
			InitializeComponent();
			myGraphic = aTextBoxGraphic;
			
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

			this.MaxLength = myGraphic.Length;
			this.Visible = myGraphic.Visible;
			this.Font = myGraphic.Font;
            //the font looks best if scaled down just a bit from the "set"
            float sizeAdj = FontHelpers.GetActualFontSize(myGraphic.Font);
            if (sizeAdj == myGraphic.Font.Size) //not a special courier
            {
                sizeAdj = Convert.ToSingle(myGraphic.Font.Size * .9);
            }
            this.Font = new Font(myGraphic.Font.Name, sizeAdj);
            
			this.TabIndex = myGraphic.TabIndex;
			this.Enabled = !myGraphic.ReadOnly;
            this.BorderStyle = myGraphic.BorderStyle;
            this.TextAlign = (HorizontalAlignment)(myGraphic.TextAlign);
            this.WordWrap = myGraphic.WordWrap;
            this.Multiline = true;

            //this is a computed field
            if (myGraphic.ComputeAssignmentID > 0)
            {
                myHasAComputeAssignment = true;
                this.BackColor = Color.LightGray;
            }
 
            switch (myGraphic.Case)
            {
                case CaseEnum.AsEntered:
                    this.CharacterCasing = CharacterCasing.Normal;
                    break;
                case CaseEnum.ConvertToUPPERCASE:
                    this.CharacterCasing = CharacterCasing.Upper;
                    break;
                case CaseEnum.ConvertTolowercase:
                    this.CharacterCasing = CharacterCasing.Lower;
                    break;
            }
            this.CurrentValue = new ValueWithDataSources(myGraphic.DefaultValue, DataSourceEnum.SystemDefault, null);

			myLastKnownGoodValue = this.CurrentValue;
            this.Leave += new EventHandler(TextBoxGraphicRT_Leave);
            this.KeyUp += new KeyEventHandler(TextBoxGraphicRT_KeyUp);
            this.KeyPress += new KeyPressEventHandler(TextBoxGraphicRT_KeyPress);
		}

        void TextBoxGraphicRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (myGraphic.AllowChar == AllowCharEnum.AlphabetOnly)
            {
                if (e.KeyChar <= 'z' && e.KeyChar >= 'a' || e.KeyChar <= 'Z' && e.KeyChar >= 'A' || e.KeyChar == ((char)(Keys.Back)) ||
                    !this.WordWrap && e.KeyChar == ((char)(Keys.Enter)))
                    return;
                else
                    e.Handled = true;
            }
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
		public void SetBindingList(){}
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
        public bool HasAComputeAssignment 
        {
             get { return myHasAComputeAssignment; } 
        }
        public bool IsShortcut { get { return myGraphic.IsShortCut && myGraphic.CanHaveShortCut; } }
        public int LinkedPageID { get { return myGraphic.LinkedPageID; } }
        public int LinkedGraphicID { get { return myGraphic.LinkedGraphicID; } }
        #endregion

		private void TextBoxGraphicRT_KeyUp(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter && !myGraphic.WordWrap)
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
            if (this.myGraphic.FormattedText == this.Text)
                return;
            try
            {
                switch (myGraphic.DataType)
                {
                    case TextBoxFieldDataTypeEnum.Money:
                    case TextBoxFieldDataTypeEnum.Integer:
                    case TextBoxFieldDataTypeEnum.Ratio:
                        decimal num = Convert.ToDecimal(this.Text);
                        if (!TextBoxDataUitl.DataInRange(myGraphic, num))
                        {
                            this.Focus();
                            return;
                        }

                        myGraphic.Text = num.ToString();
                        break;
                    default:
                        myGraphic.Text = this.Text;
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Invalid data for " + myGraphic.DataType.ToString() + " format.", "Invalid Entry");
                this.Focus();
                return;
            }
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
