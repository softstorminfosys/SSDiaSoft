using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DiamondPro.BLL.Property_Class;
using DiamondPro.BLL;
using DiamondPro.Search;
using Param_Hospital.BLL.Property_Class;
using DiamondPro.BLL.Function_Class;

namespace DiamondPro
{
    public partial class FrmKharidiMaster : DevExpress.XtraEditors.XtraForm
    {
        int Id = 0;
        bool SaveFlag = true;

        #region Constructor
        public FrmKharidiMaster()
        {
            InitializeComponent();
        }
        #endregion

        #region Main Event
        private void FrmKharidiMaster_Load(object sender, EventArgs e)
        {
            dtpKharidiDate.DateTime = System.DateTime.Now;
            FillGrid();
            GetNotNumber();
        }
        #endregion

        #region Text Event
        private void txtPaymentTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextEdit txtBox = new TextEdit();
                switch (txtBox.Name.ToUpper())
                {
                    case "TXTPAYMENTTERM":
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textEdit4_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculateBasicTotal();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CTS Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculateBasicTotal();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Rate Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPer_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculateBasicTotal();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Percentage Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAngadiyaPer_Leave(object sender, EventArgs e)
        {
            try
            {
                //CalculateFinalTotal();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Angadiya Percentage Leave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPaymentTerm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Days = txtPaymentTerm.Text == "" ? 0 : Convert.ToDouble(txtPaymentTerm.Text);
                dtpPaymentDate.EditValue = dtpKharidiDate.DateTime.AddDays(Days);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Term TextChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region User Function
        private void Clear()
        {
            Id = 0;
            txtKatNo.Text = string.Empty;
            dtpKharidiDate.DateTime = System.DateTime.Now;
            txtPaymentTerm.Text = string.Empty;
            dtpPaymentDate.EditValue = "";
            txtPartyName.Text = string.Empty;
            txtPartyName.Tag = string.Empty;
            txtDalalName.Text = string.Empty;
            txtDalalName.Tag = string.Empty;
            txtCts.Text = "0.000";
            txtRate.Text = "0.00";
            txtPer.Text = "0.00";
            txtBasicTotal.Text = "0.00";
            txtAngadiyaPer.Text = "0.00";
            txtAngadiyaValue.Text = "0.00";
            txtFinalTotal.Text = "0.00";
            txtPendingPayment.Text = "0.00";
            txtDonePayment.Text = "0.00";
            GetNotNumber();
        }

        private bool SaveValidation()
        {
            //SaveFlag = false;
            string ErrorMsg = string.Empty;
            if (txtNotNo.Text == "")
            {
                ErrorMsg = "Not No is Required.\n";
            }

            if (txtKatNo.Text == "")
            {
                ErrorMsg = ErrorMsg + "Kat No is Required.\n";
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
                XtraMessageBox.Show(ErrorMsg,"Save Validation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            return SaveFlag;
        }

        private void CalculateBasicTotal()
        {
            double Amount = 0;
            Amount = (Convert.ToDouble(txtCts.Text) * Convert.ToDouble(txtRate.Text));
            double PerValue = (Amount * Convert.ToDouble(txtPer.Text)) / 100;

            txtBasicTotal.Text = Convert.ToString(Amount - PerValue);
        }

        private void CalculateFinalTotal()
        {
            //double AngadiyaValue = (Convert.ToDouble(txtBasicTotal.Text) * Convert.ToDouble(txtAngadiyaPer.Text)) / 100;
            //txtFinalTotal.Text = Convert.ToString(Convert.ToDouble(txtBasicTotal.Text) - AngadiyaValue);

            txtPendingPayment.Text = Convert.ToString(Convert.ToDouble(txtBasicTotal.Text) - Convert.ToDouble(txtDonePayment.Text));
        }

        private void FillGrid()
        {
            try
            {
                DataTable dt = new MST_Kharidi_Function().KharidiMasterGetDataFOrGrid("");
                if (dt.Rows.Count > 0)
                {
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = dt;
                    gridView1.BestFitColumns();
                    gridView1.Columns["ID"].Visible = false;
                    gridView1.Columns["PartyId"].Visible = false;
                    gridView1.Columns["BrokerId"].Visible = false;
                }
                else
                {
                    gridControl1.DataSource = null;
                    gridControl1.Refresh();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "FillGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
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

                MST_Kharidi_Property ObjProperty = new MST_Kharidi_Property();
                ObjProperty.ID = Id;
                ObjProperty.notno = txtNotNo.Text;
                ObjProperty.katno = txtKatNo.Text;
                ObjProperty.KharidiDate = dtpKharidiDate.DateTime.ToString();
                ObjProperty.PaymentDate = dtpPaymentDate.DateTime.ToString();
                ObjProperty.Term = Convert.ToInt32(txtPaymentTerm.Text);
                ObjProperty.PartyId = Convert.ToInt32(txtPartyName.Tag);
                ObjProperty.BrokerId = Convert.ToInt32(txtDalalName.Tag);
                ObjProperty.Cts = Convert.ToDouble(txtCts.Text);
                ObjProperty.Rate = Convert.ToDouble(txtRate.Text);
                ObjProperty.RafPer = Convert.ToDouble(txtPer.Text);
                ObjProperty.BasicTotal = Convert.ToDouble(txtBasicTotal.Text);
                ObjProperty.AngadiyaPer = Convert.ToDouble(txtAngadiyaPer.Text);
                ObjProperty.AngadiyaKharch = Convert.ToDouble(txtAngadiyaValue.Text);
                ObjProperty.FinalTotal = Convert.ToDouble(txtFinalTotal.Text);
                ObjProperty.PaidAmount = Convert.ToDouble(txtDonePayment.Text);
                ObjProperty.PendingAmount = Convert.ToDouble(txtPendingPayment.Text);

                int RetVal = new MST_Kharidi_Function().InsertUpdate(ObjProperty);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Record Save Successfully...","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Clear();
                    FillGrid();
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Are you sure to delete record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                //int Id = Convert.ToInt32(dgvEmpMaster.GetFocusedRowCellValue("employeeid"));
                if (Id > 0)
                {
                    int RetVal = new MST_Kharidi_Function().Delete(Id);

                    if (RetVal > 0)
                    {
                        XtraMessageBox.Show("Record Deleted Successfully !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillGrid();
                        Clear();
                    }
                    else
                    {
                        XtraMessageBox.Show("Delete Failed !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Please Select Record.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Delete Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show(ex.Message, "Clear Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Grid Event
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {
                    Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                    txtNotNo.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("NOT NO"));
                    txtKatNo.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("KAT NO"));
                    dtpKharidiDate.DateTime = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("KHARIDI DATE"));
                    dtpPaymentDate.DateTime = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("PAYMENT DATE"));
                    txtPaymentTerm.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("PAYMENT TERM"));
                    txtPartyName.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("PARTY NAME"));
                    txtPartyName.Tag = Convert.ToString(gridView1.GetFocusedRowCellValue("PartyId"));
                    txtDalalName.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("DALAL NAME"));
                    txtDalalName.Tag = Convert.ToString(gridView1.GetFocusedRowCellValue("BrokerId"));
                    txtCts.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("CTS"));
                    txtRate.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("RATE"));
                    txtPer.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("PERCENTAGE"));
                    txtBasicTotal.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("BASIC TOTAL"));
                    txtAngadiyaPer.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("ANGADIYA PER"));
                    txtAngadiyaValue.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("ANGADIYA AMT"));
                    txtFinalTotal.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("FINAL TOTAL"));
                    txtPendingPayment.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("ANGADIYA AMT"));
                    txtDonePayment.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("FINAL TOTAL"));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Double Click",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        private void txtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new MST_Party_Function().PartyMasterGetDataFOrGrid(" PartyType in('KHARIDI') AND Active = 1");
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

        private void GetNotNumber()
        {
            DataTable dt = new MST_Kharidi_Function().KharidiMasterGetNotNo(0);
            if (dt.Rows.Count == 1)
            {
                txtNotNo.Text = Convert.ToString(dt.Rows[0]["MAXNO"]);
            }
            else
            {
                txtNotNo.Text = string.Empty;
            }
        }

        private void txtDonePayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateFinalTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Payment Done",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

        private void txtBasicTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateFinalTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Payment Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
