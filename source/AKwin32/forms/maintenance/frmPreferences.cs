using System;
using AnimeKakkoi.App.IO;

namespace AnimeKakkoi.App.Forms.Maintenance
{
    public partial class FrmPreferences : BaseToolbox
    {

        public FrmPreferences()
        {
            InitializeComponent();
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            cbBoxLanguage.Text = AppAkConfiguration.ApplicationCulture + "";

            chkBoxInstantSearch.Checked = AppAkConfiguration.UserUsingInstantSearch;
            // -
            linkLabelFontColor.LinkColor = AppAkConfiguration.UiFontsColor;

            linkLabelFontsStyle.Font = AppAkConfiguration.UiFontsStyle;
            linkLabelControlsStyle.Font = AppAkConfiguration.UiControlsFontStyle;
            // -
            linkLabelFontsStyle.Text = String.Format("{0} {1}pts", linkLabelFontsStyle.Font.Name,
                                                     linkLabelColor.Font.Size);
            linkLabelControlsStyle.Text = String.Format("{0} {1}pts", linkLabelControlsStyle.Font.Name,
                                                        linkLabelControlsStyle.Font.Size);
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
                linkLabelControlsStyle.Text = String.Format("{0} {1}pts", linkLabelControlsStyle.Font.Name,
                                                            linkLabelControlsStyle.Font.Size);
            }
        }

        private void linkLabelFontsStyle_Click(object sender, EventArgs e)
        {
            fontDialog.Font = linkLabelFontsStyle.Font;
            if (fontDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                linkLabelFontsStyle.Font = fontDialog.Font;
                linkLabelFontsStyle.Text = String.Format("{0} {1}pts", linkLabelFontsStyle.Font.Name,
                                                         linkLabelColor.Font.Size);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            SaveChanges();
            this.Close();
        }

        private void SaveChanges()
        {
            //TODO: fix this disabled behaviour
            //setts.UserfrmBackGroundColor = panelColorSample.BackColor;
            //setts.UserUiFontsStyles = linkLabelFontsStyle.Font;
            //setts.UserUiFontsColor = linkLabelFontColor.LinkColor;
            //setts.UserUiControlsFontsStyle = linkLabelControlsStyle.Font;
            //setts.UserCultureLanguage = cbBoxLanguage.Text;
            //setts.UserInstantSearch = chkBoxInstantSearch.Checked;
            //setts.Save();
            // -
            Program.RestartApp();
        }
    }
}