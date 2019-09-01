namespace DentalSystem.AdminPassword
{
    partial class FrmConfirmPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfirmPassword));
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.PnlPassword = new System.Windows.Forms.Panel();
            this.PnlPasswordCenter = new System.Windows.Forms.Panel();
            this.LblPassword = new System.Windows.Forms.Label();
            this.PnlPassword.SuspendLayout();
            this.PnlPasswordCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(6, 6);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TxtPassword.MaxLength = 50;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.ShortcutsEnabled = false;
            this.TxtPassword.Size = new System.Drawing.Size(316, 30);
            this.TxtPassword.TabIndex = 20;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(165, 51);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(119, 49);
            this.BtnCancel.TabIndex = 24;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(39, 51);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(119, 49);
            this.BtnConfirm.TabIndex = 23;
            this.BtnConfirm.Text = "Confirmar";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // PnlPassword
            // 
            this.PnlPassword.Controls.Add(this.LblPassword);
            this.PnlPassword.Controls.Add(this.PnlPasswordCenter);
            this.PnlPassword.Location = new System.Drawing.Point(12, 12);
            this.PnlPassword.Name = "PnlPassword";
            this.PnlPassword.Size = new System.Drawing.Size(709, 163);
            this.PnlPassword.TabIndex = 25;
            // 
            // PnlPasswordCenter
            // 
            this.PnlPasswordCenter.Controls.Add(this.TxtPassword);
            this.PnlPasswordCenter.Controls.Add(this.BtnConfirm);
            this.PnlPasswordCenter.Controls.Add(this.BtnCancel);
            this.PnlPasswordCenter.Location = new System.Drawing.Point(170, 40);
            this.PnlPasswordCenter.Name = "PnlPasswordCenter";
            this.PnlPasswordCenter.Size = new System.Drawing.Size(332, 114);
            this.PnlPasswordCenter.TabIndex = 26;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassword.Location = new System.Drawing.Point(6, 6);
            this.LblPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(700, 29);
            this.LblPassword.TabIndex = 27;
            this.LblPassword.Text = "Debe escribir la contraseña del administrador para proceder";
            // 
            // FrmConfirmPassword
            // 
            this.AcceptButton = this.BtnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(733, 178);
            this.Controls.Add(this.PnlPassword);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(751, 225);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(751, 225);
            this.Name = "FrmConfirmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmar contraseña";
            this.Load += new System.EventHandler(this.FrmConfirmPassword_Load);
            this.PnlPassword.ResumeLayout(false);
            this.PnlPassword.PerformLayout();
            this.PnlPasswordCenter.ResumeLayout(false);
            this.PnlPasswordCenter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Panel PnlPassword;
        private System.Windows.Forms.Panel PnlPasswordCenter;
        private System.Windows.Forms.Label LblPassword;
    }
}