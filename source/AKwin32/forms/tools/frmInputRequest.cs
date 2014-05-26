#region

using System;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;

#endregion

namespace AnimeKakkoi.App.forms.tools
{
    public partial class frmInputRequest : FrmBaseToolbox
    {
        private bool allowNullInput;

        public frmInputRequest()
        {
            InitializeComponent();
            allowNullInput = true;
        }


        public String UserInput
        {
            get { return txtUserInput.Text; }
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
                base.ShowError(this, base.Errors["invalid_input"]);
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
            return (
                       (allowNullInput || String.IsNullOrEmpty(txtUserInput.Text)) ||
                       (!allowNullInput && !String.IsNullOrEmpty(txtUserInput.Text))
                   );
        }

        public void SetUIProperties(string request, bool allowNull)
        {
            lblRequest.Text = request;
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