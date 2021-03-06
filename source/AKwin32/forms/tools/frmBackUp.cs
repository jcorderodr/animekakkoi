﻿#region

using System;
using AnimeKakkoi.Core.IO;
using AnimeKakkoi.App.Helpers;

#endregion

namespace AnimeKakkoi.App.Forms.tools
{
    //TODO: Implement class
    public partial class FrmBackUp : BaseToolbox
    {
        private BackUp bk;

        public FrmBackUp()
        {
            InitializeComponent();
            bk = new BackUp();
        }

        private void frmBackUp_Load(object sender, EventArgs e)
        {
            saveFileDialog.Title = Program.APP_TITLE;
            //saveFileDialog.Filter = FileProperties.AppBackUpFilterName;
            //openFileDialog.Title = Program.APP_TITLE;
            //openFileDialog.Filter = FileProperties.AppBackUpFilterName;
            //bk.BackUpProgressChanged += bk_BackUpProgressChanged;
            //bk.BackUpProgressFinished += bk_BackUpProgressFinished;
        }

        private void bk_BackUpProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bk_BackUpProgressFinished(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                AnimeKakkoi.App.Helpers.MessageHandler.ShowInformation(this, base.Messages["operation_sucess"]);
            }
            else
            {
                AnimeKakkoi.App.Helpers.MessageHandler.ShowInformation(this, base.Messages["operation_failed"]);
            }
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (MessageHandler.ShowQuestion(this, base.Messages["backup_question"]) == System.Windows.Forms.DialogResult.Yes)
            {
                if (openFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
            }
            else
                return;

            //bk.AsyncLoadBackUp(openFileDialog.FileName);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

            //bk.AsyncMakeBackUp(saveFileDialog.FileName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}