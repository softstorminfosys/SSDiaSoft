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


namespace DiamondPro.MASTER
{
    public partial class FrmVechan : DevExpress.XtraEditors.XtraForm
    {
        int Id = 0;
        bool SaveFlag = true;
        public FrmVechan()
        {
            InitializeComponent();
        }
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
                ObjProperty.VechanNotno = txtVechanNotNo.Text;
                ObjProperty.Quality = txtQtyName.Text;
                ObjProperty.QualitySize= txtQtySize.Text;
                ObjProperty.VechanDate = dtpVechanDate.DateTime.ToString();
                ObjProperty.PaymentDate = dtpPaymentDate.DateTime.ToString();
                ObjProperty.Term = Convert.ToInt32(txtPaymentTerm.Text);
                ObjProperty.PartyId = Convert.ToInt32(txtPartyName.Tag);
                ObjProperty.BrokerId = Convert.ToInt32(txtDalalName.Tag);
                ObjProperty.Cts = Convert.ToDouble(txtCts.Text);
                ObjProperty.Rate = Convert.ToDouble(txtRate.Text);
                ObjProperty.VechanPer = Convert.ToDouble(txtPer.Text);
                ObjProperty.BasicTotal = Convert.ToDouble(txtBasicTotal.Text);
                ObjProperty.AngadiyaPer = Convert.ToDouble(txtAngadiyaPer.Text);
                ObjProperty.AngadiyaKharch = Convert.ToDouble(txtAngadiyaValue.Text);
                ObjProperty.BroPer=Convert.ToDouble(txtBroPer.Text);
                ObjProperty.BroAmount = Convert.ToDouble(txtBroAmt.Text); ;
                ObjProperty.FinalTotal = Convert.ToDouble(txtFinalTotal.Text);
                ObjProperty.PaidAmount = Convert.ToDouble(txtDonePayment.Text);
                ObjProperty.PendingAmount = Convert.ToDouble(txtPendingPayment.Text);

                int RetVal = new MST_Vechan_Function().InsertUpdate(ObjProperty);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Record Save Successfully...", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Clear();
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
        #endregion

        #region User Function
        private bool SaveValidation()
        {
            //SaveFlag = false;
            string ErrorMsg = string.Empty;
            if (txtVechanNotNo.Text == "")
            {
                ErrorMsg = "Vechan Not No is Required.\n";
            }

            if (txtQtyName.Text == "")
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
                XtraMessageBox.Show(ErrorMsg, "Save Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return SaveFlag;
        }
        #endregion
    }
}