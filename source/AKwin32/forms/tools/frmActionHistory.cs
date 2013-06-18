using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKwin32.forms.tools
{
    public partial class frmActionHistory : AKwin32.forms.frmBaseToolbox
    {

        public frmActionHistory()
        {
            InitializeComponent();
        }

        private void frmActionHistory_Load(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(Configuration.ApplicationLoggerFile);
            txt_history.AppendText(text);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
