using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.WinForms;
using Thomson.CompositeUI.WinForms;

namespace TestHarness.ShellDirectToDB
{
    /// <summary>
    /// The work item which encapsulates the technical support use case.
    /// </summary>
    [ComVisible(false)]
    public class SupportWorkItem : WorkItem
    {
        /// <summary>
        /// Creates an shows a new <see cref="SupportView"/>.
        /// </summary>
        protected override void OnRunStarted()
        {
            base.OnRunStarted();

            //throw new Exception("Simulated Technical Support Exception");

            RIASmartPartInfo info = new RIASmartPartInfo();
            info.Title = "Technical Support";
            info.Description = "Contact information and other tools for support.";
            info.Image = Properties.Resources.user1_telephone16;

            SupportView supView = Items.AddNew<SupportView>();

            RootWorkItem.Workspaces[ShellConstants.Workspaces.CONTENT].Show(supView, info);
        }
    }
}
