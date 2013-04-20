﻿using System;
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
            Form_State = FORM_USING_STATE.LISTENING;
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            SetStyleToControl(this.Controls);
            this.Icon = Properties.Resources.app_icon;
            this.Text = Program.AppTitle + " @ " + this.Text;
        }


        protected void SetStyleToControl(Control.ControlCollection co)
        {
            foreach (Control ctrl in co)
            {
                if (ctrl.HasChildren)
                    SetStyleToControl(ctrl.Controls);

                Label lbl = ctrl as Label;
                if (lbl != null)
                    lbl.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        protected DialogResult ShowError(IWin32Window parent, string text)
        {
            return MessageBox.Show(parent, text, Program.AppTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected DialogResult ShowInformation(IWin32Window parent, string text)
        {
            return MessageBox.Show(parent, text, Program.AppTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected DialogResult ShowQuestion(IWin32Window parent, string text)
        {
            return MessageBox.Show(parent, text, Program.AppTitle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        protected DialogResult ShowCustomMessage(IWin32Window parent, string text, MessageBoxIcon icon)
        {
            return MessageBox.Show(parent, text, Program.AppTitle,
                MessageBoxButtons.OKCancel, icon);
        }

        public FORM_USING_STATE Form_State { get; set; }

    }

    public enum FORM_USING_STATE
    {
        EDITING,
        LISTENING,
        LOADED,
        MANAGING,
        READY
    }

}
