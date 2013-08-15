using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace TestHarness.ShellDirectToDB
{
	/// <summary>
	/// TextBoxWriter translates a series of writes to a TextBox display.
	/// Note that no locking is performed because this class is only written 
	/// to by BufferedStringTextWriter which does locking. However the 
	/// class does do an extra level of buffering in the case where the 
	/// control has not yet been created at the time of the Write().
	/// </summary>
	public class TextBoxWriter : TextWriter
	{
		private RichTextBox textBox;
        private RtfDocument myRTFDoc;
    			
		public TextBoxWriter(RichTextBox textBox)
		{
			this.textBox = textBox;
            myRTFDoc = new RtfDocument();

		}
        public static string logFilter = "INFO";

		public override void Write(char c)
		{
			AppendText( c.ToString() );
		}

		public override void Write(String s)
		{
			AppendText( s );
		}

		private void AppendText( string s )
		{
            if (s.Length == 0)
                return;
            int index = 0;
            myRTFDoc.AppendText("{\\intbl\\fs16");
            if (s.StartsWith("[ERROR]"))
            {
                index = myRTFDoc.UseColor(Color.Red);
                myRTFDoc.AppendText("\\cf" + index + " ");
            }
            else if (s.StartsWith("[ WARN]"))
            {
                index = myRTFDoc.UseColor(Color.DarkOrange);
                myRTFDoc.AppendText("\\cf" + index + " ");
            }
            else if (s.StartsWith("[DEBUG]"))
            {
                index = myRTFDoc.UseColor(Color.Green);
                myRTFDoc.AppendText("\\cf" + index + " ");
            }
            else if (s.StartsWith("[ INFO]"))
            {
                index = myRTFDoc.UseColor(Color.Blue);
                myRTFDoc.AppendText("\\cf" + index + " ");
            }
            myRTFDoc.AppendText(s);
            myRTFDoc.AppendText("\\row}");


            if (s.IndexOf("]") > 0)
            {
                try
                {
                    //this one is different than Taxbuilders' it has incoming [MainUI] instead of 1 or whatever
                    string s1 = s.Substring(s.IndexOf("]") + 3, s.IndexOf("]", s.IndexOf("]") + 1) - s.IndexOf("]") - 3);
                    if (s1 == "MainUI")
                    {
                        textBox.Rtf = myRTFDoc.ToString();
                        textBox.SelectionStart = this.textBox.TextLength;
                        textBox.ScrollToCaret();
                    }
                }
                catch (Exception)
                {
                }
            }
		}
        public void UpdateRTFOnMainThread()
        {
            textBox.Rtf = myRTFDoc.ToString();
            textBox.SelectionStart = this.textBox.TextLength;
            textBox.ScrollToCaret();
        }

		public override void WriteLine(string s)
		{
			AppendText( s );
		}

		public override Encoding Encoding
		{
			get { return Encoding.Default; }
		}

		public override Object InitializeLifetimeService()
		{
			return null;
		}
	}
    public class RtfDocument
	{
		private RtfFontTable fonttbl;
		private RtfColorTable colortbl;
		private string header;
		private string document;

		public RtfDocument()
		{
			//
			// TODO: Add constructor logic here
			//
			header = "{\\rtf1";
			fonttbl = new RtfFontTable();
			colortbl = new RtfColorTable();
		}

		public override string ToString()
		{
			//header += fonttbl.ToString() + colortbl.ToString();
			return header + fonttbl.ToString() + colortbl.ToString() + "{" + document + "{\\intbl\\row}}}";
		}

		public void AppendText(string text)
		{
			document += text;
		}

		public int UseFont(string fontName)
		{
			return fonttbl.UseFont(fontName);
		}

		public int UseColor(Color fromArgb)
		{
			return colortbl.UseColor(fromArgb);
		}
	}
    public class RtfColorTable
	{
		private int numberOfColors = 0;
		private string colortbl;
        private Dictionary<Color, int> loadedColors = new Dictionary<Color, int>();

		public RtfColorTable()
		{
			//
			// TODO: Add constructor logic here
			//
			colortbl = "{\\colortbl;";
		}

		public int UseColor(Color key)
		{
			if (loadedColors.ContainsKey(key))
			{
				return loadedColors[key];
			}
			else
			{
				colortbl += "\\red" + key.R + "\\green" + key.G + "\\blue" + key.B + ";";
				loadedColors.Add(key, ++numberOfColors);
				return numberOfColors;
			}
		}

		public override string ToString()
		{
			return colortbl + "}";
		}
	}
    public class RtfFontTable
	{
		private int numberOfFonts = 0;
		private string fonttbl;
        private Dictionary<string, int> loadedFonts = new Dictionary<string, int>();

		public RtfFontTable()
		{
			//
			// TODO: Add constructor logic here
			//

			fonttbl = "{\\fonttbl{\\f0\\froman Times New Roman;}";
		}

		public int UseFont(string fontName)
		{
			if (loadedFonts.ContainsKey(fontName))
			{
				return loadedFonts[fontName];
			}
			else
			{
				fonttbl += "{\\f" + (++numberOfFonts) + "\\fnil " + fontName + ";}";
				loadedFonts.Add(fontName, numberOfFonts);
				return numberOfFonts;
			}
		}


		public override string ToString()
		{
			return fonttbl + "}";
		}

	}
}

