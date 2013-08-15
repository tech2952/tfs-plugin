using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.ObjectBuilder;
using log4net;
using TaxApp.InterfacesAndConstants;

namespace TestHarness.CABModule
{
    /// <summary>
    /// The <see cref="WorkItem"/> responsible for managing the presentation and actions
    /// resulting from user interaction with the viewing of a page.  The WorkItem will
    /// contain one <see cref="PageView"/> and one <see cref="PageController"/>.
    /// </summary>
    public class PageWorkItem : WorkItem
    {
        private static ILog theLog = LogManager.GetLogger("PageWorkItem");
        private static bool theLogIsDebugEnable = theLog.IsDebugEnabled;
        private RunTimePage myRunTimePage;
        PageView myPageView;

        public int LocatorID { get { return (int)State[Constants.State.LocatorID];} }
        public string LocatorName { get { return (string)State[Constants.State.LocatorName]; } }
        public string NodeKey { get { return (string)State[Constants.State.NodeKey]; } }
        public List<RunTimeNode> RunTimeNodes { get { return (List<RunTimeNode>)State[Constants.State.RunTimeNodes]; } }
        public RunTimePage RunTimePage { get { return myRunTimePage; } set { myRunTimePage = value; } }
        public string PageName { get { return State[Constants.State.PageName].ToString(); } }
        public string PageDescription {get{return State[Constants.State.PageDescription].ToString();}}

        protected override void OnRunStarted()
        {
            base.OnRunStarted();

            try
            {
                myPageView = myPageView ?? this.Items.AddNew<PageView>();

            }
            catch (Exception ex)
            {
                theLog.Error("OnRunStarted:  Error adding new page view.", ex);

                // Get rid of the CAB exception.
                if (ex.InnerException != null)
                    throw new Exception("Error creating new page view.", ex.InnerException);
                else
                    throw ex;
            }

        }

        public void Show(IWorkspace Workspace)
        {
            if (Workspace.SmartParts.Contains(myPageView))
            {
                Workspace.Activate(myPageView);
                theLog.Debug("Workspace.Activate called");
            }
            else
            {
                Workspace.Show(myPageView, new SmartPartInfo(PageName, PageDescription ));
            }
        }

    }
}
