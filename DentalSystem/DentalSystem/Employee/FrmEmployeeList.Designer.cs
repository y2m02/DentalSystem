namespace DentalSystem.Employee
{
    partial class FrmEmployeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployeeList));
            this.DgvEmployeeList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvEmployeeList
            // 
            this.DgvEmployeeList.AllowUserToAddRows = false;
            this.DgvEmployeeList.AllowUserToDeleteRows = false;
            this.DgvEmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvEmployeeList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmployeeList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DgvEmployeeList.Location = new System.Drawing.Point(0, 140);
            this.DgvEmployeeList.Margin = new System.Windows.Forms.Padding(4);
            this.DgvEmployeeList.MultiSelect = false;
            this.DgvEmployeeList.Name = "DgvEmployeeList";
            this.DgvEmployeeList.ReadOnly = true;
            this.DgvEmployeeList.RowHeadersVisible = false;
            this.DgvEmployeeList.RowHeadersWidth = 51;
            this.DgvEmployeeList.RowTemplate.Height = 24;
            this.DgvEmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEmployeeList.Size = new System.Drawing.Size(1217, 522);
            this.DgvEmployeeList.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Buscar por nombre o cédula:";
            // 
            // BtnClear
            // 
            this.BtnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClear.Location = new System.Drawing.Point(747, 26);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(1);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(136, 33);
            this.BtnClear.TabIndex = 2;
            this.BtnClear.Text = "Limpiar filtro";
            this.BtnClear.UseVisualStyleBackColor = true;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(282, 28);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(367, 30);
            this.TxtSearch.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearch.Location = new System.Drawing.Point(654, 26);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(89, 33);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "Buscar";
            this.BtnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 75);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 51);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(213, 75);
            this.BtnModificar.Margin = new System.Windows.Forms.Padding(1);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(180, 51);
            this.BtnModificar.TabIndex = 4;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(404, 75);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(1);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(180, 51);
            this.BtnDelete.TabIndex = 5;
            this.BtnDelete.Text = "Eliminar";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // FrmEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 662);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.DgvEmployeeList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1235, 709);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1235, 709);
            this.Name = "FrmEmployeeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de empleados";
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployeeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvEmployeeList;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.TextBox TxtSearch;
        public System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnDelete;
    }
}