using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AKwin32.forms
{
    public partial class frmBaseToolbox : frmBase
    {
        public frmBaseToolbox()
        {
            InitializeComponent();
        }

        private void frmBaseToolbox_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
