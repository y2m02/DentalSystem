namespace DentalSystem.PatientList
{
    partial class FrmPatientList
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
            this.components = new System.ComponentModel.Container();
            this.DgvPatientList = new System.Windows.Forms.DataGridView();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.RbtIdentification = new System.Windows.Forms.RadioButton();
            this.RbtName = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.PnlSearch = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPatientList)).BeginInit();
            this.PnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPatientList
            // 
            this.DgvPatientList.AllowUserToAddRows = false;
            this.DgvPatientList.AllowUserToDeleteRows = false;
            this.DgvPatientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvPatientList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPatientList.Location = new System.Drawing.Point(16, 219);
            this.DgvPatientList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvPatientList.MultiSelect = false;
            this.DgvPatientList.Name = "DgvPatientList";
            this.DgvPatientList.ReadOnly = true;
            this.DgvPatientList.RowHeadersWidth = 51;
            this.DgvPatientList.RowTemplate.Height = 24;
            this.DgvPatientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPatientList.Size = new System.Drawing.Size(1351, 726);
            this.DgvPatientList.TabIndex = 1;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(334, 19);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(367, 30);
            this.TxtSearch.TabIndex = 2;
            // 
            // RbtIdentification
            // 
            this.RbtIdentification.AutoSize = true;
            this.RbtIdentification.Checked = true;
            this.RbtIdentification.Location = new System.Drawing.Point(130, 20);
            this.RbtIdentification.Margin = new System.Windows.Forms.Padding(4);
            this.RbtIdentification.Name = "RbtIdentification";
            this.RbtIdentification.Size = new System.Drawing.Size(92, 27);
            this.RbtIdentification.TabIndex = 0;
            this.RbtIdentification.TabStop = true;
            this.RbtIdentification.Text = "Cédula";
            this.RbtIdentification.UseVisualStyleBackColor = true;
            // 
            // RbtName
            // 
            this.RbtName.AutoSize = true;
            this.RbtName.Location = new System.Drawing.Point(228, 21);
            this.RbtName.Margin = new System.Windows.Forms.Padding(4);
            this.RbtName.Name = "RbtName";
            this.RbtName.Size = new System.Drawing.Size(100, 27);
            this.RbtName.TabIndex = 1;
            this.RbtName.Text = "Nombre";
            this.RbtName.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar por:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 151);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 51);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Agregar paciente";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClear.Location = new System.Drawing.Point(799, 17);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(1);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(136, 33);
            this.BtnClear.TabIndex = 4;
            this.BtnClear.Text = "Limpiar filtro";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearch.Location = new System.Drawing.Point(706, 17);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(89, 33);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "Buscar";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // PnlSearch
            // 
            this.PnlSearch.Controls.Add(this.label1);
            this.PnlSearch.Controls.Add(this.BtnClear);
            this.PnlSearch.Controls.Add(this.TxtSearch);
            this.PnlSearch.Controls.Add(this.BtnSearch);
            this.PnlSearch.Controls.Add(this.RbtIdentification);
            this.PnlSearch.Controls.Add(this.RbtName);
            this.PnlSearch.Location = new System.Drawing.Point(16, 15);
            this.PnlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.PnlSearch.Name = "PnlSearch";
            this.PnlSearch.Size = new System.Drawing.Size(951, 68);
            this.PnlSearch.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmPatientList
            // 
            this.AcceptButton = this.BtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClear;
            this.ClientSize = new System.Drawing.Size(1384, 1036);
            this.Controls.Add(this.PnlSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.DgvPatientList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1402, 1028);
            this.Name = "FrmPatientList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de pacientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPatientList_Load);
            this.Shown += new System.EventHandler(this.FrmPatientList_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmPatientList_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPatientList)).EndInit();
            this.PnlSearch.ResumeLayout(false);
            this.PnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPatientList;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.RadioButton RbtIdentification;
        private System.Windows.Forms.RadioButton RbtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button BtnClear;
        public System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel PnlSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}