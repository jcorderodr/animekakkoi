using System;
using System.Windows.Forms;
using AnimeKakkoi.Core.IO;
using AnimeKakkoi.Core.Lang;

namespace AnimeKakkoi.App
{
    internal static class Program
    {

        internal static Language Language;

        private static Forms.FrmMain _frmMain;

        private static bool _hasErrorLoading;

        public static String SystemUser
        {
            get { return Environment.UserName; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CheckIsFirstRunning();

            LoadVariables();
            if (_hasErrorLoading)
            {
                Helpers.MessageHandler.ShowError("App cannot start.");
                return;
            }

            /*
            if (args.Length > 0)
            {
                var cmd = new CommandLine();
                cmd.SetProperties(frmMain, args);
                cmd.ExecActions();
            }*/

            StartUi();
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
                _hasErrorLoading = !AkConfiguration.TryFileInspection();

                var userDefaultCulture = AkConfiguration.ApplicationDefaultCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = userDefaultCulture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = userDefaultCulture;

                Language = new Language(userDefaultCulture);
            }
            catch (Exception ex)
            {
                _hasErrorLoading = true;
                MessageBox.Show("Error loading configuration, system or app files: " + ex.Message, APP_TITLE);
            }
        }

        public static void RestartApp()
        {
            Application.Restart();
        }

        private static void StartUi()
        {
            _frmMain = new Forms.FrmMain();
            Application.Run(_frmMain);
        }

        public const String APP_TITLE = AkConfiguration.APPLICATION_NAME;

    }
}