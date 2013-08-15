using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using TaxApp.IntrinsicFunctions;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.GraphicObjects;
using TaxApp.WinformRuntimeGraphics;
using log4net;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.CompositeUI;
using TaxBuilder.GraphicObjects.TaxAppRuntime;

namespace TestHarness.CABModule
{
 	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
    [SmartPart]
	public class PageSurfaceView : System.Windows.Forms.UserControl
	{
		private static readonly ILog theLogger = LogManager.GetLogger("PageSurfaceView");
        
        private IContainer components;
        #region Events
        public event LinkClickEvent linkClicked = null;
        public delegate void LinkClickEvent(int LinkedPageID, int LinkedGraphicID, int RecordLineage, bool IsDetail, int GraphicIDOfColumn, int PageIDOfGraphic, int RowIndex);
        
		public event UpdatedValue updatedValue = null;
		public delegate void UpdatedValue(IAmARunTimeControl sender);

		public event RequestSetValues requestSetValues = null;
		public delegate void RequestSetValues(ControlCollection controlsToBeSet);

		public event SelectDataSource selectDataSource = null;
        public delegate void SelectDataSource(IAmARunTimeControl sender, bool bClearOverride, int gridRowInd, int gridColInd);

        public event LoopDataUpdated loopDataUpdated = null;
        public delegate void LoopDataUpdated(int graphicRunTimeID);
        #endregion Events
        #region Data Members
        private Rectangle myBounds = new Rectangle(0, 0,  ConstantsInInterface.SurfaceBoundWidth * 3 * ConstantsInInterface.DefaultResolution/100, 
			 ConstantsInInterface.SurfaceBoundHeight * 3 * ConstantsInInterface.DefaultResolution /100);
        private Rectangle myImageSurfaceBounds = new Rectangle(1, 1, 120, 120); // Thumbnail size for designer.
		private float myZoom = 1F;
		private float myScale100 = 1F;
		private float myScale = 1F;
        private Bitmap myShortCutBitmap = null;
        private Bitmap myDataLinkBitmap = null;
        private Bitmap myOverrideRedBitmap = null;
        private Bitmap myOverrideBlueBitmap = null;
        private RunTimePage myRunTimePage= new RunTimePage();
        private int myShadowDepth = 4;
        private Color myShadowColor = Color.Black;
        private Color myOutlineColor = Color.SteelBlue;
        private Color myImageBackColor = Color.White;
        private ContextMenuStrip contextMenuControl;
        private ToolStripMenuItem dataLinksToolStripMenuItem;
        private ToolStripMenuItem dataSourceValuesToolStripMenuItem;
        private UserConfigurationItems myUserConfigItems;
        private ToolStripMenuItem gotoSourceToolStripMenuItem;
        private bool myHaveLoadedFieldsOnceAlready = false;
        public UserConfigurationItems UserConfigItems { get { return myUserConfigItems; } set { myUserConfigItems = value; } }
        private RunTimeNode myRunTimeNode;
        #endregion Private
        #region Properties
        public Color OutlineColor { get { return myOutlineColor; } set { myOutlineColor = value; } }
        public int ShadowDepth { get { return myShadowDepth; } set { myShadowDepth = value; } }
        public RunTimePage RunTimePage
        {
            get { return myRunTimePage; }
            set { myRunTimePage = value; }
        }
        public RunTimeNode RunTimeNode
		{
			get{return myRunTimeNode;}
			set{myRunTimeNode = value;}
		}
        public float Zoom { get { return myZoom; } set { myZoom = value; } }
        #endregion
        public PageSurfaceView()
		{
			InitializeComponent();

            InitBitmaps();
            Graphics g = this.CreateGraphics();
            int nHorizRes = (int)(g.DpiX);
            myScale100 = nHorizRes / (float)ConstantsInInterface.DefaultResolution;
            myScale = myZoom * myScale100;

            SetSize();

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

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.contextMenuControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSourceValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuControl
            // 
            this.contextMenuControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataLinksToolStripMenuItem,
            this.dataSourceValuesToolStripMenuItem,
            this.gotoSourceToolStripMenuItem});
            this.contextMenuControl.Name = "contextMenuControl";
            this.contextMenuControl.Size = new System.Drawing.Size(168, 92);
            this.contextMenuControl.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuControl_Opening);
            // 
            // dataLinksToolStripMenuItem
            // 
            this.dataLinksToolStripMenuItem.Name = "dataLinksToolStripMenuItem";
            this.dataLinksToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.dataLinksToolStripMenuItem.Text = "Data Links";
            // 
            // dataSourceValuesToolStripMenuItem
            // 
            this.dataSourceValuesToolStripMenuItem.Name = "dataSourceValuesToolStripMenuItem";
            this.dataSourceValuesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.dataSourceValuesToolStripMenuItem.Text = "Data Source Values";
            // 
            // gotoSourceToolStripMenuItem
            // 
            this.gotoSourceToolStripMenuItem.Name = "gotoSourceToolStripMenuItem";
            this.gotoSourceToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gotoSourceToolStripMenuItem.Text = "Goto Source";
            this.gotoSourceToolStripMenuItem.Click += new System.EventHandler(this.gotoSourceToolStripMenuItem_Click);
            // 
            // PageSurfaceView
            // 
            this.Name = "PageSurfaceView";
            this.Size = new System.Drawing.Size(640, 480);
            this.Load += new System.EventHandler(this.TaxAppSurface_Load);
            this.contextMenuControl.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	
		#region "Transform/Convert Utility Methods"
		//this is a direct copy from the FormSurface from the designSurface project
    	protected Rectangle ZoomRectangle(Rectangle originalRect)
		{
			RectangleF myNewRectF = new RectangleF(originalRect.X * myScale, 
				originalRect.Y * myScale, 
				originalRect.Width * myScale, 
				originalRect.Height * myScale);
			return Rectangle.Round(myNewRectF);
		}
		#endregion

		#region "Draw Methods"
		private void SetSize()
		{
            if (myRunTimePage.BackGroundImage != null)
                myBounds = new Rectangle(0, 0, myRunTimePage.BackGroundImage.Width, myRunTimePage.BackGroundImage.Height);
			Rectangle bounds = ZoomRectangle(myBounds);
			if (AutoScrollMinSize.Height != bounds.Height && AutoScrollMinSize.Width != bounds.Width)
			{
				AutoScrollMinSize = new Size(bounds.Width, bounds.Height);
			}
		}
		private void DrawBKColor(Graphics g)
		{
			Color bgroundcolor = Color.White;
			Color forecolor = Color.White;
			switch (myRunTimePage.PageType)
			{
				case PageTypeEnum.Organizer:
					bgroundcolor = myUserConfigItems.OrganizerBackGroundColor;
					forecolor= myUserConfigItems.OrganizerPageColor;
					break;
				case PageTypeEnum.Workpaper:
					bgroundcolor = myUserConfigItems.WorkpaperBackGroundColor;
					forecolor= myUserConfigItems.WorkpaperPageColor;
					break;
                case PageTypeEnum.Form:
					bgroundcolor = myUserConfigItems.TaxFormBackGroundColor;
					forecolor= myUserConfigItems.TaxFormPageColor;
					break;
			}
			g.Clear(bgroundcolor);
			g.FillRectangle(new SolidBrush(forecolor), myBounds);
		}
		
		private void DrawWMF(Graphics g)
		{
			if (myRunTimePage.BackGroundImage != null)
                g.DrawImage(myRunTimePage.BackGroundImage, 0, 0, myRunTimePage.BackGroundImage.Width, myRunTimePage.BackGroundImage.Height);    // in pixel size
		}

		protected override void OnPaint(PaintEventArgs e)
		{
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;
            g.PageScale = 1;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
            g.ScaleTransform(myScale, myScale);

            DrawBKColor(e.Graphics);
            DrawWMF(e.Graphics);
		}
        
        //I honestly don't know if this is gonig to matter...
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            if (e.AffectedControl == this)
            {
                SetSize();
                if (myRunTimePage.BackGroundImage != null)
                {
                    myImageSurfaceBounds.Width = myRunTimePage.BackGroundImage.Width;
                    myImageSurfaceBounds.Height = myRunTimePage.BackGroundImage.Height;
                }
                else if (this.Controls.Count > 0)
                {
                    myImageSurfaceBounds.Width = 3300;
                    myImageSurfaceBounds.Height = 2550;
                    // No WMF.  Set size to standard 8 1/2 x 11 page size
                    //if (myRunTimePage.PageProperties.Orientation  myPageProperties.Orientation == PaperOrientationEnum.Landscape)
                    //{
                    //    myImageSurfaceBounds.Width = 3300;
                    //    myImageSurfaceBounds.Height = 2550;
                    //}
                    //else
                    //{
                    //    // If page properties were not set, default to Portrait
                    //    myImageSurfaceBounds.Width = 2550;
                    //    myImageSurfaceBounds.Height = 3300;
                    //}
                }
                SuspendLayout();
                this.Width = (int)Math.Ceiling((((float)myImageSurfaceBounds.Width) * myScale) + myShadowDepth + 2);
                this.Height = (int)Math.Ceiling((((float)myImageSurfaceBounds.Height) * myScale) + myShadowDepth + 2);
                PerformLayout();
                Invalidate();
            }
        }
		#endregion

        public void BuildGraphics(RunTimePage runTimePage)
        {
            myRunTimePage = runTimePage;
            HookUpRunTimeGraphics();
        }
        private void AddPictureControlForShortCut(GraphicObject go)
        {
            if (!go.IsShortCut)
                return;

            PictureBox pictBox = new PictureBoxRT();
            Rectangle shortcutRect = go.GetShortcutRect();
            //move the shortcut to the left of the graphic object
            pictBox.Location = new Point(go.X - shortcutRect.Width, go.Y);
            pictBox.Size = shortcutRect.Size;
            pictBox.BackgroundImage = myShortCutBitmap;
            pictBox.Scale(new SizeF(myScale, myScale));
            pictBox.Tag = new PictureBoxInfo(ImageIndicatorType.Shortcut, go.LinkedPageID, go.LinkedGraphicID);
            pictBox.DoubleClick += new EventHandler(pictBox_DoubleClick);
            this.Controls.Add(pictBox);
        }

        void pictBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox shortcut = sender as PictureBox;
            if (shortcut == null)
                return;
            if (linkClicked != null)
                linkClicked(((PictureBoxInfo)(shortcut.Tag)).ShortcutLinkedPageID, ((PictureBoxInfo)(shortcut.Tag)).ShortcutLinkedGOID, 0, false, 0, 0, 0);
        }
        private void AddPictureControlForOverrideIndicator(Point pt, bool bSameValue, Color backColor)
        {
            //draw the override indicator on the right top side of the control
            PictureBox pictBox = new PictureBoxRT();
            pictBox.Location = pt;
            if (bSameValue)
                pictBox.BackgroundImage = myOverrideBlueBitmap;
            else
                pictBox.BackgroundImage = myOverrideRedBitmap;
            pictBox.Size = myOverrideRedBitmap.Size;
            //all are calculated with the control which is scaled, so don't need to scale for it. However, if add zoom, then need to scale it with the zoom
            //pictBox.Scale(new SizeF(myScale, myScale));
            pictBox.Tag = new PictureBoxInfo(ImageIndicatorType.Override, 0, 0);
            pictBox.BackColor = backColor;

            this.Controls.Add(pictBox);
        }
        private void AddPictureControlForOverrideIndicator(IAmARunTimeControl c, bool bSameValue)
        {
            Point pictPoint =  new Point(((Control)c).Right, ((Control)c).Top + ((Control)c).Height / 2 - myOverrideRedBitmap.Height / 2);
            if (c is OptionButtonGraphicRT)
            {
                Control ctrl = c as Control;
                if (ctrl.Parent != null)
                    pictPoint = new Point(ctrl.Parent.Right, ((Control)c).Top + ctrl.Parent.Top + ((Control)c).Height / 2 - myOverrideRedBitmap.Height / 2);
            }
            AddPictureControlForOverrideIndicator(pictPoint, bSameValue, Color.Transparent);
        }
        private void AddGridColumnDataLinksToControl(GridGraphicRT grid, DataGridViewColumn col)
        {
            int subgraphicID = Convert.ToInt32(col.Name);
            if (!myRunTimePage.DataLinks.ContainsKey(subgraphicID))
                return;

            PictureBox pictBox = new PictureBoxRT();
            int nColX = grid.Left+ grid.RowHeadersWidth;
            for (int n = 0; n < col.Index; n++)
                nColX += grid.Columns[n].Width;

            pictBox.Location = new Point(nColX - (int)(TaxBuilder.GraphicObjects.Constants.ControlMinSize * myScale), grid.Top + grid.ColumnHeadersHeight - (int)(TaxBuilder.GraphicObjects.Constants.ControlMinSize * myScale));
            pictBox.Size = new Size((int)(TaxBuilder.GraphicObjects.Constants.ControlMinSize * myScale), (int)(TaxBuilder.GraphicObjects.Constants.ControlMinSize * myScale));
            pictBox.BackgroundImage = myDataLinkBitmap;
            pictBox.BackColor = grid.ColumnHeadersDefaultCellStyle.BackColor;
            //all are calculated with the control which is scaled, so don't need to scale for it. However, if add zoom, then need to scale it with the zoom
            //pictBox.Scale(new SizeF(myScale, myScale));
            pictBox.Tag = new PictureBoxInfo(ImageIndicatorType.DataLink, 0, 0);
            this.Controls.Add(pictBox);
        }
        private void AddDataLinksToControl(GraphicObject go)
        {
            if (myRunTimePage.DataLinks.ContainsKey(go.GraphicObjectID))
            {
                //it has one - just put an indicator on the graphic

                PictureBox pictBox = new PictureBoxRT();
                Rectangle shortcutRect = go.GetShortcutRect();
                //move the shortcut to the left of the graphic object
                pictBox.Location = new Point(go.X - shortcutRect.Width, go.Y + go.Height - shortcutRect.Height);
                pictBox.Size = shortcutRect.Size;
                pictBox.BackgroundImage = myDataLinkBitmap;
                //all are calculated with the go which is not scaled, so need to scale it
                pictBox.Scale(new SizeF(myScale, myScale));
                pictBox.Tag = new PictureBoxInfo(ImageIndicatorType.DataLink, 0, 0);
                pictBox.BringToFront();
                this.Controls.Add(pictBox);
            }
        }
        private void ClearOverrideControls()
        {
            for (int n = this.Controls.Count; n > 0; n--)
            {
                Control c = Controls[n - 1];
                if (c is PictureBoxRT && ((PictureBoxInfo)(c.Tag)).ImageIndicator == ImageIndicatorType.Override)
                    this.Controls.Remove(c);
            }
        }
        private bool HandleGridOverrideIndicator(GridGraphicRT grid)
        {
            bool bDrawIndicator = false;
            if (grid.CurrentDataTable == null || grid.CurrentDataTable.Rows.Count == 0)
                return bDrawIndicator;
            int nCurrentXPos = grid.Left + grid.RowHeadersWidth;
            for (int col = 0; col < grid.Columns.Count; col++)
            {
                nCurrentXPos += grid.Columns[col].Width;
                int nCurrentYPos = grid.Top + grid.ColumnHeadersHeight;

                OverrideIndicatorEnum overrideCol = OverrideIndicatorEnum.Never;
                GraphicObject go = (GraphicObject)grid.Columns[col].Tag;
                if (go is TextBoxGraphic)
                    overrideCol = ((TextBoxGraphic)go).OverrideIndicator;
                else if (go is DropDownListGraphic)
                    overrideCol = ((DropDownListGraphic)go).OverrideIndicator;
                else if (go is CheckBoxGraphic)
                    overrideCol = ((CheckBoxGraphic)go).OverrideIndicator;
                if (overrideCol == OverrideIndicatorEnum.Never)
                    continue;
                int rowCount = grid.RowCount - 1;
                if (grid.Rows[grid.RowCount - 1].HeaderCell.Value.ToString() == "Total")
                    rowCount--;
                for (int row = 0; row < rowCount; row++)
                {
                    bool bSame = false;
                    if (grid.CurrentDataTable.Rows[row][col] == DBNull.Value)
                        continue;
                    bool bAdd = NeedAddOverrideIndicator(((ValueWithDataSources)grid.CurrentDataTable.Rows[row][col]), overrideCol, out bSame);
                    if (bAdd)
                    {
                        Point pictPoint = new Point(nCurrentXPos - myOverrideRedBitmap.Width, nCurrentYPos + grid.Rows[row].Height / 2 - myOverrideRedBitmap.Height / 2);
                        AddPictureControlForOverrideIndicator(pictPoint, bSame, grid.DefaultCellStyle.BackColor);
                        bDrawIndicator = true;
                    }
                    nCurrentYPos += grid.Rows[row].Height;
                }
            }
            return bDrawIndicator;
        }
        private bool NeedAddOverrideIndicator(ValueWithDataSources currentVal, OverrideIndicatorEnum overrideInd, out bool bSame)
        {
            if (null == currentVal)
            {
                bSame = false;
                return false;
            }
            bool bAdd = false;
            bSame = false;
            switch (currentVal.DataSource)
            {
                case DataSourceEnum.Override:
                    {
                        bAdd = true;
                        ValueWithDataSources computeVal = null;
                        foreach (ValueWithDataSources value in currentVal.OtherDataSources)
                        {
                            if (value.DataSource == DataSourceEnum.Compute || value.DataSource == DataSourceEnum.Consolidation)
                            {
                                computeVal = value;
                                break;
                            }
                        }
                        if (computeVal != null && currentVal.Value.ToString() == computeVal.Value.ToString())
                            bSame = true;
                    }
                    break;
                case DataSourceEnum.DataEntry:
                    if (overrideInd == OverrideIndicatorEnum.AnyDataEntry)
                        bAdd = true;
                    break;
                default:
                    break;
            }
            return bAdd;
        }
        private bool HandleOverrideIndicator(Control c)
        {
            IAmARunTimeControl irt = c as IAmARunTimeControl;
            if (irt == null)
                return false;
            if (irt is GridGraphicRT)
            {
                return HandleGridOverrideIndicator((GridGraphicRT)irt);
            }
            else
            {
                if (irt.RuntimeGraphicID != 0 && irt.OverrideIndicator != OverrideIndicatorEnum.Never)
                {
                    bool bSame = false;
                    bool bAdd = NeedAddOverrideIndicator(irt.CurrentValue, irt.OverrideIndicator, out bSame);
                    if (bAdd)
                        AddPictureControlForOverrideIndicator(irt, bSame);
                }
            }
            return false;
        }
        public void HandleOverrideIndicator()
        {
            ArrayList sendBackControls = new ArrayList();
            ClearOverrideControls();
            foreach (Control c in this.Controls)
            {
                if (c is OptionGroupGraphicRT)
                {
                    foreach (Control button in c.Controls)
                        HandleOverrideIndicator(button);
                }
                if (HandleOverrideIndicator(c))
                    sendBackControls.Add(c);
            }
            foreach (Control c in sendBackControls)
                c.SendToBack();
        }

		private void HookUpRunTimeGraphics()
		{
			theLogger.Info(string.Format("Graphics added to GraphicsMatrix: Page Name / ID / RL / Number: {0}/{1}/{2}/{3}", myRunTimeNode.Name, myRunTimePage.PageID, myRunTimePage.RecordLineage, myRunTimePage.GraphicsCollection.Count));
            //add a tooltip control on the form to add tooltip property for other controls
            ToolTip toolTipControl = new ToolTip();

            foreach (GraphicObject go in myRunTimePage.GraphicsCollection)
			{
				try
				{
                    List<int> subGraphicIDs = new List<int>();
					Control c = go.GetRunTimeControl();
                    ((IAmARunTimeControl)c).PageID = this.RunTimePage.PageID;
                    ((IAmARunTimeControl)c).RecordLineage = this.RunTimePage.RecordLineage;
                    c.Scale(new SizeF(myScale, myScale));

                    //set the width and height of the control to be at least one in case after scale, they are 0
                    //this happens for the line graphics
                    c.Height = Math.Max(1, c.Height);
                    c.Width = Math.Max(1, c.Width);
                    //also the grid columns need to be scaled
                    if (c.GetType().ToString().EndsWith("GridGraphicRT"))
                    {
                        ((DataGridView)c).RowHeadersWidth = Convert.ToInt32(((DataGridView)c).RowHeadersWidth * myScale);
                        foreach (DataGridViewColumn dgvc in ((DataGridView)c).Columns)
                        {
                            dgvc.Width = Convert.ToInt32(dgvc.Width * myScale);
                            AddGridColumnDataLinksToControl((GridGraphicRT)c, dgvc);
                        }
                        ((DataGridView)c).CellDoubleClick += new DataGridViewCellEventHandler(TaxAppSurface_CellDoubleClick);
                    }
                    if (((IAmARunTimeControl)c).RuntimeGraphicID > 0)
                    {
                        ((IAmARunTimeControl)c).UpdatedValueEvent += new UpdatedValueEvent(TaxAppSurface_UpdatedValueEvent);
                    }

                    //Setup the context menu
                    if (null != go.GetType().GetInterface("ICanHaveTabIndexAssignedToMe"))
                    {
                        if (go is OptionGroupGraphic)
                        {
                            foreach (Control radio in c.Controls)
                                radio.ContextMenuStrip = this.contextMenuControl;
                        }
                        else
                            c.ContextMenuStrip = this.contextMenuControl;
                    }
                    //grid's individual cell will handle the double click
                    if (!(c.GetType().ToString().EndsWith("GridGraphicRT")) && myRunTimePage.DataLinks.ContainsKey(((IAmARunTimeControl)c).RuntimeGraphicID))
                        c.MouseDoubleClick += new MouseEventHandler(c_MouseDoubleClick);

                    if (go.GetType() == typeof(CheckBoxGraphic))
                    {
                        ((CheckBoxGraphicRT)c).CheckedChanged += new EventHandler(PageSurfaceView_CheckedChanged);
                    }

                    AddPictureControlForShortCut(go);
                    AddDataLinksToControl(go);
					this.Controls.Add(c);


                    //set tooltip property for the control
   					if (null != go.GetType().GetInterface("ICanHaveToolTip"))
                        toolTipControl.SetToolTip(c, ((ICanHaveToolTip)go).ToolTip);
				}
				catch (Exception ex)
				{
					Label l = new Label();
					l.Top = Convert.ToInt32(go.Y * myScale);
					l.Left = Convert.ToInt32(go.X * myScale);
					l.Text = "Error with RunTimeControl: " + go.Name;
					this.Controls.Add(l);
					theLogger.Error("Error with Runtimecontrol; " + go.Name, ex);
				}
			}
            foreach (Control c in this.Controls)
            {
                //TODO: implement some sort of Z-order 
                if (c.GetType() == typeof(FrameGraphicRT))
                    c.SendToBack();
                if (c.GetType() == typeof(DropDownListGraphicRT) || c.GetType() == typeof(GridGraphicRT))
                {
                    ((IAmARunTimeControl)c).SetBindingList();
                }
            }

            //don't have to update field value at this point, the fields value will be updated whenever the tab is selected anyway
            RequestThatAllFieldsBeUpdatedWithCurrentValues();
		}

        void PageSurfaceView_CheckedChanged(object sender, EventArgs e)
        {
            theLogger.Debug("check changed");
        }
        private void SendLinkClickedRequest(int PageID, int GraphicID, int RecordLineage, bool IsDetail, int GraphicIDOfBindingColumn, int PageIDOfGraphic, int RowIndex)
        {
            if (linkClicked != null)
            {
                linkClicked(PageID, GraphicID, RecordLineage, IsDetail, GraphicIDOfBindingColumn, PageIDOfGraphic, RowIndex);
            }
        }

        
 		public void RequestThatAllFieldsBeUpdatedWithCurrentValues()
		{
            this.Focus();
            if (myHaveLoadedFieldsOnceAlready)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType().GetInterface("IAmARunTimeControl") != null)
                    {
                        if (((IAmARunTimeControl)c).HasAComputeAssignment)
                        {
                            requestSetValues(this.Controls);
                            break;
                        }
                    }
                }
            }
            else
            {
                if (requestSetValues != null)
                {
                    requestSetValues(this.Controls);
                }
                myHaveLoadedFieldsOnceAlready = true;
            }
		}

        public IAmARunTimeControl HasGraphic(int GraphicID, out int gridColumnInd)
        {
            gridColumnInd = -1;
            foreach (Control c in Controls)
            {
                IAmARunTimeControl rtc = c as IAmARunTimeControl;
                if (rtc != null)
                {
                    if (rtc is GridGraphicRT)
                    {
                        foreach (DataGridViewColumn col in ((GridGraphicRT)rtc).Columns)
                        {
                            if (Convert.ToInt32(col.Name) == GraphicID)
                            {
                                gridColumnInd = col.Index;
                                return rtc;
                            }
                        }
                    }

                    if (rtc.RuntimeGraphicID == GraphicID)
                    {
                        theLogger.Debug("Selecting GraphicID: " + rtc.RuntimeGraphicID);
                        return rtc;
                    }
                }
            }
            return null;
        }
        public bool SelectGraphic(int GraphicID)
        {
            int gridColumnInd = -1;
            IAmARunTimeControl rtc = HasGraphic(GraphicID, out gridColumnInd);
            if (rtc == null)
                return false;
            if (rtc is GridGraphicRT)
            {
                ((GridGraphicRT)rtc).Select();
                theLogger.Debug("Selecting Grid Column: " + rtc.RuntimeGraphicID);
                if (gridColumnInd != -1)
                    ((GridGraphicRT)rtc)[gridColumnInd, 0].Selected = true;
            }
            else
            {
                theLogger.Debug("Selecting GraphicID: " + rtc.RuntimeGraphicID);
                ((Control)rtc).Select();
            }
            return true;
        }
        public void RequestComputedValueBeUpdated()
        { 
            //TODO:  put all controls that compute in a control collection
            if (requestSetValues != null)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType().GetInterface("IAmARunTimeControl") != null)
                    {
                        if (((IAmARunTimeControl)c).HasAComputeAssignment)
                        {
                            requestSetValues(this.Controls);
                            break;
                        }
                    }
                }
            }
        }
		private void TaxAppSurface_UpdatedValueEvent(IAmARunTimeControl sender)
		{
			//theLogger.Info("UpdatedValueEvent: " + ((Control)sender).Name);
			if ((updatedValue != null) && (((IAmARunTimeControl)sender).RuntimeGraphicID > 0))
			{
                if (sender is OptionGroupGraphicRT)
                {
                    //OptionGroup doesn't need to set/update value, it is handled in the OptionButtons.
                    RequestThatAllFieldsBeUpdatedWithCurrentValues();
                    return;
                }
                updatedValue((IAmARunTimeControl)sender);
                //this is running async - so can't really "wait" for answer to whether or not it is updated.

                //if (updatedValue((IAmARunTimeControl)sender))
                //{
                //    if (sender is OptionButtonGraphicRT)
                //    {
                //        //won't reload all the field values at this point for optionbutton update event to avoid multiple loading and potential wrong data loading
                //        //will load at OptionGroup update event to guarentee all the data have updated and only one time loading for the group
                //        return;
                //    }
                //    else
                //        RequestThatAllFieldsBeUpdatedWithCurrentValues();
                //}
                GridGraphicRT grid = sender as GridGraphicRT;
                if (grid != null)
                {
                    //check if the column has detail link to see if need to refresh the tree
                    for (int n = 0; n < grid.Columns.Count; n++)
                    {
                        int nColRuntimeID = ((GraphicObject)(grid.Columns[n].Tag)).GraphicObjectID;
                        if (myRunTimePage.DataLinks.ContainsKey(nColRuntimeID))
                        {
                            foreach (KeyValuePair<KeyValuePair<int, int>, GraphicDataLinkRecord> keyvalue in myRunTimePage.DataLinks[nColRuntimeID])
                            {
                                if (((GraphicDataLinkRecord)keyvalue.Value).DataLinkType == DataLinkTypeEnum.DetailLink)
                                {
                                    if (loopDataUpdated != null)
                                        loopDataUpdated(nColRuntimeID);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
			}

		}
        private void InitBitmaps()
        {
            try
            {
                this.myShortCutBitmap = Images.ShortCut;
                myShortCutBitmap.MakeTransparent(Color.White);
            }
            catch (Exception ex)
            {
                theLogger.Error("Unable to find shortcut.bmp", ex);
            }
            try
            {
                this.myDataLinkBitmap = Images.DataLink;
                myDataLinkBitmap.MakeTransparent(Color.White);
            }
            catch (Exception ex)
            {
                theLogger.Error("Unable to find DataLink.bmp", ex);
            }
            try
            {
                this.myOverrideRedBitmap = Images.OverrideIndicatorRed;
                myOverrideRedBitmap.MakeTransparent(Color.White);
            }
            catch (Exception ex)
            {
                theLogger.Error("Unable to find OverrideIndicatorRed.bmp", ex);
            }
            try
            {
                this.myOverrideBlueBitmap = Images.OverrideIndicatorBlue;
                myOverrideBlueBitmap.MakeTransparent(Color.White);
            }
            catch (Exception ex)
            {
                theLogger.Error("Unable to find OverrideIndicatorRed.bmp", ex);
            }
         }

        private void TaxAppSurface_Load(object sender, EventArgs e)
        {
            //HookUpRunTimeGraphics();
        }
        public void RefreshLoopGraphicObjectData(int graphicID)
        {
            int dumyInt = -1;
            if (graphicID == 0)
            {
                requestSetValues(this.Controls);
                return;
            }
            if (HasGraphic(graphicID, out dumyInt) != null)
                RequestThatAllFieldsBeUpdatedWithCurrentValues();
        }

        #region context menu
        private IAmARunTimeControl myCurrentControl = null;
        private DataGridView.HitTestInfo myGridHitTestInfo = null;
        private void HandleOptionButtonSelectDataSource(ValueWithDataSources itemValue)
        {
            if (!(myCurrentControl is OptionButtonGraphicRT))
                return;
            ValueWithDataSources newValue = null;
            if (itemValue == null)
            {
                //clear override, set the new value to be the computed one. So need to check if the current value is different from the computed one
                foreach (ValueWithDataSources value in myCurrentControl.CurrentValue.OtherDataSources)
                {
                    if (value.DataSource == DataSourceEnum.Compute)
                    {
                        newValue = value;
                        break;
                    }
                }
            }
            else
                newValue = itemValue;
            if (newValue != null && (bool)myCurrentControl.CurrentValue.Value != (bool)newValue.Value)
            {
                ((OptionButtonGraphicRT)myCurrentControl).Checked = (bool)newValue.Value;

                if (!(bool)newValue.Value)
                {
                    //newValue is false, set another one to be true
                    ((OptionButtonGraphicRT)myCurrentControl).Checked = false;
                    foreach (Control another in ((Control)myCurrentControl).Parent.Controls)
                    {
                        if (myCurrentControl != another)
                        {
                            ((OptionButtonGraphicRT)another).Checked = true;
                            break;
                        }
                    }
                }
            }

            if (itemValue == null)
                selectDataSource(myCurrentControl, true, 0, 0);
            else
            {
                if (myCurrentControl.CurrentValue.DataSource != itemValue.DataSource)
                {
                    myCurrentControl.CurrentValue = itemValue;
                    selectDataSource(myCurrentControl, false, 0, 0);
                }
            }
        }
        private void HandleGridSelectDataSource(ValueWithDataSources itemValue)
        {
            if (myCurrentControl == null || !(myCurrentControl is GridGraphicRT) || myGridHitTestInfo == null || myGridHitTestInfo.Type != DataGridViewHitTestType.Cell)
                return;
            object currentCellVal = ((GridGraphicRT)myCurrentControl).CurrentDataTable.Rows[myGridHitTestInfo.RowIndex][myGridHitTestInfo.ColumnIndex];
            if (currentCellVal == DBNull.Value)
                return;
            if (itemValue == null)
            {
                //clear override
                selectDataSource(myCurrentControl, true, myGridHitTestInfo.RowIndex, myGridHitTestInfo.ColumnIndex);
            }
            else
            {
                if (((ValueWithDataSources)currentCellVal).Value == itemValue.Value && ((ValueWithDataSources)currentCellVal).DataSource == itemValue.DataSource)
                {
                    //select the current one, not changed
                    return;
                }
                ((GridGraphicRT)myCurrentControl).CurrentDataTable.Rows[myGridHitTestInfo.RowIndex][myGridHitTestInfo.ColumnIndex] = itemValue;
                selectDataSource(myCurrentControl, false, myGridHitTestInfo.RowIndex, myGridHitTestInfo.ColumnIndex);
            }
        }

        private void dataLinkmi_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            if (myCurrentControl != null)
            {
                if (myCurrentControl is GridGraphicRT)
                {
                    if (myGridHitTestInfo != null)
                        rowIndex = myGridHitTestInfo.RowIndex;
                }
            }
            bool isDetail = false;
            isDetail = ((GraphicDataLinkRecord)((ToolStripMenuItem)sender).Tag).DataLinkType == DataLinkTypeEnum.DetailLink;
            SendLinkClickedRequest(((GraphicDataLinkRecord)((ToolStripMenuItem)sender).Tag).PageIDKey, ((GraphicDataLinkRecord)((ToolStripMenuItem)sender).Tag).GraphicIDKey, myRunTimePage.RecordLineage, isDetail,
                ((GraphicDataLinkRecord)((ToolStripMenuItem)sender).Tag).BindingColumnGraphicID, myRunTimePage.PageID, rowIndex);
        }
        void dataSourcemi_Click(object sender, EventArgs e)
        {
            if (myCurrentControl != null && selectDataSource != null)
            {
                if (myCurrentControl is OptionButtonGraphicRT)
                    HandleOptionButtonSelectDataSource((ValueWithDataSources)((ToolStripMenuItem)sender).Tag);
                else if (myCurrentControl is GridGraphicRT)
                    HandleGridSelectDataSource((ValueWithDataSources)((ToolStripMenuItem)sender).Tag);
                else
                {
                    if (((ToolStripMenuItem)sender).Tag == null)
                        selectDataSource(myCurrentControl, true, 0, 0);
                    else
                    {
                        if (myCurrentControl.CurrentValue.DataSource != ((ValueWithDataSources)((ToolStripMenuItem)sender).Tag).DataSource)
                        {
                            myCurrentControl.CurrentValue = (ValueWithDataSources)((ToolStripMenuItem)sender).Tag;
                            selectDataSource(myCurrentControl, false, 0, 0);
                        }
                    }
                }
                RequestThatAllFieldsBeUpdatedWithCurrentValues();
            }
        }
        private void contextMenuControl_Opening(object sender, CancelEventArgs e)
        {
            myCurrentControl = (IAmARunTimeControl)this.contextMenuControl.SourceControl;
            if (myCurrentControl == null)
                return;

            int runtimeGraphicID = 0;
            ValueWithDataSources controlValue = null;
            GridGraphicRT grid = myCurrentControl as GridGraphicRT;
            if (grid != null)
            {
                Point pt = grid.PointToClient(Control.MousePosition);
                this.myGridHitTestInfo = grid.HitTest(pt.X, pt.Y);
                if (myGridHitTestInfo.ColumnIndex != -1)
                    runtimeGraphicID = Convert.ToInt32(grid.Columns[myGridHitTestInfo.ColumnIndex].Name);

                if (myGridHitTestInfo.Type != DataGridViewHitTestType.Cell || myGridHitTestInfo.RowIndex == -1 || 
                    myGridHitTestInfo.RowIndex == grid.RowCount - 1 || (grid.NeedTotalRow && myGridHitTestInfo.RowIndex == grid.RowCount -2))
                {
                    e.Cancel = true;
                    return;
                }
                object cellVal = grid.CurrentDataTable.Rows[myGridHitTestInfo.RowIndex][myGridHitTestInfo.ColumnIndex];
                if (cellVal != DBNull.Value)
                    controlValue = cellVal as ValueWithDataSources;
            }
            else
            {
                runtimeGraphicID = myCurrentControl.RuntimeGraphicID;
                controlValue = ((IAmARunTimeControl)(this.contextMenuControl.SourceControl)).CurrentValue;
            }

            if (myRunTimePage.DataLinks.ContainsKey(runtimeGraphicID))
            {
                dataLinksToolStripMenuItem.Enabled = true;
                if (contextMenuControl.Tag == null || (int)(contextMenuControl.Tag) != runtimeGraphicID)
                {
                    contextMenuControl.Tag = runtimeGraphicID;
                    LoadDataLinks(runtimeGraphicID);
                }
            }
            else
                dataLinksToolStripMenuItem.Enabled = false;

            LoadDataSourceValues(controlValue);
            gotoSourceToolStripMenuItem.Enabled = myCurrentControl.IsShortcut;
        }
        private void LoadDataLinks(int runtimeGraphicID)
        {
            this.dataLinksToolStripMenuItem.DropDownItems.Clear();
            foreach (KeyValuePair<KeyValuePair<int, int>, GraphicDataLinkRecord> keyvalue in myRunTimePage.DataLinks[runtimeGraphicID])
            {
                string strMenuText = ((GraphicDataLinkRecord)keyvalue.Value).DisplayPageName;
                if (((GraphicDataLinkRecord)keyvalue.Value).DisplayGraphicName.Length != 0)
                    strMenuText = strMenuText + " - " + ((GraphicDataLinkRecord)keyvalue.Value).DisplayGraphicName;
                if (!((GraphicDataLinkRecord)keyvalue.Value).DirectionIsForward)
                    strMenuText = strMenuText + " - " + " (return to)";
                ToolStripMenuItem mi = new ToolStripMenuItem(strMenuText);
                mi.Tag = (GraphicDataLinkRecord)keyvalue.Value;
                mi.Click += new EventHandler(dataLinkmi_Click);
                this.dataLinksToolStripMenuItem.DropDownItems.Add(mi);
            }
        }
        private void LoadDataSourceValues(ValueWithDataSources controlValue)
        {
            this.dataSourceValuesToolStripMenuItem.DropDownItems.Clear();
            if (controlValue == null)
                return;
            //add the current one
            AddDataSourceValueMenuItem(controlValue, true);
            foreach (ValueWithDataSources value in controlValue.OtherDataSources)
                AddDataSourceValueMenuItem(value, false);
        }
        private void AddDataSourceValueMenuItem(ValueWithDataSources value, bool bCheck)
        {
            ToolStripMenuItem mi = new ToolStripMenuItem(value.DataSource.ToString() + ": " + value.Value.ToString());
            mi.Tag = value;
            mi.Checked = bCheck;
            mi.Click += new EventHandler(dataSourcemi_Click);
            this.dataSourceValuesToolStripMenuItem.DropDownItems.Add(mi);
            if (value.DataSource == DataSourceEnum.Override)
            {
                //if has override value, add clear override menu item
                mi = new ToolStripMenuItem("Clear Override");
                mi.Tag = null;
                mi.Checked = false;
                mi.Click += new EventHandler(dataSourcemi_Click);
                this.dataSourceValuesToolStripMenuItem.DropDownItems.Insert(0, mi);
            }
        }
        private void gotoSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myCurrentControl != null && myCurrentControl.IsShortcut && linkClicked != null)
                linkClicked(myCurrentControl.LinkedPageID, myCurrentControl.LinkedGraphicID, 0, false, 0, 0, 0);
        }
        #endregion

        void TaxAppSurface_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 )
                return;
            GridGraphicRT grid = sender as GridGraphicRT;
            if (grid == null)
                return;
            if (grid.RowCount - 1 == e.RowIndex)
            {
                //last empty row, don't need to handle
                return;
            }
            if (grid.NeedTotalRow && grid.RowCount - 2 == e.RowIndex)
            {
                //the total row, don't need to handle
                return;
            }
            int subgraphicid = Convert.ToInt32(((DataGridView)sender).Columns[e.ColumnIndex].Name);
            if (myRunTimePage.DataLinks.ContainsKey(subgraphicid))
            {
                foreach (KeyValuePair<KeyValuePair<int, int>, GraphicDataLinkRecord> keyvalue in myRunTimePage.DataLinks[subgraphicid])
                {
                    if (((GraphicDataLinkRecord)keyvalue.Value).IsDefault && ((GraphicDataLinkRecord)keyvalue.Value).DirectionIsForward)
                    {
                        bool bDetailLink = false;
                        if (((GraphicDataLinkRecord)keyvalue.Value).DataLinkType == DataLinkTypeEnum.DetailLink)
                            bDetailLink = true;
                        SendLinkClickedRequest(((GraphicDataLinkRecord)keyvalue.Value).PageIDKey, ((GraphicDataLinkRecord)keyvalue.Value).GraphicIDKey, myRunTimePage.RecordLineage, bDetailLink, subgraphicid, this.myRunTimePage.PageID, e.RowIndex);
                        break;
                    }
                }
            }
            //GO BACK?
        }
        void c_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //occurs when someone double clicks a control - find the Default one that is going forward.

            foreach (KeyValuePair<KeyValuePair<int, int>, GraphicDataLinkRecord> keyvalue in myRunTimePage.DataLinks[((IAmARunTimeControl)sender).RuntimeGraphicID])
            {
                if (((GraphicDataLinkRecord)keyvalue.Value).IsDefault && ((GraphicDataLinkRecord)keyvalue.Value).DirectionIsForward)
                {
                    SendLinkClickedRequest(((GraphicDataLinkRecord)keyvalue.Value).PageIDKey, ((GraphicDataLinkRecord)keyvalue.Value).GraphicIDKey, myRunTimePage.RecordLineage, false, 0, 0, 0);
                    return;
                }
            }
            //if it gets here then there isn't a default forward, go with the default back
            foreach (KeyValuePair<KeyValuePair<int, int>, GraphicDataLinkRecord> keyvalue in myRunTimePage.DataLinks[((IAmARunTimeControl)sender).RuntimeGraphicID])
            {
                if (((GraphicDataLinkRecord)keyvalue.Value).IsDefault)
                {
                    SendLinkClickedRequest(((GraphicDataLinkRecord)keyvalue.Value).PageIDKey, ((GraphicDataLinkRecord)keyvalue.Value).GraphicIDKey, myRunTimePage.RecordLineage, false, 0, 0, 0);
                    return;
                }
            }
        }
    }
    public enum ImageIndicatorType
    {
        Shortcut,
        DataLink,
        Override
    }
    public class PictureBoxInfo
    {
        private ImageIndicatorType myImageIndicator = ImageIndicatorType.Shortcut;
        private int myShortcutLinkedPageID = 0;
        private int myShortcutLinkedGOID = 0;

        public PictureBoxInfo(ImageIndicatorType imageIndicator, int shortcutLinkedPageID, int shortcutLinkedGOID)
        {
            myImageIndicator = imageIndicator;
            myShortcutLinkedPageID = shortcutLinkedPageID;
            myShortcutLinkedGOID = shortcutLinkedGOID;
        }
        public ImageIndicatorType ImageIndicator { get { return myImageIndicator; } }
        public int ShortcutLinkedPageID { get { return myShortcutLinkedPageID; } }
        public int ShortcutLinkedGOID { get { return myShortcutLinkedGOID; } }

    }
    public class TBLinkClickedEventArg : EventArgs
    {
        private int myLinkedPageID;
        private int myLinkedGraphicID;
        private int myRecordLineage;
        private bool myIsDetail;
        private int myGraphicIDOfColumn;
        private int myPageIDOfGraphic;
        private int myRowIndex;

        public TBLinkClickedEventArg(int PageID, int GraphicID, int RecordLineage, bool IsDetail, int GraphicIDOfBindingColumn, int PageIDOfGraphic, int RowIndex)
        {
            myLinkedPageID = PageID;
            myLinkedGraphicID = GraphicID;
            myRecordLineage = RecordLineage;
            myIsDetail = IsDetail;
            myGraphicIDOfColumn = GraphicIDOfBindingColumn;
            myPageIDOfGraphic = PageIDOfGraphic;
            myRowIndex = RowIndex;
        }
        public int LinkedGraphicID
        {
            get { return myLinkedGraphicID; }
            set { myLinkedGraphicID = value; }
        }
        public int RecordLineage
        {
            get { return myRecordLineage; }
            set { myRecordLineage = value; }
        }
        public bool IsDetail
        {
            get { return myIsDetail; }
            set { myIsDetail = value; }
        }
        public int GraphicIDOfColumn
        {
            get { return myGraphicIDOfColumn; }
            set { myGraphicIDOfColumn = value; }
        }
        public int PageIDOfGraphic
        {
            get { return myPageIDOfGraphic; }
            set { myPageIDOfGraphic = value; }
        }
        public int RowIndex
        {
            get { return myRowIndex; }
            set { myRowIndex = value; }
        }
        public int LinkedPageID
        {
            get { return myLinkedPageID; }
            set { myLinkedPageID = value; }
        }
    }
}
