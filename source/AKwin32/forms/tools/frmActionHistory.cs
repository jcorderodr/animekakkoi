using System;

namespace AnimeKakkoi.App.Forms.tools
{
    public partial class frmActionHistory : BaseToolbox
    {
        public frmActionHistory()
        {
            InitializeComponent();
        }

        private void frmActionHistory_Load(object sender, EventArgs e)
        {
            //string text = System.IO.File.ReadAllText(AnimeKakkoi.App.IO.AppAkConfiguration.AppLoggerFile);
            //txt_history.AppendText(text);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}