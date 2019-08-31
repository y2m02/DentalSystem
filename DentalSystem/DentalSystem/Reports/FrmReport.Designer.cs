namespace DentalSystem.Reports.AccountReceivable
{
    partial class FrmAccountReceivableReport
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
            this.CrvAccountReceivable = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrvAccountReceivable
            // 
            this.CrvAccountReceivable.ActiveViewIndex = -1;
            this.CrvAccountReceivable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvAccountReceivable.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvAccountReceivable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvAccountReceivable.Location = new System.Drawing.Point(0, 0);
            this.CrvAccountReceivable.Name = "CrvAccountReceivable";
            this.CrvAccountReceivable.ShowCloseButton = false;
            this.CrvAccountReceivable.ShowGroupTreeButton = false;
            this.CrvAccountReceivable.ShowLogo = false;
            this.CrvAccountReceivable.Size = new System.Drawing.Size(1291, 683);
            this.CrvAccountReceivable.TabIndex = 0;
            this.CrvAccountReceivable.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmAccountReceivableReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 683);
            this.Controls.Add(this.CrvAccountReceivable);
            this.MinimizeBox = false;
            this.Name = "FrmAccountReceivableReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por cobrar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrvAccountReceivable;
    }
}