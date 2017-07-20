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
using DiamondPro.BLL.Property_Class;
using DiamondPro.BLL;
using DiamondPro.Search;
using Param_Hospital.BLL.Property_Class;
using DiamondPro.BLL.Function_Class;
using DiamondPro.DLL;
using DevExpress.XtraGrid;
using DevExpress.Data;

namespace DiamondPro.MASTER
{
    public partial class FrmVechan : DevExpress.XtraEditors.XtraForm
    {
        Validation Val = new Validation();
        DataTable dtSale = new DataTable();
        int Id = 0;
        bool SaveFlag = true;
        double amount = 0;
        double Cts = 0;

        #region Main Event
        public FrmVechan()
        {
            InitializeComponent();
        }

        private void FrmVechan_Load(object sender, EventArgs e)
        {
            GetMaxSaleNo();
            AddNewRow();
        }
        #endregion

        #region Button Event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SaveValidation())
                {
                    return;
                }

                MST_Vechan_Property ObjProperty = new MST_Vechan_Property();
                ObjProperty.ID = Id;
                ObjProperty.VechanNotno = txtVechanNo.Text;
                ObjProperty.VechanDate = dtpVechanDate.DateTime.ToString();
                ObjProperty.PaymentDate = dtpPaymentDate.DateTime.ToString();
                ObjProperty.Term = Val.ToInt(txtPaymentTerm.Text);
                ObjProperty.PartyId = Val.ToInt(txtPartyName.Tag);
                ObjProperty.BrokerId = Val.ToInt(txtDalalName.Tag);
                ObjProperty.Cts = Val.ToDouble(txtCts.Text);
                ObjProperty.Rate = Val.ToDouble(txtRate.Text);
                ObjProperty.VechanPer = Val.ToDouble(txtPer.Text);
                ObjProperty.BasicTotal = Val.ToDouble(txtBasicTotal.Text);
                ObjProperty.BroPer = Val.ToDouble(txtBroPer.Text);
                ObjProperty.BroAmount = Val.ToDouble(txtBroAmt.Text);
                ObjProperty.FinalTotal = Val.ToDouble(txtFinalAmount.Text);
                ObjProperty.PaidAmount = Val.ToDouble(txtDonePayment.Text);
                ObjProperty.PendingAmount = Val.ToDouble(txtPendingPayment.Text);

                int RetVal = new MST_Vechan_Function().InsertUpdate(ObjProperty, dtSale);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Record Save Successfully...", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    //FillGrid();
                }
                else
                {
                    XtraMessageBox.Show("Record Save Failed...", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Save Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #endregion

        #region User Function
        private void Clear()
        {
            dtpVechanDate.EditValue = DateTime.Now.ToShortDateString();
            txtPaymentTerm.Text = string.Empty;
            dtpPaymentDate.EditValue = string.Empty;
            txtPartyName.Text = String.Empty;
            txtPartyName.Tag = String.Empty;
            txtDalalName.Text = String.Empty;
            txtDalalName.Tag = String.Empty;
            txtBroPer.Text = "0.00";
            txtBroAmt.Text = "0.00";
            txtCts.Text = "0.000";
            txtRate.Text = "0.00";
            txtBasicTotal.Text = "0.00";
            txtPer.Text = "0.00";
            txtFinalAmount.Text = "0.00";
            txtDonePayment.Text = "0.00";
            txtPendingPayment.Text = "0.00";
            dtSale.Rows.Clear();
            AddNewRow();
            GetMaxSaleNo();
        }

        private void AddNewRow()
        {
            if (dtSale.Columns.Count == 0)
            {
                for (int i = 0; i < dgvSale.Columns.Count; i++)
                {
                    dtSale.Columns.Add(dgvSale.Columns[i].FieldName, typeof(String));
                }
            }
            DataRow dr;
            dr = dtSale.NewRow();
            dtSale.Rows.Add(dr);
            grdSale.DataSource = dtSale;
            dgvSale.SelectRow(dtSale.Rows.Count - 1);
        }

        private void GetMaxSaleNo()
        {
            txtVechanNo.Text = new MST_Vechan_Function().GetMaxSalNo();
        }

        private bool SaveValidation()
        {
            //SaveFlag = false;
            string ErrorMsg = string.Empty;
            if (txtVechanNo.Text == "")
            {
                ErrorMsg = "Vechan No is Required.\n";
            }

            if (txtPartyName.Text == "")
            {
                ErrorMsg = ErrorMsg + "Party Name is Required.\n";
            }

            if (txtDalalName.Text == "")
            {
                ErrorMsg = ErrorMsg + "Dalal Name is Required.\n";
            }

            if (Convert.ToDouble(txtCts.Text) <= 0)
            {
                ErrorMsg = ErrorMsg + "Raf Vajan is Required.\n";
            }

            if (Convert.ToDouble(txtRate.Text) <= 0)
            {
                ErrorMsg = ErrorMsg + "Raf Rate is Required.\n";
            }

            //if (Convert.ToDouble(txtDonePayment.Text) <= 0)
            //{
            //    ErrorMsg = ErrorMsg + "Paid Amount is Required.\n";
            //}

            if (ErrorMsg != "")
            {
                SaveFlag = false;
                XtraMessageBox.Show(ErrorMsg, "Save Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return SaveFlag;
        }

        private void Calculation()
        { 
            double PerAmount = (Val.ToDouble(txtBasicTotal.Text) * Val.ToDouble(txtPer.Text)) / 100;
            double BrokAmount = (Val.ToDouble(txtBasicTotal.Text) * Val.ToDouble(txtBroPer.Text)) / 100;
            double FinalTot = Val.ToDouble(txtBasicTotal.Text) - PerAmount - BrokAmount;
           
            txtBroAmt.Text = Val.ToString(BrokAmount);
            txtFinalAmount.Text = Val.ToString(Val.TruncateDecimal(FinalTot,2));
        }
        #endregion


        private void txtPer_EditValueChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void txtBroPer_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void txtDonePayment_TextChanged(object sender, EventArgs e)
        {
           double Amount = Val.TruncateDecimal(Val.ToDouble(txtFinalAmount.Text) - Val.ToDouble(txtDonePayment.Text),2);
           txtPendingPayment.Text = Amount.ToString();
        }

        private void txtFinalAmount_TextChanged(object sender, EventArgs e)
        {
            double Amount = Val.TruncateDecimal(Val.ToDouble(txtFinalAmount.Text) - Val.ToDouble(txtDonePayment.Text), 2);
            txtPendingPayment.Text = Amount.ToString();
        }

        private void txtPaymentTerm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Days = txtPaymentTerm.Text == "" ? 0 : Convert.ToDouble(txtPaymentTerm.Text);
                dtpPaymentDate.EditValue = dtpVechanDate.DateTime.AddDays(Days);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Term TextChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new MST_Party_Function().PartyMasterGetDataFOrGrid(" PartyType in('VECHAN') AND Active = 1");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "PARTY NAME";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmPartyMaster");
                    frm.ShowDialog();
                    e.Handled = true;
                    if (!frm.FlagExit)
                    {
                        txtPartyName.Text = frm.Dr.Cells["PARTY NAME"].Value.ToString();
                        txtPartyName.Tag = frm.Dr.Cells["PartyId"].Value.ToString();
                    }
                }

                if (e.KeyChar == 8)
                {
                    txtPartyName.Text = "";
                    txtPartyName.Tag = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Party KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDalalName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new MST_Dalal_Function().DalalMasterGetDataFOrGrid(" dbo.MST_Dalal.PartyId = " + Convert.ToInt32(txtPartyName.Tag) + " AND dbo.MST_Dalal.ACTIVE = 1");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "DALAL NAME";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmDalalMaster");
                    frm.ShowDialog();
                    e.Handled = true;
                    if (!frm.FlagExit)
                    {
                        txtDalalName.Text = frm.Dr.Cells["DALAL NAME"].Value.ToString();
                        txtDalalName.Tag = frm.Dr.Cells["DalalId"].Value.ToString();
                    }
                }

                if (e.KeyChar == 8)
                {
                    txtDalalName.Text = "";
                    txtDalalName.Tag = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Party KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                        dgvSale.SetFocusedRowCellValue("Quality", frm.Dr.Cells["PARAMETER VALUE"].Value.ToString());
                        dgvSale.SetFocusedRowCellValue("QualityId", frm.Dr.Cells["ParaValueId"].Value.ToString());
                        DataTable dt = new StockTransfer_Function().GetQualityDetailSale("QualityId = " + Convert.ToInt32(frm.Dr.Cells["ParaValueId"].Value));

                        if (dt.Rows.Count == 1)
                        {
                            dgvSale.SetFocusedRowCellValue("Cts", Val.ToString(dt.Rows[0]["Cts"]));
                            dgvSale.SetFocusedRowCellValue("Rate", Val.ToString(dt.Rows[0]["Rate"]));
                            dgvSale.SetFocusedRowCellValue("Amount", Val.ToString(dt.Rows[0]["Amount"]));
                        }
                    }
                }

                if (e.KeyChar == 8)
                {
                    dgvSale.SetFocusedRowCellValue("Quality", "");
                    dgvSale.SetFocusedRowCellValue("QualityId", "");
                    dgvSale.SetFocusedRowCellValue("Cts", "");
                    dgvSale.SetFocusedRowCellValue("Rate", "");
                    dgvSale.SetFocusedRowCellValue("Amount", "");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Quality KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextEdit teValue = (TextEdit)sender;

                    if (Val.ToInt(dgvSale.GetFocusedRowCellValue("QualityId")) == 0)
                    {
                        XtraMessageBox.Show("Please Select Quality.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvSale.FocusedColumn = gridColumn1;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(dgvSale.GetFocusedRowCellValue("Cts")) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Sale Carat.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvSale.FocusedColumn = gridColumn3;
                        e.Handled = true;
                        return;
                    }
                    else if (Val.ToDouble(teValue.EditValue) == 0)
                    {
                        XtraMessageBox.Show("Please Enter Sale Rate.", "Grid Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvSale.FocusedColumn = gridColumn4;
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        if (dgvSale.IsLastRow)
                        {
                            AddNewRow();
                        }
                        dgvSale.MoveNext();
                        dgvSale.Focus();
                        dgvSale.FocusedColumn = gridColumn1;

                        txtCts.Text = Val.ToString(dgvSale.Columns["Cts"].SummaryText);
                        txtRate.Text = Val.ToString(dgvSale.Columns["Rate"].SummaryText);
                        txtBasicTotal.Text = Val.ToString(dgvSale.Columns["Amount"].SummaryText);
                        txtFinalAmount.Text = Val.ToString(dgvSale.Columns["Amount"].SummaryText);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Grid Column Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtxtCarat_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit teValue = (TextEdit)sender;

            double Rate = Val.ToDouble(dgvSale.GetFocusedRowCellValue("Rate"));
            double Cts = Val.ToDouble(teValue.EditValue);
            double Amount = Val.TruncateDecimal(Rate * Cts, 2);
            dgvSale.SetFocusedRowCellValue("Amount",Amount);
        }

        private void dgvSale_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                GridSummaryItem item = ((GridSummaryItem)e.Item);                               
                // Initialization.  
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    amount = 0;
                    Cts = 0;
                    
                }
                // Calculation. 
                if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    amount += Val.ToDouble(dgvSale.GetRowCellValue(e.RowHandle, "Amount"));
                    Cts += Val.ToDouble(dgvSale.GetRowCellValue(e.RowHandle, "Cts"));
                    
                }
                // Finalization.  
                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    switch (item.FieldName.ToUpper())
                    {
                        case "RATE":
                            if (Cts != 0)
                            {
                                e.TotalValue = Math.Round(Val.ToDouble(amount / Cts), 2);
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

        

        
    }
}