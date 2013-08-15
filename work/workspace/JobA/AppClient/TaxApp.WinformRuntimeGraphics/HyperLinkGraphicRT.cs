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
	public class HyperLinkGraphicRT : LinkLabel, IAmARunTimeControl
	{
		private System.ComponentModel.Container components = null;
		private HyperLinkGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;

		public HyperLinkGraphicRT()
		{
			InitializeComponent();
		}

		public HyperLinkGraphicRT(HyperLinkGraphic aHyperLinkGraphic)
		{
			InitializeComponent();
			myGraphic = aHyperLinkGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

			//set any properties on the control that come from the GraphicObject
			this.Text = myGraphic.Text;
			this.Font = myGraphic.Font;
			
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
        public ValueWithDataSources CurrentValue
		{
			//TODO: hyperlink needs to return linked value on current value - or link could be a different GetSet...
			get{return null;}
			set{}
		}
		public void ResetCurrentValueToLastKnownGoodValue()
		{
			
		}
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