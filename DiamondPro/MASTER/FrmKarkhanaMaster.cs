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
using DiamondPro.BLL.Function_Class;

namespace DiamondPro
{
    public partial class FrmKarkhanaMaster : DevExpress.XtraEditors.XtraForm
    {
        int Id = 0;
        bool SaveFlag = true;
        int count = 0;

        #region Constructor
        public FrmKarkhanaMaster()
        {
            InitializeComponent();
        }
        #endregion

        #region Main Event
        private void FrmKharidiMaster_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        #endregion

        #region Text Event
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                count++;
                if (count == 2)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            else
                count = 0;
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region User Function
        private void Clear()
        {
            Id = 0;
            txtKarkhanaName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            cmbActive.SelectedIndex = -1;
            txtOwnerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            FillGrid();
        }

        private bool SaveValidation()
        {
            //SaveFlag = false;
            string ErrorMsg = string.Empty;

            if (txtKarkhanaName.Text == "")
            {
                ErrorMsg = ErrorMsg + "Parameter Type is Required.\n";
            }
                        
            if (ErrorMsg != "")
            {
                SaveFlag = false;
                XtraMessageBox.Show(ErrorMsg, "Save Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return SaveFlag;
        }

        private void FillGrid()
        {
            try
            {
                DataTable dt = new MST_Karkhana_Function().GetDataFoGrid("");
                if (dt.Rows.Count > 0)
                {
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = dt;
                    gridView1.BestFitColumns();
                    gridView1.Columns["Id"].Visible = false;
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

                MST_Karkhana_Property ObjProperty = new MST_Karkhana_Property();
                ObjProperty.Id = Id;
                ObjProperty.KarkhanaName = txtKarkhanaName.Text;
                ObjProperty.OwnerName = txtOwnerName.Text;
                ObjProperty.Mobile = txtMobile.Text;
                ObjProperty.Address = txtAddress.Text;
                ObjProperty.Active = cmbActive.Text == "YES" ? 1 : 0;

                int RetVal = new MST_Karkhana_Function().InsertUpdate(ObjProperty);

                if (RetVal > 0)
                {
                    XtraMessageBox.Show("Record Save Successfully...", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
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
                    int RetVal = new MST_Party_Function().Delete(Id);

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
                    Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    txtKarkhanaName.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("KARKHANA NAME"));
                    txtOwnerName.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("OWNER"));
                    txtMobile.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("MOBILE"));
                    txtAddress.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("ADDRESS"));
                    cmbActive.Text = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ACTIVE")) == 1 ? "YES" : "NO";
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
