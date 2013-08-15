using System;
using System.Windows.Forms;
using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
	/// <summary>
	/// Summary description for LabelGraphicRT.
	/// </summary>
	public class LabelGraphicRT : Label, IAmARunTimeControl
	{
		private System.ComponentModel.Container components = null;
		private LabelGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;

		public LabelGraphicRT()
		{
			InitializeComponent();
		}

		public LabelGraphicRT(LabelGraphic aLabelGraphic)
		{
			InitializeComponent();
			myGraphic = aLabelGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

			//set any properties on the Label control that come from the LabelGraphic
			this.Text = myGraphic.Text;
			this.Font = myGraphic.Font;
			this.BackColor = Color.Transparent;
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

		protected override void OnPaint(PaintEventArgs pe)
		{
			//labels are decently simple - there are only 3 things to worry about: overscore, underscore, and special text options.
			switch (myGraphic.SpecialText)
			{
				case SpecialTextOptionsEnum.CurrentDate:
					this.Text = DateTime.Now.ToShortDateString();
					break;
				case SpecialTextOptionsEnum.CurrentTime:
					this.Text = DateTime.Now.ToShortTimeString();
					break;
		//TODO: for these special character sequences should be inserted so that the running / consuming program
		//can pick them out and replace them with the actual values.
					//TODO - update - seems like the best way is to have all "updatable" lables 
					//have unique names and a known graphicobjecttype / return type.
//				case SpecialTextOptionsEnum.FirmCode:
//					break;
//				case SpecialTextOptionsEnum.LocatorCode:
//					break;
//				case SpecialTextOptionsEnum.OfficeCode:
//					break;
//				case SpecialTextOptionsEnum.SoftwareVersion:
//					break;
//				case SpecialTextOptionsEnum.PageXofY:
//					break;
//				case SpecialTextOptionsEnum.PageNumber:
//					break;
//				case SpecialTextOptionsEnum.AttachmentPage:
//					break;
//				case SpecialTextOptionsEnum.AttachmentSectionHeading:
//					break;
//				case SpecialTextOptionsEnum.ContinuedOnNextPage:
//					break;
				default:
					break;
			}


			// Calling the base class OnPaint
			base.OnPaint(pe);
			RunTimeControlUtilities.DrawUnderScore(pe, this, myGraphic.UnderScore);
			RunTimeControlUtilities.DrawOverScore(pe, this, myGraphic.OverScore);
		}


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
                //TODO: make sure this is correct
                return myCurrentValue;
            }
			set
            {
                //TODO: handle new incoming object
                myCurrentValue = value;
                this.Text = value.Value.ToString();
            }
		}
		public void ResetCurrentValueToLastKnownGoodValue(){}
		public void SetBindingList(){}
		public event UpdatedValueEvent UpdatedValueEvent;
		private void UpdatedValue()
		{
			if (UpdatedValueEvent != null)
			{
				UpdatedValueEvent(this);
			}
		}
        public OverrideIndicatorEnum OverrideIndicator
        {
            get { return OverrideIndicatorEnum.Never; }
        }
        public bool HasAComputeAssignment { get { return false; } }
        public bool IsShortcut { get { return myGraphic.IsShortCut && myGraphic.CanHaveShortCut; } }
        public int LinkedPageID { get { return myGraphic.LinkedPageID; } }
        public int LinkedGraphicID { get { return myGraphic.LinkedGraphicID; } }
        #endregion
	}

}
