using System;

namespace AnimeKakkoi.App.Forms
{
    public partial class BaseToolbox : Base
    {
        public BaseToolbox()
        {
            InitializeComponent();
        }

        private void frmBaseToolbox_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}