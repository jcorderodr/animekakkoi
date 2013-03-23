using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AKwin32.forms.tools
{
    public partial class frmImporter : frmBase
    {
        public frmImporter()
        {
            InitializeComponent();
        }

        private void frmImporter_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string uri = "http://www.mcanime.net/perfil/281371/lista/anime";

            System.Net.HttpWebRequest request;

            System.Net.WebRequest wrequest = System.Net.HttpWebRequest.Create(uri);

            wrequest.PreAuthenticate = true;
            wrequest.Timeout = 60 * 1000;
            

            System.Net.WebResponse wresponse = wrequest.GetResponse();
            

            MessageBox.Show(wresponse.ContentLength+"");
        }
    }
}
