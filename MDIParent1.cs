using DevExpress.LookAndFeel;
using DevExpress.Skins;
using Microsoft.Win32;
using Param_Hospital.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Param_Hospital.BLL.Function_Class;

namespace Param_Hospital
{
    public partial class MDIParent1 : Form
    {   
        private int childFormNumber = 1;
        private bool MDIStatus = true;
        public OPD objopd = null;
        public Doctormaster dm = null;
        public Employee_Master em = null;
        public Patient_Entry pm = null;
        public Company_Master cm = null;
        public string BackString = string.Empty;
        DataTable dtDue = new DataTable();

        public MDIParent1()
        {
            InitializeComponent();
        }

        #region Menus
        private void patientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (pm == null)
            //{
            pm = new Patient_Entry();
            pm.MdiParent = this;
            pm.Show();
            //}
            //else { pm.Focus(); }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (dm==null)
            //{
            dm = new Doctormaster();
            dm.MdiParent = this;
            dm.Show();
            //}
            //else
            //{

            //    dm.Focus();
            //} 
        }

        private void agentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (cm == null)
            //{
            cm = new Company_Master();
            cm.MdiParent = this;
            cm.Show();
            //}
            //else { cm.Focus(); }

        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (em == null)
            //{
            em = new Employee_Master();
            em.MdiParent = this;
            em.Show();
            //}
            //else { em.Focus(); }

        }

        private void oPDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (objopd == null)
            //{
            objopd = new OPD();
            objopd.MdiParent = this;
            objopd.Show();
            //}
            //else { objopd.Focus(); }

        }

        private void iNDOORPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InDoor frm = new InDoor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void xRayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmXRayServices frm = new FrmXRayServices();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hospitalExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHospitalExpences frm = new FrmHospitalExpences();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salaryPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHospitalSalary frm = new FrmHospitalSalary();
            frm.MdiParent = this;
            frm.Show();
        }

        private void doctorCahrgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDoctorCharge frm = new FrmDoctorCharge();
            frm.MdiParent = this;
            frm.Show();
        }

        private void agentChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgentCharge frm = new FrmAgentCharge();
            frm.MdiParent = this;
            frm.Show();
        }

        private void agentcyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgentMaster frm = new AgentMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void medicalSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicalSalary frm = new FrmMedicalSalary();
            frm.MdiParent = this;
            frm.Show();
        }

        private void medicalExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicalExpences frm = new FrmMedicalExpences();
            frm.MdiParent = this;
            frm.Show();
        }

        private void billPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBillPayment frm = new FrmBillPayment();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dailyCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDailyCollection frm = new FrmDailyCollection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void customReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPHospital frm = new RPHospital();
            frm.MdiParent = this;
            frm.Show();
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dischargeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DischargeDetails frm = new DischargeDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void customReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RPMedicalStore frm = new RPMedicalStore();
            frm.MdiParent = this;
            frm.Show();
        }

        private void thisMonthPendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPMediclaimPending frm = new RPMediclaimPending();
            frm.MdiParent = this;
            frm.Show();
        }

        private void customRecievedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPMediclaimRecieve frm = new RPMediclaimRecieve();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region Main Event
        private void MDIParent1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Blue");
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            rkey.SetValue("sShortDate", "dd/MM/yyyy");

            BackString = "DUEPAYMENT";
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        #region Timer Event
        private void timer1_Tick(object sender, EventArgs e)
        {
            tsTime.Text = "Time : " + DateTime.Parse(System.DateTime.Now.ToString()).ToString("dd/MM/yyyy hh:mm:ss");
        }
        #endregion

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #region TabbedMDI Event
        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            MDIStatus = false;
            if (!MDIStatus)
            {
                splitContainerControl1.Visible = false;
            }
            else
            {
                splitContainerControl1.Visible = true;
            }
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {            
            if (xtraTabbedMdiManager1.Pages.Count == 0)
            {
                MDIStatus = true;
            }
            if (!MDIStatus)
            {
                splitContainerControl1.Visible = false;
            }
            else
            {
                splitContainerControl1.Visible = true;
            }
        }
        #endregion

        #region BG Event
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (BackString)
                {
                    case "DUEPAYMENT":
                        dtDue = new InDoor_Function().GetDuePayment("");
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"DoWork",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                switch (BackString)
                {
                    case "DUEPAYMENT":
                        GrdDueAmount.DataSource = null;
                        GrdDueAmount.DataSource = dtDue;
                        GrdDueAmount.Refresh();
                        dgvDueAmount.BestFitColumns();
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Work Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                BackString = "DUEPAYMENT";
                CheckForIllegalCrossThreadCalls = false;
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Refresh",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        

        
        
    }
}
