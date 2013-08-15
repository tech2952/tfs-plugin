using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
    public class PictureBoxRT : PictureBox , IAmARunTimeControl
    {
        private System.ComponentModel.Container components = null;
        public PictureBoxRT()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
            this.BackgroundImageLayout = ImageLayout.Zoom;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }
		#endregion

        
        #region IAmARunTimeControl Members

        public int RuntimeGraphicID
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }
        public int PageID
        {
            get { return 0; }
            set { }
        }
        public int RecordLineage
        {
            get { return 0; }
            set {}
        }

        public bool IsShortcut
        {
            get
            {
                return false;
            }
        }

        public int LinkedGraphicID
        {
            get
            {
                return 0;
            }
        }

        public int LinkedPageID
        {
            get
            {
                return 0;
            }
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

        public void SetBindingList()
        {
            
        }

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
        #endregion
    }
}
