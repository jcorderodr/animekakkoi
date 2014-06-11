using System.Windows.Forms;

namespace AnimeKakkoi.App.Helpers
{
     static class MessageHandler
    {

     
        #region UI Messages

         public static DialogResult ShowError(string text)
        {
            return MessageBox.Show(text, Program.APP_TITLE,
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

         public static DialogResult ShowError(IWin32Window parent, string text)
        {
            return MessageBox.Show(parent, text, Program.APP_TITLE,
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

         public static DialogResult ShowInformation(string text)
        {
            return MessageBox.Show(text, Program.APP_TITLE,
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

         public static DialogResult ShowInformation(IWin32Window parent, string text)
        {
            return MessageBox.Show(parent, text, Program.APP_TITLE,
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

         public static DialogResult ShowQuestion(string text)
        {
            return MessageBox.Show(text, Program.APP_TITLE,
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

         public static DialogResult ShowQuestion(IWin32Window parent, string text)
        {
            return MessageBox.Show(parent, text, Program.APP_TITLE,
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

         public static DialogResult ShowCustomMessage(string text, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, Program.APP_TITLE,
                                   MessageBoxButtons.OKCancel, icon);
        }

         public static DialogResult ShowCustomMessage(IWin32Window parent, string text, MessageBoxIcon icon)
        {
            return MessageBox.Show(parent, text, Program.APP_TITLE,
                                   MessageBoxButtons.OKCancel, icon);
        }

        #endregion

    }
}
