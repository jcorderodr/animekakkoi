#region

using System;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;

#endregion

namespace AnimeKakkoi.App.Forms.tools
{
    public partial class WaitingBox : BaseToolbox
    {
        private readonly System.ComponentModel.BackgroundWorker underThread;

        public WaitingBox()
        {
            InitializeComponent();
            underThread = new System.ComponentModel.BackgroundWorker();
            underThread.WorkerSupportsCancellation = true;

            Control.CheckForIllegalCrossThreadCalls = false;
            underThread.DoWork += underThread_DoWork;

            this.TopMost = true;
        }


        private void WaitingBox_Load(object sender, EventArgs e)
        {
            this.Text = base.Messages["waiting"];
        }

        private delegate void Starter(object sender, System.ComponentModel.DoWorkEventArgs e);

        private void underThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Starter del = underThread_DoWork;
                object[] values = {sender, e};
                this.Invoke(del, values);
            }
            else
            {
                if (e.Argument != null && e.Argument.GetType() == typeof (IWin32Window))
                    this.ShowDialog((IWin32Window) e.Argument);
                else
                    this.ShowDialog();
            }
        }

        /// <summary>
        /// Shows the form until the stop is indicated.
        /// </summary>
        public void StartUntilStopped()
        {
            underThread.RunWorkerAsync();
        }

        /// <summary>
        /// Shows the form from the parent until the stop is indicated.
        /// </summary>
        public void StartUntilStopped(IWin32Window parent)
        {
            underThread.RunWorkerAsync(parent);
        }


        /// <summary>
        /// Resume the showing of the box.
        /// </summary>
        [Obsolete("StartUntilStopped")]
        public void Resume()
        {
            underThread.RunWorkerAsync();
        }

        /// <summary>
        /// Stop
        /// <seealso cref="StartUntilStopped"/>
        /// </summary>
        public void Stop()
        {
            underThread.CancelAsync();
            this.Hide();
        }
    }
}