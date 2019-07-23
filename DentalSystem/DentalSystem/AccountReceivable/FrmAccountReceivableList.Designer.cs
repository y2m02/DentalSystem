namespace DentalSystem.AccountReceivable
{
    partial class FrmAccountReceivableList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnDeletePayment = new System.Windows.Forms.Button();
            this.BtnAddPayment = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.DgvPaymentList = new System.Windows.Forms.DataGridView();
            this.DgvAccountReceivableList = new System.Windows.Forms.DataGridView();
            this.LblPatientName = new System.Windows.Forms.Label();
            this.LblTotalPending = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPaymentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccountReceivableList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnDeletePayment);
            this.panel1.Controls.Add(this.LblPatientName);
            this.panel1.Controls.Add(this.BtnAddPayment);
            this.panel1.Controls.Add(this.LblTotalPending);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.DgvPaymentList);
            this.panel1.Controls.Add(this.DgvAccountReceivableList);
            this.panel1.Location = new System.Drawing.Point(17, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 659);
            this.panel1.TabIndex = 37;
            // 
            // BtnDeletePayment
            // 
            this.BtnDeletePayment.Location = new System.Drawing.Point(190, 42);
            this.BtnDeletePayment.Name = "BtnDeletePayment";
            this.BtnDeletePayment.Size = new System.Drawing.Size(165, 39);
            this.BtnDeletePayment.TabIndex = 40;
            this.BtnDeletePayment.Text = "Eliminar abono";
            this.BtnDeletePayment.UseVisualStyleBackColor = true;
            this.BtnDeletePayment.Click += new System.EventHandler(this.BtnDeletePayment_Click);
            // 
            // BtnAddPayment
            // 
            this.BtnAddPayment.Location = new System.Drawing.Point(19, 42);
            this.BtnAddPayment.Name = "BtnAddPayment";
            this.BtnAddPayment.Size = new System.Drawing.Size(165, 39);
            this.BtnAddPayment.TabIndex = 40;
            this.BtnAddPayment.Text = "Abonar";
            this.BtnAddPayment.UseVisualStyleBackColor = true;
            this.BtnAddPayment.Click += new System.EventHandler(this.BtnAddPayment_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(15, 87);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(201, 24);
            this.label18.TabIndex = 34;
            this.label18.Text = "Cuentas por cobrar:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 382);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 24);
            this.label13.TabIndex = 34;
            this.label13.Text = "Abonos:";
            // 
            // DgvPaymentList
            // 
            this.DgvPaymentList.AllowUserToAddRows = false;
            this.DgvPaymentList.AllowUserToDeleteRows = false;
            this.DgvPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvPaymentList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPaymentList.Location = new System.Drawing.Point(11, 410);
            this.DgvPaymentList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvPaymentList.MultiSelect = false;
            this.DgvPaymentList.Name = "DgvPaymentList";
            this.DgvPaymentList.ReadOnly = true;
            this.DgvPaymentList.RowHeadersWidth = 51;
            this.DgvPaymentList.RowTemplate.Height = 24;
            this.DgvPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPaymentList.Size = new System.Drawing.Size(893, 245);
            this.DgvPaymentList.TabIndex = 10;
            // 
            // DgvAccountReceivableList
            // 
            this.DgvAccountReceivableList.AllowUserToAddRows = false;
            this.DgvAccountReceivableList.AllowUserToDeleteRows = false;
            this.DgvAccountReceivableList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvAccountReceivableList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvAccountReceivableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAccountReceivableList.Location = new System.Drawing.Point(11, 114);
            this.DgvAccountReceivableList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvAccountReceivableList.MultiSelect = false;
            this.DgvAccountReceivableList.Name = "DgvAccountReceivableList";
            this.DgvAccountReceivableList.ReadOnly = true;
            this.DgvAccountReceivableList.RowHeadersWidth = 51;
            this.DgvAccountReceivableList.RowTemplate.Height = 24;
            this.DgvAccountReceivableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAccountReceivableList.Size = new System.Drawing.Size(893, 260);
            this.DgvAccountReceivableList.TabIndex = 10;
            this.DgvAccountReceivableList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAccountReceivableList_CellClick);
            // 
            // LblPatientName
            // 
            this.LblPatientName.AutoSize = true;
            this.LblPatientName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPatientName.Location = new System.Drawing.Point(4, 6);
            this.LblPatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPatientName.Name = "LblPatientName";
            this.LblPatientName.Size = new System.Drawing.Size(204, 24);
            this.LblPatientName.TabIndex = 36;
            this.LblPatientName.Text = "Nombre del paciente";
            // 
            // LblTotalPending
            // 
            this.LblTotalPending.AutoSize = true;
            this.LblTotalPending.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalPending.Location = new System.Drawing.Point(502, 87);
            this.LblTotalPending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTotalPending.Name = "LblTotalPending";
            this.LblTotalPending.Size = new System.Drawing.Size(219, 24);
            this.LblTotalPending.TabIndex = 34;
            this.LblTotalPending.Text = "Total pendiente: RD$0";
            // 
            // FrmAccountReceivableList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 683);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(966, 730);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(966, 730);
            this.Name = "FrmAccountReceivableList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por cobrar";
            this.Load += new System.EventHandler(this.FrmAccountReceivableList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPaymentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccountReceivableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnDeletePayment;
        private System.Windows.Forms.Label LblPatientName;
        private System.Windows.Forms.Button BtnAddPayment;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView DgvPaymentList;
        private System.Windows.Forms.DataGridView DgvAccountReceivableList;
        private System.Windows.Forms.Label LblTotalPending;
    }
}