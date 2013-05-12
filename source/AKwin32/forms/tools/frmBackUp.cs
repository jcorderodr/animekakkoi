using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace AKwin32.forms.tools
{
    public partial class frmBackUp : AKwin32.forms.frmBaseToolbox
    {
        Framework.io.BackUp bk;

        public frmBackUp()
        {
            InitializeComponent();
            bk = new Framework.io.BackUp();
        }

        private void frmBackUp_Load(object sender, EventArgs e)
        {
            saveFileDialog.Title = Program.AppTitle;
            saveFileDialog.Filter = Framework.io.FileProperties.AppBackUpFilterName;
            openFileDialog.Title = Program.AppTitle;
            openFileDialog.Filter = Framework.io.FileProperties.AppBackUpFilterName;
            bk.BackUpProgressChanged += new EventHandler<System.ComponentModel.ProgressChangedEventArgs>(bk_BackUpProgressChanged);
            bk.BackUpProgressFinished += new EventHandler<System.ComponentModel.RunWorkerCompletedEventArgs>(bk_BackUpProgressFinished);
        }


        void bk_BackUpProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        void bk_BackUpProgressFinished(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                base.ShowInformation(this, base.Messages["operation_sucess"]);
            }
            else
            {
                base.ShowInformation(this, base.Messages["operation_failed"]);
            }
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (base.ShowQuestion(this, base.Messages["backup_question"]) == System.Windows.Forms.DialogResult.Yes)
            {
                if (openFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
            }
            else
                return;

            bk.AsyncLoadBackUp(openFileDialog.FileName);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

            bk.AsyncMakeBackUp(saveFileDialog.FileName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }



    }
}
