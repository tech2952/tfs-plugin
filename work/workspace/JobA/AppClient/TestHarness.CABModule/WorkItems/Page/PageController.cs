using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Net;
using Microsoft.Practices.CompositeUI;
using System.Xml;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.GraphicObjects;
using TaxApp.WinformRuntimeGraphics;
using log4net;

namespace TestHarness.CABModule
{
    /// <summary>
    /// The <see cref="Controller"/> based class for processing user requests
    /// in the <see cref="PageView"/> smart part user control.
    /// </summary>
    public class PageController : Controller
    {
        PageSurfaceView  surface;
        public static readonly ILog theLog = LogManager.GetLogger("PageController");
        
        private ITaxAppInfo myApplicationInfoRetriever;
        private ITaxAppData myLocatorImpl;
        private UserConfigurationItems myUserConfig;
        [ServiceDependency]
        public ITaxAppInfo ApplicationInfoRetriever { set { myApplicationInfoRetriever = value; } }
        [ServiceDependency]
        public ITaxAppData LocatorImpl { set { myLocatorImpl = value; } }
        [ServiceDependency]
        public UserConfigurationItems UserConfigOptions { set { myUserConfig = value; } }


        public new PageWorkItem WorkItem
        {
            get { return base.WorkItem as PageWorkItem; }
        }

        public List<RunTimePage> GetPage(List<RunTimeNode> runTimeNodes)
        {
            List<RunTimePage> pages = new List<RunTimePage>();
            foreach (RunTimeNode rtn in runTimeNodes)
            {
                theLog.Debug("Page Controller getting Page: " + rtn.PageID);
                pages.Add(myApplicationInfoRetriever.GetPage(rtn));
            }
            return pages;
        }

        public bool SetValue(bool IsGrid, int PageID, int RuntimeGraphicID, DataTable CurrentDataTable, object CurrentValueValue, DataSourceEnum valueType, int  RecordLineage)
        {
            bool changedResult = false;
            if (IsGrid)
            {
                changedResult = myLocatorImpl.SetValue(PageID, RuntimeGraphicID, CurrentDataTable, valueType, RecordLineage);
            }
            else
            {
                changedResult = myLocatorImpl.SetValue(PageID, RuntimeGraphicID, CurrentValueValue, valueType, RecordLineage);
            }
            return changedResult;
        }
        public DataTable GetGridDataTable(IAmARunTimeControl gridGraphicRT)
        {
            return myLocatorImpl.GetGridDataTable(gridGraphicRT.PageID, gridGraphicRT.RuntimeGraphicID, gridGraphicRT.RecordLineage);
        }
        public ValueWithDataSources GetSingleValue(IAmARunTimeControl runTimeControl)
        {
            return myLocatorImpl.GetSingleValue(runTimeControl.PageID, runTimeControl.RuntimeGraphicID, runTimeControl.RecordLineage);
        }
        
        public void SelectDataSource(bool bClearOverride, int PageID, int RuntimeGraphicID, DataSourceEnum dataSource, int RecordLineage, int RowInd)
        {
            myLocatorImpl.SelectDataSource(bClearOverride, PageID, RuntimeGraphicID, dataSource, RecordLineage, RowInd);
        }
        /// <summary>
        /// Sends the currently displayed page to the printer.
        /// </summary>
        /// <param name="pageSurface">The <PageSurfaceView/> containing the page's image and <see cref="IGraphicsObject"/>s.</param>
        public void SendPageToPrinter(PageSurfaceView pageSurface)
        {
            try
            {
                surface = pageSurface;
                PrintDocument prndoc = new PrintDocument();

                prndoc.DocumentName = (string)State["Name"];
                prndoc.PrintPage += new PrintPageEventHandler(prndoc_PrintPage);
                prndoc.Print();
            }
            catch (Exception ex)
            {
                theLog.Error("Page controller - send page to printer", ex);
            }
        }

        void prndoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                
                //TaxPageRenderer pageRenderer = new TaxPageRenderer();
                //try
                //{
                //    pageRenderer.Paint(g, surface.GraphicsCollection, surface.TaxFormImage, 1f, false);
                //}
                //catch (Exception ex)
                //{
                //    string msg = ErrorHelper.BuildNLogExString("An error occurred while printing " +
                //                                                PageName + ".", ex);
                //    MessageBox.Show(msg, "Print", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

    }
}
