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
using DiamondPro.BLL.Function_Class;
using Param_Hospital.BLL.Property_Class;
using DiamondPro.Search;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DiamondPro.DLL;

namespace DiamondPro.TRANSACTION
{
    public partial class FrmStockTransfer : DevExpress.XtraEditors.XtraForm
    {
        Validation Val = new Validation();

        DataTable dtFrom = new DataTable();
        DataTable dtTo = new DataTable();
        double amount = 0, Cts = 0;
        double TAmount = 0;
        double TCts = 0;
        double amountT = 0, CtsT = 0;
        double TTAmount = 0;
        double TTCts = 0;

        public FrmStockTransfer()
        {
            InitializeComponent();
        }

        private void FrmStockTransfer_Load(object sender, EventArgs e)
        {
            AddFromRow();
            AddToRow();
        }

        #region User Function
        private void AddFromRow()
        {
            if (dtFrom.Columns.Count == 0)
            {
                for (int i = 0; i < dgvFrom.Columns.Count; i++)
                {
                    dtFrom.Columns.Add(dgvFrom.Columns[i].FieldName,typeof(String));
                }
            }
            DataRow dr;
            dr = dtFrom.NewRow();
            dtFrom.Rows.Add(dr);
            grdFrom.DataSource = dtFrom;
            dgvFrom.SelectRow(dtFrom.Rows.Count - 1);
        }

        private void AddToRow()
        {
            if (dtTo.Columns.Count == 0)
            {
                for (int i = 0; i < dgvTo.Columns.Count; i++)
                {
                    dtTo.Columns.Add(dgvTo.Columns[i].FieldName, typeof(String));
                }
            }
            DataRow dr;
            dr = dtTo.NewRow();
            dtTo.Rows.Add(dr);
            grdTo.DataSource = dtTo;
            dgvTo.SelectRow(dtTo.Rows.Count - 1);
        }

        private void Clear()
        {
            dtFrom.Rows.Clear();
            dgvFrom.RefreshData();

            dtTo.Rows.Clear();
            dgvTo.RefreshData();

            AddFromRow();
            AddToRow();
        }
        #endregion

        #region Radio Group Event
        private void rbgOneMany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbgOneMany.SelectedIndex == 0)
                {
                    
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Radio Button Event",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int Result = 0;
                if (XtraMessageBox.Show("Do you want save record ?","Save Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (Val.ToDouble(dgvFrom.Columns["TCarat"].SummaryText) == Val.ToDouble(dgvTo.Columns["TCarat"].SummaryText))
                {
                    if (dtFrom != null && dtTo != null)
                    {
                        Result = new StockTransfer_Function().Save(dtFrom,dtTo);
                    }

                    if (Result > 0)
                    {
                        XtraMessageBox.Show("Stock Transfer Successfully.","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Clear();
                    }
                    else
                    {
                        XtraMessageBox.Show("Stock Transfer can't Transfered.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Save",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Repository Event
        private void rtxtFQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtFQuality = new ParameterValue_Function().GetDataFoGrid(" ParameterType = 'Quality' AND MST_ParameterValue.Active = 1 ");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtFQuality.Copy();
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
                        dgvFrom.SetFocusedRowCellValue("Quality", frm.Dr.Cells["PARAMETER VALUE"].Value.ToString());
                        dgvFrom.SetFocusedRowCellValue("QualityId", frm.Dr.Cells["ParaValueId"].Value.ToString());
                        DataTable dt = new StockTransfer_Function().GetQualityDetail("QualityId = " + Convert.ToInt32(frm.Dr.Cells["ParaValueId"].Value));

                        if (dt.Rows.Count == 1)
                        {
                            dgvFrom.SetFocusedRowCellValue("Cts", Val.ToString(dt.Rows[0]["Cts"]));
                            dgvFrom.SetFocusedRowCellValue("Rate", Val.ToString(dt.Rows[0]["Rate"]));
                            dgvFrom.SetFocusedRowCellValue("Amount", Val.ToString(dt.Rows[0]["Amount"]));
                        }
                    }
                }

                if (e.KeyChar == 8)
                {
                    dgvFrom.SetFocusedRowCellValue("Quality", "");
                    dgvFrom.SetFocusedRowCellValue("QualityId", "");
                    dgvFrom.SetFocusedRowCellValue("Cts", "");
                    dgvFrom.SetFocusedRowCellValue("Rate", "");
                    dgvFrom.SetFocusedRowCellValue("Amount", "");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Quality KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtTQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtTQuality = new ParameterValue_Function().GetDataFoGrid(" ParameterType = 'Quality' AND MST_ParameterValue.Active = 1 ");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtTQuality.Copy();
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

                        DataTable dt = new StockTransfer_Function().GetQualityDetail("QualityId = " + Convert.ToInt32(frm.Dr.Cells["ParaValueId"].Value));

                        if (dt.Rows.Count == 1)
                        {
                            dgvTo.SetFocusedRowCellValue("Cts", Val.ToDouble(dt.Rows[0]["Cts"]));
                            dgvTo.SetFocusedRowCellValue("Rate", Val.ToDouble(dt.Rows[0]["Rate"]));
                            dgvTo.SetFocusedRowCellValue("Amount", Val.ToDouble(dt.Rows[0]["Amount"]));
                        }
                    }
                }

                if (e.KeyChar == 8)
                {
                    dgvTo.SetFocusedRowCellValue("Quality", "");
                    dgvTo.SetFocusedRowCellValue("QualityId", "");
                    dgvTo.SetFocusedRowCellValue("Cts", "");
                    dgvTo.SetFocusedRowCellValue("Rate", "");
                    dgvTo.SetFocusedRowCellValue("Amount", "");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Quality KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtTTRate_Leave(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtEdit = (TextEdit)sender;
                double Cts = Val.ToDouble(dgvTo.GetFocusedRowCellValue("TCarat"));
                double Rate = Val.ToDouble(txtEdit.EditValue);

                double Amount = Cts * Rate;
                dgvTo.SetFocusedRowCellValue("TAmount", Amount);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ToRate Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtFRate_Leave(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtEdit = (TextEdit)sender;
                double Cts = Val.ToDouble(dgvFrom.GetFocusedRowCellValue("TCarat"));
                double Rate = Val.ToDouble(txtEdit.EditValue);

                double Amount = Cts * Rate;
                dgvFrom.SetFocusedRowCellValue("TAmount", Amount);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Rate KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtFAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextEdit teValue = (TextEdit)sender;

                    if (Val.ToInt(dgvFrom.GetFocusedRowCellValue("QualityId")) == 0)
                    {
                        XtraMessageBox.Show("Please Select Quality.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvFrom.FocusedColumn = gridColumn3;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(dgvFrom.GetFocusedRowCellValue("TCarat")) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Transfer Carat.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvFrom.FocusedColumn = gridColumn17;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(dgvFrom.GetFocusedRowCellValue("TRate")) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Transfer Rate.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvFrom.FocusedColumn = gridColumn18;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(teValue.EditValue) == 0)//Convert.ToDouble(dgvTo.GetFocusedRowCellValue("Amount")
                    {
                        XtraMessageBox.Show("Please Enter From Amount.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvFrom.FocusedColumn = gridColumn19;
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        if (rbgOneMany.SelectedIndex == 0)
                        {
                            dgvTo.Focus();
                            dgvTo.FocusedColumn = gridColumn7;
                        }
                        else
                        {
                            if (dgvFrom.IsLastRow)
                            {
                                AddFromRow();
                            }                            
                            dgvFrom.MoveNext();
                            dgvFrom.FocusedColumn = gridColumn1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Grid Column Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtTTAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextEdit teValue = (TextEdit)sender;

                    if (Val.ToInt(dgvTo.GetFocusedRowCellValue("QualityId")) == 0)
                    {
                        XtraMessageBox.Show("Please Select Quality.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn7;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(dgvTo.GetFocusedRowCellValue("TCarat")) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Transfer Carat.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn20;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(dgvTo.GetFocusedRowCellValue("TRate")) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Transfer Rate.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn21;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(teValue.EditValue) == 0)//Convert.ToDouble(dgvTo.GetFocusedRowCellValue("Amount")
                    {
                        XtraMessageBox.Show("Please Enter From Amount.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvTo.FocusedColumn = gridColumn22;
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        if (rbgOneMany.SelectedIndex == 0)
                        {
                            if (dgvTo.IsLastRow)
                            {
                                AddToRow();
                            }                           
                            dgvTo.MoveNext();
                            dgvTo.FocusedColumn = gridColumn7;
                            
                        }
                        else
                        {
                            BtnSave.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Grid Column Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtFTCarat_Leave(object sender, EventArgs e)
        {
            TextEdit teValue = (TextEdit)sender;
            if (Val.ToDouble(teValue.EditValue) > Val.ToDouble(dgvFrom.GetFocusedRowCellValue("Cts")))
            {
                XtraMessageBox.Show("Transfer Carat Must Be Less Than Carat.");
                dgvFrom.FocusedColumn = gridColumn17;
            }
        }

        #endregion

        #region Grid Event
        private void dgvFrom_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                GridSummaryItem item = ((GridSummaryItem)e.Item);

                
                // Initialization.  
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    amount = 0;
                    Cts = 0;
                    TAmount = 0;
                    TCts = 0;
                }
                // Calculation. 
                if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    amount += Val.ToDouble(dgvFrom.GetRowCellValue(e.RowHandle, "Amount"));
                    Cts += Val.ToDouble(dgvFrom.GetRowCellValue(e.RowHandle, "Cts"));
                    TAmount += Val.ToDouble(dgvFrom.GetRowCellValue(e.RowHandle, "TAmount"));
                    TCts += Val.ToDouble(dgvFrom.GetRowCellValue(e.RowHandle, "TCarat"));
                }
                // Finalization.  
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    switch (item.FieldName.ToUpper())
                    {
                        case "RATE":
                            if (Cts != 0)
                            {
                                e.TotalValue = Math.Round(Val.ToDouble(amount / Cts),2);
                            }
                            else
                            {
                                e.TotalValue = 0;
                            }
                        break;
                        case "TRATE":
                            if (TCts != 0)
                            {
                                e.TotalValue = Math.Round(Val.ToDouble(TAmount / TCts),2);
                            }
                            else
                            {
                                e.TotalValue = 0;
                            }
                        break;
                   }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dgvTo_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            try
            {
                GridSummaryItem item = ((GridSummaryItem)e.Item);
                
                // Initialization.  
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    amountT = 0;
                    CtsT = 0;
                    TTAmount = 0;
                    TTCts = 0;
                }
                // Calculation. 
                if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    amountT += Val.ToDouble(dgvTo.GetRowCellValue(e.RowHandle, "Amount"));
                    CtsT += Val.ToDouble(dgvTo.GetRowCellValue(e.RowHandle, "Cts"));
                    TTAmount += Val.ToDouble(dgvTo.GetRowCellValue(e.RowHandle, "TAmount"));
                    TTCts += Val.ToDouble(dgvTo.GetRowCellValue(e.RowHandle, "TCarat"));
                }
                // Finalization.  
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    switch (item.FieldName.ToUpper())
                    {
                        case "RATE":
                            if (Cts != 0)
                            {
                                e.TotalValue = Math.Round(Val.ToDouble(amountT / CtsT), 2);
                            }
                            else
                            {
                                e.TotalValue = 0;
                            }
                            break;
                        case "TRATE":
                            if (TCts != 0)
                            {
                                e.TotalValue = Math.Round(Val.ToDouble(TTAmount / TTCts), 2);
                            }
                            else
                            {
                                e.TotalValue = 0;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}