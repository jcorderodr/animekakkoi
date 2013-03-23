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
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
            this.Text = Program.AppTitle + " -[ ";
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            
        }
    }
}
