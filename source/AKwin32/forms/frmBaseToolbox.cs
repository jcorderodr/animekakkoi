#region

using System;

#endregion

namespace AnimeKakkoi.App.Forms
{
    public partial class FrmBaseToolbox : FrmBase
    {
        public FrmBaseToolbox()
        {
            InitializeComponent();
        }

        private void frmBaseToolbox_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}