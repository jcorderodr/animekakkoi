#region

using System;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.App.IO;
using AnimeKakkoi.Framework.Entities;
using AnimeKakkoi.Framework.IO;

#endregion

namespace AnimeKakkoi.App
{
    internal static class Program
    {
        internal static Framework.IO.Language Language;

        private static User _user;

        public static User SystemUser
        {
            get { return _user; }
            set
            {
                _user = value;
                frmMain.OnPropertiesChange();
            }
        }


        private static FrmMain frmMain;

        private static bool varsErrorLoading;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread.CurrentThread.CurrentCulture = AppAkConfiguration.ApplicationCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = AppAkConfiguration.ApplicationCulture;

            CheckIsFirstRunning();

            LoadVariables();
            if (varsErrorLoading) return;

            if (args.Length > 0)
            {
                var cmd = new CommandLine();
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
            //TODO: Implement this mechanism...

            //var isFirstRun = AnimeKakkoi.App.IO.AppAkConfiguration.ApplicationFirstRunning;
            //var path = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Start.bat";

            //if (!isFirstRun) return;

            //System.Diagnostics.Process.Start(path);
            //Properties.Settings.Default.ApplicationFirstRunning = false;
            //Properties.Settings.Default.Save();
            //System.IO.File.Delete(path);
        }

        private static void LoadVariables()
        {
            try
            {
                Language = new Language();

                varsErrorLoading = !Framework.IO.AkConfiguration.TryFileInspection();
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

        private static void StartUI()
        {
            //wBox = new forms.tools.WaitingBox();
            //wBox.StartUntilStopped(null);
            frmMain = new FrmMain();

            Application.Run(frmMain);
        }

        public const String AppTitle = AkConfiguration.APPLICATION_NAME;
    }
}