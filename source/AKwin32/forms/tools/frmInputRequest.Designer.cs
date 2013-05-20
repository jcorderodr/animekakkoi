namespace AKwin32.forms.tools
{
    partial class frmInputRequest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputRequest));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelBase = new System.Windows.Forms.Panel();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.panelBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelBase
            // 
            resources.ApplyResources(this.panelBase, "panelBase");
            this.panelBase.Controls.Add(this.txtUserInput);
            this.panelBase.Controls.Add(this.lblRequest);
            this.panelBase.Name = "panelBase";
            // 
            // txtUserInput
            // 
            resources.ApplyResources(this.txtUserInput, "txtUserInput");
            this.txtUserInput.Name = "txtUserInput";
            // 
            // lblRequest
            // 
            resources.ApplyResources(this.lblRequest, "lblRequest");
            this.lblRequest.Name = "lblRequest";
            // 
            // frmInputRequest
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmInputRequest";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInputRequest_FormClosing);
            this.Load += new System.EventHandler(this.frmInputRequest_Load);
            this.panelBase.ResumeLayout(false);
            this.panelBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Label lblRequest;
    }
}
