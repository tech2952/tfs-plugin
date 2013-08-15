using System;
using NUnit.Framework;

namespace TaxApp.InterfacesAndConstants
{
	/// <summary>
	/// Summary description for Constants.
	/// </summary>
	public class ConstantsInInterface
	{
		public const string CurrentSchemaVersion = "0.13";

		public static readonly int SurfaceBoundWidth = 850;             //in 0.01 inch
		public static readonly int SurfaceBoundHeight = 1100;           //in 0.01 inch
		public static readonly int CornerSize = 12;
		public static readonly int SurfaceMargin = 10;                  //in 0.01 inch
		public static readonly int DefaultResolution = 300;
		public static readonly int HeaderFooterHeight = 100;
		public static readonly int MinMouseMove = 20;
		public const float PAPER_WIDTH = 8.5f;
		public const float LETTER_HEIGHT = 11f;
		public const float LEGAL_HEIGHT = 14f;

        public static readonly string TaxAppNavigationRootName = "TaxApp.Navigation.";
        public static readonly string PrintNavigationRootName = "Print.Navigation.";
		
	}
    namespace Tests
    {
        [TestFixture]
        public class ConstantsInInterfaceTests
        {
            [Test]
            public void ObjectCD()
            {
                Assert.AreEqual("0.13", ConstantsInInterface.CurrentSchemaVersion);
                Assert.AreEqual(850, ConstantsInInterface.SurfaceBoundWidth);
                Assert.AreEqual(1100, ConstantsInInterface.SurfaceBoundHeight);
                Assert.AreEqual(12, ConstantsInInterface.CornerSize);
                Assert.AreEqual(10, ConstantsInInterface.SurfaceMargin);
                Assert.AreEqual(300, ConstantsInInterface.DefaultResolution);
                Assert.AreEqual(100, ConstantsInInterface.HeaderFooterHeight);
                Assert.AreEqual(20, ConstantsInInterface.MinMouseMove);
                Assert.AreEqual(8.5f, ConstantsInInterface.PAPER_WIDTH);
                Assert.AreEqual(11f, ConstantsInInterface.LETTER_HEIGHT);
                Assert.AreEqual(14f, ConstantsInInterface.LEGAL_HEIGHT);
            }
        }
    }
}
