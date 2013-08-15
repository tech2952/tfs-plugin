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
	/// OptionGroupGraphic Runtime is a frame graphic filled with Option buttons
	/// upon initialization - loop the OptionGroupGraphic's graphics and create 
	/// appropriate options.
	/// </summary>
	public class OptionGroupGraphicRT : GroupBox, IAmARunTimeControl
	{
		private System.ComponentModel.Container components = null;
		private OptionGroupGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;
        private bool myFirstButtonChanged = true;

		public OptionGroupGraphicRT()
		{
			InitializeComponent();
		}

		public OptionGroupGraphicRT(OptionGroupGraphic aOptionGroupGraphic)
		{
			InitializeComponent();
			myGraphic = aOptionGroupGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

			//set any properties on the control that come from the GraphicObject
			this.Text = myGraphic.Text;
			this.Font = myGraphic.Font;
			this.Enabled = !myGraphic.ReadOnly;
			this.Visible = myGraphic.Visible;
			this.TabIndex = myGraphic.TabIndex;

			foreach (IGraphicsObject graphic in myGraphic.GraphicCollection)
			{
				//they are all option group buttons
                OptionButtonGraphicRT rb = new OptionButtonGraphicRT((OptionButtonGraphic)graphic.GetGraphicObject());
                rb.Left = rb.Left - this.Location.X;
                rb.Top = rb.Top - this.Location.Y;
                rb.UpdatedValueEvent += new UpdatedValueEvent(OptionButtonUpdatedValueEvent);
				this.Controls.Add(rb);
			}
		}

        void OptionButtonUpdatedValueEvent(IAmARunTimeControl sender)
        {
            UpdatedValueEvent(sender);
            if (this.myFirstButtonChanged)
                myFirstButtonChanged = false;
            else
            {
                UpdatedValueEvent(this);
                myFirstButtonChanged = true;
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
            set 
            { 
                myPageID = value;
                foreach (Control c in this.Controls)
                {
                    ((IAmARunTimeControl)c).PageID = value;
                }
            }
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
			get
			{
				return null;
			}
			set
			{
			}
		}
		public void ResetCurrentValueToLastKnownGoodValue()
		{
			
		}
		public void SetBindingList(){}
		public event UpdatedValueEvent UpdatedValueEvent;
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