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
using DiamondPro.BLL.Property_Class;
using DiamondPro.BLL.Function_Class;
using Param_Hospital.BLL.Property_Class; 

namespace DiamondPro
{
    public partial class FrmKarkhanaIssue : DevExpress.XtraEditors.XtraForm
    {
        int Id = 0;
        bool SaveFlag = true;

        #region Constructor
        public FrmKarkhanaIssue()
        {
            InitializeComponent();
        }
        #endregion

        #region Main Event
        private void FrmKharidiMaster_Load(object sender, EventArgs e)
        {
            dtpIssueDate.Text = System.DateTime.Now.ToShortDateString();
            FillGrid();
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

                Karkhana_Issue_Property ObjProperty = new Karkhana_Issue_Property();
                ObjProperty.Id = Id;
                ObjProperty.KarkhanaId = Convert.ToInt32(txtKarkhanaName.Tag);
                ObjProperty.IssueDate = DateTime.Parse(dtpIssueDate.Text).ToString("MM/dd/yyyy");
                ObjProperty.NotNo = txtNotNo.Text;
                ObjProperty.KatNo = txtKatNo.Text;
                ObjProperty.Kharididate = DateTime.Parse(dtpKharidiDate.Text).ToString("MM/dd/yyyy");
                ObjProperty.Vajan = Convert.ToDouble(txtCts.Text);
                ObjProperty.Rate = Convert.ToDouble(txtRate.Text);
                ObjProperty.Amount = Convert.ToDouble(txtAmount.Text);
                ObjProperty.BanvaChadelu = 0.00;
                ObjProperty.VajanLoss     = 0.00;
                ObjProperty.VajanGhatt    = 0.00;
                ObjProperty.PalsuVajan    = 0.00;
                ObjProperty.PalsuRate     = 0.00;
                ObjProperty.PalsuAmount   = 0.00;
                ObjProperty.ChokiVajan    = 0.00;
                ObjProperty.ChokiRate     = 0.00;
                ObjProperty.ChokiAmount   = 0.00;
                ObjProperty.DblVajan      = 0.00;
                ObjProperty.DblRate       = 0.00;
                ObjProperty.DblAmount     = 0.00;
                ObjProperty.PCDAmount     = 0.00;
                ObjProperty.Than          = 0;
                ObjProperty.ThanTotal     = 0.00;
                ObjProperty.TaiyarVajan   = 0.00;
                ObjProperty.TaiyarPadatar = 0.00;
                ObjProperty.CommPadatar   = 0.00;
                ObjProperty.FinalPadatar  = 0.00;
                ObjProperty.STaka         = 0.00;
                ObjProperty.RafTaka       = 0.00;
                ObjProperty.ThanMajuri    = 0.00;
                ObjProperty.CommMajuri    = 0.00;
                ObjProperty.FinalPadatarTaka = 0.00;
                ObjProperty.Status = "I";

                int RetVal = new Karkhana_Issue_Function().InsertUpdate(ObjProperty);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Save Successfully...!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
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
                if (XtraMessageBox.Show("Are you sure to delete record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                //int Id = Convert.ToInt32(dgvEmpMaster.GetFocusedRowCellValue("employeeid"));
                if (Id > 0)
                {
                    int RetVal = new Karkhana_Issue_Function().Delete(Id, Convert.ToInt32(txtKarkhanaName.Tag), txtNotNo.Text, Convert.ToInt32(txtKatNo.Text));

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
                XtraMessageBox.Show(ex.Message,"Delete Click",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region User Function
        private void Clear()
        {
            Id = 0;
            txtKarkhanaName.Text = string.Empty;
            txtKarkhanaName.Tag = string.Empty;
            txtNotNo.Text = string.Empty;
            txtKatNo.Text = string.Empty;
            dtpKharidiDate.Text = "";
            dtpIssueDate.EditValue = System.DateTime.Now;
            txtCts.Text = "0.000";
            txtRate.Text = "0.000";
            txtAmount.Text = "0.000";
            FillGrid();
        }

        public bool SaveValidation()
        {
            string ErroMsg = string.Empty;

            if (txtKatNo.Text == "")
            {
                ErroMsg = "Kat No is Required.\n";
            }

            if (txtNotNo.Text == "")
            {
                ErroMsg = ErroMsg + "Not No is Required.\n";
            }

            if (Convert.ToDouble(txtCts.Text) <= 0)
            {
                ErroMsg = ErroMsg + "Vajan Must be Greater Then Zero.\n";
            }

            if (Convert.ToDouble(txtRate.Text) <= 0)
            {
                ErroMsg = ErroMsg + "Rate Must be Greater Then Zero.\n";
            }

            if (Convert.ToDouble(txtAmount.Text) <= 0)
            {
                ErroMsg = ErroMsg + "Amount Must be Greater Then Zero.\n";
            }

            string KatNo = new Karkhana_Issue_Function().CheckNotNoIssue("[STATUS] = 'I' AND NotNo = '"+txtNotNo.Text+"' AND KatNo = '"+Convert.ToInt32(txtKatNo.Text)+"'", "TRN_Karkhana_IssueReturn", "KatNo");
            if (txtKatNo.Text == KatNo)
            {
                ErroMsg = ErroMsg + "Kat No is already issued.\n";
            }

            if (ErroMsg != "")
            {
                XtraMessageBox.Show(ErroMsg,"Save Validation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void FillGrid()
        {
            try
            {
                DataTable dt = new Karkhana_Issue_Function().GetDataFoGrid("");
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
        #endregion

        #region Grid Event
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {
                    Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    txtKarkhanaName.Tag = Convert.ToString(gridView1.GetFocusedRowCellValue("KarkhanaId"));
                    txtKarkhanaName.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("KARKHANA NAME"));
                    txtNotNo.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("NOT NO"));
                    txtKatNo.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("KAT NO"));
                    dtpKharidiDate.EditValue = Convert.ToString(gridView1.GetFocusedRowCellValue("KHARIDI DATE"));
                    txtCts.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("VAJAN"));
                    txtRate.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("RATE"));
                    txtAmount.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("AMOUNT"));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Double Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TextBox Event
        private void txtNotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new TRN_Payment_detail_Function().FilluniqueNotNo("", 1);
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
                        txtCts.Text = frm.Dr.Cells["Cts"].Value.ToString();
                        txtRate.Text = frm.Dr.Cells["Rate"].Value.ToString();
                        txtAmount.Text = frm.Dr.Cells["BasicTotal"].Value.ToString();                                                
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
                XtraMessageBox.Show(ex.Message, "Party KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new TRN_Payment_detail_Function().FillNotNo("", 1);
                    //dtParty.Columns["PARTY NAME"].SetOrdinal(1);
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "KatNo";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmKharidiMaster");
                    frm.ShowDialog();
                    e.Handled = true;
                    if (!frm.FlagExit)
                    {
                        txtNotNo.Text = frm.Dr.Cells["NotNo"].Value.ToString();
                        txtKatNo.Text = frm.Dr.Cells["KatNo"].Value.ToString();
                        dtpKharidiDate.EditValue = frm.Dr.Cells["KharidiDate"].Value.ToString();
                        txtCts.Text = frm.Dr.Cells["Cts"].Value.ToString();
                        txtRate.Text = frm.Dr.Cells["Rate"].Value.ToString();
                        txtAmount.Text = frm.Dr.Cells["FinalTotal"].Value.ToString();

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
                XtraMessageBox.Show(ex.Message, "Party KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKarkhanaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    DataTable dtParty = new MST_Karkhana_Function().GetDataFoGrid(" Active = 1");
                    FrmSearchProperty frmSearch = new FrmSearchProperty();
                    frmSearch.dtTable = dtParty.Copy();
                    frmSearch.serachfield = "KARKHANA NAME";

                    FrmSearch frm = new FrmSearch(frmSearch, "DiamondPro.FrmKarkhanaMaster");
                    frm.ShowDialog();
                    e.Handled = true;
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
        #endregion                            
    }
}
