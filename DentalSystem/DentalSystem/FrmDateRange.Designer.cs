namespace DentalSystem
{
    partial class FrmDateRange
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
            this.DtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkDateRange = new System.Windows.Forms.CheckBox();
            this.BtnShowReport = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DtpTo
            // 
            this.DtpTo.CustomFormat = "dd/MM/yyyy";
            this.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpTo.Location = new System.Drawing.Point(373, 92);
            this.DtpTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtpTo.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DtpTo.Name = "DtpTo";
            this.DtpTo.Size = new System.Drawing.Size(242, 30);
            this.DtpTo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(369, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 43;
            this.label2.Text = "Hasta:";
            // 
            // DtpFrom
            // 
            this.DtpFrom.CustomFormat = "dd/MM/yyyy";
            this.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFrom.Location = new System.Drawing.Point(48, 92);
            this.DtpFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtpFrom.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DtpFrom.Name = "DtpFrom";
            this.DtpFrom.Size = new System.Drawing.Size(242, 30);
            this.DtpFrom.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 63);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Desde:";
            // 
            // ChkDateRange
            // 
            this.ChkDateRange.AutoSize = true;
            this.ChkDateRange.Checked = true;
            this.ChkDateRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDateRange.Location = new System.Drawing.Point(13, 25);
            this.ChkDateRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChkDateRange.Name = "ChkDateRange";
            this.ChkDateRange.Size = new System.Drawing.Size(187, 27);
            this.ChkDateRange.TabIndex = 45;
            this.ChkDateRange.Text = "Rango de fechas:";
            this.ChkDateRange.UseVisualStyleBackColor = true;
            this.ChkDateRange.CheckedChanged += new System.EventHandler(this.ChkDateRange_CheckedChanged);
            // 
            // BtnShowReport
            // 
            this.BtnShowReport.Location = new System.Drawing.Point(284, 141);
            this.BtnShowReport.Margin = new System.Windows.Forms.Padding(1);
            this.BtnShowReport.Name = "BtnShowReport";
            this.BtnShowReport.Size = new System.Drawing.Size(180, 51);
            this.BtnShowReport.TabIndex = 2;
            this.BtnShowReport.Text = "Ver reporte";
            this.BtnShowReport.UseVisualStyleBackColor = true;
            this.BtnShowReport.Click += new System.EventHandler(this.BtnShowReport_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(476, 141);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(1);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(180, 51);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmDateRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 209);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnShowReport);
            this.Controls.Add(this.DtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpFrom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ChkDateRange);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(694, 256);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(694, 256);
            this.Name = "FrmDateRange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rango de fechas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ChkDateRange;
        private System.Windows.Forms.Button BtnShowReport;
        private System.Windows.Forms.Button BtnCancel;
    }
}