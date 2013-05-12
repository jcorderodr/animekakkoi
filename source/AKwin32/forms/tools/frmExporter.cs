using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKwin32.forms.tools
{
    public partial class frmExporter : AKwin32.forms.frmBaseToolbox
    {
        public frmExporter()
        {
            InitializeComponent();
        }

        public void SetProperties(string title)
        {
            this.Text = title;
        }

        private void btnDoSelection_Click(object sender, EventArgs e)
        {
            frmItemSelector frm = new frmItemSelector();
            DialogResult result = frm.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

    }
}
