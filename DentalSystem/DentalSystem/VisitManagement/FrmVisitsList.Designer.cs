namespace DentalSystem.VisitManagement
{
    partial class FrmVisitsList
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
            this.DgvVisitList = new System.Windows.Forms.DataGridView();
            this.BtnBackToVisit = new System.Windows.Forms.Button();
            this.LblPatientName = new System.Windows.Forms.Label();
            this.BtnVisitDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVisitList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvVisitList
            // 
            this.DgvVisitList.AllowUserToAddRows = false;
            this.DgvVisitList.AllowUserToDeleteRows = false;
            this.DgvVisitList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvVisitList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvVisitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVisitList.Location = new System.Drawing.Point(13, 113);
            this.DgvVisitList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvVisitList.MultiSelect = false;
            this.DgvVisitList.Name = "DgvVisitList";
            this.DgvVisitList.ReadOnly = true;
            this.DgvVisitList.RowHeadersVisible = false;
            this.DgvVisitList.RowHeadersWidth = 51;
            this.DgvVisitList.RowTemplate.Height = 24;
            this.DgvVisitList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvVisitList.Size = new System.Drawing.Size(1074, 484);
            this.DgvVisitList.TabIndex = 5;
            this.DgvVisitList.SelectionChanged += new System.EventHandler(this.DgvVisitList_SelectionChanged);
            // 
            // BtnBackToVisit
            // 
            this.BtnBackToVisit.Location = new System.Drawing.Point(10, 57);
            this.BtnBackToVisit.Margin = new System.Windows.Forms.Padding(1);
            this.BtnBackToVisit.Name = "BtnBackToVisit";
            this.BtnBackToVisit.Size = new System.Drawing.Size(180, 51);
            this.BtnBackToVisit.TabIndex = 6;
            this.BtnBackToVisit.Text = "Volver a la visita";
            this.BtnBackToVisit.UseVisualStyleBackColor = true;
            this.BtnBackToVisit.Click += new System.EventHandler(this.BtnBackToVisit_Click);
            // 
            // LblPatientName
            // 
            this.LblPatientName.AutoSize = true;
            this.LblPatientName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPatientName.Location = new System.Drawing.Point(13, 9);
            this.LblPatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPatientName.Name = "LblPatientName";
            this.LblPatientName.Size = new System.Drawing.Size(204, 24);
            this.LblPatientName.TabIndex = 27;
            this.LblPatientName.Text = "Nombre del paciente";
            // 
            // BtnVisitDetails
            // 
            this.BtnVisitDetails.Location = new System.Drawing.Point(203, 57);
            this.BtnVisitDetails.Margin = new System.Windows.Forms.Padding(1);
            this.BtnVisitDetails.Name = "BtnVisitDetails";
            this.BtnVisitDetails.Size = new System.Drawing.Size(180, 51);
            this.BtnVisitDetails.TabIndex = 6;
            this.BtnVisitDetails.Text = "Ver detalles";
            this.BtnVisitDetails.UseVisualStyleBackColor = true;
            this.BtnVisitDetails.Click += new System.EventHandler(this.BtnVisitDetails_Click);
            // 
            // FrmVisitsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.LblPatientName);
            this.Controls.Add(this.BtnVisitDetails);
            this.Controls.Add(this.BtnBackToVisit);
            this.Controls.Add(this.DgvVisitList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1118, 694);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1118, 694);
            this.Name = "FrmVisitsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de visitas";
            this.Activated += new System.EventHandler(this.FrmVisitsList_Activated);
            this.Load += new System.EventHandler(this.FrmVisitsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVisitList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvVisitList;
        private System.Windows.Forms.Button BtnBackToVisit;
        private System.Windows.Forms.Label LblPatientName;
        private System.Windows.Forms.Button BtnVisitDetails;
    }
}