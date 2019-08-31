namespace DentalSystem.VisitManagement
{
    partial class FrmActivityPerformedMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActivityPerformedMaintenance));
            this.CbxSection = new System.Windows.Forms.ComboBox();
            this.BtnModifyActivity = new System.Windows.Forms.Button();
            this.BtnCancelActivity = new System.Windows.Forms.Button();
            this.BtnSaveActivity = new System.Windows.Forms.Button();
            this.DtpActivityDate = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.TxtActivityDescription = new System.Windows.Forms.TextBox();
            this.CbxActivityResponsable = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CbxSection
            // 
            this.CbxSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxSection.FormattingEnabled = true;
            this.CbxSection.Items.AddRange(new object[] {
            "Primer",
            "Segundo",
            "Tercer",
            "Cuarto"});
            this.CbxSection.Location = new System.Drawing.Point(29, 54);
            this.CbxSection.Name = "CbxSection";
            this.CbxSection.Size = new System.Drawing.Size(455, 31);
            this.CbxSection.TabIndex = 39;
            // 
            // BtnModifyActivity
            // 
            this.BtnModifyActivity.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnModifyActivity.Location = new System.Drawing.Point(369, 293);
            this.BtnModifyActivity.Name = "BtnModifyActivity";
            this.BtnModifyActivity.Size = new System.Drawing.Size(110, 52);
            this.BtnModifyActivity.TabIndex = 52;
            this.BtnModifyActivity.Text = "Modificar";
            this.BtnModifyActivity.UseVisualStyleBackColor = true;
            this.BtnModifyActivity.Click += new System.EventHandler(this.BtnModifyActivity_Click);
            // 
            // BtnCancelActivity
            // 
            this.BtnCancelActivity.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelActivity.Location = new System.Drawing.Point(253, 293);
            this.BtnCancelActivity.Name = "BtnCancelActivity";
            this.BtnCancelActivity.Size = new System.Drawing.Size(110, 52);
            this.BtnCancelActivity.TabIndex = 48;
            this.BtnCancelActivity.Text = "Cancelar";
            this.BtnCancelActivity.UseVisualStyleBackColor = true;
            // 
            // BtnSaveActivity
            // 
            this.BtnSaveActivity.Location = new System.Drawing.Point(137, 293);
            this.BtnSaveActivity.Name = "BtnSaveActivity";
            this.BtnSaveActivity.Size = new System.Drawing.Size(110, 52);
            this.BtnSaveActivity.TabIndex = 50;
            this.BtnSaveActivity.Text = "Guardar";
            this.BtnSaveActivity.UseVisualStyleBackColor = true;
            this.BtnSaveActivity.Visible = false;
            this.BtnSaveActivity.Click += new System.EventHandler(this.BtnSaveActivity_Click);
            // 
            // DtpActivityDate
            // 
            this.DtpActivityDate.CustomFormat = "dd/MM/yyyy";
            this.DtpActivityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpActivityDate.Location = new System.Drawing.Point(29, 186);
            this.DtpActivityDate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DtpActivityDate.Name = "DtpActivityDate";
            this.DtpActivityDate.Size = new System.Drawing.Size(455, 30);
            this.DtpActivityDate.TabIndex = 40;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(25, 225);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(132, 24);
            this.label22.TabIndex = 51;
            this.label22.Text = "Responsable";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(25, 159);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 24);
            this.label25.TabIndex = 46;
            this.label25.Text = "Fecha";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(25, 94);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(187, 24);
            this.label26.TabIndex = 45;
            this.label26.Text = "Actividad realizada";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(25, 27);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(108, 24);
            this.label27.TabIndex = 44;
            this.label27.Text = "Cuadrante";
            // 
            // TxtActivityDescription
            // 
            this.TxtActivityDescription.Location = new System.Drawing.Point(29, 122);
            this.TxtActivityDescription.Margin = new System.Windows.Forms.Padding(4);
            this.TxtActivityDescription.MaxLength = 100;
            this.TxtActivityDescription.Name = "TxtActivityDescription";
            this.TxtActivityDescription.ShortcutsEnabled = false;
            this.TxtActivityDescription.Size = new System.Drawing.Size(455, 30);
            this.TxtActivityDescription.TabIndex = 42;
            // 
            // CbxActivityResponsable
            // 
            this.CbxActivityResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxActivityResponsable.FormattingEnabled = true;
            this.CbxActivityResponsable.Location = new System.Drawing.Point(29, 252);
            this.CbxActivityResponsable.Name = "CbxActivityResponsable";
            this.CbxActivityResponsable.Size = new System.Drawing.Size(455, 31);
            this.CbxActivityResponsable.TabIndex = 39;
            // 
            // FrmActivityPerformedMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelActivity;
            this.ClientSize = new System.Drawing.Size(511, 358);
            this.Controls.Add(this.CbxActivityResponsable);
            this.Controls.Add(this.CbxSection);
            this.Controls.Add(this.BtnModifyActivity);
            this.Controls.Add(this.BtnCancelActivity);
            this.Controls.Add(this.BtnSaveActivity);
            this.Controls.Add(this.DtpActivityDate);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.TxtActivityDescription);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(529, 405);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(529, 405);
            this.Name = "FrmActivityPerformedMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento actividad";
            this.Load += new System.EventHandler(this.FrmActivityPerformedMaintenance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbxSection;
        private System.Windows.Forms.Button BtnModifyActivity;
        private System.Windows.Forms.Button BtnCancelActivity;
        private System.Windows.Forms.Button BtnSaveActivity;
        private System.Windows.Forms.DateTimePicker DtpActivityDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox TxtActivityDescription;
        private System.Windows.Forms.ComboBox CbxActivityResponsable;
    }
}