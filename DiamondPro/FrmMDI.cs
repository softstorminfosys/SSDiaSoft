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
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Microsoft.Win32;
using DiamondPro.TRANSACTION;
using DiamondPro.BLL.Function_Class;
using DiamondPro.MASTER;
using DiamondPro.DLL;
using InterviewDemo.DLL;

namespace DiamondPro
{
    public partial class FrmMDI : DevExpress.XtraEditors.XtraForm
    {
        private bool MDIStatus = true;
        public FrmMDI()
        {
            InitializeComponent();
        }

        #region Main Event
        private void FrmMDI_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();

            UserLookAndFeel.Default.SetSkinStyle("Blue");
            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Blue");

            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            rkey.SetValue("sShortDate", "dd/MM/yyyy");
        }

        private void FrmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Menu Event

        private void partyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPartyMaster frm = new FrmPartyMaster();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void dalalMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDalalMaster frm = new FrmDalalMaster();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();

        }

        private void pARAMETERTYPEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParameterType frm = new FrmParameterType();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void pARAMETERVALUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParameterValue frm = new FrmParameterValue();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void kARKHANAMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKarkhanaMaster frm = new FrmKarkhanaMaster();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void kachuKharidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKharidiMaster frm = new FrmKharidiMaster();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void polishKharidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPolishKharidi frm = new FrmPolishKharidi();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void BoxCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBoxCreate frm = new FrmBoxCreate();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void કરખનઇસસયToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKarkhanaIssue frm = new FrmKarkhanaIssue();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void કરખનરટરનToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKarkhanaDetails frm = new FrmKarkhanaDetails();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void BoxNumberingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBoxNumbering frm = new FrmBoxNumbering();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }

        private void StockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStockTransfer frm = new FrmStockTransfer();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();

        }
        private void વચણToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVechan frm = new FrmVechan();
            frm.MdiParent = this;
            imageSlider1.Visible = false;
            frm.Show();
        }
        #endregion

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RetVal = new BoxNumbering_Function().DBBackup();

            if (RetVal > 0)
            {
                XtraMessageBox.Show("Backed Up Save Successfully.");
            }
            else
            {
                XtraMessageBox.Show("Error While Backed Up DB.");
            }
        }

        public DataTable menuListNew()
        {

            String strQuit = "quitToolStripMenuItem";
            String strQuit1 = "windowsMenu";
            String strQuitChangePass = "changePasswordToolStripMenuItem";
            Int32 intPading = 5;
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("srno", typeof(String));
            dt.Columns.Add("formname", typeof(String));
            dt.Columns.Add("formnameText", typeof(String));
            dt.Columns.Add("allow", typeof(Boolean));
            dt.Columns.Add("menulevel", typeof(Int32));
            dt.Columns.Add("subitems", typeof(Int32));
            dt.Columns.Add("addRights", typeof(Boolean));
            dt.Columns.Add("editRights", typeof(Boolean));
            dt.Columns.Add("delRights", typeof(Boolean));
            dt.Columns.Add("printRights", typeof(Boolean));

            DataRow dr;
            Boolean boolFirstLevel;
            Boolean boolSecondLevel;
            Boolean boolThirdLevel;
            try
            {
                DataTable dtRights = new UserRights_Function().GetUserData(GlobalCls.UserTypeID);
                for (Int32 i = 0; i < menuStrip1.Items.Count; i += 1)
                {
                    if (!(strQuit.Equals(menuStrip1.Items[i].Name) || strQuit1.Equals(menuStrip1.Items[i].Name)))
                    {
                        ToolStripMenuItem FirstLevel = menuStrip1.Items[i] as ToolStripMenuItem;
                        //FirstLevel.BackColor = SQLServerDB.FormMenuColor;
                        //FirstLevel.ForeColor = SQLServerDB.FormMenuColorFont;
                        dr = dt.NewRow();
                        dr["formname"] = menuStrip1.Items[i].Name;
                        dr["formnameText"] = menuStrip1.Items[i].Text.Replace("&", String.Empty);
                        dr["srno"] = (i + 1).ToString() + ". ";
                        dr["menulevel"] = 0;
                        dr["subitems"] = FirstLevel.DropDownItems.Count;
                        dr["allow"] = false;
                        dr["addRights"] = false;
                        dr["editRights"] = false;
                        dr["delRights"] = false;
                        dr["printRights"] = false;
                        dt.Rows.Add(dr);
                        /// Rights ////
                        boolFirstLevel = false;
                        boolSecondLevel = false;
                        boolThirdLevel = false;


                        for (Int32 j = 0; j < FirstLevel.DropDownItems.Count; j += 1)
                        {
                            ToolStripMenuItem SecondLevel = FirstLevel.DropDownItems[j] as ToolStripMenuItem;
                            //SecondLevel.BackColor = SQLServerDB.FormMenuColor;
                            //SecondLevel.ForeColor = SQLServerDB.FormMenuColorFont;
                            if (strQuitChangePass.Equals(FirstLevel.DropDownItems[j].Name))
                                continue;
                            dr = dt.NewRow();

                            dr["formname"] = FirstLevel.DropDownItems[j].Name;
                            dr["formnameText"] = String.Empty.PadLeft(intPading * 1) + FirstLevel.DropDownItems[j].Text.Replace("&", String.Empty); ;
                            dr["srno"] = (i + 1).ToString() + "." + (j + 1).ToString();
                            dr["menulevel"] = 1;
                            dr["subitems"] = SecondLevel.DropDownItems.Count;
                            dr["allow"] = false;
                            dr["addRights"] = false;
                            dr["editRights"] = false;
                            dr["delRights"] = false;
                            dr["printRights"] = false;
                            dt.Rows.Add(dr);

                            for (Int32 k = 0; k < SecondLevel.DropDownItems.Count; k += 1)
                            {
                                ToolStripMenuItem ThirdLevel = SecondLevel.DropDownItems[k] as ToolStripMenuItem;
                                //ThirdLevel.BackColor = SQLServerDB.FormMenuColor;
                                //ThirdLevel.ForeColor = SQLServerDB.FormMenuColorFont;
                                dr = dt.NewRow();
                                dr["formname"] = SecondLevel.DropDownItems[k].Name;
                                dr["formnameText"] = String.Empty.PadLeft(intPading * 2) + SecondLevel.DropDownItems[k].Text.Replace("&", String.Empty); ;
                                dr["srno"] = (i + 1).ToString() + "." + (j + 1).ToString() + "." + (k + 1).ToString();
                                dr["menulevel"] = 2;
                                dr["subitems"] = ThirdLevel.DropDownItems.Count;
                                dr["allow"] = false;
                                dr["addRights"] = false;
                                dr["editRights"] = false;
                                dr["delRights"] = false;
                                dr["printRights"] = false;
                                dt.Rows.Add(dr);

                                for (Int32 l = 0; l < ThirdLevel.DropDownItems.Count; l += 1)
                                {
                                    ToolStripMenuItem ForthLevel = ThirdLevel.DropDownItems[l] as ToolStripMenuItem;
                                    //ForthLevel.BackColor = SQLServerDB.FormMenuColor;
                                    //ForthLevel.ForeColor = SQLServerDB.FormMenuColorFont;
                                    dr = dt.NewRow();
                                    dr["formname"] = ThirdLevel.DropDownItems[l].Name;
                                    dr["formnameText"] = String.Empty.PadLeft(intPading * 3) + ThirdLevel.DropDownItems[l].Text.Replace("&", String.Empty); ;
                                    dr["srno"] = (i + 1).ToString() + "." + (j + 1).ToString() + "." + (k + 1).ToString() + "." + (l + 1).ToString();
                                    dr["menulevel"] = 3;
                                    dr["subitems"] = ForthLevel.DropDownItems.Count;
                                    dr["allow"] = false;
                                    dr["addRights"] = false;
                                    dr["editRights"] = false;
                                    dr["delRights"] = false;
                                    dr["printRights"] = false;
                                    dt.Rows.Add(dr);

                                    dtRights.DefaultView.RowFilter = "formname='" + ForthLevel.Name + "' and allow=True";
                                    if (dtRights.DefaultView.Count == 0)
                                        ForthLevel.Visible = false;
                                    else
                                        boolThirdLevel = true;
                                }
                                dtRights.DefaultView.RowFilter = "formname='" + ThirdLevel.Name + "' and allow=True";
                                if (dtRights.DefaultView.Count == 0)
                                    ThirdLevel.Visible = false;
                                else
                                    boolSecondLevel = true;
                                if (ThirdLevel.DropDownItems.Count > 0)
                                    ThirdLevel.Visible = boolThirdLevel;
                            }
                            dtRights.DefaultView.RowFilter = "formname='" + SecondLevel.Name + "' and allow=True";
                            if (dtRights.DefaultView.Count == 0)
                                SecondLevel.Visible = false;
                            else
                                boolFirstLevel = true;
                            if (SecondLevel.DropDownItems.Count > 0)
                                SecondLevel.Visible = boolSecondLevel;
                        }
                        dtRights.DefaultView.RowFilter = "formname='" + FirstLevel.Name + "' and allow=True";
                        if (dtRights.DefaultView.Count == 0 && !menuStrip1.Items[i].Name.ToUpper().Equals("UTILITYTOOLSTRIPMENUITEM"))
                            FirstLevel.Visible = false;

                        if (FirstLevel.DropDownItems.Count > 0 && !menuStrip1.Items[i].Name.ToUpper().Equals("UTILITYTOOLSTRIPMENUITEM"))
                            FirstLevel.Visible = boolFirstLevel;

                        dtRights.DefaultView.RowFilter = "formname='" + FirstLevel.Name + "' and allow=True";
                        Operation.dtCmpRights = dtRights;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                //objdb.releaseObjects();
            }


            return dt;

        }
    }
}