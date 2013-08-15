using System;
using System.Windows.Forms;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
	/// <summary>
	/// Summary description for LabelGraphicRT.
	/// </summary>
	public class FrameGraphicRT : UserControl, IAmARunTimeControl
	{

		public FrameGraphicRT()
		{
            InitializeStyles();
            InitializeGroupBox();
		}

		public FrameGraphicRT(FrameGraphic aFrameGraphic)
		{
            InitializeStyles();
			InitializeGroupBox();

			myGraphic = aFrameGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

			//set any properties on the control that come from the GraphicObject
			this.GroupTitle = myGraphic.Text;
			this.Font = myGraphic.Font;
			this.BackColor = System.Drawing.Color.Transparent;
            this.BorderColor = myGraphic.FrameColor;            
			this.Visible = myGraphic.Visible;
		}
		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
        
        protected override void OnPaint(PaintEventArgs e)
		{
			PaintBack(e.Graphics);
			PaintGroupText(e.Graphics);
		}

		#region IAmARunTimeControl Members

		public int RuntimeGraphicID
		{
			get{return myRunTimeID;}set{myRunTimeID = value;}
		}
        public int PageID
        {
            get { return myPageID; }
            set { myPageID = value; }
        }
        public int RecordLineage
        {
            get { return myRecordLineage; }
            set { myRecordLineage = value; }
        }
        public DataTable CurrentDataTable
        {
            get { return null; }
            set { }
        }
		public ValueWithDataSources CurrentValue
		{
			get{return null;}
			set{}
		}
		public void ResetCurrentValueToLastKnownGoodValue()
		{
			
		}
		public void SetBindingList(){}
		public event UpdatedValueEvent UpdatedValueEvent;
		private void UpdatedValue()
		{
			if (UpdatedValueEvent != null)
			{
				UpdatedValueEvent(this);
			}
		}
        public OverrideIndicatorEnum OverrideIndicator
        {
            get { return OverrideIndicatorEnum.Never; }
        }
        public bool HasAComputeAssignment { get { return false; } }
        public bool IsShortcut { get { return false; } }
        public int LinkedPageID { get { return 0; } }
        public int LinkedGraphicID { get { return 0; } }
        #endregion
        #region Constants

        /// <summary>The sweep angle of the arc.</summary>
        public const int SweepAngle = 90;

        /// <summary>The minimum control height.</summary>
        public const int MinControlHeight = 32;

        /// <summary>The minimum control width.</summary>
        public const int MinControlWidth = 96;

        #endregion
        #region Enumerations

		/// <summary>A special gradient enumeration.</summary>
		public enum GroupBoxGradientMode
		{
			/// <summary>Specifies no gradient mode.</summary>
			None = 4,

			/// <summary>Specifies a gradient from upper right to lower left.</summary>
			BackwardDiagonal = 3,

			/// <summary>Specifies a gradient from upper left to lower right.</summary>
			ForwardDiagonal = 2,

			/// <summary>Specifies a gradient from left to right.</summary>
			Horizontal = 0,

			/// <summary>Specifies a gradient from top to bottom.</summary>
			Vertical = 1
		}

		
		#endregion

		#region Private Variables
        private FrameGraphic myGraphic;
        private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;
		private System.ComponentModel.Container components = null;
		private int myRoundCorners = 10;
		private string myGroupTitle = string.Empty;
		private Color myBorderColor = Color.Black;
		private float myBorderThickness = 1;
		private bool myShadowControl = false;
		private Color myBackgroundColor = Color.Transparent;
		private Color myBackgroundGradientColor = Color.White;
		private GroupBoxGradientMode myBackgroundGradientMode = GroupBoxGradientMode.None;
		private Color myShadowColor = Color.DarkGray;
		private int myShadowThickness = 3;
		private Image myGroupImage = null;
		private Color myCustomGroupBoxColor = Color.White;
		private bool myPaintGroupBox = true;
		private Color myBackColor = Color.Transparent;

		#endregion
        
		#region Properties

		public override System.Drawing.Color BackColor{get{return myBackColor;} set{myBackColor=value; this.Refresh();}}
		public System.Drawing.Color CustomGroupBoxColor{get{return myCustomGroupBoxColor;} set{myCustomGroupBoxColor=value; this.Refresh();}}
		public bool PaintGroupBox{get{return myPaintGroupBox;} set{myPaintGroupBox=value; this.Refresh();}}
		public System.Drawing.Image GroupImage{get{return myGroupImage;} set{myGroupImage=value; this.Refresh();}}
		public System.Drawing.Color ShadowColor{get{return myShadowColor;} set{myShadowColor=value; this.Refresh();}}
		public int ShadowThickness
		{
			get{return myShadowThickness;} 
			set
			{
				if(value>10)
				{
					myShadowThickness=10;
				}
				else
				{
					if(value<1){myShadowThickness=1;}
					else{myShadowThickness=value; }
				}

				this.Refresh();
			}
		}
		public System.Drawing.Color BackgroundColor{get{return myBackgroundColor;} set{myBackgroundColor=value; this.Refresh();}}
		public System.Drawing.Color BackgroundGradientColor{get{return myBackgroundGradientColor;} set{myBackgroundGradientColor=value; this.Refresh();}}
		public GroupBoxGradientMode BackgroundGradientMode{get{return myBackgroundGradientMode;} set{myBackgroundGradientMode=value; this.Refresh();}}
		public int RoundCorners
		{
			get{return myRoundCorners;} 
			set
			{
				if(value>25)
				{
					myRoundCorners=25;
				}
				else
				{
					if(value<1){myRoundCorners=1;}
					else{myRoundCorners=value; }
				}
				
				this.Refresh();
			}
		}
        public string GroupTitle{get{return myGroupTitle;} set{myGroupTitle=value; this.Refresh();}}
		public System.Drawing.Color BorderColor{get{return myBorderColor;} set{myBorderColor=value; this.Refresh();}}
		public float BorderThickness
		{
			get{return myBorderThickness;} 
			set
			{
				if(value>3)
				{
					myBorderThickness=3;
				}
				else
				{
					if(value<1){myBorderThickness=1;}
					else{myBorderThickness=value;}
				}
				this.Refresh();
			}
		}
        public bool ShadowControl{get{return myShadowControl;} set{myShadowControl=value; this.Refresh();}}

		#endregion
        
		#region Initialization

		/// <summary>This method will initialize the controls custom styles.</summary>
		private void InitializeStyles()
		{
			//Set the control styles----------------------------------
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			//--------------------------------------------------------
		}


		/// <summary>This method will initialize the GroupBox control.</summary>
		private void InitializeGroupBox()
		{
			components = new System.ComponentModel.Container();
			this.Resize+=new EventHandler(GroupBox_Resize);
			this.DockPadding.All = 20;
			this.Name = "GroupBox";
			//this.Size = new System.Drawing.Size(368, 288);
		}

	
		#endregion
        #region Private Paint Methods

		/// <summary>This method will paint the group title.</summary>
		/// <param name="g">The paint event graphics object.</param>
		private void PaintGroupText(System.Drawing.Graphics g)
		{
			//Check if string has something-------------
			if(this.GroupTitle==string.Empty){return;}
			//------------------------------------------

			//Set Graphics smoothing mode to Anit-Alias-- 
			g.SmoothingMode = SmoothingMode.AntiAlias;
			//-------------------------------------------

			//Declare Variables------------------
			SizeF StringSize = g.MeasureString(this.GroupTitle, this.Font);
			Size StringSize2 = StringSize.ToSize();
			if(this.GroupImage!=null){StringSize2.Width+=18;}
			int ArcWidth = this.RoundCorners;
			int ArcHeight = this.RoundCorners;
			int ArcX1 = 20;
			int ArcX2 = (StringSize2.Width+34) - (ArcWidth + 1);
			int ArcY1 = 0;
			int ArcY2 = 24 - (ArcHeight + 1);
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			System.Drawing.Brush BorderBrush = new SolidBrush(this.BorderColor);
			System.Drawing.Pen BorderPen = new Pen(BorderBrush, this.BorderThickness);
			System.Drawing.Drawing2D.LinearGradientBrush BackgroundGradientBrush = null;
			System.Drawing.Brush BackgroundBrush = (this.PaintGroupBox) ? new SolidBrush(this.CustomGroupBoxColor) : new SolidBrush(this.BackgroundColor);
			System.Drawing.SolidBrush TextColorBrush = new SolidBrush(this.ForeColor);
			System.Drawing.SolidBrush ShadowBrush = null;
			System.Drawing.Drawing2D.GraphicsPath ShadowPath  = null;
			//-----------------------------------

			//Check if shadow is needed----------
			if(this.ShadowControl)
			{
				ShadowBrush = new SolidBrush(this.ShadowColor);
				ShadowPath = new System.Drawing.Drawing2D.GraphicsPath();
				ShadowPath.AddArc(ArcX1+(this.ShadowThickness-1), ArcY1+(this.ShadowThickness-1), ArcWidth, ArcHeight, 180, SweepAngle); // Top Left
				ShadowPath.AddArc(ArcX2+(this.ShadowThickness-1), ArcY1+(this.ShadowThickness-1), ArcWidth, ArcHeight, 270, SweepAngle); //Top Right
				ShadowPath.AddArc(ArcX2+(this.ShadowThickness-1), ArcY2+(this.ShadowThickness-1), ArcWidth, ArcHeight, 360, SweepAngle); //Bottom Right
				ShadowPath.AddArc(ArcX1+(this.ShadowThickness-1), ArcY2+(this.ShadowThickness-1), ArcWidth, ArcHeight, 90, SweepAngle); //Bottom Left
				ShadowPath.CloseAllFigures();

				//Paint Rounded Rectangle------------
				g.FillPath(ShadowBrush, ShadowPath);
				//-----------------------------------
			}
			//-----------------------------------

			//Create Rounded Rectangle Path------
			path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, SweepAngle); // Top Left
			path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, SweepAngle); //Top Right
			path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, SweepAngle); //Bottom Right
			path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, SweepAngle); //Bottom Left
			path.CloseAllFigures(); 
			//-----------------------------------

			//Check if Gradient Mode is enabled--
			if(this.PaintGroupBox)
			{
				//Paint Rounded Rectangle------------
				g.FillPath(BackgroundBrush, path);
				//-----------------------------------
			}
			else
			{
				if(this.BackgroundGradientMode==GroupBoxGradientMode.None)
				{
					//Paint Rounded Rectangle------------
					g.FillPath(BackgroundBrush, path);
					//-----------------------------------
				}
				else
				{
					BackgroundGradientBrush = new LinearGradientBrush(new Rectangle(0,0,this.Width,this.Height), this.BackgroundColor, this.BackgroundGradientColor, (LinearGradientMode)this.BackgroundGradientMode);
				
					//Paint Rounded Rectangle------------
					g.FillPath(BackgroundGradientBrush, path);
					//-----------------------------------
				}
			}
			//-----------------------------------

			//Paint Borded-----------------------
			g.DrawPath(BorderPen, path);
			//-----------------------------------

			//Paint Text-------------------------
			int CustomStringWidth = (this.GroupImage!=null) ? 44 : 28;
			g.DrawString(this.GroupTitle, this.Font, TextColorBrush, CustomStringWidth, 5);
			//-----------------------------------

			//Draw GroupImage if there is one----
			if(this.GroupImage!=null)
			{
				g.DrawImage(this.GroupImage, 28,4, 16, 16);
			}
			//-----------------------------------

			//Destroy Graphic Objects------------
			if(path!=null){path.Dispose();}
			if(BorderBrush!=null){BorderBrush.Dispose();}
			if(BorderPen!=null){BorderPen.Dispose();}
			if(BackgroundGradientBrush!=null){BackgroundGradientBrush.Dispose();}
			if(BackgroundBrush!=null){BackgroundBrush.Dispose();}
			if(TextColorBrush!=null){TextColorBrush .Dispose();}
			if(ShadowBrush!=null){ShadowBrush.Dispose();}
			if(ShadowPath!=null){ShadowPath.Dispose();}
			//-----------------------------------
		}

		
		/// <summary>This method will paint the control.</summary>
		/// <param name="g">The paint event graphics object.</param>
		private void PaintBack(System.Drawing.Graphics g)
		{
			//Set Graphics smoothing mode to Anit-Alias-- 
			g.SmoothingMode = SmoothingMode.AntiAlias;
			//-------------------------------------------

			//Declare Variables------------------
			int ArcWidth = this.RoundCorners * 2;
			int ArcHeight = this.RoundCorners * 2;
			int ArcX1 = 0;
			int ArcX2 = (this.ShadowControl) ? (this.Width - (ArcWidth + 1))-this.ShadowThickness : this.Width - (ArcWidth + 1);
			int ArcY1 = 10;
			int ArcY2 = (this.ShadowControl) ? (this.Height - (ArcHeight + 1))-this.ShadowThickness : this.Height - (ArcHeight + 1);
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			System.Drawing.Brush BorderBrush = new SolidBrush(this.BorderColor);
			System.Drawing.Pen BorderPen = new Pen(BorderBrush, this.BorderThickness);
			System.Drawing.Drawing2D.LinearGradientBrush BackgroundGradientBrush = null;
			System.Drawing.Brush BackgroundBrush = new SolidBrush(this.BackgroundColor);
			System.Drawing.SolidBrush ShadowBrush = null;
			System.Drawing.Drawing2D.GraphicsPath ShadowPath  = null;
			//-----------------------------------

			//Check if shadow is needed----------
			if(this.ShadowControl)
			{
				ShadowBrush = new SolidBrush(this.ShadowColor);
				ShadowPath = new System.Drawing.Drawing2D.GraphicsPath();
				ShadowPath.AddArc(ArcX1+this.ShadowThickness, ArcY1+this.ShadowThickness, ArcWidth, ArcHeight, 180, SweepAngle); // Top Left
				ShadowPath.AddArc(ArcX2+this.ShadowThickness, ArcY1+this.ShadowThickness, ArcWidth, ArcHeight, 270, SweepAngle); //Top Right
				ShadowPath.AddArc(ArcX2+this.ShadowThickness, ArcY2+this.ShadowThickness, ArcWidth, ArcHeight, 360, SweepAngle); //Bottom Right
				ShadowPath.AddArc(ArcX1+this.ShadowThickness, ArcY2+this.ShadowThickness, ArcWidth, ArcHeight, 90, SweepAngle); //Bottom Left
				ShadowPath.CloseAllFigures();

				//Paint Rounded Rectangle------------
				g.FillPath(ShadowBrush, ShadowPath);
				//-----------------------------------
			}
			//-----------------------------------

			//Create Rounded Rectangle Path------
			path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, SweepAngle); // Top Left
			path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, SweepAngle); //Top Right
			path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, SweepAngle); //Bottom Right
			path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, SweepAngle); //Bottom Left
			path.CloseAllFigures(); 
			//-----------------------------------

			//Check if Gradient Mode is enabled--
			if(this.BackgroundGradientMode==GroupBoxGradientMode.None)
			{
				//Paint Rounded Rectangle------------
				g.FillPath(BackgroundBrush, path);
				//-----------------------------------
			}
			else
			{
				BackgroundGradientBrush = new LinearGradientBrush(new Rectangle(0,0,this.Width,this.Height), this.BackgroundColor, this.BackgroundGradientColor, (LinearGradientMode)this.BackgroundGradientMode);
				
				//Paint Rounded Rectangle------------
				g.FillPath(BackgroundGradientBrush, path);
				//-----------------------------------
			}
			//-----------------------------------

			//Paint Borded-----------------------
			g.DrawPath(BorderPen, path);
			//-----------------------------------

			//Destroy Graphic Objects------------
			if(path!=null){path.Dispose();}
			if(BorderBrush!=null){BorderBrush.Dispose();}
			if(BorderPen!=null){BorderPen.Dispose();}
			if(BackgroundGradientBrush!=null){BackgroundGradientBrush.Dispose();}
			if(BackgroundBrush!=null){BackgroundBrush.Dispose();}
			if(ShadowBrush!=null){ShadowBrush.Dispose();}
			if(ShadowPath!=null){ShadowPath.Dispose();}
			//-----------------------------------
		}

	
		/// <summary>This method fires when the GroupBox resize event occurs.</summary>
		/// <param name="sender">The object the sent the event.</param>
		/// <param name="e">The event arguments.</param>
		private void GroupBox_Resize(object sender, EventArgs e)
		{
			this.Refresh();
		}


		#endregion
	}
}