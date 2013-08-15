using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{

	public class RunTimeControlUtilities
	{
		public static void SetCommonGraphicProperties(GraphicObject myGraphic, Control RTControl)
		{
			RTControl.Width = myGraphic.Width;
			RTControl.Height = myGraphic.Height;
			RTControl.Top = myGraphic.Y;
			RTControl.Left = myGraphic.X;
			RTControl.Name = myGraphic.Name;
            if (myGraphic.RequiresAUniqueRuntimeGraphicID())
            {
                ((IAmARunTimeControl)RTControl).RuntimeGraphicID = myGraphic.GraphicObjectID;
            }
            else
                ((IAmARunTimeControl)RTControl).RuntimeGraphicID = 0;
		}
		//TODO: the OverScore & UnderScore are currently kind of a Kludge - as the distance between the lines will not scale
		//The lines should be drawn outside of the label's boundaries - as seperate graphics.
		public static void DrawOverScore(PaintEventArgs pe, Control c, OverScoreUnderScoreCharacterEnum OverScoreEnumValue)
		{	
			switch(OverScoreEnumValue)
			{
				case OverScoreUnderScoreCharacterEnum.Dash:
					pe.Graphics.DrawLine(Pens.Black, 0, 0, c.Width, 0);
					break;
				case OverScoreUnderScoreCharacterEnum.EqualsSign:					
					pe.Graphics.DrawLine(Pens.Black, 0, 0, c.Width, 0);
					pe.Graphics.DrawLine(Pens.Black, 0, 2, c.Width, 2);
					break;
				case OverScoreUnderScoreCharacterEnum.None:
					break;
			}			
		}

		public static void DrawUnderScore(PaintEventArgs pe, Control c, OverScoreUnderScoreCharacterEnum UnderScoreEnumValue)
		{
			switch(UnderScoreEnumValue)
			{
				case OverScoreUnderScoreCharacterEnum.Dash:
					pe.Graphics.DrawLine(Pens.Black, 0, c.Height - 1, c.Width, c.Height - 1);
					break;
				case OverScoreUnderScoreCharacterEnum.EqualsSign:
					pe.Graphics.DrawLine(Pens.Black, 0, c.Height - 3, c.Width, c.Height - 3);
					pe.Graphics.DrawLine(Pens.Black, 0, c.Height - 1, c.Width, c.Height - 1);
					break;
				case OverScoreUnderScoreCharacterEnum.None:
					break;
			}			
		}


		
	}

}
