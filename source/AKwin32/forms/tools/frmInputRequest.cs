﻿using System;
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
                MessageBox.Show(this, "invalid input", Program.AppTitle, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isValidInput())
                this.Close();
        }

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