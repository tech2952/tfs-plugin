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
	public class LineGraphicRT : GroupBox, IAmARunTimeControl
	{
		private System.ComponentModel.Container components = null;
		private LineGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;

        public LineGraphicRT()
		{
			InitializeComponent();

		}

		public LineGraphicRT(LineGraphic aLineGraphic)
		{
			InitializeComponent();
			myGraphic = aLineGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);
	
			//set any properties on the control that come from the GraphicObject
			if (this.Width == 0) this.Width = 1;
			if (this.Height == 0) this.Height = 1;
            this.BackColor = SystemColors.ControlText;
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
		public ValueWithDataSources CurrentValue
		{
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
        public bool IsShortcut { get { return false; } }
        public int LinkedPageID { get { return 0; } }
        public int LinkedGraphicID { get { return 0; } }
		#endregion
	}
}