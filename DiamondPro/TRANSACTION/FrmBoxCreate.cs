using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DiamondPro.BLL.Function_Class;

namespace DiamondPro.TRANSACTION
{
    public partial class FrmBoxCreate : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtFrom = new DataTable();
        
        #region Constructor
        public FrmBoxCreate()
        {
            InitializeComponent();
        }
        #endregion

        #region Main Event
        private void FrmBoxCreate_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        #endregion

        #region User Functions
        private void FillGrid()
        {
            _dtFrom = new BoxMerge_Function().PacketDetailGetDataForGrid("BoxNo = 0");
            if (_dtFrom.Rows.Count > 0)
            {
                grdTo.DataSource = null;
                grdTo.DataSource = _dtFrom;
                dgvTo.RefreshData();
                dgvTo.BestFitColumns();

                for (int i = 0; i < dgvTo.Columns.Count; i++)
                {
                    dgvTo.Columns[i].OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                }
            }
        }

        private void FillBoxDetail()
        {
            DataSet _dsDetail = new BoxMerge_Function().BoxSummaryDetails("");
            if (_dsDetail.Tables[0].Rows.Count > 0)
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = _dsDetail.Tables[0];
                gridView1.RefreshData();
                gridView1.BestFitColumns();

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                }
            }

            if (_dsDetail.Tables[1].Rows.Count > 0)
            {
                gridControl2.DataSource = null;
                gridControl2.DataSource = _dsDetail.Tables[1];
                gridView2.RefreshData();
                gridView2.BestFitColumns();

                for (int i = 0; i < gridView2.Columns.Count; i++)
                {
                    gridView2.Columns[i].OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                }
                gridView2.Columns["BoxId"].Visible = false;
            }
        }
        #endregion

        #region Repository Event
        private void rtxtFTAmount_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {

            //        if (Convert.ToString(dgvFrom.GetFocusedRowCellValue("NotNo")) == "")
            //        {
            //            MessageBox.Show("Not No is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            dgvFrom.FocusedColumn = FNotNo;
            //            e.Handled = true;
            //            return;
            //        }

            //        if (Convert.ToString(dgvFrom.GetFocusedRowCellValue("KatNo")) == "")
            //        {
            //            MessageBox.Show("Kat No is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            dgvFrom.FocusedColumn = FKatNo;
            //            e.Handled = true;
            //            return;
            //        }

            //        if (Convert.ToString(dgvFrom.GetFocusedRowCellValue("TCarat")) == "")
            //        {
            //            MessageBox.Show("Transfer Carat is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            dgvFrom.FocusedColumn = FTCarat;
            //            e.Handled = true;
            //            return;
            //        }

            //        if (RdOneMany.SelectedIndex == 1)
            //        {
            //            AddNewRow(_dtFrom, grdFrom);
            //            dgvFrom.MoveNext();
            //            dgvFrom.FocusedColumn = FNotNo;
            //        }
            //        else
            //        {
            //            dgvTo.Focus();
            //            dgvTo.FocusedColumn = TNotNo;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "From Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void rtxtTTAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (Convert.ToString(dgvTo.GetFocusedRowCellValue("NotNo")) == "")
                    {
                        MessageBox.Show("Not No is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTo.FocusedColumn = TNotNo;
                        e.Handled = true;
                        return;
                    }

                    if (Convert.ToString(dgvTo.GetFocusedRowCellValue("KatNo")) == "")
                    {
                        MessageBox.Show("Kat No is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTo.FocusedColumn = TKatNo;
                        e.Handled = true;
                        return;
                    }

                    if (Convert.ToString(dgvTo.GetFocusedRowCellValue("TCarat")) == "")
                    {
                        //MessageBox.Show("Transfer Carat is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //dgvTo.FocusedColumn = TTCarat;
                        //e.Handled = true;
                        //return;
                    }

                    if (RdOneMany.SelectedIndex == 0)
                    {
                        //AddNewRow(_dtFrom, grdFrom);
                        dgvTo.MoveNext();
                        dgvTo.FocusedColumn = TNotNo;
                    }
                    else
                    {
                        BtnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "From Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtFTCarat_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    double FAmount = 0;
            //    FAmount = Convert.ToDouble(dgvFrom.GetRowCellValue(dgvFrom.FocusedRowHandle, "TCarat")) * Convert.ToDouble(dgvFrom.GetRowCellValue(dgvFrom.FocusedRowHandle, "TRate"));
            //    dgvFrom.SetRowCellValue(dgvFrom.FocusedRowHandle,"TAmount", FAmount.ToString());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"FCarat",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
        }
        #endregion

        #region Button Event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable _dtSelect = new DataTable();
                if (dgvTo.SelectedRowsCount < 1)
                {
                    MessageBox.Show("Please select any rows.","Merge",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                //int[] selectedRow = dgvTo.GetSelectedRows();
                
                //for (int i = 0; i < selectedRow.Length; i++)
                //{
                //    if (dgvTo.IsRowSelected(selectedRow[i]) == true)
                //    {
                //        dgvTo.SetFocusedRowCellValue("Sel", 1);
                //    }
                //    else
                //    {
                //        dgvTo.SetFocusedRowCellValue("Sel", 0);
                //    }
                //}
                int BoxNo = new BoxMerge_Function().GetBoxNumber();
                _dtSelect = (DataTable)grdTo.DataSource;
                _dtSelect.Select("Sel = 1", "");

                int Result = new BoxMerge_Function().BoxCreate(_dtSelect, BoxNo);

                if (Result > 0)
                {
                    MessageBox.Show("Box No. B"+Result+" is created successfully.");
                    BtnClear_Click(null,null);
                }
                else
                {
                    MessageBox.Show("Sorry you can't create box.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {               
                grdTo.DataSource = null;
                grdTo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Clear Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (XtraMessageBox.Show("Are you sure to delete record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    int RetVal = new BoxMerge_Function().Delete(Convert.ToString(gridView1.GetFocusedRowCellValue("BoxName")));

                    if (RetVal > 0)
                    {
                        XtraMessageBox.Show("Record Deleted Successfully !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillBoxDetail();
                        //Clear();
                    }
                    else
                    {
                        XtraMessageBox.Show("Delete Failed !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Delete Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SBtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                panelControl1.Visible = false;
                pnlButton.Visible = false;
                panelControl3.Visible = true;
                panelControl3.Dock = DockStyle.Fill;
                FillBoxDetail();
                xtraTabControl1_SelectedPageChanged(null,null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Show Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SBtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                panelControl1.Visible = true;
                pnlButton.Visible = true;
                panelControl3.Visible = false;
                panelControl3.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Close Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void dgvTo_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (dgvTo.IsRowSelected(dgvTo.FocusedRowHandle) == true)
            {
                dgvTo.SetFocusedRowCellValue("Sel", 1);
            }
            else
            {
                dgvTo.SetFocusedRowCellValue("Sel", 0);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                BtnDelete.Enabled = true;
            }
            else
            {
                BtnDelete.Enabled = false;
            }
        }
        
    }
}