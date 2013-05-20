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
    /// <summary>
    /// 
    /// </summary>
    public partial class frmBase : Form
    {

        #region Constants & Inherit vars

        /// <summary>
        /// Indicates the char/string used to separate/splits Control's Names.
        /// </summary>
        protected internal const Char CharacterNameSeparator = '_';


        #endregion

        #region Properties

        public com.io.AkConfiguration Configuration
        {
            get;
            set;
        }

        public FORM_USING_STATE Form_State { get; set; }

        protected internal Dictionary<string, string> Messages
        {
            get { return Program.Language.MessagesLibrary; }
        }

        protected internal Dictionary<string, string> Errors
        {
            get { return Program.Language.ErrorsLibrary; }
        }

        #endregion


        public frmBase()
        {
            InitializeComponent();
            Form_State = FORM_USING_STATE.LISTENING;
            Configuration = new com.io.AkConfiguration();
        }

        ~frmBase()
        {
            //Configuration.Save();
        }


        #region Handler & Events

        private void frmBase_Load(object sender, EventArgs e)
        {
            SetStyleToControl(this.Controls);
            this.Icon = Properties.Resources.bluegletek_beta_icon;
            this.Text = Program.AppTitle + " @ " + this.Text;
        }

        protected internal void listViewItems_Resize(object sender, EventArgs e)
        {
            SizeLastColumn(sender as ListView);
        }

        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms[Application.OpenForms.Count - 1].Focus();
            }
            catch { }
        }

        #endregion


        #region UI Messages

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

        #endregion


        #region Functions

        protected void CleanUIComponents()
        {
            foreach (Control ctrl in this.Controls)
                CleanInheritUIControl(ctrl);
        }

        protected void CleanUIComponents(params Control[] ctrls)
        {
            foreach (Control ctrl in ctrls)
                CleanInheritUIControl(ctrl);
        }

        private void CleanInheritUIControl(Control ctrl)
        {
            if (ctrl.HasChildren)
                foreach (Control inner in ctrl.Controls)
                    CleanInheritUIControl(inner);

            if (ctrl.GetType() == typeof(TextBox))
                ctrl.Text = String.Empty;
            else if (ctrl.GetType() == typeof(ComboBox))
                //ctrl.Text = "--";
                ((ComboBox)ctrl).SelectedIndex = 0;
            else if (ctrl.GetType() == typeof(ListView))
                ((ListView)ctrl).Items.Clear();
        }

        protected void FillComboBoxCatalog(ComboBox ctrl, object dataSource)
        {
            try
            {
                ((List<Framework.io.Catalog>)dataSource).Insert(0, new Framework.io.Catalog { Id = "0", Description = "--" });
                ctrl.DataSource = dataSource;
                ctrl.ValueMember = "Id";
                ctrl.DisplayMember = "Description";
            }
            catch
            {
                this.ShowError(this, Program.Language.ErrorsLibrary["loading_catalog"]);
            }
        }

        bool usedColorIndicator;
        protected internal Color GetAlternateItemColor()
        {
            if (usedColorIndicator)
            {
                usedColorIndicator = !usedColorIndicator;
                return Color.AliceBlue;
            }
            else
            {
                usedColorIndicator = !usedColorIndicator;
                return Color.AntiqueWhite;
            }
        }

        protected void SetStyleToControl(Control.ControlCollection co)
        {
            this.BackColor = Configuration.FormBackGroundColor;
            
            foreach (Control ctrl in co)
            {
                if (ctrl.HasChildren)
                    SetStyleToControl(ctrl.Controls);

                //ctrl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ctrl.Font = Configuration.UiControlsFontStyle;

                if (ctrl is ListView)
                {
                    ListView lv = ((ListView)ctrl);
                    lv.AllowColumnReorder = true;
                    lv.FullRowSelect = true;
                    lv.GridLines = true;
                    lv.HideSelection = false;
                    lv.MultiSelect = false;
                    lv.Name = "listViewItems";
                    lv.Sorting = System.Windows.Forms.SortOrder.Ascending;
                    lv.UseCompatibleStateImageBehavior = false;
                    lv.View = System.Windows.Forms.View.Details;
                    SizeLastColumn(lv);
                }

                Label lbl = ctrl as Label;
                if (lbl != null)
                {
                    //new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lbl.Font = Configuration.UiFontsStyle;
                    lbl.ForeColor = Configuration.UiFontsColor;
                }
            }
        }

        protected void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }

        #endregion


    }

    /// <summary>
    /// 
    /// </summary>
    public enum FORM_USING_STATE
    {
        EDITING,
        LISTENING,
        LOADED,
        MANAGING,
        READY
    }

}
