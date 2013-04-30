using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AKwin32
{
    static class Program
    {

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
        static bool varsErrorLoading = false;

        static forms.tools.WaitingBox wBox;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadVariables();
            if (varsErrorLoading) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            wBox = new forms.tools.WaitingBox();
            //wBox.StartUntilStopped(null);

            frmMain = new forms.FrmMain();
        
            Application.Run(frmMain);

        }

        private static void LoadVariables()
        {
            try
            {
                Language = new Framework.io.Language();

                varsErrorLoading = !Framework.io.Configuration.TryFileInspection();
            }
            catch
            {
                varsErrorLoading = true;
                MessageBox.Show("Error loading configuration, system or app files.", AppTitle);
            }
        }


        public const String AppTitle = "AnimeKakkoi [DevPhase]";

        internal static Framework.io.Language Language;

    }
}
