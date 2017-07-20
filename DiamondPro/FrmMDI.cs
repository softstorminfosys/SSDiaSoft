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

        
    }
}