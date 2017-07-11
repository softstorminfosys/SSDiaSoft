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
using Param_Hospital.BLL.Property_Class;
using DiamondPro.Search;
using DiamondPro.BLL.Function_Class;
using DiamondPro.BLL.Property_Class;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;

namespace DiamondPro.TRANSACTION
{
    public partial class FrmBoxNumbering : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtDetail = new DataTable();
        double amount;
        double Cts;
        #region Constructor
        public FrmBoxNumbering()
        {
            InitializeComponent();
        }
        #endregion

        #region Main Event
        private void FrmBoxNumbering_Load(object sender, EventArgs e)
        {
            AddNewRow();
        }
        #endregion

        #region TextBox Event
        private void txtBoxNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new BoxMerge_Function().GetBoxDetail("");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "BOX NAME"; 

                    FrmSearch frm = new FrmSearch(frmSearch, "");
                    frm.ShowDialog();
                    e.Handled = true;

                    if (frm.IsAdd)
                    {
                        FrmKarkhanaMaster objfrm = new FrmKarkhanaMaster();
                        objfrm.StartPosition = FormStartPosition.CenterScreen;
                        objfrm.ShowDialog();
                    }
                    if (!frm.FlagExit)
                    {
                        txtBoxNo.Text = frm.Dr.Cells["BOX NAME"].Value.ToString();
                        txtBoxNo.Tag = frm.Dr.Cells["Box No"].Value.ToString();
                        txtCts.Text = frm.Dr.Cells["Cts"].Value.ToString();
                        txtRate.Text = frm.Dr.Cells["Rate"].Value.ToString();
                        txtAmount.Text = frm.Dr.Cells["Amount"].Value.ToString();
                    }
                }

                if (e.KeyChar == 8)
                {
                    txtBoxNo.Text = "";
                    txtBoxNo.Tag = "";
                    txtCts.Text = "";
                    txtRate.Text = "";
                    txtAmount.Text = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "BoxNo KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new ParameterValue_Function().GetDataFoGrid(" ParameterType = 'Quality' AND MST_ParameterValue.Active = 1 ");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "PARAMETER VALUE";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmParameterValue");
                    frm.ShowDialog();
                    e.Handled = true;

                    if (frm.IsAdd)
                    {
                        FrmKarkhanaMaster objfrm = new FrmKarkhanaMaster();
                        objfrm.StartPosition = FormStartPosition.CenterScreen;
                        objfrm.ShowDialog();
                    }
                    if (!frm.FlagExit)
                    {
                        dgvTo.SetFocusedRowCellValue("Quality", frm.Dr.Cells["PARAMETER VALUE"].Value.ToString());
                        dgvTo.SetFocusedRowCellValue("QualityId", frm.Dr.Cells["ParaValueId"].Value.ToString());  
                    }
                }

                if (e.KeyChar == 8)
                {
                    dgvTo.SetFocusedRowCellValue("Quality", "");
                    dgvTo.SetFocusedRowCellValue("QualityId", "");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Quality KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtChavni_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new ParameterValue_Function().GetDataFoGrid(" ParameterType = 'Chavni' AND MST_ParameterValue.Active = 1 ");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "PARAMETER VALUE";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmParameterValue");
                    frm.ShowDialog();
                    e.Handled = true;

                    if (frm.IsAdd)
                    {
                        FrmKarkhanaMaster objfrm = new FrmKarkhanaMaster();
                        objfrm.StartPosition = FormStartPosition.CenterScreen;
                        objfrm.ShowDialog();
                    }
                    if (!frm.FlagExit)
                    {
                        dgvTo.SetFocusedRowCellValue("Chavni", frm.Dr.Cells["PARAMETER VALUE"].Value.ToString());
                        dgvTo.SetFocusedRowCellValue("ChavniId", frm.Dr.Cells["ParaValueId"].Value.ToString());  
                    }
                }

                if (e.KeyChar == 8)
                {
                    dgvTo.SetFocusedRowCellValue("Chavni", "");
                    dgvTo.SetFocusedRowCellValue("ChavniId", "");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Chavni KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxNo_Validated(object sender, EventArgs e)
        {
            if (txtBoxNo.Text.Length > 0)
            {
                FillGrid();
            }            
        }
        #endregion

        #region User Function
        private void FillGrid()
        {
            dtDetail = new BoxNumbering_Function().GetBoxDetails("BM.BoxNo = " + Convert.ToInt32(txtBoxNo.Tag) + "  AND BM.BoxName = '" + txtBoxNo.Text + "'");
            if (dtDetail.Rows.Count > 0)
            {
                grdTo.DataSource = null;
                grdTo.DataSource = dtDetail;
                dgvTo.RefreshData();
                dgvTo.BestFitColumns();

                for (int i = 0; i < dgvTo.Columns.Count; i++)
                {
                    dgvTo.Columns[i].OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                }

                AddNewRow();
            }
            else
            {
                AddNewRow();
            }
        }

        private void Clear()
        { 
            txtBoxNo.Text = "";
            txtBoxNo.Tag = "";
            txtCts.Text = "0.000";
            txtRate.Text = "0.00";
            txtAmount.Text = "0.00";
            grdTo.DataSource = null;
            grdTo.RefreshDataSource();
        }

        private void AddNewRow()
        {
            DataRow dr;
            dr = dtDetail.NewRow();
            dtDetail.Rows.Add(dr);
            grdTo.DataSource = dtDetail;
        }
        #endregion

        #region Button Event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BoxNumbering_Property objNumber = new BoxNumbering_Property();
                objNumber.BoxName = txtBoxNo.Text;
                objNumber.BoxNo = Convert.ToInt32(txtBoxNo.Tag);
                objNumber.Cts = Convert.ToDouble(txtCts.Text);
                objNumber.Rate = Convert.ToDouble(txtRate.Text);
                objNumber.Amount = Convert.ToDouble(txtAmount.Text);

                DataTable dt = new DataTable();
                dt = (DataTable)grdTo.DataSource;

                int retVal = new BoxNumbering_Function().SaveNumbering(objNumber, dt);

                if (retVal > 0)
                {
                    XtraMessageBox.Show("Numbering Successfully...", "Box Numbering", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                    Clear();
                    
                }
                else
                {
                    XtraMessageBox.Show("Can't Save Numbering", "Box Numbering", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Save",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Clear", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Are you sure to delete record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                int RetVal = new BoxNumbering_Function().Delete(Convert.ToInt32(txtBoxNo.Tag), txtBoxNo.Text, 0);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Record Deleted Successfully !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    XtraMessageBox.Show("Delete Failed !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Delete",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void DeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Are you sure to delete record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                int RetVal = new BoxNumbering_Function().Delete(Convert.ToInt32(txtBoxNo.Tag), txtBoxNo.Text, 1);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Record Deleted Successfully !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    XtraMessageBox.Show("Delete Failed !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextEdit teValue = (TextEdit)sender;
                    
                    if (Convert.ToInt32(dgvTo.GetFocusedRowCellValue("QualityId")) == 0)
                    {
                         XtraMessageBox.Show("Please Select Quality.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         dgvTo.FocusedColumn = gridColumn1;
                         e.Handled = true;
                         return;
                    }
                    else if (Convert.ToInt32(dgvTo.GetFocusedRowCellValue("ChavniId")) == 0)
                    {
                        XtraMessageBox.Show("Please Select Chavni.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn2;
                        e.Handled = true;
                        return;
                    }
                    else if (Convert.ToDouble(dgvTo.GetFocusedRowCellValue("Cts")) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Carat.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn3;
                        e.Handled = true;
                        return;
                    }
                    else if (Convert.ToDouble(dgvTo.GetFocusedRowCellValue("Rate")) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Rate.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn4;
                        e.Handled = true;
                        return;
                    }
                    else if (Convert.ToDouble(teValue.EditValue) == 0)//Convert.ToDouble(dgvTo.GetFocusedRowCellValue("Amount")
                    {
                        XtraMessageBox.Show("Please Enter Amount.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn5;
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        AddNewRow();
                        dgvTo.MoveNext();
                        dgvTo.FocusedColumn = gridColumn1;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Grid Column Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextEdit txtEdit = (TextEdit)sender;
                if (e.KeyCode == Keys.Enter)
                {
                    double Cts = Convert.ToDouble(dgvTo.GetFocusedRowCellValue("Cts"));
                    double Rate = Convert.ToDouble(txtEdit.EditValue);

                    double Amount = Cts * Rate;
                    dgvTo.SetFocusedRowCellValue("Amount", Amount);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Rate KeyDown",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dgvTo_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {                
                // Initialization.  
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    amount = 0;
                    Cts = 0;
                }
                // Calculation. 
                if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    amount += Convert.ToDouble(dgvTo.GetRowCellValue(e.RowHandle,"Amount"));
                    Cts += Convert.ToDouble(dgvTo.GetRowCellValue(e.RowHandle,"Cts"));
                }
                // Finalization.  
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    //switch (dgvTo.FocusedColumn.FieldName.ToUpper())
                    //{
                        //case "RATE":
                            if (Cts != 0)
                            {
                                e.TotalValue = Convert.ToDouble(amount/Cts);
                            }
                            else
                            {
                                e.TotalValue = 0;
                            }
                            //break;
                    //}
                   
                }      
                
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

    }
}