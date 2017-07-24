using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using InterviewDemo.DLL;
using DiamondPro.DLL;
using DiamondPro.BLL.Function_Class;

namespace DiamondPro.MASTER
{
    public partial class FrmUsersRights : Form
    {
        Validation Val = new Validation();
        public FrmUsersRights()
        {
            InitializeComponent();
            //SQLServerDB.GetAllControls(this);
            //SQLServerDB.strFormName = "FrmUsersRights";
            //this.Icon = SoftStorm_Infosys.Properties.Resources.icon;
        }
        public int isallow = 0;

        #region Show, Save

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = new DataTable();
            //FrmLoading frmloader = new FrmLoading();
            //frmloader.Show();

            Type t = Type.GetType(Operation.MDI);
            MethodInfo method = t.GetMethod("menuListNew");
            Form c = Activator.CreateInstance(t) as Form;

            //will call menuListNew method and return datatable 
            object datatable = method.Invoke(c, null);
            dt = (DataTable)datatable;

            DataTable dtRights = new DataTable();
            try
            {
                //String strQuery = "Select * from tbluserrights where usertypeid=" + cmbUserType.SelectedValue;
                dtRights = new UserRights_Function().GetUserData(Val.ToInt(cmbUserType.SelectedValue));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
           
            grdUserRights.DataSource = dt;
            for (Int32 i = 0; i < grdUserRights.Rows.Count; i += 1)
            {
                if (Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString()) == 0 && Val.ToInt(grdUserRights.Rows[i].Cells["subitems"].Value.ToString()) > 0)
                    grdUserRights.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                if (Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString()) == 1 && Val.ToInt(grdUserRights.Rows[i].Cells["subitems"].Value.ToString()) > 0)
                {
                    grdUserRights.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(123, 123, 5 * Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString()));
                    grdUserRights.Rows[i].Cells["formnameText"].Style.ForeColor = Color.White;
                }
                if (Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString()) == 2 && Val.ToInt(grdUserRights.Rows[i].Cells["subitems"].Value.ToString()) > 0)
                {
                    grdUserRights.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                    grdUserRights.Rows[i].Cells["formnameText"].Style.ForeColor = Color.White;
                }
                if (Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString()) == 3 && Val.ToInt(grdUserRights.Rows[i].Cells["subitems"].Value.ToString()) > 0)
                    grdUserRights.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;


                grdUserRights.Rows[i].Cells["formnameText"].Style.Font = new Font("Vardana", 12, FontStyle.Bold);

                if (dtRights.Rows.Count > 0)
                {
                    dtRights.DefaultView.RowFilter = "formname='" + grdUserRights.Rows[i].Cells["formname"].Value.ToString() + "'";
                    if (dtRights.DefaultView.Count > 0)
                    {
                        grdUserRights.Rows[i].Cells["allow"].Value = dtRights.DefaultView[0]["allow"];
                        grdUserRights.Rows[i].Cells["addRights"].Value = dtRights.DefaultView[0]["addRights"];
                        grdUserRights.Rows[i].Cells["editRights"].Value = dtRights.DefaultView[0]["editRights"];
                        grdUserRights.Rows[i].Cells["delRights"].Value = dtRights.DefaultView[0]["delRights"];
                        grdUserRights.Rows[i].Cells["printRights"].Value = dtRights.DefaultView[0]["printRights"];
                    }
                }
                if (Val.ToInt(grdUserRights.Rows[i].Cells["subitems"].Value.ToString()) > 0 || Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString()) == 0)
                    grdUserRights.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(250, 255 - (40 * Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString())), 62 * Val.ToInt(grdUserRights.Rows[i].Cells["menulevel"].Value.ToString()));
                else
                    grdUserRights.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            //grdUserRights.Columns["formnameText"].Width = 200;

            this.Cursor = Cursors.Default;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //SQLServerDB.strFormName = "FrmUsersRights"; 
            //if (grdUserRights.Rows.Count <= 0)
            //    return;
            //this.Cursor = Cursors.WaitCursor;
            //DataTable dt = grdUserRights.DataSource as DataTable;

            //SQLServerDB objdb = new SQLServerDB();
            //try
            //{

            //    objdb.BeginTransaction(true);
            //    String strQry = "delete  tbluserrights where usertypeid=" + cmbUserType.SelectedValue;
            //    objdb.Prepare(strQry, CommandType.Text);
            //    objdb.delete_Record(strQry);

            //    for (int i = 0; i < grdUserRights.Rows.Count; i += 1)
            //    {
            //        Hashtable hTbl = new Hashtable();
            //        hTbl.Add("formname", grdUserRights.Rows[i].Cells["formname"].Value);
            //        hTbl.Add("formnametext", grdUserRights.Rows[i].Cells["formnameText"].Value);
            //        hTbl.Add("allow", grdUserRights.Rows[i].Cells["allow"].Value);
            //        hTbl.Add("addRights", grdUserRights.Rows[i].Cells["addRights"].Value);
            //        hTbl.Add("editRights", grdUserRights.Rows[i].Cells["editRights"].Value);
            //        hTbl.Add("delRights", grdUserRights.Rows[i].Cells["delRights"].Value);
            //        hTbl.Add("printRights", grdUserRights.Rows[i].Cells["printRights"].Value);
            //        hTbl.Add("usertypeid", cmbUserType.SelectedValue);
            //        hTbl.Add("menulevel", grdUserRights.Rows[i].Cells["menulevel"].Value);
            //        hTbl.Add("subitems", grdUserRights.Rows[i].Cells["subitems"].Value);
            //        hTbl.Add("cmpid", LOGIN_INFO.CmpID);

            //        objdb.insert_Record("tbluserrights", hTbl);
            //    }
            //    objdb.Commit(true);
            //    IISMessage.ShowMessage("Details are saved,Logout to change effect", IISMsgBoxType.Information);

            //}
            //catch (Exception Ex)
            //{
            //    objdb.Rollback(true);
            //    IISMessage.ShowMessage(Ex.Message, IISMsgBoxType.Error);
            //    return;
            //}
            //finally
            //{
            //    objdb.releaseObjects();
            //    this.Cursor = Cursors.Default;
            //}

            //if (Val.ToInt(cmbUserType.SelectedValue.ToString()) == LOGIN_INFO.UserID)
            //{
            //    for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //    {
            //        if (Application.OpenForms[i].Name != "FrmLogin")
            //            Application.OpenForms[i].Dispose();
            //    }
            //    FrmLogin frm = Application.OpenForms["FrmLogin"] as FrmLogin;
            //    frm.Show();
            //}
        }

        #endregion


        #region login

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //if (LOGIN_INFO.UserPass.Equals(password.Text.Trim()))
            //{
            //    MainPanel.Visible = true;
            //    pnllogin.Visible = false;
            //    pnllogin.SendToBack();
            //}
            //else
            //{
            //    MessageBox.Show("Password is Wrong", "LOGIN ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    password.Focus();
            //    return;
            //}
            //cmbUserType.Focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            //IISMethods.setKey(e);
        }

        private void btnclse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

#endregion


        #region Check All

        private void chkallow_CheckedChanged(object sender, EventArgs e)
        {
            int a = 0;
            for (int i = 0; i < grdUserRights.Rows.Count; i++)
            {
                if (chkallow.Checked == true) { a = 1; }
                grdUserRights.Rows[i].Cells["allow"].Value = a;
            }
        }

        private void chkadd_CheckedChanged(object sender, EventArgs e)
        {
            int a = 0;
            for (int i = 0; i < grdUserRights.Rows.Count; i++)
            {
                if (chkadd.Checked == true) { a = 1; }
                grdUserRights.Rows[i].Cells["addRights"].Value = a;
            }
        }

        private void chkedit_CheckedChanged(object sender, EventArgs e)
        {
            int a = 0;
            for (int i = 0; i < grdUserRights.Rows.Count; i++)
            {
                if (chkedit.Checked == true) { a = 1; }
                grdUserRights.Rows[i].Cells["editRights"].Value = a;
            }
        }

        private void chkdel_CheckedChanged(object sender, EventArgs e)
        {
            int a = 0;
            for (int i = 0; i < grdUserRights.Rows.Count; i++)
            {
                if (chkdel.Checked == true) { a = 1; }
                grdUserRights.Rows[i].Cells["delRights"].Value = a;
            }
        }

        private void chkprint_CheckedChanged(object sender, EventArgs e)
        {
            int a = 0;
            for (int i = 0; i < grdUserRights.Rows.Count; i++)
            {
                if (chkprint.Checked == true) { a = 1; }
                grdUserRights.Rows[i].Cells["printRights"].Value = a;
            }
        }

        #endregion


        private void usersrights_Load(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState != FormWindowState.Maximized)
                //{
                //    this.WindowState = FormWindowState.Maximized;
                //}
                
                //SQLServerDB objdb = new SQLServerDB();
                //try
                //{

                //    objdb.fillComboBoxNoWhere(cmbUserType, "id", "usertype", "tblusertype");
                //}
                //catch (Exception Ex)
                //{
                //    MessageBox.Show(Ex.Message, IISMessage.ErrorMessageTitle);
                //}
                //finally
                //{
                //    objdb.releaseObjects();
                //}

                ///////
                
                //DataTable dtright = new DataTable();
                //dtright = SQLServerDB.dtCmpRights;
                //foreach (DataRow dr in dtright.Rows)
                //{
                //    foreach (DataColumn col in dtright.Columns)
                //    {
                //        if (col.ColumnName == "formnametext" && col.DataType == typeof(System.String))
                //        {
                //            dr[col] = dr[col].ToString().Trim();
                //        }
                //    }

                //}
                //var chk = dtright.Select("formnametext='" + this.Text + "'");

                //if (chk.Length == 1)
                //{
                //   isallow = 1;
                //   btnSave.Visible = Val.ToBoolean(chk[0].ItemArray[4].ToString());                   
                //}
                ////////

                 
                //pnllogin.BringToFront();
                //MainPanel.Visible = false;
                //pnllogin.Enabled = true;
                //password.Focus();
                //cmbUserType.SelectedIndex = 0;
                //btnShow.Focus();
                //btnShow_Click(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Load");
            }
           
        }

    }
}
