using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI;

namespace TestHarness.ShellDirectToDB
{
    /// <summary>
    /// The smart part used by the shell to provide technical support to the user.
    /// </summary>
    [SmartPart]
    [ComVisible(false)]
    public partial class SupportView : UserControl
    {
        SupportWorkItem myWorkItem;

        /// <summary>
        /// Creates an instance of the <see cref="SupportView"/> class.
        /// </summary>
        public SupportView()
        {
            InitializeComponent();

            // Implement double buffering.
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region Properties

        /// <summary>
        /// The parent <see cref="WorkItem"/> of this smart part.
        /// </summary>
        [ServiceDependency]
        public SupportWorkItem ParentWorkItem
        {
            get { return myWorkItem; }
            set { myWorkItem = value; }
        }

        #endregion

        /// <summary>
        /// closes ALL supportviews.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_Click(object sender, EventArgs e)
        {
            myWorkItem.Terminate();
        }
    }
}
