using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AKwin32.Properties;

namespace AKwin32.forms.maintenance
{
    public partial class frmPreferences : AKwin32.forms.frmBaseToolbox
    {

        Settings setts = Properties.Settings.Default;

        public frmPreferences()
        {
            InitializeComponent();
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            cbBoxLanguage.Text = setts.UserCultureLanguage;

            chkBoxInstantSearch.Checked = setts.UserInstantSearch;
            // -
            panelColorSample.BackColor = setts.UserfrmBackGroundColor;
            linkLabelFontColor.LinkColor = setts.UserUiFontsColor;

            linkLabelFontsStyle.Font = setts.UserUiFontsStyles;
            linkLabelControlsStyle.Font = setts.UserUiControlsFontsStyle;
            // -
            linkLabelFontsStyle.Text = String.Format("{0} {1}pts", linkLabelFontsStyle.Font.Name, linkLabelColor.Font.Size);
            linkLabelControlsStyle.Text = String.Format("{0} {1}pts", linkLabelControlsStyle.Font.Name, linkLabelControlsStyle.Font.Size);
        }

        private void linkLabelColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                panelColorSample.BackColor = colorDialog.Color;
            }
        }

        private void linkLabelFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                linkLabelFontColor.LinkColor = colorDialog.Color;
            }
        }

        private void linkLabelControlsStyle_Click(object sender, EventArgs e)
        {
            fontDialog.Font = linkLabelControlsStyle.Font;
            if (fontDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                linkLabelControlsStyle.Font = fontDialog.Font;
                linkLabelControlsStyle.Text = String.Format("{0} {1}pts", linkLabelControlsStyle.Font.Name, linkLabelControlsStyle.Font.Size);
            }
        }

        private void linkLabelFontsStyle_Click(object sender, EventArgs e)
        {
            fontDialog.Font = linkLabelFontsStyle.Font;
            if (fontDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                linkLabelFontsStyle.Font = fontDialog.Font;
                linkLabelFontsStyle.Text = String.Format("{0} {1}pts", linkLabelFontsStyle.Font.Name, linkLabelColor.Font.Size);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            SaveChanges();
            this.Close();
        }

        private void SaveChanges()
        {
            setts.UserfrmBackGroundColor = panelColorSample.BackColor;
            setts.UserUiFontsStyles = linkLabelFontsStyle.Font;
            setts.UserUiFontsColor = linkLabelFontColor.LinkColor;
            setts.UserUiControlsFontsStyle = linkLabelControlsStyle.Font;
            setts.UserCultureLanguage = cbBoxLanguage.Text;
            setts.UserInstantSearch = chkBoxInstantSearch.Checked;
            setts.Save();
            // -
            Framework.io.Configuration.SaveSetting("lang", setts.UserCultureLanguage);
            // -
            Program.RestartApp();
        }


    }
}
