using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AnimeKakkoi.App.IO;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.App.Helpers;

namespace AnimeKakkoi.App.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Base : Form
    {

        #region Constants & Inherit vars

        /// <summary>
        /// Indicates the char/string used to separate/splits Control's Names.
        /// </summary>
        protected internal const Char CharacterNameSeparator = '_';

        #endregion

        #region Properties

        public FormUsingState Form_State { get; set; }

        protected internal Dictionary<string, string> Messages
        {
            get { return Program.Language.MessagesLibrary; }
        }

        protected internal Dictionary<string, string> Errors
        {
            get { return Program.Language.MessagesLibrary; }
        }

        #endregion

        public Base()
        {
            InitializeComponent();
            Form_State = FormUsingState.Listening;
        }

        #region Handler & Events

        private void frmBase_Load(object sender, EventArgs e)
        {
            //  Calling this here, cause an error in-design
            SetStyleToControl(this.Controls);
            this.Icon = Properties.Resources.logo_icon;
            this.Text = Program.APP_TITLE + " @ " + this.Text;
        }

        protected internal void listViewItems_Resize(object sender, EventArgs e)
        {
            SizeLastColumn(sender as ListView);
        }

        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count > 0)
                Application.OpenForms[Application.OpenForms.Count - 1].Focus();
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
                ((ComboBox)ctrl).SelectedIndex = 0;
            else if (ctrl.GetType() == typeof(ListView))
                ((ListView)ctrl).Items.Clear();
        }

        protected void FillComboBoxCatalog(ComboBox ctrl, object dataSource)
        {
            try
            {
                ((List<Catalog>)dataSource).Insert(0, new Catalog { Id = "0", Description = "--" });
                ctrl.DataSource = dataSource;
                ctrl.ValueMember = "Id";
                ctrl.DisplayMember = "Description";
            }
            catch
            {
                MessageHandler.ShowError(this, Program.Language.MessagesLibrary["loading_catalog"]);
            }
        }

        private bool usedColorIndicator;

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
            this.BackColor = Color.FromArgb(255, 255, 192);

            foreach (Control ctrl in co)
            {
                if (ctrl.HasChildren)
                    SetStyleToControl(ctrl.Controls);

                //ctrl.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);

                if (ctrl is ListView)
                {
                    var lv = ((ListView)ctrl);
                    lv.AllowColumnReorder = true;
                    lv.FullRowSelect = true;
                    lv.GridLines = true;
                    lv.HideSelection = false;
                    lv.MultiSelect = false;
                    lv.Name = "listViewItems";
                    lv.Sorting = SortOrder.Ascending;
                    lv.UseCompatibleStateImageBehavior = false;
                    lv.View = View.Details;
                    SizeLastColumn(lv);
                }

                var lbl = ctrl as Label;
                if (lbl != null)
                {
                    var font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    lbl.Font = font;
                    lbl.ForeColor = Color.DimGray;
                }
            }
        }

        protected void SetPersonalStyleToControl(Control.ControlCollection co)
        {
            this.BackColor = Color.FromArgb(255, 255, 192);

            foreach (Control ctrl in co)
            {
                if (ctrl.HasChildren)
                    SetStyleToControl(ctrl.Controls);

                ctrl.Font = AppAkConfiguration.UiControlsFontStyle;

                var lbl = ctrl as Label;
                if (lbl != null)
                {
                    lbl.Font = AppAkConfiguration.UiFontsStyle;
                    lbl.ForeColor = AppAkConfiguration.UiFontsColor;
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
    public enum FormUsingState
    {
        Editing,
        Listening,
        Loaded,
        Managing,
        Ready
    }

}