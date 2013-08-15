namespace TestHarness.ShellDirectToDB
{
    partial class LogPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RTBLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RTBLog
            // 
            this.RTBLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTBLog.CausesValidation = false;
            this.RTBLog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RTBLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBLog.Location = new System.Drawing.Point(0, 0);
            this.RTBLog.Name = "RTBLog";
            this.RTBLog.ReadOnly = true;
            this.RTBLog.Size = new System.Drawing.Size(100, 96);
            this.RTBLog.TabIndex = 0;
            this.RTBLog.Text = "";
            this.RTBLog.WordWrap = false;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox RTBLog;

    }
}
