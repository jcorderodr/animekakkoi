using System.Windows.Forms;

namespace AnimeKakkoi.App.Helpers
{
    static class MessageHandler
    {

        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, Program.APP_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(IWin32Window parent, string msg)
        {
            MessageBox.Show(parent, msg, Program.APP_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(IWin32Window parent, string msg)
        {
            MessageBox.Show(parent, msg, Program.APP_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(IWin32Window parent, string msg)
        {
            return MessageBox.Show(parent, msg, Program.APP_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}
