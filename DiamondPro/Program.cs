using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using InterviewDemo.DLL;
using System.Configuration;

namespace DiamondPro
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

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Blue");
            Application.Run(new FrmMDI());
        }
    }
}
