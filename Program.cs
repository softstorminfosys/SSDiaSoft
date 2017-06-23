using InterviewDemo.DLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Skins;

namespace Param_Hospital
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Operation.ConnectionString1 = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());

                       
           
        }
    }
}
