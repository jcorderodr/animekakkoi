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

            Form_State = FORM_USING_STATE.LISTENING;
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            SetStyleToControl(this.Controls);
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
