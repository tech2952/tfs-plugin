using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Thomson.CompositeUI.WinForms;
using Thomson.CompositeUI.Services;
using Thomson.CompositeUI.WinForms.Services;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinDock;
using log4net;

namespace TaxAppClient.Shell
{
    /// <summary>
    /// The RootWorkItem of the ShellApplication.
    /// </summary>
    public class ShellWorkItem : WorkItem
    {
        static ILog theLog = LogManager.GetLogger("ShellWorkItem");
        /// <summary>
        /// Called when the CAB starts the root work item.
        /// </summary>
        protected override void OnRunStarted()
        {
            base.OnRunStarted();
            PrepareUIElements();
        }

        /// <summary>
        /// Prepare shared UI elements and commands.
        /// </summary>
        private void PrepareUIElements()
        {
            UltraMainMenuManagerService mgr = Services.Get<UltraMainMenuManagerService>();

            Commands["OnTechnicalSupport"].AddInvoker(mgr.ShellManager.Tools["HelpTechnicalSupport"], "ToolClick");
        }

        /// <summary>
        /// Handles the technical support command, typically issued when the 
        /// user clicks on the HelpTechnicalSupport tool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [CommandHandler("OnTechnicalSupport")]
        public void OnTechnicalSupport(object sender, EventArgs e)
        {
            try
            {
                SupportWorkItem support = WorkItems.Get<SupportWorkItem>("support");

                if (support == null)
                {
                    support = WorkItems.AddNew<SupportWorkItem>("support");
                }

                support.Run();
            }
            catch (Exception ex)
            {
                string msg = "A problem was encountered opening technical support and can not be displayed.\r\n\r\n" +
                    ShellApplication.BuildExceptionString(ex);
                ShellApplication.theLog.Error(msg, ex);
                MessageBox.Show(msg, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
