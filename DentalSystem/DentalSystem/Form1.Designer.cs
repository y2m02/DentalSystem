namespace DentalSystem
{
    partial class Form1
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PnlTeeth1 = new System.Windows.Forms.Panel();
            this.BtnTeeth1Botton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnTeeth1Center = new System.Windows.Forms.Button();
            this.BtnTeeth1Right = new System.Windows.Forms.Button();
            this.BtnTeeth1Left = new System.Windows.Forms.Button();
            this.BtnTeeth1Top = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PnlTeeth1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(116, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(682, 454);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(674, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnTeeth1Center);
            this.panel1.Controls.Add(this.BtnTeeth1Right);
            this.panel1.Controls.Add(this.BtnTeeth1Left);
            this.panel1.Controls.Add(this.BtnTeeth1Top);
            this.panel1.Controls.Add(this.PnlTeeth1);
            this.panel1.Location = new System.Drawing.Point(287, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 194);
            this.panel1.TabIndex = 7;
            // 
            // PnlTeeth1
            // 
            this.PnlTeeth1.Controls.Add(this.BtnTeeth1Botton);
            this.PnlTeeth1.Location = new System.Drawing.Point(40, 28);
            this.PnlTeeth1.Name = "PnlTeeth1";
            this.PnlTeeth1.Size = new System.Drawing.Size(101, 106);
            this.PnlTeeth1.TabIndex = 6;
            // 
            // BtnTeeth1Botton
            // 
            this.BtnTeeth1Botton.Location = new System.Drawing.Point(26, 81);
            this.BtnTeeth1Botton.Name = "BtnTeeth1Botton";
            this.BtnTeeth1Botton.Size = new System.Drawing.Size(50, 15);
            this.BtnTeeth1Botton.TabIndex = 5;
            this.BtnTeeth1Botton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Silver;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(674, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // BtnTeeth1Center
            // 
            this.BtnTeeth1Center.Location = new System.Drawing.Point(124, 80);
            this.BtnTeeth1Center.Name = "BtnTeeth1Center";
            this.BtnTeeth1Center.Size = new System.Drawing.Size(50, 50);
            this.BtnTeeth1Center.TabIndex = 8;
            this.BtnTeeth1Center.UseVisualStyleBackColor = true;
            // 
            // BtnTeeth1Right
            // 
            this.BtnTeeth1Right.Location = new System.Drawing.Point(175, 80);
            this.BtnTeeth1Right.Name = "BtnTeeth1Right";
            this.BtnTeeth1Right.Size = new System.Drawing.Size(15, 50);
            this.BtnTeeth1Right.TabIndex = 10;
            this.BtnTeeth1Right.UseVisualStyleBackColor = true;
            // 
            // BtnTeeth1Left
            // 
            this.BtnTeeth1Left.Location = new System.Drawing.Point(108, 80);
            this.BtnTeeth1Left.Name = "BtnTeeth1Left";
            this.BtnTeeth1Left.Size = new System.Drawing.Size(15, 50);
            this.BtnTeeth1Left.TabIndex = 9;
            this.BtnTeeth1Left.UseVisualStyleBackColor = true;
            // 
            // BtnTeeth1Top
            // 
            this.BtnTeeth1Top.Location = new System.Drawing.Point(124, 64);
            this.BtnTeeth1Top.Name = "BtnTeeth1Top";
            this.BtnTeeth1Top.Size = new System.Drawing.Size(50, 15);
            this.BtnTeeth1Top.TabIndex = 7;
            this.BtnTeeth1Top.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PnlTeeth1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel PnlTeeth1;
        private System.Windows.Forms.Button BtnTeeth1Botton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnTeeth1Center;
        private System.Windows.Forms.Button BtnTeeth1Right;
        private System.Windows.Forms.Button BtnTeeth1Left;
        private System.Windows.Forms.Button BtnTeeth1Top;
    }
}

