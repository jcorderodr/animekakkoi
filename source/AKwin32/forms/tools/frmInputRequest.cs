using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKwin32.forms.tools
{
    public partial class frmInputRequest : AKwin32.forms.frmBaseToolbox
    {

        bool allowNullInput;

        public frmInputRequest()
        {
            InitializeComponent();
            allowNullInput = true;
        }


        public String UserInput
        {
            get
            {
                return txtUserInput.Text;
            }
        }


        #region GUI Events

        private void frmInputRequest_Load(object sender, EventArgs e)
        {
            txtUserInput.Focus();
        }

        private void frmInputRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isValidInput())
                e.Cancel = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValidInput())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                base.ShowError(this,
                      Program.Language.MessagesLibrary["invalid_input"]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isValidInput())
                this.Close();
        }

        #endregion

        private bool isValidInput()
        {
            return (allowNullInput && String.IsNullOrEmpty(txtUserInput.Text) ||
                !allowNullInput && !String.IsNullOrEmpty(txtUserInput.Text));
        }

        public void SetUIProperties(string request, bool allowNull)
        {
            lblRequest.Text = request + ":";
            this.allowNullInput = allowNull;
        }

        public void SetUIProperties(string title, string request, bool allowNull)
        {
            this.Text = title;
            lblRequest.Text = request + ":";
            this.allowNullInput = allowNull;
        }









    }
}
