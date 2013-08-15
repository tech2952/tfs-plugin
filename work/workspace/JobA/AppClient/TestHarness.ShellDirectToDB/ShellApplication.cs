using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.ObjectBuilder;
using Thomson.CompositeUI.UIElements;
using Thomson.CompositeUI.Services;
using Thomson.CompositeUI.WinForms.Services;
using Thomson.CompositeUI.WinForms;
using Infragistics.Win.UltraWinToolbars;
using log4net;
using System.Net.Mail;

namespace TestHarness.ShellDirectToDB
{
    /// <summary>
    /// The main shell application class in which contains the Main() method for program entry and calls Run().
    /// </summary>
    public class ShellApplication : FormShellApplication<ShellWorkItem, ShellForm>
    {
        public static SplashScreen SplashScreen;
        /// <summary>
        /// The <see cref="ILog"/> reference to the shell's logger.
        /// </summary>
        public static readonly ILog theLog = LogManager.GetLogger("ShellApplication");

        /// <summary>
        /// Occurs when the application shell has been created.
        /// </summary>
        public static event EventHandler ShellCreated;

        /// <summary>
        /// Occurs when the root work item has initialized.
        /// </summary>
        public static event EventHandler RootWorkItemInitialized;

        private static ShellApplication theApplication = null;

        /// <summary>
        /// Create and start the application.  This is the entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (String.IsNullOrEmpty(Thread.CurrentThread.Name))
                Thread.CurrentThread.Name = "MainUI";
            theLog.Info("ShellApplication starting.");

            SplashScreen = new SplashScreen();
            SplashScreen.Show();
            Application.DoEvents();

            //
            // Initialize the application.
            try
            {
                theApplication = new ShellApplication();
            }
            catch (ModuleLoadException ex)
            {
                string msg = "The application encountered an error while loading a module and must close.\r\n\r\n" + BuildExceptionString(ex);
                theLog.Error(msg, ex);
                MessageBox.Show(msg, "Module Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string msg = "The application encountered an error during startup and must close.\r\n\r\n" + BuildExceptionString(ex);
                theLog.Error(msg, ex);
                MessageBox.Show(msg, "Application Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //
            // Run the application.
            try
            {
                theApplication.Run();
            }
            catch (ModuleLoadException ex)
            {
                string msg = "The application encountered an error while loading a module and must close.\r\n\r\n" + BuildExceptionString(ex);
                theLog.Error(msg, ex);
                MessageBox.Show(msg, "Module Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string msg = "The application encountered an error and must close.\r\n\r\n" + BuildExceptionString(ex);
                theLog.Error(msg, ex);
                MessageBox.Show(msg, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                theLog.Info("ShellApplication exiting.");
                theApplication = null;
            }

        }

        /// <summary>
        /// Gets a reference to the main form of the application.
        /// </summary>
        public ShellForm MainForm
        {
            get { return Shell; }
        }

        #region Overrides

        /// <summary>
        /// Once the shell is created, we will create new services and
        /// register a new command adapter for the Infragistics base class ToolBase.
        /// </summary>
        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();

            try
            {
                //throw new Exception("Simulated shell application initialization error.");

                // These services are added here because the shell's form 
                // will not have been instantiated yet while in AddService().
                RootWorkItem.Services.Add<UltraMainMenuManagerService>(new UltraMainMenuManagerService(Shell.ultraToolbarsManager1));
                RootWorkItem.Services.Add<ToolTipManagerService>(new ToolTipManagerService(Shell.ultraToolTipManager1));
                RootWorkItem.Services.Add<StatusBarService>(new StatusBarService(Shell.ultraStatusBar1, Shell.ultraToolTipManager1));
                ShellClosingService closingService = new ShellClosingService();
                RootWorkItem.Services.Add<ShellClosingService>(closingService);
                Shell.FormClosing += new FormClosingEventHandler(closingService.FormClosing_Handler);

                // Register the ToolBaseCommandAdapter.
                ICommandAdapterMapService mapService = RootWorkItem.Services.Get<ICommandAdapterMapService>();
                mapService.Register(typeof(ToolBase), typeof(ToolBaseCommandAdapter));

                // Expose the root work items' Initialized event;
                RootWorkItem.Initialized += new EventHandler(RootWorkItem_Initialized);

                // Fire the ShellCreated event.
                if (ShellCreated != null)
                    ShellCreated(this, new EventArgs());

            }
            catch (Exception ex)
            {
                string msg = "The application encountered a problem initializing a shell application service.";// +BuildExceptionString(ex);
                theLog.Error(msg, ex);
                throw new Exception(msg, ex);
            }
        }

        void RootWorkItem_Initialized(object sender, EventArgs e)
        {
            if (RootWorkItemInitialized != null)
                RootWorkItemInitialized(this, e);
            if (SplashScreen != null)
            {
                SplashScreen.Dispose();
            }

        }

        /// <summary>
        /// The AddServices() virtual method is provided by the CAB to enable adding new
        /// services during the approriate stage of application initialization.
        /// </summary>
        protected override void AddServices()
        {
            base.AddServices();

            try
            {
                //throw new Exception("Simulated Command Line Exception.");

                // Add the CommandLineService so all modules can access the command line.
                CommandLineService cmdService = new CommandLineService();
                cmdService.ProcessGetCommandLineArgs(Environment.GetCommandLineArgs(), true);
                RootWorkItem.Services.Add(typeof(CommandLineService), cmdService);
            }
            catch (Exception ex)
            {
                string msg = "The application was unable to process the command line options provided.";
                throw new Exception(msg, ex);
            }
        }

        #endregion Overrides

        #region Static Helper Methods

        /// <summary>
        /// Iterates an <see cref="Exception"/>, providing a formatted string of all exception messages.
        /// </summary>
        /// <param name="ex">The <see cref="Exception"/> to iterate.</param>
        /// <returns>A formatted string of <see cref="Exception"/> messages.</returns>
        public static string BuildExceptionString(Exception ex)
        {
            string msg = string.Empty;
            int msgCount = 1;

            if (ex.InnerException == null)
            {
                msg = "Message:\r\n\r\n" + ex.Message + "\r\n";
            }
            else
            {
                msg = "Messages:";
                while (ex != null)
                {
                    msg += "\r\n\r\n" + msgCount.ToString() + ")  " + ex.Message;
                    msgCount++;
                    ex = ex.InnerException;
                }
                msg += "\r\n";
            }
            return msg;
        }

        /// <summary>
        /// Iterates an <see cref="Exception"/>, providing a formatted string of exception messages.
        /// </summary>
        /// <param name="ex">The <see cref="Exception"/> to iterate.</param>
        /// <param name="innerMost">Determines if only the inner most exception message is used.</param>
        /// <returns>A formatted string of <see cref="Exception"/> messages.</returns>
        public static string BuildExceptionString(Exception ex, bool innerMost)
        {
            if (innerMost)
            {
                Exception innerEx = ex;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;

                return BuildExceptionString(innerEx);
            }
            else
                return BuildExceptionString(ex);
        }

        public static void SendMailMessage(string To, string From, string Body, string Subject)
        {
            try
            {
                MailMessage mailMess = new MailMessage(new MailAddress(From), new MailAddress(To));
                mailMess.Body = Body;
                mailMess.Subject = Subject;
                mailMess.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("RiaCentral");
                smtp.Send(mailMess);
            }
            catch (Exception ex)
            {
                //TODO: identify catchable errors
                theLog.Error("Error sending eMail Message", ex);
            }
        }

        #endregion Helper Methods
    }
}