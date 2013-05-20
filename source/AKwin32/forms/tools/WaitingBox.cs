using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKwin32.forms.tools
{
    public partial class WaitingBox : AKwin32.forms.frmBaseToolbox
    {

        System.ComponentModel.BackgroundWorker underThread;

        public WaitingBox()
        {
            InitializeComponent();
            underThread = new System.ComponentModel.BackgroundWorker();
            underThread.WorkerSupportsCancellation = true;

            WaitingBox.CheckForIllegalCrossThreadCalls = false;
            underThread.DoWork += new System.ComponentModel.DoWorkEventHandler(underThread_DoWork);


            this.TopMost = true;
        }


        private void WaitingBox_Load(object sender, EventArgs e)
        {
            this.Text = base.Messages["waiting"];
        }

        private delegate void Starter(object sender, System.ComponentModel.DoWorkEventArgs e);
        void underThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Starter del = new Starter(underThread_DoWork);
                object[] values = { sender, e };
                this.Invoke(del, values);
            }
            else
            {
                if (e.Argument != null && e.Argument.GetType() == typeof(IWin32Window))
                    this.ShowDialog((IWin32Window)e.Argument);
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
