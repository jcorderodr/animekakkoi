using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AKwin32
{
    static class Program
    {

        internal static Framework.io.Language Language;

        internal static com.io.AkConfiguration AkConfiguration;

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

            LoadVariables();
            if (varsErrorLoading) return;


            if (args.Length > 0)
            {
                //TODO: implements cmd
                com.io.CommandLine cmd = new com.io.CommandLine();
                cmd.SetProperties(frmMain, args);
                cmd.ExecActions();
            }

            StartUI();
        }

        private static void LoadVariables()
        {
            try
            {
                Language = new Framework.io.Language();
                AkConfiguration = new com.io.AkConfiguration();

                varsErrorLoading = !Framework.io.Configuration.TryFileInspection();
            }
            catch
            {
                varsErrorLoading = true;
                MessageBox.Show("Error loading configuration, system or app files.", AppTitle);
            }
        }

        private static void StartUI()
        {
            //wBox = new forms.tools.WaitingBox();
            //wBox.StartUntilStopped(null);
            frmMain = new forms.FrmMain();
            frmMain.Configuration = AkConfiguration;

            Application.Run(frmMain);
        }

        public static void ReloadVariables()
        {
            LoadVariables();
        }

        public const String AppTitle = "AnimeKakkoi 0.1.2";


    }
}
