namespace DentalSystem.VisitManagement
{
    partial class FrmVisitManagement
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
            this.TclVisitManagement = new System.Windows.Forms.TabControl();
            this.TabGeneralInfo = new System.Windows.Forms.TabPage();
            this.BtnGeneralInfo = new System.Windows.Forms.Button();
            this.BtnInitialOdontogram = new System.Windows.Forms.Button();
            this.BtnTreatmentOdontogram = new System.Windows.Forms.Button();
            this.BtnActivitiesPerformed = new System.Windows.Forms.Button();
            this.BtnInvoice = new System.Windows.Forms.Button();
            this.TabTreatmentOdontogram = new System.Windows.Forms.TabPage();
            this.TabActivitiesPermormed = new System.Windows.Forms.TabPage();
            this.TabInvoice = new System.Windows.Forms.TabPage();
            this.TabInitialOdontogram = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.PnlPatientHealth = new System.Windows.Forms.Panel();
            this.LblPatientHealth = new System.Windows.Forms.Label();
            this.TxtDiseaseCause = new System.Windows.Forms.TextBox();
            this.ChkHasAllergicReaction = new System.Windows.Forms.CheckBox();
            this.ChkHasDiabeticParents = new System.Windows.Forms.CheckBox();
            this.ChkHeartValve = new System.Windows.Forms.CheckBox();
            this.ChkHasHepatitis = new System.Windows.Forms.CheckBox();
            this.ChkHasAnemia = new System.Windows.Forms.CheckBox();
            this.ChkHasAllergy = new System.Windows.Forms.CheckBox();
            this.ChkHasBleeding = new System.Windows.Forms.CheckBox();
            this.ChkHasHeartMurmur = new System.Windows.Forms.CheckBox();
            this.ChkHasRenalDisease = new System.Windows.Forms.CheckBox();
            this.ChkHasBeenSickRecently = new System.Windows.Forms.CheckBox();
            this.ChkHasTuberculosis = new System.Windows.Forms.CheckBox();
            this.ChkIsEpileptic = new System.Windows.Forms.CheckBox();
            this.ChkHasBronchialAsthma = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PnlInsurance = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.RbtInsuranceYes = new System.Windows.Forms.RadioButton();
            this.RbtInsuranceNo = new System.Windows.Forms.RadioButton();
            this.PnlZone = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.RbtRural = new System.Windows.Forms.RadioButton();
            this.RbtUrban = new System.Windows.Forms.RadioButton();
            this.PnlGender = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.RbtMale = new System.Windows.Forms.RadioButton();
            this.RbtFemale = new System.Windows.Forms.RadioButton();
            this.DtpAdmissionDate = new System.Windows.Forms.DateTimePicker();
            this.DtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.NudAge = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtIdentificationCard = new System.Windows.Forms.TextBox();
            this.TxtPhoneNumber = new System.Windows.Forms.TextBox();
            this.TxtNss = new System.Windows.Forms.TextBox();
            this.TxtSector = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.BtnModify = new System.Windows.Forms.Button();
            this.TclVisitManagement.SuspendLayout();
            this.TabGeneralInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PnlPatientHealth.SuspendLayout();
            this.PnlInsurance.SuspendLayout();
            this.PnlZone.SuspendLayout();
            this.PnlGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudAge)).BeginInit();
            this.SuspendLayout();
            // 
            // TclVisitManagement
            // 
            this.TclVisitManagement.Controls.Add(this.TabGeneralInfo);
            this.TclVisitManagement.Controls.Add(this.TabInitialOdontogram);
            this.TclVisitManagement.Controls.Add(this.TabTreatmentOdontogram);
            this.TclVisitManagement.Controls.Add(this.TabActivitiesPermormed);
            this.TclVisitManagement.Controls.Add(this.TabInvoice);
            this.TclVisitManagement.Dock = System.Windows.Forms.DockStyle.Right;
            this.TclVisitManagement.Location = new System.Drawing.Point(168, 0);
            this.TclVisitManagement.Name = "TclVisitManagement";
            this.TclVisitManagement.SelectedIndex = 0;
            this.TclVisitManagement.Size = new System.Drawing.Size(1114, 683);
            this.TclVisitManagement.TabIndex = 5;
            this.TclVisitManagement.Click += new System.EventHandler(this.TclVisitManagement_Click);
            // 
            // TabGeneralInfo
            // 
            this.TabGeneralInfo.Controls.Add(this.panel1);
            this.TabGeneralInfo.Location = new System.Drawing.Point(4, 32);
            this.TabGeneralInfo.Name = "TabGeneralInfo";
            this.TabGeneralInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneralInfo.Size = new System.Drawing.Size(1106, 647);
            this.TabGeneralInfo.TabIndex = 0;
            this.TabGeneralInfo.Text = "Datos generales";
            this.TabGeneralInfo.UseVisualStyleBackColor = true;
            // 
            // BtnGeneralInfo
            // 
            this.BtnGeneralInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnGeneralInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGeneralInfo.Location = new System.Drawing.Point(0, 0);
            this.BtnGeneralInfo.Name = "BtnGeneralInfo";
            this.BtnGeneralInfo.Size = new System.Drawing.Size(168, 81);
            this.BtnGeneralInfo.TabIndex = 0;
            this.BtnGeneralInfo.Text = "Datos generales";
            this.BtnGeneralInfo.UseVisualStyleBackColor = true;
            this.BtnGeneralInfo.Click += new System.EventHandler(this.BtnGeneralInfo_Click);
            // 
            // BtnInitialOdontogram
            // 
            this.BtnInitialOdontogram.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnInitialOdontogram.Location = new System.Drawing.Point(0, 81);
            this.BtnInitialOdontogram.Name = "BtnInitialOdontogram";
            this.BtnInitialOdontogram.Size = new System.Drawing.Size(168, 81);
            this.BtnInitialOdontogram.TabIndex = 1;
            this.BtnInitialOdontogram.Text = "Odontograma inicial";
            this.BtnInitialOdontogram.UseVisualStyleBackColor = true;
            this.BtnInitialOdontogram.Click += new System.EventHandler(this.BtnInitialOdontogram_Click);
            // 
            // BtnTreatmentOdontogram
            // 
            this.BtnTreatmentOdontogram.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnTreatmentOdontogram.Location = new System.Drawing.Point(0, 162);
            this.BtnTreatmentOdontogram.Name = "BtnTreatmentOdontogram";
            this.BtnTreatmentOdontogram.Size = new System.Drawing.Size(168, 81);
            this.BtnTreatmentOdontogram.TabIndex = 2;
            this.BtnTreatmentOdontogram.Text = "Odontograma tratamiento";
            this.BtnTreatmentOdontogram.UseVisualStyleBackColor = true;
            this.BtnTreatmentOdontogram.Click += new System.EventHandler(this.BtnTreatmentOdontogram_Click);
            // 
            // BtnActivitiesPerformed
            // 
            this.BtnActivitiesPerformed.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnActivitiesPerformed.Location = new System.Drawing.Point(0, 243);
            this.BtnActivitiesPerformed.Name = "BtnActivitiesPerformed";
            this.BtnActivitiesPerformed.Size = new System.Drawing.Size(168, 81);
            this.BtnActivitiesPerformed.TabIndex = 3;
            this.BtnActivitiesPerformed.Text = "Actividades realizadas";
            this.BtnActivitiesPerformed.UseVisualStyleBackColor = true;
            this.BtnActivitiesPerformed.Click += new System.EventHandler(this.BtnActivitiesPerformed_Click);
            // 
            // BtnInvoice
            // 
            this.BtnInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnInvoice.Location = new System.Drawing.Point(0, 324);
            this.BtnInvoice.Name = "BtnInvoice";
            this.BtnInvoice.Size = new System.Drawing.Size(168, 81);
            this.BtnInvoice.TabIndex = 4;
            this.BtnInvoice.Text = "Facturación";
            this.BtnInvoice.UseVisualStyleBackColor = true;
            this.BtnInvoice.Click += new System.EventHandler(this.BtnInvoice_Click);
            // 
            // TabTreatmentOdontogram
            // 
            this.TabTreatmentOdontogram.Location = new System.Drawing.Point(4, 32);
            this.TabTreatmentOdontogram.Name = "TabTreatmentOdontogram";
            this.TabTreatmentOdontogram.Size = new System.Drawing.Size(1106, 647);
            this.TabTreatmentOdontogram.TabIndex = 2;
            this.TabTreatmentOdontogram.Text = "Odontograma tratamiento";
            this.TabTreatmentOdontogram.UseVisualStyleBackColor = true;
            // 
            // TabActivitiesPermormed
            // 
            this.TabActivitiesPermormed.Location = new System.Drawing.Point(4, 32);
            this.TabActivitiesPermormed.Name = "TabActivitiesPermormed";
            this.TabActivitiesPermormed.Size = new System.Drawing.Size(1106, 647);
            this.TabActivitiesPermormed.TabIndex = 3;
            this.TabActivitiesPermormed.Text = "Actividades realizadas";
            this.TabActivitiesPermormed.UseVisualStyleBackColor = true;
            // 
            // TabInvoice
            // 
            this.TabInvoice.Location = new System.Drawing.Point(4, 32);
            this.TabInvoice.Name = "TabInvoice";
            this.TabInvoice.Size = new System.Drawing.Size(1106, 647);
            this.TabInvoice.TabIndex = 4;
            this.TabInvoice.Text = "Facturación";
            this.TabInvoice.UseVisualStyleBackColor = true;
            // 
            // TabInitialOdontogram
            // 
            this.TabInitialOdontogram.Location = new System.Drawing.Point(4, 32);
            this.TabInitialOdontogram.Name = "TabInitialOdontogram";
            this.TabInitialOdontogram.Padding = new System.Windows.Forms.Padding(3);
            this.TabInitialOdontogram.Size = new System.Drawing.Size(1106, 647);
            this.TabInitialOdontogram.TabIndex = 1;
            this.TabInitialOdontogram.Text = "OdontogramaInicial";
            this.TabInitialOdontogram.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Controls.Add(this.BtnModify);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.PnlPatientHealth);
            this.panel1.Controls.Add(this.PnlInsurance);
            this.panel1.Controls.Add(this.PnlZone);
            this.panel1.Controls.Add(this.PnlGender);
            this.panel1.Controls.Add(this.DtpAdmissionDate);
            this.panel1.Controls.Add(this.DtpBirthDate);
            this.panel1.Controls.Add(this.NudAge);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtIdentificationCard);
            this.panel1.Controls.Add(this.TxtPhoneNumber);
            this.panel1.Controls.Add(this.TxtNss);
            this.panel1.Controls.Add(this.TxtSector);
            this.panel1.Controls.Add(this.TxtAddress);
            this.panel1.Controls.Add(this.TxtName);
            this.panel1.Location = new System.Drawing.Point(7, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 590);
            this.panel1.TabIndex = 31;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(978, 66);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 52);
            this.BtnCancel.TabIndex = 38;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(978, 8);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 52);
            this.BtnSave.TabIndex = 35;
            this.BtnSave.Text = "Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // PnlPatientHealth
            // 
            this.PnlPatientHealth.Controls.Add(this.LblPatientHealth);
            this.PnlPatientHealth.Controls.Add(this.TxtDiseaseCause);
            this.PnlPatientHealth.Controls.Add(this.ChkHasAllergicReaction);
            this.PnlPatientHealth.Controls.Add(this.ChkHasDiabeticParents);
            this.PnlPatientHealth.Controls.Add(this.ChkHeartValve);
            this.PnlPatientHealth.Controls.Add(this.ChkHasHepatitis);
            this.PnlPatientHealth.Controls.Add(this.ChkHasAnemia);
            this.PnlPatientHealth.Controls.Add(this.ChkHasAllergy);
            this.PnlPatientHealth.Controls.Add(this.ChkHasBleeding);
            this.PnlPatientHealth.Controls.Add(this.ChkHasHeartMurmur);
            this.PnlPatientHealth.Controls.Add(this.ChkHasRenalDisease);
            this.PnlPatientHealth.Controls.Add(this.ChkHasBeenSickRecently);
            this.PnlPatientHealth.Controls.Add(this.ChkHasTuberculosis);
            this.PnlPatientHealth.Controls.Add(this.ChkIsEpileptic);
            this.PnlPatientHealth.Controls.Add(this.ChkHasBronchialAsthma);
            this.PnlPatientHealth.Controls.Add(this.label5);
            this.PnlPatientHealth.Location = new System.Drawing.Point(14, 423);
            this.PnlPatientHealth.Name = "PnlPatientHealth";
            this.PnlPatientHealth.Size = new System.Drawing.Size(1074, 164);
            this.PnlPatientHealth.TabIndex = 33;
            // 
            // LblPatientHealth
            // 
            this.LblPatientHealth.AutoSize = true;
            this.LblPatientHealth.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPatientHealth.Location = new System.Drawing.Point(13, 5);
            this.LblPatientHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPatientHealth.Name = "LblPatientHealth";
            this.LblPatientHealth.Size = new System.Drawing.Size(265, 29);
            this.LblPatientHealth.TabIndex = 25;
            this.LblPatientHealth.Text = "Cuestionario de salud";
            // 
            // TxtDiseaseCause
            // 
            this.TxtDiseaseCause.Location = new System.Drawing.Point(599, 101);
            this.TxtDiseaseCause.Multiline = true;
            this.TxtDiseaseCause.Name = "TxtDiseaseCause";
            this.TxtDiseaseCause.ReadOnly = true;
            this.TxtDiseaseCause.Size = new System.Drawing.Size(465, 60);
            this.TxtDiseaseCause.TabIndex = 13;
            // 
            // ChkHasAllergicReaction
            // 
            this.ChkHasAllergicReaction.AutoSize = true;
            this.ChkHasAllergicReaction.Location = new System.Drawing.Point(406, 134);
            this.ChkHasAllergicReaction.Name = "ChkHasAllergicReaction";
            this.ChkHasAllergicReaction.Size = new System.Drawing.Size(188, 27);
            this.ChkHasAllergicReaction.TabIndex = 11;
            this.ChkHasAllergicReaction.Text = "Reacción alérgica";
            this.ChkHasAllergicReaction.UseVisualStyleBackColor = true;
            // 
            // ChkHasDiabeticParents
            // 
            this.ChkHasDiabeticParents.AutoSize = true;
            this.ChkHasDiabeticParents.Location = new System.Drawing.Point(212, 134);
            this.ChkHasDiabeticParents.Name = "ChkHasDiabeticParents";
            this.ChkHasDiabeticParents.Size = new System.Drawing.Size(190, 27);
            this.ChkHasDiabeticParents.TabIndex = 7;
            this.ChkHasDiabeticParents.Text = "Padres diabéticos";
            this.ChkHasDiabeticParents.UseVisualStyleBackColor = true;
            // 
            // ChkHeartValve
            // 
            this.ChkHeartValve.AutoSize = true;
            this.ChkHeartValve.Location = new System.Drawing.Point(19, 134);
            this.ChkHeartValve.Name = "ChkHeartValve";
            this.ChkHeartValve.Size = new System.Drawing.Size(177, 27);
            this.ChkHeartValve.TabIndex = 3;
            this.ChkHeartValve.Text = "Válvula cardíaca";
            this.ChkHeartValve.UseVisualStyleBackColor = true;
            // 
            // ChkHasHepatitis
            // 
            this.ChkHasHepatitis.AutoSize = true;
            this.ChkHasHepatitis.Location = new System.Drawing.Point(406, 101);
            this.ChkHasHepatitis.Name = "ChkHasHepatitis";
            this.ChkHasHepatitis.Size = new System.Drawing.Size(108, 27);
            this.ChkHasHepatitis.TabIndex = 10;
            this.ChkHasHepatitis.Text = "Hepatitis";
            this.ChkHasHepatitis.UseVisualStyleBackColor = true;
            // 
            // ChkHasAnemia
            // 
            this.ChkHasAnemia.AutoSize = true;
            this.ChkHasAnemia.Location = new System.Drawing.Point(212, 101);
            this.ChkHasAnemia.Name = "ChkHasAnemia";
            this.ChkHasAnemia.Size = new System.Drawing.Size(97, 27);
            this.ChkHasAnemia.TabIndex = 6;
            this.ChkHasAnemia.Text = "Anemia";
            this.ChkHasAnemia.UseVisualStyleBackColor = true;
            // 
            // ChkHasAllergy
            // 
            this.ChkHasAllergy.AutoSize = true;
            this.ChkHasAllergy.Location = new System.Drawing.Point(19, 101);
            this.ChkHasAllergy.Name = "ChkHasAllergy";
            this.ChkHasAllergy.Size = new System.Drawing.Size(93, 27);
            this.ChkHasAllergy.TabIndex = 2;
            this.ChkHasAllergy.Text = "Alergia";
            this.ChkHasAllergy.UseVisualStyleBackColor = true;
            // 
            // ChkHasBleeding
            // 
            this.ChkHasBleeding.AutoSize = true;
            this.ChkHasBleeding.Location = new System.Drawing.Point(406, 68);
            this.ChkHasBleeding.Name = "ChkHasBleeding";
            this.ChkHasBleeding.Size = new System.Drawing.Size(117, 27);
            this.ChkHasBleeding.TabIndex = 9;
            this.ChkHasBleeding.Text = "Sangrado";
            this.ChkHasBleeding.UseVisualStyleBackColor = true;
            // 
            // ChkHasHeartMurmur
            // 
            this.ChkHasHeartMurmur.AutoSize = true;
            this.ChkHasHeartMurmur.Location = new System.Drawing.Point(212, 68);
            this.ChkHasHeartMurmur.Name = "ChkHasHeartMurmur";
            this.ChkHasHeartMurmur.Size = new System.Drawing.Size(165, 27);
            this.ChkHasHeartMurmur.TabIndex = 5;
            this.ChkHasHeartMurmur.Text = "Soplo cardíaco";
            this.ChkHasHeartMurmur.UseVisualStyleBackColor = true;
            // 
            // ChkHasRenalDisease
            // 
            this.ChkHasRenalDisease.AutoSize = true;
            this.ChkHasRenalDisease.Location = new System.Drawing.Point(19, 68);
            this.ChkHasRenalDisease.Name = "ChkHasRenalDisease";
            this.ChkHasRenalDisease.Size = new System.Drawing.Size(188, 27);
            this.ChkHasRenalDisease.TabIndex = 1;
            this.ChkHasRenalDisease.Text = "Enfermedad renal";
            this.ChkHasRenalDisease.UseVisualStyleBackColor = true;
            // 
            // ChkHasBeenSickRecently
            // 
            this.ChkHasBeenSickRecently.AutoSize = true;
            this.ChkHasBeenSickRecently.Location = new System.Drawing.Point(599, 35);
            this.ChkHasBeenSickRecently.Name = "ChkHasBeenSickRecently";
            this.ChkHasBeenSickRecently.Size = new System.Drawing.Size(353, 27);
            this.ChkHasBeenSickRecently.TabIndex = 12;
            this.ChkHasBeenSickRecently.Text = "¿Ha estado enfermo recientemente?";
            this.ChkHasBeenSickRecently.UseVisualStyleBackColor = true;
            // 
            // ChkHasTuberculosis
            // 
            this.ChkHasTuberculosis.AutoSize = true;
            this.ChkHasTuberculosis.Location = new System.Drawing.Point(406, 35);
            this.ChkHasTuberculosis.Name = "ChkHasTuberculosis";
            this.ChkHasTuberculosis.Size = new System.Drawing.Size(141, 27);
            this.ChkHasTuberculosis.TabIndex = 8;
            this.ChkHasTuberculosis.Text = "Tuberculosis";
            this.ChkHasTuberculosis.UseVisualStyleBackColor = true;
            // 
            // ChkIsEpileptic
            // 
            this.ChkIsEpileptic.AutoSize = true;
            this.ChkIsEpileptic.Location = new System.Drawing.Point(212, 35);
            this.ChkIsEpileptic.Name = "ChkIsEpileptic";
            this.ChkIsEpileptic.Size = new System.Drawing.Size(111, 27);
            this.ChkIsEpileptic.TabIndex = 4;
            this.ChkIsEpileptic.Text = "Epilepcia";
            this.ChkIsEpileptic.UseVisualStyleBackColor = true;
            // 
            // ChkHasBronchialAsthma
            // 
            this.ChkHasBronchialAsthma.AutoSize = true;
            this.ChkHasBronchialAsthma.Location = new System.Drawing.Point(19, 35);
            this.ChkHasBronchialAsthma.Name = "ChkHasBronchialAsthma";
            this.ChkHasBronchialAsthma.Size = new System.Drawing.Size(169, 27);
            this.ChkHasBronchialAsthma.TabIndex = 0;
            this.ChkHasBronchialAsthma.Text = "Asma Branquial";
            this.ChkHasBronchialAsthma.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(595, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Causa";
            // 
            // PnlInsurance
            // 
            this.PnlInsurance.Controls.Add(this.label16);
            this.PnlInsurance.Controls.Add(this.RbtInsuranceYes);
            this.PnlInsurance.Controls.Add(this.RbtInsuranceNo);
            this.PnlInsurance.Location = new System.Drawing.Point(14, 342);
            this.PnlInsurance.Name = "PnlInsurance";
            this.PnlInsurance.Size = new System.Drawing.Size(172, 68);
            this.PnlInsurance.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 6);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 24);
            this.label16.TabIndex = 17;
            this.label16.Text = "¿Asegurado?";
            // 
            // RbtInsuranceYes
            // 
            this.RbtInsuranceYes.AutoSize = true;
            this.RbtInsuranceYes.Checked = true;
            this.RbtInsuranceYes.Location = new System.Drawing.Point(8, 32);
            this.RbtInsuranceYes.Name = "RbtInsuranceYes";
            this.RbtInsuranceYes.Size = new System.Drawing.Size(50, 27);
            this.RbtInsuranceYes.TabIndex = 0;
            this.RbtInsuranceYes.TabStop = true;
            this.RbtInsuranceYes.Text = "Sí";
            this.RbtInsuranceYes.UseVisualStyleBackColor = true;
            // 
            // RbtInsuranceNo
            // 
            this.RbtInsuranceNo.AutoSize = true;
            this.RbtInsuranceNo.Location = new System.Drawing.Point(82, 32);
            this.RbtInsuranceNo.Name = "RbtInsuranceNo";
            this.RbtInsuranceNo.Size = new System.Drawing.Size(55, 27);
            this.RbtInsuranceNo.TabIndex = 1;
            this.RbtInsuranceNo.Text = "No";
            this.RbtInsuranceNo.UseVisualStyleBackColor = true;
            // 
            // PnlZone
            // 
            this.PnlZone.Controls.Add(this.label15);
            this.PnlZone.Controls.Add(this.RbtRural);
            this.PnlZone.Controls.Add(this.RbtUrban);
            this.PnlZone.Location = new System.Drawing.Point(492, 141);
            this.PnlZone.Name = "PnlZone";
            this.PnlZone.Size = new System.Drawing.Size(200, 68);
            this.PnlZone.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 8);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 24);
            this.label15.TabIndex = 17;
            this.label15.Text = "Zona";
            // 
            // RbtRural
            // 
            this.RbtRural.AutoSize = true;
            this.RbtRural.Checked = true;
            this.RbtRural.Location = new System.Drawing.Point(8, 34);
            this.RbtRural.Name = "RbtRural";
            this.RbtRural.Size = new System.Drawing.Size(77, 27);
            this.RbtRural.TabIndex = 0;
            this.RbtRural.TabStop = true;
            this.RbtRural.Text = "Rural";
            this.RbtRural.UseVisualStyleBackColor = true;
            // 
            // RbtUrban
            // 
            this.RbtUrban.AutoSize = true;
            this.RbtUrban.Location = new System.Drawing.Point(100, 34);
            this.RbtUrban.Name = "RbtUrban";
            this.RbtUrban.Size = new System.Drawing.Size(94, 27);
            this.RbtUrban.TabIndex = 1;
            this.RbtUrban.Text = "Urbana";
            this.RbtUrban.UseVisualStyleBackColor = true;
            // 
            // PnlGender
            // 
            this.PnlGender.Controls.Add(this.label12);
            this.PnlGender.Controls.Add(this.RbtMale);
            this.PnlGender.Controls.Add(this.RbtFemale);
            this.PnlGender.Location = new System.Drawing.Point(15, 141);
            this.PnlGender.Name = "PnlGender";
            this.PnlGender.Size = new System.Drawing.Size(272, 68);
            this.PnlGender.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 24);
            this.label12.TabIndex = 17;
            this.label12.Text = "Género";
            // 
            // RbtMale
            // 
            this.RbtMale.AutoSize = true;
            this.RbtMale.Checked = true;
            this.RbtMale.Location = new System.Drawing.Point(8, 34);
            this.RbtMale.Name = "RbtMale";
            this.RbtMale.Size = new System.Drawing.Size(118, 27);
            this.RbtMale.TabIndex = 0;
            this.RbtMale.TabStop = true;
            this.RbtMale.Text = "Masculino";
            this.RbtMale.UseVisualStyleBackColor = true;
            // 
            // RbtFemale
            // 
            this.RbtFemale.AutoSize = true;
            this.RbtFemale.Location = new System.Drawing.Point(140, 34);
            this.RbtFemale.Name = "RbtFemale";
            this.RbtFemale.Size = new System.Drawing.Size(116, 27);
            this.RbtFemale.TabIndex = 1;
            this.RbtFemale.Text = "Femenino";
            this.RbtFemale.UseVisualStyleBackColor = true;
            // 
            // DtpAdmissionDate
            // 
            this.DtpAdmissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAdmissionDate.Location = new System.Drawing.Point(495, 38);
            this.DtpAdmissionDate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DtpAdmissionDate.Name = "DtpAdmissionDate";
            this.DtpAdmissionDate.Size = new System.Drawing.Size(452, 30);
            this.DtpAdmissionDate.TabIndex = 24;
            // 
            // DtpBirthDate
            // 
            this.DtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpBirthDate.Location = new System.Drawing.Point(16, 242);
            this.DtpBirthDate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.DtpBirthDate.Name = "DtpBirthDate";
            this.DtpBirthDate.Size = new System.Drawing.Size(452, 30);
            this.DtpBirthDate.TabIndex = 20;
            // 
            // NudAge
            // 
            this.NudAge.Location = new System.Drawing.Point(16, 308);
            this.NudAge.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.NudAge.Name = "NudAge";
            this.NudAge.Size = new System.Drawing.Size(452, 30);
            this.NudAge.TabIndex = 21;
            this.NudAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(491, 277);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 24);
            this.label11.TabIndex = 40;
            this.label11.Text = "Barrio o paraje";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 281);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 24);
            this.label9.TabIndex = 39;
            this.label9.Text = "Edad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 212);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 24);
            this.label8.TabIndex = 37;
            this.label8.Text = "Fecha de nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(488, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 24);
            this.label7.TabIndex = 36;
            this.label7.Text = "Teléfono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(491, 212);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(556, 348);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 24);
            this.label4.TabIndex = 30;
            this.label4.Text = "NSS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(491, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 24);
            this.label3.TabIndex = 29;
            this.label3.Text = "Fecha de registro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Identificación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nombre";
            // 
            // TxtIdentificationCard
            // 
            this.TxtIdentificationCard.Location = new System.Drawing.Point(19, 106);
            this.TxtIdentificationCard.Margin = new System.Windows.Forms.Padding(4);
            this.TxtIdentificationCard.MaxLength = 11;
            this.TxtIdentificationCard.Name = "TxtIdentificationCard";
            this.TxtIdentificationCard.ShortcutsEnabled = false;
            this.TxtIdentificationCard.Size = new System.Drawing.Size(455, 30);
            this.TxtIdentificationCard.TabIndex = 18;
            // 
            // TxtPhoneNumber
            // 
            this.TxtPhoneNumber.Location = new System.Drawing.Point(495, 106);
            this.TxtPhoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPhoneNumber.MaxLength = 10;
            this.TxtPhoneNumber.Name = "TxtPhoneNumber";
            this.TxtPhoneNumber.ShortcutsEnabled = false;
            this.TxtPhoneNumber.Size = new System.Drawing.Size(455, 30);
            this.TxtPhoneNumber.TabIndex = 22;
            // 
            // TxtNss
            // 
            this.TxtNss.Location = new System.Drawing.Point(495, 374);
            this.TxtNss.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNss.Name = "TxtNss";
            this.TxtNss.Size = new System.Drawing.Size(455, 30);
            this.TxtNss.TabIndex = 32;
            // 
            // TxtSector
            // 
            this.TxtSector.Location = new System.Drawing.Point(495, 307);
            this.TxtSector.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSector.MaxLength = 99;
            this.TxtSector.Name = "TxtSector";
            this.TxtSector.Size = new System.Drawing.Size(455, 30);
            this.TxtSector.TabIndex = 31;
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(495, 239);
            this.TxtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAddress.MaxLength = 199;
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(455, 30);
            this.TxtAddress.TabIndex = 28;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(19, 38);
            this.TxtName.Margin = new System.Windows.Forms.Padding(4);
            this.TxtName.MaxLength = 99;
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(455, 30);
            this.TxtName.TabIndex = 17;
            // 
            // BtnModify
            // 
            this.BtnModify.Location = new System.Drawing.Point(978, 129);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(110, 52);
            this.BtnModify.TabIndex = 35;
            this.BtnModify.Text = "Modificar";
            this.BtnModify.UseVisualStyleBackColor = true;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // FrmVisitManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 683);
            this.Controls.Add(this.BtnInvoice);
            this.Controls.Add(this.BtnActivitiesPerformed);
            this.Controls.Add(this.BtnTreatmentOdontogram);
            this.Controls.Add(this.BtnInitialOdontogram);
            this.Controls.Add(this.BtnGeneralInfo);
            this.Controls.Add(this.TclVisitManagement);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1300, 730);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1300, 730);
            this.Name = "FrmVisitManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de visita del paciente";
            this.Load += new System.EventHandler(this.FrmVisitManagement_Load);
            this.SizeChanged += new System.EventHandler(this.FrmVisitManagement_SizeChanged);
            this.TclVisitManagement.ResumeLayout(false);
            this.TabGeneralInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PnlPatientHealth.ResumeLayout(false);
            this.PnlPatientHealth.PerformLayout();
            this.PnlInsurance.ResumeLayout(false);
            this.PnlInsurance.PerformLayout();
            this.PnlZone.ResumeLayout(false);
            this.PnlZone.PerformLayout();
            this.PnlGender.ResumeLayout(false);
            this.PnlGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudAge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TclVisitManagement;
        private System.Windows.Forms.TabPage TabGeneralInfo;
        private System.Windows.Forms.Button BtnGeneralInfo;
        private System.Windows.Forms.Button BtnInitialOdontogram;
        private System.Windows.Forms.Button BtnTreatmentOdontogram;
        private System.Windows.Forms.Button BtnActivitiesPerformed;
        private System.Windows.Forms.Button BtnInvoice;
        private System.Windows.Forms.TabPage TabTreatmentOdontogram;
        private System.Windows.Forms.TabPage TabActivitiesPermormed;
        private System.Windows.Forms.TabPage TabInvoice;
        private System.Windows.Forms.TabPage TabInitialOdontogram;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Panel PnlPatientHealth;
        private System.Windows.Forms.Label LblPatientHealth;
        private System.Windows.Forms.TextBox TxtDiseaseCause;
        private System.Windows.Forms.CheckBox ChkHasAllergicReaction;
        private System.Windows.Forms.CheckBox ChkHasDiabeticParents;
        private System.Windows.Forms.CheckBox ChkHeartValve;
        private System.Windows.Forms.CheckBox ChkHasHepatitis;
        private System.Windows.Forms.CheckBox ChkHasAnemia;
        private System.Windows.Forms.CheckBox ChkHasAllergy;
        private System.Windows.Forms.CheckBox ChkHasBleeding;
        private System.Windows.Forms.CheckBox ChkHasHeartMurmur;
        private System.Windows.Forms.CheckBox ChkHasRenalDisease;
        private System.Windows.Forms.CheckBox ChkHasBeenSickRecently;
        private System.Windows.Forms.CheckBox ChkHasTuberculosis;
        private System.Windows.Forms.CheckBox ChkIsEpileptic;
        private System.Windows.Forms.CheckBox ChkHasBronchialAsthma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel PnlInsurance;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton RbtInsuranceYes;
        private System.Windows.Forms.RadioButton RbtInsuranceNo;
        private System.Windows.Forms.Panel PnlZone;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton RbtRural;
        private System.Windows.Forms.RadioButton RbtUrban;
        private System.Windows.Forms.Panel PnlGender;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton RbtMale;
        private System.Windows.Forms.RadioButton RbtFemale;
        private System.Windows.Forms.DateTimePicker DtpAdmissionDate;
        private System.Windows.Forms.DateTimePicker DtpBirthDate;
        private System.Windows.Forms.NumericUpDown NudAge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIdentificationCard;
        private System.Windows.Forms.TextBox TxtPhoneNumber;
        private System.Windows.Forms.TextBox TxtNss;
        private System.Windows.Forms.TextBox TxtSector;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Button BtnModify;
    }
}