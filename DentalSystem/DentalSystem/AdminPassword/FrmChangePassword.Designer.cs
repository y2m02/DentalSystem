namespace DentalSystem.AdminPassword
{
    partial class FrmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePassword));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNewPassword = new System.Windows.Forms.TextBox();
            this.TxtCurrentPassword = new System.Windows.Forms.TextBox();
            this.TxtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PnlCurrentPassword = new System.Windows.Forms.Panel();
            this.PnlNewPassword = new System.Windows.Forms.Panel();
            this.PnlCurrentPassword.SuspendLayout();
            this.PnlNewPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nueva contraseña ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Contraseña actual";
            // 
            // TxtNewPassword
            // 
            this.TxtNewPassword.Location = new System.Drawing.Point(9, 29);
            this.TxtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNewPassword.MaxLength = 50;
            this.TxtNewPassword.Name = "TxtNewPassword";
            this.TxtNewPassword.ShortcutsEnabled = false;
            this.TxtNewPassword.Size = new System.Drawing.Size(292, 30);
            this.TxtNewPassword.TabIndex = 1;
            this.TxtNewPassword.UseSystemPasswordChar = true;
            // 
            // TxtCurrentPassword
            // 
            this.TxtCurrentPassword.Location = new System.Drawing.Point(9, 36);
            this.TxtCurrentPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCurrentPassword.MaxLength = 50;
            this.TxtCurrentPassword.Name = "TxtCurrentPassword";
            this.TxtCurrentPassword.Size = new System.Drawing.Size(292, 30);
            this.TxtCurrentPassword.TabIndex = 0;
            this.TxtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // TxtConfirmNewPassword
            // 
            this.TxtConfirmNewPassword.Location = new System.Drawing.Point(9, 100);
            this.TxtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TxtConfirmNewPassword.MaxLength = 50;
            this.TxtConfirmNewPassword.Name = "TxtConfirmNewPassword";
            this.TxtConfirmNewPassword.ShortcutsEnabled = false;
            this.TxtConfirmNewPassword.Size = new System.Drawing.Size(292, 30);
            this.TxtConfirmNewPassword.TabIndex = 2;
            this.TxtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 24);
            this.label3.TabIndex = 30;
            this.label3.Text = "Confiarmar nueva contraseña ";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(31, 140);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(119, 49);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Actualizar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(157, 140);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(119, 49);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // PnlCurrentPassword
            // 
            this.PnlCurrentPassword.Controls.Add(this.label1);
            this.PnlCurrentPassword.Controls.Add(this.TxtCurrentPassword);
            this.PnlCurrentPassword.Location = new System.Drawing.Point(10, 12);
            this.PnlCurrentPassword.Name = "PnlCurrentPassword";
            this.PnlCurrentPassword.Size = new System.Drawing.Size(315, 76);
            this.PnlCurrentPassword.TabIndex = 31;
            // 
            // PnlNewPassword
            // 
            this.PnlNewPassword.Controls.Add(this.label2);
            this.PnlNewPassword.Controls.Add(this.TxtNewPassword);
            this.PnlNewPassword.Controls.Add(this.BtnSave);
            this.PnlNewPassword.Controls.Add(this.TxtConfirmNewPassword);
            this.PnlNewPassword.Controls.Add(this.BtnCancel);
            this.PnlNewPassword.Controls.Add(this.label3);
            this.PnlNewPassword.Location = new System.Drawing.Point(10, 94);
            this.PnlNewPassword.Name = "PnlNewPassword";
            this.PnlNewPassword.Size = new System.Drawing.Size(315, 196);
            this.PnlNewPassword.TabIndex = 32;
            // 
            // FrmChangePassword
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(328, 292);
            this.Controls.Add(this.PnlNewPassword);
            this.Controls.Add(this.PnlCurrentPassword);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(346, 339);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(346, 339);
            this.Name = "FrmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar contraseña";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChangePassword_FormClosing);
            this.Load += new System.EventHandler(this.FrmChangePassword_Load);
            this.PnlCurrentPassword.ResumeLayout(false);
            this.PnlCurrentPassword.PerformLayout();
            this.PnlNewPassword.ResumeLayout(false);
            this.PnlNewPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNewPassword;
        private System.Windows.Forms.TextBox TxtCurrentPassword;
        private System.Windows.Forms.TextBox TxtConfirmNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Panel PnlCurrentPassword;
        private System.Windows.Forms.Panel PnlNewPassword;
    }
}