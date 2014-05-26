#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.Framework.Entities;
using AnimeKakkoi.Framework.IO;
using AnimeKakkoi.Framework.util;

#endregion

namespace AnimeKakkoi.App.forms.tools
{
    public partial class frmExporter : FrmBaseToolbox
    {
        private List<object> elements;

        public frmExporter()
        {
            InitializeComponent();

            elements = new List<object>();
        }

        private void frmExporter_Load(object sender, EventArgs e)
        {
            saveFileDialog.Title = Program.AppTitle;
            saveFileDialog.Filter = FileProperties.AppSharingFileFilterName;

            List<Catalog> cbValues = Catalog.GetEntitiesTypesByLanguage();

            int id = Convert.ToInt32(cbValues.LastOrDefault().Id) + 1;
            cbValues.Add(new Catalog {Id = id + "", Description = "by own"});

            base.FillComboBoxCatalog(cb_OptionOutputState, cbValues);
        }

        private void btnDoSelection_Click(object sender, EventArgs e)
        {
            var frm = new frmItemSelector();
            DialogResult result = frm.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                elements = frm.UserSelection;
                Analize();
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            if (DoOperation())
                base.ShowInformation(this, base.Messages[LanguageExpressions.OPERATION_SUCESS]);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Analize()
        {
            lblItemsSelected.Text = elements.Count + "";
        }

        public void SetProperties(string title)
        {
            this.Text = title;
        }

        private bool DoOperation()
        {
            var state = cb_OptionOutputState.SelectedItem as Catalog;

            FileManager mgr;
            mgr = new FileManager(saveFileDialog.FileName);
            try
            {
                mgr.ElementState = (EntityState) Enum.Parse(typeof (EntityState), state.Value);
            }
            catch
            {
            }
            mgr.Elements = elements;
            mgr.Save();
            this.progressBar.Value = 100;

            return true;
        }
    }
}