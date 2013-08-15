using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("TestHarness.ShellDirectToDB")]
[assembly: AssemblyDescription("Thomson TestHarness shell, this implementation goes directly to a design db")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("TaxBuilder")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("988b6cd0-7b6b-4816-81c6-42b798b2c891")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number - set by the build machine
//      Build Date - MONTHYEAR - this only shows up in the file version
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:

// Set the configuration file for log4net.
[assembly: log4net.Config.XmlConfigurator(Watch=true)]