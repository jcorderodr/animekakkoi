using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace AKwin32.forms.maintenance
{
    /// <summary>
    /// //TODO: implement this
    /// </summary>
    public partial class frmOptions : AKwin32.forms.frmBaseToolbox
    {

        WebProxy proxy;
    

        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            proxy = (WebProxy)Framework.io.Configuration.GetProxy();

            txtHost.Text = proxy.Address.ToString();

        }
    }
}
