namespace DentalSystem.Patient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatientList));
            this.DgvPatientList = new System.Windows.Forms.DataGridView();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.RbtIdentification = new System.Windows.Forms.RadioButton();
            this.RbtName = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.PnlSearch = new System.Windows.Forms.Panel();
            this.DtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkDateRange = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtnVisits = new System.Windows.Forms.Button();
            this.BtnCreateVisit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnBackToVisit = new System.Windows.Forms.Button();
            this.BtnAccountReceivable = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PbxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPatientList)).BeginInit();
            this.PnlSearch.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPatientList
            // 
            this.DgvPatientList.AllowUserToAddRows = false;
            this.DgvPatientList.AllowUserToDeleteRows = false;
            this.DgvPatientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvPatientList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPatientList.Location = new System.Drawing.Point(16, 244);
            this.DgvPatientList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvPatientList.MultiSelect = false;
            this.DgvPatientList.Name = "DgvPatientList";
            this.DgvPatientList.ReadOnly = true;
            this.DgvPatientList.RowHeadersVisible = false;
            this.DgvPatientList.RowHeadersWidth = 51;
            this.DgvPatientList.RowTemplate.Height = 24;
            this.DgvPatientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPatientList.Size = new System.Drawing.Size(1351, 701);
            this.DgvPatientList.TabIndex = 4;
            this.DgvPatientList.SelectionChanged += new System.EventHandler(this.DgvPatientList_SelectionChanged);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(334, 6);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(367, 30);
            this.TxtSearch.TabIndex = 2;
            // 
            // RbtIdentification
            // 
            this.RbtIdentification.AutoSize = true;
            this.RbtIdentification.Checked = true;
            this.RbtIdentification.Location = new System.Drawing.Point(130, 7);
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
            this.RbtName.Location = new System.Drawing.Point(228, 8);
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
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar por:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 188);
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
            this.BtnClear.Location = new System.Drawing.Point(799, 4);
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
            this.BtnSearch.Location = new System.Drawing.Point(706, 4);
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
            this.PnlSearch.Controls.Add(this.DtpTo);
            this.PnlSearch.Controls.Add(this.label2);
            this.PnlSearch.Controls.Add(this.DtpFrom);
            this.PnlSearch.Controls.Add(this.label8);
            this.PnlSearch.Controls.Add(this.label1);
            this.PnlSearch.Controls.Add(this.BtnClear);
            this.PnlSearch.Controls.Add(this.TxtSearch);
            this.PnlSearch.Controls.Add(this.BtnSearch);
            this.PnlSearch.Controls.Add(this.RbtIdentification);
            this.PnlSearch.Controls.Add(this.RbtName);
            this.PnlSearch.Controls.Add(this.ChkDateRange);
            this.PnlSearch.Location = new System.Drawing.Point(16, 96);
            this.PnlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.PnlSearch.Name = "PnlSearch";
            this.PnlSearch.Size = new System.Drawing.Size(951, 88);
            this.PnlSearch.TabIndex = 0;
            // 
            // DtpTo
            // 
            this.DtpTo.CustomFormat = "dd/MM/yyyy";
            this.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpTo.Location = new System.Drawing.Point(607, 50);
            this.DtpTo.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DtpTo.Name = "DtpTo";
            this.DtpTo.Size = new System.Drawing.Size(177, 30);
            this.DtpTo.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(544, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 39;
            this.label2.Text = "Hasta:";
            // 
            // DtpFrom
            // 
            this.DtpFrom.CustomFormat = "dd/MM/yyyy";
            this.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFrom.Location = new System.Drawing.Point(333, 50);
            this.DtpFrom.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DtpFrom.Name = "DtpFrom";
            this.DtpFrom.Size = new System.Drawing.Size(177, 30);
            this.DtpFrom.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(265, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 23);
            this.label8.TabIndex = 39;
            this.label8.Text = "Desde:";
            // 
            // ChkDateRange
            // 
            this.ChkDateRange.AutoSize = true;
            this.ChkDateRange.Checked = true;
            this.ChkDateRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDateRange.Location = new System.Drawing.Point(87, 50);
            this.ChkDateRange.Name = "ChkDateRange";
            this.ChkDateRange.Size = new System.Drawing.Size(187, 27);
            this.ChkDateRange.TabIndex = 40;
            this.ChkDateRange.Text = "Rango de fechas:";
            this.ChkDateRange.UseVisualStyleBackColor = true;
            this.ChkDateRange.CheckedChanged += new System.EventHandler(this.ChkDateRange_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BtnVisits
            // 
            this.BtnVisits.Location = new System.Drawing.Point(380, 188);
            this.BtnVisits.Margin = new System.Windows.Forms.Padding(1);
            this.BtnVisits.Name = "BtnVisits";
            this.BtnVisits.Size = new System.Drawing.Size(180, 51);
            this.BtnVisits.TabIndex = 1;
            this.BtnVisits.Text = "Ver visitas";
            this.BtnVisits.UseVisualStyleBackColor = true;
            this.BtnVisits.Click += new System.EventHandler(this.BtnVisits_Click);
            // 
            // BtnCreateVisit
            // 
            this.BtnCreateVisit.Location = new System.Drawing.Point(198, 188);
            this.BtnCreateVisit.Margin = new System.Windows.Forms.Padding(1);
            this.BtnCreateVisit.Name = "BtnCreateVisit";
            this.BtnCreateVisit.Size = new System.Drawing.Size(180, 51);
            this.BtnCreateVisit.TabIndex = 2;
            this.BtnCreateVisit.Text = "Crear visita";
            this.BtnCreateVisit.UseVisualStyleBackColor = true;
            this.BtnCreateVisit.Click += new System.EventHandler(this.BtnCreateVisit_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(562, 188);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(180, 51);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "Eliminar paciente";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(373, 38);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(536, 38);
            this.LblTitle.TabIndex = 27;
            this.LblTitle.Text = "CLINICA DENTAL DRA. RAMIREZ\t\t\t\t\t\t";
            // 
            // BtnBackToVisit
            // 
            this.BtnBackToVisit.Location = new System.Drawing.Point(926, 188);
            this.BtnBackToVisit.Margin = new System.Windows.Forms.Padding(1);
            this.BtnBackToVisit.Name = "BtnBackToVisit";
            this.BtnBackToVisit.Size = new System.Drawing.Size(180, 51);
            this.BtnBackToVisit.TabIndex = 3;
            this.BtnBackToVisit.Text = "Volver a la visita";
            this.BtnBackToVisit.UseVisualStyleBackColor = true;
            this.BtnBackToVisit.Visible = false;
            this.BtnBackToVisit.Click += new System.EventHandler(this.BtnBackToVisit_Click);
            // 
            // BtnAccountReceivable
            // 
            this.BtnAccountReceivable.Location = new System.Drawing.Point(744, 188);
            this.BtnAccountReceivable.Margin = new System.Windows.Forms.Padding(1);
            this.BtnAccountReceivable.Name = "BtnAccountReceivable";
            this.BtnAccountReceivable.Size = new System.Drawing.Size(180, 51);
            this.BtnAccountReceivable.TabIndex = 28;
            this.BtnAccountReceivable.Text = "Ver deudas";
            this.BtnAccountReceivable.UseVisualStyleBackColor = true;
            this.BtnAccountReceivable.Click += new System.EventHandler(this.BtnAccountReceivable_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 28);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.salirToolStripMenuItem1});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.salirToolStripMenuItem.Text = "Realizar copia de seguridad";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(277, 26);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.SalirToolStripMenuItem1_Click);
            // 
            // PbxLogo
            // 
            this.PbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbxLogo.Image")));
            this.PbxLogo.Location = new System.Drawing.Point(974, 38);
            this.PbxLogo.Name = "PbxLogo";
            this.PbxLogo.Size = new System.Drawing.Size(266, 133);
            this.PbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxLogo.TabIndex = 30;
            this.PbxLogo.TabStop = false;
            // 
            // FrmPatientList
            // 
            this.AcceptButton = this.BtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClear;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.PbxLogo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BtnAccountReceivable);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.PnlSearch);
            this.Controls.Add(this.BtnBackToVisit);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnCreateVisit);
            this.Controls.Add(this.BtnVisits);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.DgvPatientList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "FrmPatientList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de pacientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmPatientList_Activated);
            this.Load += new System.EventHandler(this.FrmPatientList_Load);
            this.SizeChanged += new System.EventHandler(this.FrmPatientList_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPatientList)).EndInit();
            this.PnlSearch.ResumeLayout(false);
            this.PnlSearch.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button BtnVisits;
        private System.Windows.Forms.Button BtnCreateVisit;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Button BtnBackToVisit;
        private System.Windows.Forms.Button BtnAccountReceivable;
        private System.Windows.Forms.CheckBox ChkDateRange;
        private System.Windows.Forms.DateTimePicker DtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.PictureBox PbxLogo;
    }
}