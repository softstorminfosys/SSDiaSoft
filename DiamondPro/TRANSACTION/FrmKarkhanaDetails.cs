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
    public partial class FrmKarkhanaDetails : DevExpress.XtraEditors.XtraForm
    {
        int Id = 0;
        bool SaveFlag = true;
        

        #region Constructor
        public FrmKarkhanaDetails()
        {
            InitializeComponent();
        }
        #endregion

        #region Main Event
        private void FrmKharidiMaster_Load(object sender, EventArgs e)
        {
            dtpReturnDate.EditValue = System.DateTime.Now;            
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
                Karkhana_Return_Property ObjProperty = new Karkhana_Return_Property();
                ObjProperty.Id = Id;
                ObjProperty.KarkhanaId = Convert.ToInt32(txtKarkhanaName.Tag);
                ObjProperty.IssueDate = DateTime.Parse(dtpIssueDate.EditValue.ToString()).ToString("MM/dd/yyyy");
                ObjProperty.ReturnDate = DateTime.Parse(dtpReturnDate.EditValue.ToString()).ToString("MM/dd/yyyy");
                ObjProperty.NotNo = txtNotNo.Text;
                ObjProperty.KatNo = txtKatNo.Text;
                ObjProperty.Kharididate = DateTime.Parse(dtpKharidiDate.EditValue.ToString()).ToString("MM/dd/yyyy");
                ObjProperty.KachuVajan = Convert.ToDouble(txtCts.Text);
                ObjProperty.Rate = Convert.ToDouble(txtRate.Text);
                ObjProperty.Amount = Convert.ToDouble(txtAmount.Text);
                ObjProperty.BanvaChadelu = Convert.ToDouble(txtBanvaChadelu.Text);
                ObjProperty.VajanLoss = Convert.ToDouble(txtCtsLoss.Text);
                ObjProperty.VajanGhatt = Convert.ToDouble(txtVajanGhatt.Text);
                ObjProperty.PalsuVajan = Convert.ToDouble(txtPalsuKachu.Text);
                ObjProperty.PalsuRate = Convert.ToDouble(txtPalsuRate.Text);
                ObjProperty.PalsuAmount = Convert.ToDouble(txtPalsuAmount.Text);
                ObjProperty.ChokiVajan = Convert.ToDouble(txtChokiVajan.Text);
                ObjProperty.ChokiRate = Convert.ToDouble(txtChokiRate.Text);
                ObjProperty.ChokiAmount = Convert.ToDouble(txtChokiAmount.Text);
                ObjProperty.DblVajan = Convert.ToDouble(txtDblVajan.Text);
                ObjProperty.DblRate = Convert.ToDouble(txtDblRate.Text);
                ObjProperty.DblAmount = Convert.ToDouble(txtDblAmount.Text);
                ObjProperty.PCDAmount = Convert.ToDouble(txtPCDAmount.Text);
                ObjProperty.Than = Convert.ToInt32(txtThan.Text);
                ObjProperty.ThanTotal = Convert.ToDouble(txtThanTotal.Text);
                ObjProperty.TaiyarVajan = Convert.ToDouble(txtTaiyarVajan.Text);
                ObjProperty.TaiyarPadatar = Convert.ToDouble(txtTaiyarPadatar.Text);
                ObjProperty.CommPadatar = Convert.ToDouble(txtComissionTaiyar.Text);
                ObjProperty.FinalPadatar = Convert.ToDouble(txtFinalPadatar.Text);
                ObjProperty.STaka = Convert.ToDouble(txtSTaka.Text);
                ObjProperty.RafTaka = Convert.ToDouble(txtRafTaka.Text);
                ObjProperty.ThanMajuri = Convert.ToDouble(txtThanMajuri.Text);
                ObjProperty.CommMajuri = Convert.ToDouble(txtComissionMajuri.Text);
                ObjProperty.FinalPadatarTaka = Convert.ToDouble(txtFinalPer.Text);
                ObjProperty.FinalAmount = Convert.ToDouble(txtFinalAmount.Text);
                ObjProperty.Status = "R";

                int RetVal = new Karkhana_Return_Function().InsertUpdate(ObjProperty);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Save Successfully...!!!","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    XtraMessageBox.Show("Save Failed...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Save Click",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                    int RetVal = new Karkhana_Return_Function().Delete(Id,Convert.ToInt32(txtKarkhanaName.Tag),txtNotNo.Text,txtKatNo.Text);

                    if (RetVal > 0)
                    {
                        XtraMessageBox.Show("Record Deleted Successfully !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //FillGrid();
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

        private void SBtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                panelControl1.Visible = false;
                panelControl3.Visible = true;
                panelControl3.Dock = DockStyle.Fill;
                FillGrid();
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
                panelControl3.Visible = false;
                panelControl3.Dock = DockStyle.Fill;
                Clear();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Close Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region User Function
        private void Clear()
        {
            Id = 0;
            txtNotNo.Text = string.Empty;
            txtKatNo.Text = string.Empty;
            dtpKharidiDate.EditValue = System.DateTime.Now;
            txtCts.Text = "0.000";
            txtRate.Text = "0.00";
            txtAmount.Text = "0.00";
            txtBanvaChadelu.Text = "0.000";
            txtCtsLoss.Text = "0.000";
            txtVajanGhatt.Text = "0.000";
            txtPalsuKachu.Text = "0.000";
            txtPalsuRate.Text = "0.00";
            txtPalsuAmount.Text = "0.00";
            txtChokiVajan.Text = "0.000";
            txtChokiRate.Text = "0.00";
            txtChokiAmount.Text = "0.00";
            txtDblVajan.Text = "0.000";
            txtDblRate.Text = "0.00";
            txtDblAmount.Text = "0.00";
            txtPCDAmount.Text = "0.00";
            txtThan.Text = "0.00";
            txtThanTotal.Text = "0.00";
            txtTaiyarVajan.Text = "0.000";
            txtTaiyarPadatar.Text = "0.00";
            txtComissionTaiyar.Text = "0.00";
            txtFinalPadatar.Text = "0.00";
            txtSTaka.Text = "0.00";
            txtRafTaka.Text = "0.00";
            txtThanMajuri.Text = "0.00";
            txtComissionMajuri.Text = "0.00";
            txtFinalPer.Text = "0.00";
            //FillGrid();
        }

        private bool SaveValidation()
        {
            string ErrorMsg = string.Empty;
            if (txtNotNo.Text == "")
            {
                ErrorMsg = "Not No is required.\n";
            }
            if (txtKatNo.Text == "")
            {
                ErrorMsg = "Kat No is required.\n";
            }
            if (Convert.ToDouble(txtBanvaChadelu.Text) != (Convert.ToDouble(txtCtsLoss.Text) + Convert.ToDouble(txtTaiyarVajan.Text)))
            {
                ErrorMsg = "Banava Chadelu Vajan is Wrong Please Check.\n";
            }
            if (Convert.ToDouble(txtCts.Text) != (Convert.ToDouble(txtBanvaChadelu.Text) + Convert.ToDouble(txtVajanGhatt.Text) + Convert.ToDouble(txtDblVajan.Text) + Convert.ToDouble(txtChokiVajan.Text) + Convert.ToDouble(txtPalsuKachu.Text)))
            {
                ErrorMsg = "Total Vajan is not Match with Kul Vajan.\n";
            }
            if (ErrorMsg != "")
            {
                XtraMessageBox.Show(ErrorMsg,"Save Validation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void FillGrid()
        {
            try
            {
                DataTable dt = new Karkhana_Return_Function().GetDataFoGrid("");
                if (dt.Rows.Count > 0)
                {
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = dt;
                    gridView1.BestFitColumns();
                    gridView1.Columns["Id"].Visible = false;
                    gridView1.Columns["KarkhanaId"].Visible = false;
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

        private double CalculatePCD()
        {
            double PCD = 0;
            PCD = Convert.ToDouble(txtPalsuAmount.Text) + Convert.ToDouble(txtChokiAmount.Text) + Convert.ToDouble(txtDblAmount.Text);
            return PCD;
        }

        private double CalculateThanAmount()
        {
            double TA = 0;
            TA = Convert.ToDouble(txtThan.Text) * Convert.ToDouble(txtThanMajuri.Text);
            return TA;
        }

        private void CalcBanavaChadelu()
        {
            double BanavaChadelu = 0;
            BanavaChadelu = Convert.ToDouble(txtCtsLoss.Text) + Convert.ToDouble(txtTaiyarVajan.Text);
            txtBanvaChadelu.Text = BanavaChadelu.ToString();
        }

        private void CalcTaiyarPadatar()
        {
            double TaiyarPadatar = 0;
           if (Convert.ToDouble(txtTaiyarVajan.Text) > 0)
            {
                TaiyarPadatar = (Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(txtThanTotal.Text) - Convert.ToDouble(txtPCDAmount.Text)) / Convert.ToDouble(txtTaiyarVajan.Text);
                txtTaiyarPadatar.Text = Convert.ToInt32(TaiyarPadatar).ToString();
            }
           else
               txtTaiyarPadatar.Text = "0.00";
        }
        private void Calccomissionpadatar()
        {
            double commissionper = 0;
            //if (Convert.ToDouble(txtComissionMajuri.Text) > 0)
            //{
            commissionper = (Convert.ToDouble(txtComissionMajuri.Text) + Convert.ToDouble(txtTaiyarPadatar.Text));
            txtComissionTaiyar.Text =(Convert.ToInt32(commissionper)).ToString();
            //}
            // else
            //   txtRafTaka.Text = "0.00";
        }

        private void CalcMarginTaka()
        {
            double Mtaka = 0;
            double CTM = 0;
            if (Convert.ToDouble(txtFinalPer.Text) > 0)
            {
                Mtaka = Math.Round(Convert.ToDouble(txtComissionTaiyar.Text) * 100) / Convert.ToDouble(txtFinalPer.Text);
                int Mtaka1 = Convert.ToInt32(Mtaka);
                txtFinalPadatar.Text = Mtaka1.ToString();
                CTM = Convert.ToDouble(txtFinalPadatar.Text) - Convert.ToDouble(txtComissionTaiyar.Text);
                txtctmargin.Text = CTM.ToString();
                txtrufmargin.Text = (CTM * Convert.ToDouble(txtTaiyarVajan.Text)).ToString(); ;
            }
            else
            {
                txtFinalPadatar.Text = txtComissionTaiyar.Text;
            }
            CalcRafTaka();
            CalcSTaka();
           
        }
        private void CalcSTaka()
        {
            double Staka = 0;
            if (Convert.ToDouble(txtBanvaChadelu.Text) > 0)
            {
                Staka = (Convert.ToDouble(txtTaiyarVajan.Text) * 100) / Convert.ToDouble(txtBanvaChadelu.Text);
                txtSTaka.Text = Staka.ToString();
            }
            else
                txtSTaka.Text = "0.00";
        }

       
       
        private void CalcRafTaka()
        {
            double RTaka = 0;
            if (Convert.ToDouble(txtCts.Text) > 0)
            {
                RTaka = (Convert.ToDouble(txtTaiyarVajan.Text) * 100) / Convert.ToDouble(txtCts.Text);
                txtRafTaka.Text = RTaka.ToString();
            }
            else
                txtRafTaka.Text = "0.00";
        }
        #endregion

        #region TextBox Event
        private void txtKarkhanaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new MST_Karkhana_Function().GetDataFoGrid(" Active = 1");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "KarkhanaName";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmKarkhanaMaster");
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
                        txtKarkhanaName.Text = frm.Dr.Cells["KARKHANA NAME"].Value.ToString();
                        txtKarkhanaName.Tag = frm.Dr.Cells["Id"].Value.ToString();
                    }
                }

                if (e.KeyChar == 8)
                {
                    txtKarkhanaName.Text = "";
                    txtKarkhanaName.Tag = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Karkhana KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new Karkhana_Issue_Function().GetDataFoGrid("[Status] = 'I' AND KarkhanaName='"+txtKarkhanaName.Text+"'");
                    //dtParty.Columns["PARTY NAME"].SetOrdinal(1);
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "NOT NO";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmKharidiMaster");
                    frm.ShowDialog();
                    e.Handled = true;
                    if (!frm.FlagExit)
                    {
                        txtNotNo.Text = frm.Dr.Cells["NOT NO"].Value.ToString();
                        txtKatNo.Text = frm.Dr.Cells["KAT NO"].Value.ToString();
                        dtpKharidiDate.EditValue = frm.Dr.Cells["KHARIDI DATE"].Value.ToString();
                        txtCts.Text = frm.Dr.Cells["VAJAN"].Value.ToString();
                        txtRate.Text = frm.Dr.Cells["RATE"].Value.ToString();
                        txtAmount.Text = frm.Dr.Cells["AMOUNT"].Value.ToString();
                        dtpIssueDate.EditValue = frm.Dr.Cells["ISSUE DATE"].Value.ToString();

                    }
                }

                if (e.KeyChar == 8)
                {
                    txtNotNo.Text = string.Empty;
                    txtKatNo.Text = string.Empty;
                    dtpKharidiDate.EditValue = System.DateTime.Now;
                    txtCts.Text = "0.000";
                    txtRate.Text = "0.000";
                    txtAmount.Text = "0.000";

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "NotNo KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPalsuAmount_TextChanged(object sender, EventArgs e)
        {
            txtPCDAmount.Text = Convert.ToString(CalculatePCD());
        }

        protected void txtTaiyarVajan_TextChanged(object sender, EventArgs e)
        {
            CalcTaiyarPadatar();
            CalcSTaka();
            CalcRafTaka();
            Calccomissionpadatar();
            CalcMarginTaka();
            //txtComissionMajuri_TextChanged(null, EventArgs.Empty);
        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
          
           txtTaiyarVajan_TextChanged(null, EventArgs.Empty);

        }
        private void txtPCDAmount_TextChanged(object sender, EventArgs e)
        {
            txtTaiyarVajan_TextChanged(null, EventArgs.Empty);
        }

        private void txtThanTotal_TextChanged(object sender, EventArgs e)
        {
            //CalcTaiyarPadatar();
            txtTaiyarVajan_TextChanged(null, EventArgs.Empty);
        }

        private void txtBanvaChadelu_TextChanged(object sender, EventArgs e)
        {
            CalcSTaka();
        }

        private void txtCts_TextChanged(object sender, EventArgs e)
        {
            CalcRafTaka();
        }

        private void txtPalsuKachu_TextChanged(object sender, EventArgs e)
        {
            txtPalsuAmount.Text = Convert.ToString(Convert.ToDouble(txtPalsuKachu.Text) * Convert.ToDouble(txtPalsuRate.Text));
            CalculatePCD();
        }
        private void txtChokiVajan_TextChanged(object sender, EventArgs e)
        {
            txtChokiAmount.Text = Convert.ToString(Convert.ToDouble(txtChokiVajan.Text) * Convert.ToDouble(txtChokiRate.Text));
            CalculatePCD();
        }
        private void txtDblVajan_TextChanged(object sender, EventArgs e)
        {
            txtDblAmount.Text = Convert.ToString(Convert.ToDouble(txtDblVajan.Text) * Convert.ToDouble(txtDblRate.Text));
            CalculatePCD();
        }
        private void txtThan_TextChanged(object sender, EventArgs e)
        {
            CalculateThanAmount();
        }

        private void txtThanMajuri_TextChanged(object sender, EventArgs e)
        {
            txtThanTotal.Text = Convert.ToString(CalculateThanAmount()); 
        }

        private void txtComissionMajuri_TextChanged(object sender, EventArgs e)
        {
            Calccomissionpadatar();
            CalcMarginTaka();
        }
        private void txtFinalPer_TextChanged(object sender, EventArgs e)
        {
            CalcMarginTaka();
        }

        #endregion

        #region Grid Event
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {
                    Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    txtKarkhanaName.Tag = Convert.ToString(gridView1.GetFocusedRowCellValue("KarkhanaId"));
                    txtKarkhanaName.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("KARKHANA NAME"));
                    dtpIssueDate.EditValue = Convert.ToString(gridView1.GetFocusedRowCellValue("ISSUE DATE"));
                    dtpReturnDate.EditValue = Convert.ToString(gridView1.GetFocusedRowCellValue("REURN DATE"));
                    txtNotNo.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("NOT NO"));
                    txtKatNo.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("KAT NO"));
                    dtpKharidiDate.EditValue = Convert.ToString(gridView1.GetFocusedRowCellValue("KHARIDI DATE"));
                    txtCts.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("VAJAN"));
                    txtRate.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("RATE"));
                    txtAmount.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("AMOUNT"));
                    txtBanvaChadelu.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("BANAVA CHADELU"));
                    txtCtsLoss.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("VAJAN LOSS"));
                    txtVajanGhatt.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("VAJAN GHATT"));
                    txtPalsuKachu.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("PALSU VAJAN"));
                    txtPalsuRate.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("PALSU RATE"));
                    txtPalsuAmount.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("PALSU AMOUNT"));
                    txtDblVajan.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("DOUBLE VAJAN"));
                    txtDblRate.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("DOUBLE RATE"));
                    txtDblAmount.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("DOUBLE AMOUNT"));
                    txtChokiVajan.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("CHOKI VAJAN"));
                    txtChokiRate.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("CHOKI RATE"));
                    txtChokiAmount.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("CHOKI AMOUNT"));
                    txtPCDAmount.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("PCD AMOUNT"));
                    txtThan.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("THAN"));
                    txtThanTotal.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("THAN TOTAL"));
                    txtTaiyarVajan.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("TAIYAR VAJAN"));
                    txtTaiyarPadatar.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("TAIYAR PADATAR"));
                    txtComissionTaiyar.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("COMISSION PADATAR"));
                    txtFinalPadatar.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("FINAL PADATAR"));
                    txtSTaka.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("S-TAKA"));
                    txtRafTaka.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("RAF TAKA"));
                    txtThanMajuri.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("THAN MAJURI"));
                    txtComissionMajuri.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("COMISSION MAJURI"));
                    txtFinalPer.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("FINAL PADATAR PER"));

                    panelControl1.Visible = true;
                    panelControl3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Double Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

      
      

      

      
    }
}
