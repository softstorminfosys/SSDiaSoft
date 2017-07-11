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

namespace DiamondPro.TRANSACTION
{
    public partial class FrmPaymentDetail : DevExpress.XtraEditors.XtraForm
    {
        int PaymentId = 0;
        int PaymentType = 0;
        DataTable dtSearch = new DataTable();

        #region Constructor
        public FrmPaymentDetail()
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
                ObjProperty.PartyId = Convert.ToInt32(txtPartyName.Tag);
                ObjProperty.PaymentDate = DateTime.Parse(dtpPaymentDate.EditValue.ToString()).ToString("yyyy/MM/dd");
                ObjProperty.KharidiDate = DateTime.Parse(dtpKharidiDate.EditValue.ToString()).ToString("yyyy/MM/dd");
                ObjProperty.NotNo = txtNotNo.Text;
                ObjProperty.KatNo = txtKatNo.Text;
                ObjProperty.Cts = Convert.ToDouble(txtCts.Text);
                ObjProperty.Rate = Convert.ToDouble(txtRate.Text);
                ObjProperty.Amount = Convert.ToDouble(txtTotalAmt.Text);
                ObjProperty.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
                ObjProperty.DueAmount = Convert.ToDouble(txtDueAmount.Text);

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
            txtNotNo.Text = string.Empty;
            txtKatNo.Text = string.Empty;
            dtpPaymentDate.EditValue = System.DateTime.Now;
            dtpKharidiDate.EditValue = System.DateTime.Now;
            txtCts.Text = "0.000";
            txtRate.Text = "0.000";
            txtTotalAmt.Text = "0.000";
            txtPaidAmount.Text = "0.000";
            txtDueAmount.Text = "0.000";
            EnableAll();
        }

        private void DesableAll()
        {
            txtNotNo.Enabled = false;
            txtKatNo.Enabled = false;
            dtpKharidiDate.Enabled = false;
            dtpPaymentDate.Enabled = false;
            txtCts.Enabled = false;
            txtRate.Enabled = false;
            txtTotalAmt.Enabled = false;
        }

        private void EnableAll()
        {
            txtNotNo.Enabled = true;
            txtKatNo.Enabled = true;
            dtpKharidiDate.Enabled = true;
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

            if (txtNotNo.Text == "")
            {
                ErrorMsg = ErrorMsg + "\n Not No is Required.";
            }

            if (txtKatNo.Text == "")
            {
                ErrorMsg = ErrorMsg + "\n Kat No is Required.";
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
            txtDueAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - Convert.ToDouble(txtPaidAmount.Text));
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
                    DataTable dtParty = new TRN_Payment_detail_Function().FillNotNo("PartyId = "+ txtPartyName.Tag +"",PaymentType);
                    //dtParty.Columns["PARTY NAME"].SetOrdinal(1);
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "NotNo";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmKharidiMaster");
                    frm.ShowDialog();
                    e.Handled = true;
                    if (!frm.FlagExit)
                    {
                        txtNotNo.Text = frm.Dr.Cells["NotNo"].Value.ToString();
                        txtKatNo.Text = frm.Dr.Cells["KatNo"].Value.ToString();
                        dtpKharidiDate.EditValue = frm.Dr.Cells["KharidiDate"].Value.ToString();
                        dtpPaymentDate.EditValue = frm.Dr.Cells["PaymentDate"].Value.ToString();
                        txtCts.Text = frm.Dr.Cells["Cts"].Value.ToString();
                        txtRate.Text = frm.Dr.Cells["Rate"].Value.ToString();
                        txtTotalAmt.Text = frm.Dr.Cells["FinalTotal"].Value.ToString();

                        DesableAll();
                    }

                }

                if (e.KeyChar == 8)
                {
                    txtNotNo.Text = string.Empty;
                    txtKatNo.Text = string.Empty;
                    dtpPaymentDate.EditValue = System.DateTime.Now;
                    dtpKharidiDate.EditValue = System.DateTime.Now;
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

        private void txtKatNo_KeyPress(object sender, KeyPressEventArgs e)
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
                    DataTable dtParty = new TRN_Payment_detail_Function().FillNotNo("PartyId = " + txtPartyName.Tag + "", PaymentType);
                    //dtParty.Columns["PARTY NAME"].SetOrdinal(1);
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "NotNo";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmKharidiMaster");
                    frm.ShowDialog();
                    e.Handled = true;
                    if (!frm.FlagExit)
                    {
                        txtNotNo.Text = frm.Dr.Cells["NotNo"].Value.ToString();
                        txtKatNo.Text = frm.Dr.Cells["KatNo"].Value.ToString();
                        dtpKharidiDate.EditValue = frm.Dr.Cells["KharidiDate"].Value.ToString();
                        dtpPaymentDate.EditValue = frm.Dr.Cells["PaymentDate"].Value.ToString();
                        txtCts.Text = frm.Dr.Cells["Cts"].Value.ToString();
                        txtRate.Text = frm.Dr.Cells["Rate"].Value.ToString();
                        txtTotalAmt.Text = frm.Dr.Cells["FinalTotal"].Value.ToString();

                        DesableAll();
                    }

                }

                if (e.KeyChar == 8)
                {
                    txtNotNo.Text = string.Empty;
                    txtKatNo.Text = string.Empty;
                    dtpPaymentDate.EditValue = System.DateTime.Now;
                    dtpKharidiDate.EditValue = System.DateTime.Now;
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