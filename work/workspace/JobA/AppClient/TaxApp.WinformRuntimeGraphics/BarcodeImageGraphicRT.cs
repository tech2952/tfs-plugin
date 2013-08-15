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
	/// GridGraphic - 
	/// TODO: replace Label with datagrid...
	/// </summary>
	public class BarcodeImageGraphicRT : Label, IAmARunTimeControl
	{
		private System.ComponentModel.Container components = null;
		private BarcodeImageGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;

		public BarcodeImageGraphicRT()
		{
			InitializeComponent();
		}
		public BarcodeImageGraphicRT(BarcodeImageGraphic aBarcodeGraphic)
		{
			InitializeComponent();
			myGraphic = aBarcodeGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

			//set any properties on the Grid control from the Graphic
			this.Text = "Barcode";
			
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
            //TODO: barcodes might use the DataTable instead of theh CurrentValue - bind to and creating the resulting 
            //string for barcode use might be easiest in table format
            get { return null; }
            set { }
        }
		public ValueWithDataSources CurrentValue
		{
			//TODO: barcodes will have a currentvalue - and will use it to display the barcode.
			get{return null;}
			set{}
		}
		public void ResetCurrentValueToLastKnownGoodValue()
		{
			//Barcode's should take the BarCodeFields and turn them over to a "data getter" when 
			//sets all the values, then this guy just uses BarCodeFields.
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

