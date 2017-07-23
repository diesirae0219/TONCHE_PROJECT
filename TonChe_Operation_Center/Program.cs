using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using TonChe_Operation_Cneter;
using System.Threading;
using TonChe_Operation_Cneter.Database;
using System.Data;
using TonChe_Operation_Cneter.Utility;

namespace TonChe_Operation_Cneter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

     

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            DialogResult result;
            using (var loginForm = new frmLogin())
                result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // login was successful
                Thread th = new Thread(new ThreadStart(ShowSplashScreen));
                th.Start();
                Thread.Sleep(2000);
                Application.Run(new frmMain());
                th.Abort();
                //Application.Run(new );
            }
     
        }


        static void ShowSplashScreen()
        {
            Application.Run(new frmLoading());
        }
    }
}