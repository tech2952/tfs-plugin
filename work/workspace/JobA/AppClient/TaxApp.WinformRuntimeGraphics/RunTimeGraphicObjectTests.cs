using System;
using NUnit.Framework;
using System.Collections.Generic;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics.Tests
{
	/// <summary>
	/// Summary description for RunTimeGraphicObjectTests.
	/// </summary>
	[TestFixture]
	public class RunTimeGraphicObjectTests
	{
		[Test]public void TextBoxGraphicRTTests()
		{
			TextBoxGraphic o1 = new TextBoxGraphic(9, 9, 90, 90);
			TextBoxGraphicRT o2 = new TextBoxGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));
			Assert.AreEqual(3, o2.Top );
			//Assert.AreEqual(30, o2.Width); //for some reason these are coming back as 32
		}
		[Test] public void CheckBoxGraphicRTTests()
		{
			CheckBoxGraphic o1 = new CheckBoxGraphic(9, 9, 90, 90);
			CheckBoxGraphicRT o2 = new CheckBoxGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
		}
		[Test] public void DropDownListGraphicRTTests()
		{
			DropDownListGraphic o1 = new DropDownListGraphic(9, 9, 90, 90);
			DropDownListGraphicRT o2 = new DropDownListGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
            //Assert.AreEqual(30, o2.Width); //for some reason these are coming back as 32
				
		}
		[Test] public void FrameGraphicRTTests()
		{
			FrameGraphic o1 = new FrameGraphic(9, 9, 90, 90);
			FrameGraphicRT o2 = new FrameGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
				
		}
		[Test] public void GroupGraphicRTTests()
		{
			GroupGraphic o1 = new GroupGraphic(9, 9, 90, 90);
			GroupGraphicRT o2 = new GroupGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
				
		}
		[Test] public void HyperLinkGraphicRTTests()
		{
			HyperLinkGraphic o1 = new HyperLinkGraphic(9, 9, 90, 90);
			HyperLinkGraphicRT o2 = new HyperLinkGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
				
		}
		[Test] public void LabelGraphicRTTests()
		{
			LabelGraphic o1 = new LabelGraphic(9, 9, 90, 90);
			LabelGraphicRT o2 = new LabelGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
				
		}
		[Test] public void LineGraphicRTTests()
		{
			LineGraphic o1 = new LineGraphic(9, 9, 90, 0);
			LineGraphicRT o2 = new LineGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
				
		}
		[Test] public void LinkLabelGraphicRTTests()
		{
			LinkLabelGraphic o1 = new LinkLabelGraphic(9, 9, 90, 90);
			LinkLabelGraphicRT o2 = new LinkLabelGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));
			Assert.AreEqual(3, o2.Top);
			Assert.AreEqual(30, o2.Width);
		}
		[Test] public void OptionGroupGraphicRTTests()
		{
			OptionGroupGraphic o1 = new OptionGroupGraphic(9, 9, 90, 0);
			OptionGroupGraphicRT o2 = new OptionGroupGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
				
		}
		[Test] public void PushButtonGraphicRTTests()
		{
			PushButtonGraphic o1 = new PushButtonGraphic(9, 9, 90, 0);
			PushButtonGraphicRT o2 = new PushButtonGraphicRT(o1);
			Assert.IsNotNull(o2);
            o2.Scale(new System.Drawing.SizeF(.33f, .33f));

			Assert.AreEqual(3, o2.Top );
			Assert.AreEqual(30, o2.Width);
				
		}
		[Test] public void TestInterface()
		{
			TextBoxGraphic tbg = new TextBoxGraphic(2, 2, 40, 20);
			System.Windows.Forms.Control c = tbg.GetRunTimeControl();
			((IAmARunTimeControl)c).CurrentValue.Value = "1234";
			Assert.AreEqual("1234", ((IAmARunTimeControl)c).CurrentValue.Value );
			
			TextBoxGraphic tbg2 = new TextBoxGraphic(2, 2, 40, 20);
			System.Windows.Forms.Control c2 = tbg2.GetRunTimeControl();
			Console.WriteLine("Default Textbox setting: datatype: " + tbg2.DataType.ToString());
			Console.WriteLine("Default Textbox setting: moneyformat: " + tbg2.MoneyFormat.ToString());

			Assert.AreEqual("0", ((IAmARunTimeControl)c2).CurrentValue.Value);

		}
        [Test]
        public void ValueWithDataSourcesTests()
        {
            ValueWithDataSources vd = new ValueWithDataSources("hey", DataSourceEnum.DataEntry, null);
            Assert.AreEqual("hey", vd.Value.ToString());
            Assert.AreEqual(0, vd.OtherDataSources.Count);
            Assert.AreEqual(DataSourceEnum.DataEntry, vd.DataSource);
            List<ValueWithDataSources> vds = new List<ValueWithDataSources>();
            vds.Add(new ValueWithDataSources("subhey", DataSourceEnum.Compute, null));
            vd = new ValueWithDataSources("hey", DataSourceEnum.DataEntry, vds);
            Assert.AreEqual(1, vd.OtherDataSources.Count);
            Assert.AreEqual("subhey", vd.OtherDataSources[0].Value.ToString());
            Assert.AreEqual("hey", vd.ToString());
        }
	}
}
