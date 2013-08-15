using System;
using System.Collections.Generic;
using System.Text;

namespace TestHarness.CABModule
{
    public class Constants
    {
        public class ImageIndecies
        {
            public static readonly int Folder = 0;
            public static readonly int Page = 1;
        }
        public class Tools
        {
            public const string MainMenuName = "MainMenu";
            public const string ToolBarKey = "TaxAppTools";
            public const string OpenKey = "FileOpen";
            public const string CloseKey = "FileClose";
            public const string PrintKey = "FilePrint";
            public const string NewKey = "FileNew";
            public const string OptionsKey = "Tools";
            public const string NavTreeContextMenuKey = "NavTreeContextMenu";
            public const string Refresh = "Refresh";
            public const string FullCompute = "FullCompute";
            public const string DeleteKey = "FileDelete";
        }
        public class State
        {
            public const string LocatorID = "LocatorID";
            public const string LocatorName = "LocatorName";
            public const string RunTimeNodes = "RunTimeNodes";
            public const string RunTimePage = "RunTimePage";
            public const string NodeKey = "NodeKey";
            public const string PageName = "PageName";
            public const string Year = "Year";
            public const string PageDescription = "PageDescription";
        }
    }
}