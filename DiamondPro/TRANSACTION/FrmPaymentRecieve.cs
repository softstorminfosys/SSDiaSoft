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
using DiamondPro.BLL.Property_Class;
using Param_Hospital.BLL.Property_Class;
using DiamondPro.Search;
using DiamondPro.DLL;

namespace DiamondPro.TRANSACTION
{
    public partial class FrmPaymentRecieve : DevExpress.XtraEditors.XtraForm
    {
        Validation Val = new Validation();
        int PaymentId = 0;
        int PaymentType = 0;
        DataTable dtSearch = new DataTable();

        #region Constructor
        public FrmPaymentRecieve()
        {
            InitializeComponent();
        }
        #endregion

        #region Main Event

        private void FrmPaymentDetail_Load(object sender, EventArgs e)
        {
            //dtpKharidiDate.EditValue = System.DateTime.Now;

            CmbPaymentType.SelectedIndex = 0;
            Guid guid = Guid.NewGuid();
            lblTransId.Text = guid.ToString();
        }
        #endregion

        #region Click Event
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SaveValidation())
                {
                    return;
                }

                TRN_Payment_detail_Property ObjProperty = new TRN_Payment_detail_Property();
                ObjProperty.Id = PaymentId;
                ObjProperty.TransId = lblTransId.Text;
                ObjProperty.PaymentType = CmbPaymentType.Text;
                ObjProperty.PartyId = Val.ToInt(txtPartyName.Tag);
                ObjProperty.PaymentDate = DateTime.Parse(dtpPaymentDate.EditValue.ToString()).ToString("yyyy/MM/dd");
                ObjProperty.KharidiDate = DateTime.Parse(dtpVechanDate.EditValue.ToString()).ToString("yyyy/MM/dd");
                ObjProperty.NotNo = txtVechanNo.Text;
                ObjProperty.Cts = Val.ToDouble(txtCts.Text);
                ObjProperty.Rate = Val.ToDouble(txtRate.Text);
                ObjProperty.Amount = Val.ToDouble(txtTotalAmt.Text);
                ObjProperty.AngadiyaPer = Val.ToDouble(txtAngadiyaPer.Text);
                ObjProperty.AngadiyaAmt = Val.ToDouble(txtAngadiyaValue.Text);
                ObjProperty.PaidAmount = Val.ToDouble(txtPaidAmount.Text);
                ObjProperty.DueAmount = Val.ToDouble(txtDueAmount.Text);

                int RetVal = new TRN_Payment_detail_Function().InsertUpdate(ObjProperty,PaymentType);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Payment Successfully Done...!!!","Save Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    XtraMessageBox.Show("Payment Failed...!!!", "Save Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Save Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Delete Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region User Function
        private void Clear()
        {
            PaymentId = 0;
            CmbPaymentType.SelectedIndex = 0;
            txtPartyName.Text = string.Empty;
            txtPartyName.Tag = string.Empty;
            txtVechanNo.Text = string.Empty;
            //txtKatNo.Text = string.Empty;
            dtpPaymentDate.EditValue = System.DateTime.Now;
            dtpVechanDate.EditValue = System.DateTime.Now;
            txtCts.Text = "0.000";
            txtRate.Text = "0.000";
            txtTotalAmt.Text = "0.000";
            txtPaidAmount.Text = "0.000";
            txtDueAmount.Text = "0.000";
            EnableAll();
        }

        private void DesableAll()
        {
            txtVechanNo.Enabled = false;
            txtKatNo.Enabled = false;
            dtpVechanDate.Enabled = false;
            dtpPaymentDate.Enabled = false;
            txtCts.Enabled = false;
            txtRate.Enabled = false;
            txtTotalAmt.Enabled = false;
        }

        private void EnableAll()
        {
            txtVechanNo.Enabled = true;
            txtKatNo.Enabled = true;
            dtpVechanDate.Enabled = true;
            dtpPaymentDate.Enabled = true;
            txtCts.Enabled = true;
            txtRate.Enabled = true;
            txtTotalAmt.Enabled = true;
        }

        private bool SaveValidation()
        {
            string ErrorMsg = string.Empty;
            if (CmbPaymentType.Text == "" || CmbPaymentType.SelectedIndex == -1) 
            {
                ErrorMsg = "Payment Type is Required.";

            }
            if (txtPartyName.Text == "")
            {
                ErrorMsg = ErrorMsg + "\n Party Name is Required.";
            }

            if (txtVechanNo.Text == "")
            {
                ErrorMsg = ErrorMsg + "\n Vechan No is Required.";
            }

            if (ErrorMsg != "")
            {
                XtraMessageBox.Show(ErrorMsg,"Save Validation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;

            }

            return true;
        }
        #endregion

        #region TextBox Event
        private void txtPaidAmount_EditValueChanged(object sender, EventArgs e)
        {
            txtDueAmount.Text = Val.ToString(Convert.ToDouble(txtFinalTotal.Text) - Val.ToDouble(txtPaidAmount.Text));
        }

        private void txtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (CmbPaymentType.Text == "" || CmbPaymentType.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("Please Select Payment Type","Party Selection",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new MST_Party_Function().PartyMasterGetDataFOrGrid(" Active = 1");
                    dtParty.Columns["PARTY NAME"].SetOrdinal(1);
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

        private void txtNotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtPartyName.Text == "")
                {
                    XtraMessageBox.Show("Please Select Party.", "NotNo Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new TRN_Payment_detail_Function().FillVechanNo("Vechanno = " + txtPartyName.Tag + "");
                    //dtParty.Columns["PARTY NAME"].SetOrdinal(1);
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "NotNo";

                    FrmSearch frm = new FrmSearch(frmSearch, "");
                    frm.ShowDialog();
                    e.Handled = true;
                    if (!frm.FlagExit)
                    {
                        txtVechanNo.Text = frm.Dr.Cells["Vechanno"].Value.ToString();
                        dtpVechanDate.EditValue = frm.Dr.Cells["VechanDate"].Value.ToString();
                        dtpPaymentDate.EditValue = frm.Dr.Cells["PaymentDate"].Value.ToString();
                        txtCts.Text = frm.Dr.Cells["Cts"].Value.ToString();
                        txtRate.Text = frm.Dr.Cells["Rate"].Value.ToString();
                        txtTotalAmt.Text = frm.Dr.Cells["FinalTotal"].Value.ToString();
                        txtPaidAmount.Text = frm.Dr.Cells["PaidAmount"].Value.ToString();
                        DesableAll();
                    }

                }

                if (e.KeyChar == 8)
                {
                    txtVechanNo.Text = string.Empty;
                    txtKatNo.Text = string.Empty;
                    dtpPaymentDate.EditValue = System.DateTime.Now;
                    dtpVechanDate.EditValue = System.DateTime.Now;
                    txtCts.Text = "0.000";
                    txtRate.Text = "0.000";
                    txtTotalAmt.Text = "0.000";
                    txtPaidAmount.Text = "0.000";
                    txtDueAmount.Text = "0.000";

                    EnableAll();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Party KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void txtAngadiyaPer_TextChanged(object sender, EventArgs e)
        {
            txtAngadiyaValue.Text = Val.ToString((Convert.ToDouble(txtTotalAmt.Text) * Val.ToDouble(txtAngadiyaPer.Text)) / 100);
        }

        private void txtAngadiyaValue_TextChanged(object sender, EventArgs e)
        {
            txtFinalTotal.Text = Val.ToString(Val.ToDouble(txtTotalAmt.Text) - Val.ToDouble(txtAngadiyaValue.Text));
        }
        #endregion

        #region Combo Event
        private void CmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbPaymentType.SelectedIndex == 0)
                {
                    PaymentType = 0;
                }
                else
                {
                    PaymentType = 1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"PaymentType Selection",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion
                
    }
}