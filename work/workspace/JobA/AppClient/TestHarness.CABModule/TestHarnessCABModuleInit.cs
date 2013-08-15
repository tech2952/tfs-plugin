using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.ObjectBuilder;
using log4net;


namespace TestHarness.CABModule
{
    public class TestHarnessCABModuleInit : ModuleInit
    {
        /// <summary>
        /// The <see cref="ILog"/> reference to the <see cref="PrintDataModule"/>'s logger.
        /// </summary>
        public static readonly ILog theLog = LogManager.GetLogger("TaxAppModuleInit");

        /// <summary>
        /// Reference to the shell's work item.
        /// </summary>
        private WorkItem parentWorkItem; // Will be ShellApplication.ShellWorkItem

        

        /// <summary>
        /// Creates an instance of the <see cref="PrintDataModuleInit"/> class.  
        /// </summary>
        /// <param name="ParentWorkItem">Dependency injected parent <see cref="WorkItem"/>.</param>
		[InjectionConstructor]
        public TestHarnessCABModuleInit([ServiceDependency] WorkItem ParentWorkItem)
		{
            this.parentWorkItem = ParentWorkItem;
            theLog.Info("Test Harness CAB Module starting.");
		}

        /// <summary>
        /// Performs the actual initialization of the PrintDataModule.  
        /// A new <see cref="MainWorkItem"/> is added to the WorkItems
        /// collection and it's Run() method called.
        /// </summary>
        public override void Load()
        {
            base.Load();
            MainWorkItem mainWorkItem = parentWorkItem.WorkItems.AddNew<MainWorkItem>(typeof(MainWorkItem).ToString());
            mainWorkItem.Terminating += new EventHandler(mainWorkItem_Terminating);
            mainWorkItem.Run();
        }

        void mainWorkItem_Terminating(object sender, EventArgs e)
        {
            theLog.Info("Module terminating.");
        }
    }
}
