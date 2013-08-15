using System;
using System.Windows.Forms;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Common;
using log4net;
using Infragistics.Win.UltraDataGridView;
using TaxBuilder.GraphicObjects;

namespace TaxApp.WinformRuntimeGraphics
{
	/// <summary>
	/// GridGraphic - Updated to use the DataGridView
	/// </summary>
	public class GridGraphicRT : DataGridView, IAmARunTimeControl
	{
        private static readonly ILog theLogger = LogManager.GetLogger("GridGraphicRT");
		private System.ComponentModel.Container components = null;
		private GridGraphic myGraphic;
		private int myRunTimeID;
        private int myPageID;
        private int myRecordLineage;
        private bool mySelectCell = false;
        private bool myNeedTotalRow = false;

        public bool NeedTotalRow { get { return myNeedTotalRow; } }

		public GridGraphicRT()
		{
			InitializeComponent();
		}
		public GridGraphicRT(GridGraphic aGridGraphic)
		{
			InitializeComponent();

			myGraphic = aGridGraphic;
			RunTimeControlUtilities.SetCommonGraphicProperties(myGraphic, this);

			this.TabIndex = myGraphic.TabIndex;
            this.AutoGenerateColumns = false;
			for (int i = 0;i < myGraphic.GraphicCollection.Count;i ++)
			{
				foreach (IGraphicsObject go in myGraphic.GraphicCollection)
				{
					if (go.GetGraphicObject().DisplayOrder == i + 1)
					{
                        DataGridViewColumn newCol;

						if (go.GetGraphicObject().GetType() == typeof(TextBoxGraphic))
						{
                            if (((TextBoxGraphic)go.GetGraphicObject()).NeedMaskControl())
                            {
                                newCol = new UltraMaskEditorColumn();
                                ((UltraMaskEditorColumn)newCol).PromptChar = ' ';
                            }
                            else
                            {
                                newCol = new DataGridViewTextBoxColumn();
                                ((DataGridViewTextBoxColumn)newCol).MaxInputLength = ((TextBoxGraphic)go.GetGraphicObject()).Length;
                            }
                            newCol.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)(Enum.Parse(typeof(DataGridViewContentAlignment), "Middle" + ((TextBoxGraphic)go.GetGraphicObject()).TextAlign.ToString()));
                            if (((TextBoxGraphic)go.GetGraphicObject()).WordWrap)
                                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            else
                                newCol.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                            newCol.ReadOnly = ((TextBoxGraphic)go.GetGraphicObject()).ReadOnly;
                            newCol.ToolTipText = ((TextBoxGraphic)go.GetGraphicObject()).ToolTip;
                            if (!myNeedTotalRow)
                                myNeedTotalRow = IsColumnNeedTotalRow(go.GetGraphicObject());
						}
						else if (go.GetGraphicObject().GetType().ToString().EndsWith("CheckBoxGraphic"))
						{
                            newCol = new DataGridViewCheckBoxColumn();
                            ((DataGridViewCheckBoxColumn)newCol).ThreeState = false;
                            newCol.ReadOnly = ((CheckBoxGraphic)go.GetGraphicObject()).ReadOnly;
                            newCol.ToolTipText = ((CheckBoxGraphic)go.GetGraphicObject()).ToolTip;
						}
						else if (go.GetGraphicObject().GetType().ToString().EndsWith("DropDownListGraphic"))
						{
                            newCol = new DataGridViewComboBoxColumn();
                            newCol.DataPropertyName = ((DropDownListGraphic)go.GetGraphicObject()).BoundToValueListID.ToString();
                            newCol.ReadOnly = ((DropDownListGraphic)go.GetGraphicObject()).ReadOnly;
                            newCol.ToolTipText = ((DropDownListGraphic)go.GetGraphicObject()).ToolTip;
						}
						else
						{
							//unknown graphic in the grid
							throw new ArgumentOutOfRangeException("Unknown Graphic Type: " + go.GetGraphicObject().GetType());
						}
                        if (go.GetGraphicObject().IsShortCut)
                        {
                            newCol.Name = go.LinkedGraphicID.ToString();
                        }
                        else
                        {
                            newCol.Name = go.GetGraphicObject().GraphicObjectID.ToString();
                        }
                        newCol.HeaderText = ((TextGraphic)go.GetGraphicObject()).Text;
                        newCol.Width = ((TextGraphic)go.GetGraphicObject()).Width;
                        newCol.DefaultCellStyle.Font = ((TextGraphic)go.GetGraphicObject()).Font;
                        newCol.Visible = ((TextGraphic)go.GetGraphicObject()).Visible;
                        newCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                        newCol.Tag = go.GetGraphicObject();

                        this.Columns.Add(newCol);
                        break;
					}
				}
			}

            this.Visible = myGraphic.Visible;
            this.MultiSelect = false;
            this.AllowUserToAddRows = false;
            this.AutoSizeColumnsMode = myGraphic.Column_Autosize_Mode;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RowHeadersWidth = GridGraphic.GridRowHeaderWidth;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.CellEndEdit += new DataGridViewCellEventHandler(GridGraphicRT_CellEndEdit);
            this.CellBeginEdit += new DataGridViewCellCancelEventHandler(GridGraphicRT_CellBeginEdit);
            this.CellEnter += new DataGridViewCellEventHandler(GridGraphicRT_CellEnter);
            this.RowsRemoved += new DataGridViewRowsRemovedEventHandler(GridGraphicRT_RowsRemoved);
            this.DefaultValuesNeeded += new DataGridViewRowEventHandler(GridGraphicRT_DefaultValuesNeeded);
            this.CurrentCellDirtyStateChanged += new EventHandler(GridGraphicRT_CurrentCellDirtyStateChanged);
            this.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(GridGraphicRT_EditingControlShowing);
            this.UserDeletingRow += new DataGridViewRowCancelEventHandler(GridGraphicRT_UserDeletingRow);
		}

        void GridGraphicRT_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //won't delete the new row and total row
            if (e.Row.Index == this.RowCount - 1)
                e.Cancel = true;
            if (this.myNeedTotalRow)
            {
                if (e.Row.Index == this.RowCount - 2)
                    e.Cancel = true;
            }
            if (DialogResult.No == MessageBox.Show("You are deleting the data of the row. If the data is part of any looping data, the node and all descendant nodes will be deleted. Do you want to continue?", "Delete Row", MessageBoxButtons.YesNo))
                e.Cancel = true;
        }

        void GridGraphicRT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl textBox = e.Control as DataGridViewTextBoxEditingControl;
            if (textBox != null)
            {
                TextBoxGraphic textGO = (TextBoxGraphic)this.Columns[this.CurrentCell.ColumnIndex].Tag;

                switch (textGO.Case)
                {
                    case CaseEnum.AsEntered:
                        textBox.CharacterCasing = CharacterCasing.Normal;
                        break;
                    case CaseEnum.ConvertToUPPERCASE:
                        textBox.CharacterCasing = CharacterCasing.Upper;
                        break;
                    case CaseEnum.ConvertTolowercase:
                        textBox.CharacterCasing = CharacterCasing.Lower;
                        break;
                }
                textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            }
        }

        void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxGraphic textGO = (TextBoxGraphic)this.Columns[this.CurrentCell.ColumnIndex].Tag;
            if (textGO.AllowChar == AllowCharEnum.AlphabetOnly)
            {
                if (e.KeyChar <= 'z' && e.KeyChar >= 'a' || e.KeyChar <= 'Z' && e.KeyChar >= 'A' || e.KeyChar == ((char)(Keys.Back)))
                    return;
                else
                    e.Handled = true;
            }
        }

        void GridGraphicRT_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.IsCurrentCellDirty)
            {
                DataGridViewColumn col = this.Columns[this.CurrentCell.ColumnIndex];
                if (col is DataGridViewComboBoxColumn || col is DataGridViewCheckBoxColumn)
                {
                    //for check box and dropdown columns, save value right way when data is changed instead of waiting to leave the cell as the textbox column
                    this.CurrentCell.Value = this.CurrentCell.EditedFormattedValue;
                    GridGraphicRT_CellEndEdit(sender, new DataGridViewCellEventArgs(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex));
                }
            }
        }
        private object GetColumnDefaultValue(int col)
        {
            GraphicObject go = (GraphicObject)this.Columns[col].Tag;
            if (go is CheckBoxGraphic)
               return ((CheckBoxGraphic)go).Checked;
            if (go is DropDownListGraphic)
                return ((DropDownListGraphic)go).DefaultValue;
            TextBoxGraphic textGo = go as TextBoxGraphic;
            if (textGo != null)
            {
                ((TextBoxGraphic)go).Text = ((TextBoxGraphic)go).DefaultValue;
                string strFormatText = ((TextBoxGraphic)go).FormattedText;
                if (strFormatText != string.Empty)
                    return strFormatText;
            }
            return null;
        }

        void GridGraphicRT_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            for (int n = 0; n < this.ColumnCount; n++)
                e.Row.Cells[n].Value = GetColumnDefaultValue(n);
        }

        void GridGraphicRT_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            myCurrentDataTable.Rows[e.RowIndex].Delete();
            FireUpdatedEvent();
        }
        void GridGraphicRT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            mySelectCell = true;
        }

        void GridGraphicRT_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (mySelectCell)
            {
                mySelectCell = false;
                return;
            }
            GraphicObject go = (GraphicObject)this.Columns[e.ColumnIndex].Tag;
            TextBoxGraphic tb = go as TextBoxGraphic;
            if (tb != null && tb.NeedMaskControl())
            {
                if (tb.DataType == TextBoxFieldDataTypeEnum.Date)
                {
                    for (int n = 0; n < this.RowCount; n++)
                    {
                        try
                        {
                            DateTime date = Convert.ToDateTime(this[e.ColumnIndex, n].Value.ToString());
                            this[e.ColumnIndex, n].Value = date.ToShortDateString();
                        }
                        catch
                        {
                        }
                    }
                }
                SetMask(tb, e.ColumnIndex, true);
            }
        }

        void GridGraphicRT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (myCurrentDataTable != null && e.RowIndex == myCurrentDataTable.Rows.Count)
            {
                //new row
                myCurrentDataTable.Rows.Add(myCurrentDataTable.NewRow());
            }

            GraphicObject goCol = (GraphicObject)(this.Columns[e.ColumnIndex].Tag);
            bool bInvalidData = false;
            ValueWithDataSources currentCellValue = null;
            if (this.myCurrentDataTable.Rows[e.RowIndex][e.ColumnIndex] != DBNull.Value)
            {
                currentCellValue = (ValueWithDataSources)this.myCurrentDataTable.Rows[e.RowIndex][e.ColumnIndex];
            }
            else
            {
                currentCellValue = new ValueWithDataSources(null, DataSourceEnum.DataEntry, null);
                this.myCurrentDataTable.Rows[e.RowIndex][e.ColumnIndex] = currentCellValue;
            }
            currentCellValue.HasChanged = true;
            DataSourceEnum newDataSource = DataSourceEnum.DataEntry;
            if (currentCellValue.HasComputeDataSource())
                newDataSource = DataSourceEnum.Override;

            if (goCol is TextBoxGraphic)
            {
                bool bValueChanged = true;
                string strVal = string.Empty;
                if (this[e.ColumnIndex, e.RowIndex].Value != null)
                    strVal = this[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (((TextBoxGraphic)goCol).NeedMaskControl())
                {
                    if (((TextBoxGraphic)goCol).DataType == TextBoxFieldDataTypeEnum.Date)
                    {
                        try
                        {
                            DateTime date = Convert.ToDateTime(strVal);
                        }
                        catch
                        {
                            strVal = strVal.Insert(2, "/");
                            strVal = strVal.Insert(5, "/");
                        }
                    }
                    else
                        strVal = TextBoxDataUitl.RemoveMask(strVal);
                }

                try
                {
                    switch (((TextBoxGraphic)goCol).DataType)
                    {
                        case TextBoxFieldDataTypeEnum.Money:
                        case TextBoxFieldDataTypeEnum.Integer:
                        case TextBoxFieldDataTypeEnum.Ratio:
                            decimal num = Convert.ToDecimal(strVal);
                            if (!TextBoxDataUitl.DataInRange((TextBoxGraphic)goCol, num))
                                bInvalidData = true;
                            else
                            {
                                if (currentCellValue.Value != null && num.ToString() == currentCellValue.Value.ToString())
                                    bValueChanged = false;
                                strVal = num.ToString();
                            }
                            break;
                        case TextBoxFieldDataTypeEnum.Date:
                            DateTime date = Convert.ToDateTime(strVal);
                            TextBoxDataUitl.DataInRange((TextBoxGraphic)goCol, ref date);
                            if (currentCellValue.Value!= null && date.ToString() == currentCellValue.Value.ToString())
                                bValueChanged = false;
                            strVal = date.ToShortDateString();
                            break;
                        default:
                            if (currentCellValue.Value != null && strVal == currentCellValue.Value.ToString())
                                bValueChanged = false;
                            break;
                    }
                    SetMask((TextBoxGraphic)goCol, e.ColumnIndex, false);
                }
                catch
                {
                    MessageBox.Show("Invalid data for " + ((TextBoxGraphic)goCol).DataType.ToString() + " format.", "Invalid Entry");
                    bInvalidData = true;
                }
                if (bInvalidData)
                {
                    this.Focus();
                    return;
                }
                if (!bValueChanged && currentCellValue.DataSource == newDataSource)
                {
                    //value is not changed, don't need to save, however, need to set the column with the formatted text
                    for (int n = 0; n < this.CurrentDataTable.Rows.Count; n++)
                    {
                        ((TextBoxGraphic)goCol).Text = ((ValueWithDataSources)this.CurrentDataTable.Rows[n][e.ColumnIndex]).Value.ToString();
                        this[e.ColumnIndex, n].Value = ((TextBoxGraphic)goCol).FormattedText;
                    }
                    return;
                }
                currentCellValue.Value = strVal;
            }
            else
            {
                if (currentCellValue.Value == this[e.ColumnIndex, e.RowIndex].Value && currentCellValue.DataSource == newDataSource)
                {
                    //value is not changed
                    return;
                }
                currentCellValue.Value = this[e.ColumnIndex, e.RowIndex].Value;
            }

            currentCellValue.DataSource = newDataSource;

            if (this.myCurrentDataTable.Rows[e.RowIndex].RowState == DataRowState.Unchanged)
                this.myCurrentDataTable.Rows[e.RowIndex].SetModified();

            FireUpdatedEvent();
        }
        private void SetMask(TextBoxGraphic go, int nColumn, bool bSet)
        {
            if (go.NeedMaskControl())
            {
                if (bSet)
                {
                    string strMask = GetMaskInput(go);
                    ((UltraMaskEditorColumn)this.Columns[nColumn]).MaskInput = strMask;
                    ((UltraMaskEditorColumn)this.Columns[nColumn]).PromptChar = '_';
                }
                else
                {
                    ((UltraMaskEditorColumn)this.Columns[nColumn]).MaskInput = string.Empty;
                    ((UltraMaskEditorColumn)this.Columns[nColumn]).PromptChar = ' ';
                }
            }
        }
        private void HandleAutoFit()
        {
            for (int col = 0; col < this.ColumnCount; col++)
            {
                TextBoxGraphic textBoxGO = this.Columns[col].Tag as TextBoxGraphic;
                if (textBoxGO != null && textBoxGO.AutoFit)
                {
                    string strLongest = string.Empty;
                    for (int row = 0; row < this.RowCount; row++)
                    {
                        if (this[col, row].Value == null)
                            continue;
                        if (strLongest.Length < this[col, row].Value.ToString().Length)
                            strLongest = this[col, row].Value.ToString();
                    }
                    Graphics g = this.CreateGraphics();
                    Font fontDraw = FontHelpers.SetFontSize(this.Font, this.CreateGraphics(), 1, strLongest, this.Columns[col].Width);
                    this.Columns[col].DefaultCellStyle.Font = fontDraw;
                }
            }
        }
        private bool IsColumnNeedTotalRow(GraphicObject go)
        {
            TextBoxGraphic textGO = go as TextBoxGraphic;
            if (textGO != null)
            {
                if (textGO.ShowColumnTotal &&
                    (textGO.DataType == TextBoxFieldDataTypeEnum.Integer || textGO.DataType == TextBoxFieldDataTypeEnum.Money || textGO.DataType == TextBoxFieldDataTypeEnum.Ratio))
                    return true;
            }
            return false;
        }
        private void CalculateTotalRowValues()
        {
            if (!myNeedTotalRow)
                return;
            int totalRowInd = this.RowCount-1;
            this.Rows[totalRowInd - 1].ReadOnly = false;
            this.Rows[totalRowInd - 1].HeaderCell.Value = string.Empty;
            this.Rows[totalRowInd].ReadOnly = true;
            this.Rows[totalRowInd].HeaderCell.Value = "Total";
            for (int col = 0; col < this.ColumnCount; col++)
            {
                GraphicObject go = (GraphicObject)this.Columns[col].Tag;
                if (!IsColumnNeedTotalRow(go))
                {
                    if (go is TextBoxGraphic)
                        this[col, totalRowInd].Value = null;
                    continue;
                }
                decimal total = 0;
                for (int row = 0; row < this.RowCount - 2; row++)
                {
                    //all the rows except the new row and total row
                    if (this[col, row].Value == null || this[col, row].Value.ToString() == string.Empty)
                        continue;
                    total += Convert.ToDecimal(this[col, row].Value.ToString());
                }
                ((TextBoxGraphic)go).Text = total.ToString();
                this[col, totalRowInd].Value = ((TextBoxGraphic)go).FormattedText;
            }
        }

        protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
        private string GetMaskInput(TextBoxGraphic go)
        {
            string strMask = string.Empty;
            switch (go.DataType)
            {
                case TextBoxFieldDataTypeEnum.String:
                    switch (go.AlphaNumericMask)
                    {
                        case AlphaNumericMasksEnum.PhoneNumberHyphens:
                            strMask = "###-###-####";
                            break;
                        case AlphaNumericMasksEnum.PhoneNumberBraces:
                            strMask = "(###)###-####";
                            break;
                        case AlphaNumericMasksEnum.PhoneNumberSpaces:
                            strMask = "### ### ####";
                            break;
                        case AlphaNumericMasksEnum.PhoneNumberSpaceHyphen:
                            strMask = "### ###-####";
                            break;
                        case AlphaNumericMasksEnum.SSNAllNineDigits:
                            strMask = "###-##-####";
                            break;
                        case AlphaNumericMasksEnum.SSNLastFourOnly:
                            strMask = "XXX-XX-####";
                            break;
                        case AlphaNumericMasksEnum.EIN:
                            strMask = "##-#######";
                            break;
                        case AlphaNumericMasksEnum.ZipCodeHyphen:
                            strMask = "#####-####";
                            break;
                        case AlphaNumericMasksEnum.ZipCodeSpace:
                            strMask = "##### ####";
                            break;
                        case AlphaNumericMasksEnum.ZipCodeNumberOnly:
                            strMask = "#########";
                            break;
                    }
                    break;
                case TextBoxFieldDataTypeEnum.Date:
                    strMask = "mm/dd/yyyy";
                    break;
            }
            return strMask;
        }

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region IAmARunTimeControl Members
        private DataTable myCurrentDataTable;
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
            get
            {
                return myCurrentDataTable;
            }
            set
            {
                if (value == null)
                {
                    theLogger.Debug("NULL passed to GridGraphicRT.CurrentDataTable.  GID: " + myGraphic.GraphicObjectID);
                    return;
                }
                if (theLogger.IsDebugEnabled)
                    theLogger.Debug("CurrentDataTable set for grid, row count: " + ((DataTable)value).Rows.Count.ToString());
                int nAddRows = 0;
                if (this.myNeedTotalRow)
                    nAddRows += 1;
                //the grid should have a new row and total row if necessary
                int count = value.Rows.Count + 1 + nAddRows - this.Rows.Count;
                if (count > 0)
                    this.Rows.Add(count);

                for (int i = 0; i < value.Rows.Count; i++)
                {
                    DataRow row = value.Rows[i];

                    for (int j = 0; j < value.Columns.Count; j++)
                    {
                        GraphicObject goCol = (GraphicObject)(this.Columns[value.Columns[j].ColumnName].Tag);
                        if (row[j] == DBNull.Value)
                            this[j, i].Value = GetColumnDefaultValue(j);
                        else
                        {
                            if (goCol is TextBoxGraphic)
                            {
                                ((TextBoxGraphic)goCol).Text = ((ValueWithDataSources)row[j]).Value.ToString();
                                this[j, i].Value = ((TextBoxGraphic)goCol).FormattedText;
                                if (i == 0)
                                    SetMask((TextBoxGraphic)goCol, j, false);
                            }
                            else
                                this[j, i].Value = ((ValueWithDataSources)row[j]).Value;
                            switch (((ValueWithDataSources)row[j]).DataSource)
                            {
                                case DataSourceEnum.DataEntry:
                                case DataSourceEnum.Override:
                                case DataSourceEnum.SystemDefault:
                                case DataSourceEnum.UserDefault:
                                    this[j, i].Style.ForeColor = SystemColors.WindowText;
                                    break;
                                default:
                                    this[j, i].Style.ForeColor = SystemColors.ActiveCaption;
                                    break;
                            }
                        }
                    }
                }
                GridGraphicRT_DefaultValuesNeeded(this, new DataGridViewRowEventArgs(this.Rows[value.Rows.Count]));
                CalculateTotalRowValues();
                //TODO: comment out for now since it seems that the font shown and the font when editing are somehow different
                //the HandleAutoFit() method could set the font perfectly for editing but not for showing
                //HandleAutoFit();
                myCurrentDataTable = value;
            }
        }
 
        //not used in the datagrid for right now - might change to allow singular updates to the grid.
		public ValueWithDataSources CurrentValue
		{
            get { return null; }
            set { }
			
		}
		public void ResetCurrentValueToLastKnownGoodValue(){}
		public void SetBindingList()
		{
			//if this is being called, then there are columns that need to be bound to
			foreach (DataGridViewColumn dgvc in this.Columns)
			{
                foreach (IGraphicsObject go in myGraphic.GraphicCollection)
	            {
                    Type t = go.GetGraphicObject().GetType();
            		if (t == typeof(DropDownListGraphic))
                    {
                        if (((DropDownListGraphic)go.GetGraphicObject()).BoundToValueListID.ToString() == dgvc.DataPropertyName)
                        {
                           ((DataGridViewComboBoxColumn)dgvc).DisplayMember = "";
                           ((DataGridViewComboBoxColumn)dgvc).DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                           ((DataGridViewComboBoxColumn)dgvc).DataSource = ((DropDownListGraphic)go.GetGraphicObject()).ValueListItems;
                        }
                    }
	            }
    		}
		}

		public event UpdatedValueEvent UpdatedValueEvent;
		private void FireUpdatedEvent()
		{
            theLogger.Debug("Firing Updated Event");

			if (UpdatedValueEvent != null)
				UpdatedValueEvent(this);
		}
        public OverrideIndicatorEnum OverrideIndicator
        {
            get { return OverrideIndicatorEnum.Never; }
        }
        public bool HasAComputeAssignment { get { return false; } }
        public bool IsShortcut { get { return myGraphic.IsShortCut && myGraphic.CanHaveShortCut; } }
        public int LinkedPageID { get { return myGraphic.LinkedPageID; } }
        public int LinkedGraphicID { get { return myGraphic.LinkedGraphicID; } }
        #endregion
	}
}

