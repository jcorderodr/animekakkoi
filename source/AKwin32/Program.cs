using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AKwin32
{
    static class Program
    {

        static forms.FrmMain frmMain;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmMain = new forms.FrmMain();
            
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            Application.Run(frmMain);
        }

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

//        public static String App

        public const String AppTitle = "AnimeKakkoi [DevPhase]";


    }
}
