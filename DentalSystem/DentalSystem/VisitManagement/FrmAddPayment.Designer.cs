namespace DentalSystem.VisitManagement
{
    partial class FrmAddPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddPayment));
            this.label26 = new System.Windows.Forms.Label();
            this.TxtTotalPending = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPayment = new System.Windows.Forms.TextBox();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(18, 27);
            this.label26.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(169, 24);
            this.label26.TabIndex = 47;
            this.label26.Text = "Monto pendiente";
            // 
            // TxtTotalPending
            // 
            this.TxtTotalPending.Location = new System.Drawing.Point(22, 57);
            this.TxtTotalPending.Margin = new System.Windows.Forms.Padding(6);
            this.TxtTotalPending.MaxLength = 100;
            this.TxtTotalPending.Name = "TxtTotalPending";
            this.TxtTotalPending.ReadOnly = true;
            this.TxtTotalPending.ShortcutsEnabled = false;
            this.TxtTotalPending.Size = new System.Drawing.Size(289, 30);
            this.TxtTotalPending.TabIndex = 1;
            this.TxtTotalPending.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 49;
            this.label1.Text = "Monto a pagar";
            // 
            // TxtPayment
            // 
            this.TxtPayment.Location = new System.Drawing.Point(22, 134);
            this.TxtPayment.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPayment.MaxLength = 100;
            this.TxtPayment.Name = "TxtPayment";
            this.TxtPayment.ShortcutsEnabled = false;
            this.TxtPayment.Size = new System.Drawing.Size(289, 30);
            this.TxtPayment.TabIndex = 0;
            this.TxtPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPayment_KeyPress);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddPayment.Location = new System.Drawing.Point(53, 178);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(110, 44);
            this.btnAddPayment.TabIndex = 2;
            this.btnAddPayment.Text = "Abonar";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.BtnAddPayment_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(175, 178);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(1);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 44);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmAddPayment
            // 
            this.AcceptButton = this.btnAddPayment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(340, 232);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPayment);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.TxtTotalPending);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 279);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 279);
            this.Name = "FrmAddPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar abono";
            this.Load += new System.EventHandler(this.FrmAddPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox TxtTotalPending;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPayment;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button BtnCancel;
    }
}