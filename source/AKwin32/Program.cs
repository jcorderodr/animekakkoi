using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AKwin32
{
    static class Program
    {

        internal static Framework.io.Language Language;

        internal static com.io.AkConfiguration AkConfiguration = new com.io.AkConfiguration();

        private static Framework.entity.User _user;
        public static Framework.entity.User SystemUser
        {
            get { return _user; }
            set
            {
                _user = value;
                frmMain.OnPropertiesChange();
            }
        }


        static forms.FrmMain frmMain;

        //static forms.tools.WaitingBox wBox;

        static bool varsErrorLoading = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread.CurrentThread.CurrentCulture = AkConfiguration.ApplicationCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = AkConfiguration.ApplicationCulture;

            CheckIsFirstRunning();

            LoadVariables();
            if (varsErrorLoading) return;

            if (args.Length > 0)
            {
                com.io.CommandLine cmd = new com.io.CommandLine();
                cmd.SetProperties(frmMain, args);
                cmd.ExecActions();
            }

            StartUI();
        }

        /// <summary>
        /// Check out if it is the first execution. If do, run a batch to preserve files after uninstall.
        /// </summary>
        private static void CheckIsFirstRunning()
        {
            bool isFirst = Properties.Settings.Default.ApplicationFirstRunning;
            if (isFirst)
            {
                try
                {
                    string path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Start.bat";
                    System.Diagnostics.Process.Start(path);
                    //-System.IO.File.Delete(path);
                }
                catch { }
            }
            else
            {
                Properties.Settings.Default.ApplicationFirstRunning = false;
                Properties.Settings.Default.Save();
            }

        }

        private static void LoadVariables()
        {
            try
            {
                Language = new Framework.io.Language();

                varsErrorLoading = !Framework.io.Configuration.TryFileInspection();
            }
            catch (Exception ex)
            {
                varsErrorLoading = true;
                MessageBox.Show("Error loading configuration, system or app files: " + ex.Message, AppTitle);
            }
        }

        public static void RestartApp()
        {
            Application.Restart();
            //LoadVariables();
        }

        private static void SplitWords(string text)
        {

        }

        private static void StartUI()
        {
            //wBox = new forms.tools.WaitingBox();
            //wBox.StartUntilStopped(null);
            frmMain = new forms.FrmMain();
            frmMain.Configuration = AkConfiguration;

            Application.Run(frmMain);
        }


        public const String AppTitle = "AnimeKakkoi 0.1.3";


    }
}
