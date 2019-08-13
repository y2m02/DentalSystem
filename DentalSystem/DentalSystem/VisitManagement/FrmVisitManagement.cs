using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Requests.InvoiceDetail;
using DentalSystem.Entities.Requests.Odontogram;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Entities.Requests.PlateRegistration;
using DentalSystem.Entities.Requests.TreatmentOdontogram;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.ActivityPerformed;
using DentalSystem.Entities.Results.InvoiceDetail;
using DentalSystem.Entities.Results.Odontogram;
using DentalSystem.Entities.Results.Patient;
using DentalSystem.Entities.Results.PlateRegistration;
using DentalSystem.Enum;
using DentalSystem.Odontogram;
using Newtonsoft.Json;

namespace DentalSystem.VisitManagement
{
    public partial class FrmVisitManagement : Form
    {
        private readonly IAccountReceivableService _accountReceivableService;
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IMapper _iMapper;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IOdontogramService _odontogramService;
        private readonly IPatientService _patientService;
        private readonly IPaymentService _paymentService;
        private readonly IPlateRegistrationService _plateRegistrationService;
        private readonly ITreatmentOdontogramService _treatmentOdontogramService;
        private readonly IVisitService _visitService;
        private bool _isClosing;

        public FrmVisitManagement(IMapper iMapper, IPatientService patientService,
            IActivityPerformedService activityPerformedService, IVisitService visitService,
            IInvoiceDetailService invoiceDetailService, IAccountReceivableService accountReceivableService,
            IPaymentService paymentService, IPlateRegistrationService plateRegistrationService,
            IOdontogramService odontogramService, ITreatmentOdontogramService treatmentOdontogramService)
        {
            _iMapper = iMapper;
            _patientService = patientService;
            _activityPerformedService = activityPerformedService;
            _visitService = visitService;
            _invoiceDetailService = invoiceDetailService;
            _accountReceivableService = accountReceivableService;
            _paymentService = paymentService;
            _plateRegistrationService = plateRegistrationService;
            _odontogramService = odontogramService;
            _treatmentOdontogramService = treatmentOdontogramService;
            InitializeComponent();
        }

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public bool IsDetail { get; set; }

        //public GetPatientInformationResult PatientInformation { get; set; }
        //public bool VisitHasOdontograms { get; set; }

        private void DisableAllButtons()
        {
            BtnSaveGeneralInfo.Visible = false;
            BtnModifyGeneralInfo.Visible = false;
            BtnCancelGeneralInfo.Visible = false;

            BtnNewOdontogram.Visible = false;
            BtnSaveOdontogram.Visible = false;

            BtnSaveTreatment.Visible = false;
            BtnModifyTreatment.Visible = false;
            BtnCancelTreatment.Visible = false;

            BtnSaveRegistration.Visible = false;
            BtnModifyRegistration.Visible = false;
            BtnCancelRegistration.Visible = false;

            BtnAddPayment.Visible = false;
            BtnDeletePayment.Visible = false;

            BtnEndInvoice.Visible = false;
            BtnEndVisit.Visible = false;

            //SetInitialOdontogramButtonsStatus(false);
            //SetTreatmentOdontogramButtonsStatus(false);
        }

        private void FrmVisitManagement_Load(object sender, EventArgs e)
        {
            var getPatientInformationRequest = new GetPatientInformationRequest
            {
                PatientId = PatientId,
                VisitId = GenericProperties.VisitId,
                Mapper = _iMapper
            };

            var patInfo = _patientService.GetPatientInformation(getPatientInformationRequest);

            InitializeControlPositions();
            SetInitialOdontogramButtonsFunctionality();
            FillInformation(patInfo.PatientInformation);
            //DtpBirthDate.MaxDate = DtpAdmissionDate.MaxDate = DateTime.Now;
            TxtAdmissionDate.Text = DtpAdmissionDate.Value.ToString("dd/MM/yyyy");
            TxtBirthDate.Text = DtpBirthDate.Value.ToString("dd/MM/yyyy");
            TxtAge.Text = NudAge.Text;
            LblPatientNameInitialOdontogram.Text = LblPatientNameTreatmentOdontogram.Text =
                LblPatientNameActivitiesPerformed.Text = LblPatientNameInvoice.Text = $"Paciente: {PatientName}";

            SetControlsStatus(false, PnlInformation, PnlGender, PnlZone, PnlInsurance, PnlPatientHealth,
                PnlPlateRegistration);
            SetOdontogramBtnNames();
            GetInitialOdontogramInformation(patInfo.Odontogram);
            ListActivitiesPerformed(patInfo.VisitActivities.Any() ? patInfo.VisitActivities : new List<GetAllActivitiesPerformedResultModel>());
            FillPlateRegistrationInformation(patInfo.PlateRegistration);
            
            if (!IsDetail) return;

            GetTreatmentOdontogramInformation();

            GetInvoiceLists();
            var invoiceDetailsCurrentVisit = (List<GetInvoiceDetailByVisitIdResultModel>)DgvItemsToBill.DataSource;
            var totalCurrentVisit = invoiceDetailsCurrentVisit.Sum(w => w.Price);
            LblTotalCurrentVisit.Text = $"Monto total de esta visita: RD{totalCurrentVisit:C}";

            DisableAllButtons();
        }

        private void FrmVisitManagement_SizeChanged(object sender, EventArgs e)
        {
            //InitializeControlPositions();
        }

        private void BtnGeneralInfo_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 0;
            ChangeButtonSelectedStatus(BtnGeneralInfo);
        }

        private void BtnInitialOdontogram_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 1;
            ChangeButtonSelectedStatus(BtnInitialOdontogram);
        }

        private void BtnTreatmentOdontogram_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 2;
            ChangeButtonSelectedStatus(BtnTreatmentOdontogram);
            if (IsDetail) return;
            GetTreatmentOdontogramInformation();
        }

        private void BtnActivitiesPerformed_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 3;
            ChangeButtonSelectedStatus(BtnActivitiesPerformed);
        }

        private void BtnInvoice_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 4;
            ChangeButtonSelectedStatus(BtnInvoice);
            if (IsDetail) return;

            GetInvoiceLists();
            var invoiceDetailsCurrentVisit = (List<GetInvoiceDetailByVisitIdResultModel>)DgvItemsToBill.DataSource;
            var totalCurrentVisit = invoiceDetailsCurrentVisit.Sum(w => w.Price);
            LblTotalCurrentVisit.Text = $"Monto total de esta visita: RD{totalCurrentVisit:C}";
            BtnAddPayment.Enabled = DgvAccountReceivableList.RowCount != 0;
            BtnDeletePayment.Enabled = DgvAccountReceivableList.RowCount != 0 && DgvPaymentList.RowCount != 0;
        }

        private void TclVisitManagement_Click(object sender, EventArgs e)
        {
            switch (TclVisitManagement.SelectedIndex)
            {
                case 0:
                    ChangeButtonSelectedStatus(BtnGeneralInfo);
                    break;
                case 1:
                    ChangeButtonSelectedStatus(BtnInitialOdontogram);
                    break;
                case 2:
                    ChangeButtonSelectedStatus(BtnTreatmentOdontogram);
                    if (IsDetail) return;

                    GetTreatmentOdontogramInformation();
                    break;
                case 3:
                    ChangeButtonSelectedStatus(BtnActivitiesPerformed);
                    break;
                case 4:
                    ChangeButtonSelectedStatus(BtnInvoice);
                    if (IsDetail) return;

                    GetInvoiceLists();
                    var invoiceDetailsCurrentVisit =
                        (List<GetInvoiceDetailByVisitIdResultModel>)DgvItemsToBill.DataSource;
                    var totalCurrentVisit = invoiceDetailsCurrentVisit.Sum(w => w.Price);
                    LblTotalCurrentVisit.Text = $"Monto total de esta visita: RD{totalCurrentVisit:C}";
                    BtnAddPayment.Enabled = DgvAccountReceivableList.RowCount != 0;
                    BtnDeletePayment.Enabled = DgvAccountReceivableList.RowCount != 0 && DgvPaymentList.RowCount != 0;
                    break;
            }
        }

        private void ChangeButtonSelectedStatus(Button button)
        {
            button.Font = button.Font = new Font(button.Font, FontStyle.Bold);
            button.BackColor = SystemColors.ActiveCaption;

            foreach (Control control in Controls)
            {
                if (!(control is Button)) continue;
                if (control.Name == button.Name) continue;

                control.Font = new Font(control.Font, FontStyle.Regular);
                control.BackColor = SystemColors.ControlLight;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (GenericProperties.VisitHasBeenBilled)
            {
                MessageBox.Show(
                    "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ChangeControlsOnSaveOrCancel();
                SetControlsStatus(false, PnlInformation, PnlGender, PnlZone, PnlInsurance, PnlPatientHealth);
                return;
            }

            if (string.IsNullOrEmpty(TxtName.Text.Trim()))
            {
                MessageBox.Show("El campo Nombre es requerido", "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var updatePatientHealth = new UpdatePatientHealthRequest
                {
                    PatientHealthId = PatientId,
                    HasHeartMurmur = ChkHasHeartMurmur.Checked,
                    HasBeenSickRecently = ChkHasBeenSickRecently.Checked,
                    HasAllergicReaction = ChkHasAllergicReaction.Checked,
                    HasHepatitis = ChkHasHepatitis.Checked,
                    HasBronchialAsthma = ChkHasBronchialAsthma.Checked,
                    HasTuberculosis = ChkHasTuberculosis.Checked,
                    HeartValve = ChkHeartValve.Checked,
                    HasBleeding = ChkHasBleeding.Checked,
                    HasDiabeticParents = ChkHasDiabeticParents.Checked,
                    HasRenalDisease = ChkHasRenalDisease.Checked,
                    HasAllergy = ChkHasAllergy.Checked,
                    IsEpileptic = ChkIsEpileptic.Checked,
                    DiseaseCause = ChkHasBeenSickRecently.Checked ? TxtDiseaseCause.Text.Trim() : "",
                    HasAnemia = ChkHasAnemia.Checked
                };

                var updatePatientRequest = new UpdatePatientRequest
                {
                    PatientId = PatientId,
                    PatientHealth = updatePatientHealth,
                    IdentificationCard = TxtIdentificationCard.Text.Trim(),
                    FullName = TxtName.Text.Trim(),
                    AdmissionDate = DtpAdmissionDate.Value,
                    PhoneNumber = TxtPhoneNumber.Text.Trim(),
                    Sector = TxtSector.Text.Trim(),
                    Age = (int)NudAge.Value,
                    BirthDate = DtpBirthDate.Value,
                    HasInsurancePlan = RbtInsuranceYes.Checked,
                    NSS = TxtNss.Text.Trim(),
                    Address = TxtAddress.Text.Trim(),
                    IsUrbanZone = RbtUrban.Checked,
                    Gender = RbtMale.Checked ? "M" : "F"
                };

                _patientService.UpdatePatient(_iMapper, updatePatientRequest);

                ChangeControlsOnSaveOrCancel();
                SetControlsStatus(false, PnlInformation, PnlGender, PnlZone, PnlInsurance, PnlPatientHealth);

                LblPatientNameActivitiesPerformed.Text = "Paciente: " + TxtName.Text;
                LblPatientNameInitialOdontogram.Text = "Paciente: " + TxtName.Text;
                LblPatientNameTreatmentOdontogram.Text = "Paciente: " + TxtName.Text;
                LblPatientNameInvoice.Text = "Paciente: " + TxtName.Text;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (GenericProperties.VisitHasBeenBilled)
            {
                MessageBox.Show(
                    "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BtnModifyGeneralInfo.Visible = false;
            BtnSaveGeneralInfo.Visible = true;

            TxtAdmissionDate.Visible = false;
            DtpAdmissionDate.Visible = true;
            TxtBirthDate.Visible = false;
            DtpBirthDate.Visible = true;

            TxtAge.Visible = false;
            NudAge.Visible = true;
            SetControlsStatus(true, PnlInformation, PnlGender, PnlZone, PnlInsurance, PnlPatientHealth);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            ChangeControlsOnSaveOrCancel();
            SetControlsStatus(false, PnlInformation, PnlGender, PnlZone, PnlInsurance, PnlPatientHealth);
        }

        private void ChkHasBeenSickRecently_CheckedChanged(object sender, EventArgs e)
        {
            TxtDiseaseCause.ReadOnly = !ChkHasBeenSickRecently.Checked;
        }

        private void DtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            var years = Convert.ToInt32(DateTime.Now.Year - DtpBirthDate.Value.Year);
            if (DtpBirthDate.Value > DateTime.Now.AddYears(-years)) years--;

            NudAge.Value = years;
        }

        private void TxtIdentificationCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOnlyNumbers(e);
        }

        public void ValidateOnlyNumbers(KeyPressEventArgs e)
        {
            if (TxtIdentificationCard.ReadOnly) return;
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Enter) return;

            MessageBox.Show("Solo se permiten números", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            e.Handled = true;
        }

        public void ValidateOnlyNumbersNoMsg(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Enter) return;
            e.Handled = true;
        }

        private void InitializeControlPositions()
        {
            TclVisitManagement.Width = Width - 158;

            BtnModifyGeneralInfo.Location = new Point(BtnSaveGeneralInfo.Location.X, BtnSaveGeneralInfo.Location.Y);
            BtnModifyTreatment.Location = new Point(BtnSaveTreatment.Location.X, BtnSaveTreatment.Location.Y);
            BtnModifyRegistration.Location = new Point(BtnSaveRegistration.Location.X, BtnSaveRegistration.Location.Y);
            BtnSaveOdontogram.Location = new Point(BtnNewOdontogram.Location.X, BtnNewOdontogram.Location.Y);
            TxtAdmissionDate.Location = new Point(DtpAdmissionDate.Location.X, DtpAdmissionDate.Location.Y);
            TxtBirthDate.Location = new Point(DtpBirthDate.Location.X, DtpBirthDate.Location.Y);
            TxtAge.Location = new Point(NudAge.Location.X, NudAge.Location.Y);


            PnlActivitiesPerformed.Location = new Point(
                TclVisitManagement.Width / 2 - PnlActivitiesPerformed.Size.Width / 2,
                PnlActivitiesPerformed.Location.Y);
        }

        private static void SetControlsStatus(bool isModify, params Panel[] panels)
        {
            foreach (var panel in panels)
            {
                switch (panel.Name)
                {
                    case "PnlInformation":
                        foreach (var control in panel.Controls)
                            switch (control)
                            {
                                case TextBox textBox:
                                    textBox.ReadOnly = !isModify;
                                    break;
                                case DateTimePicker date:
                                    date.Enabled = isModify;
                                    break;
                            }

                        break;

                    case "PnlPatientHealth":
                        var a = false;
                        foreach (var control in panel.Controls)
                            switch (control)
                            {
                                case CheckBox chk:
                                    if (chk.Name.Equals("ChkHasBeenSickRecently")) a = chk.Checked;
                                    chk.AutoCheck = isModify;
                                    break;
                                case TextBox textBox:
                                    textBox.ReadOnly = !(isModify && a);
                                    break;
                            }

                        break;

                    case "PnlPlateRegistration":
                        foreach (var control in panel.Controls)
                            if (control is TextBox textBox)
                                textBox.ReadOnly = !isModify;
                        break;
                }

                if (!panel.Name.Equals("PnlGender") && !panel.Name.Equals("PnlZone") &&
                    !panel.Name.Equals("PnlInsurance")) continue;
                {
                    foreach (var control in panel.Controls)
                    {
                        if (!(control is RadioButton radio)) continue;
                        radio.AutoCheck = isModify;
                    }
                }
            }
        }

        private void FillPlateRegistrationInformation(GetPlateRegistrationByPatientIdResult result)
        {
            TxtPdb.Text = result.PDB;
            TxtN16.Text = result.N16;
            TxtN11.Text = result.N11;
            TxtN26.Text = result.N26;
            TxtN36.Text = result.N36;
            TxtN32.Text = result.N32;
            TxtN46.Text = result.N46;
            TxtCt.Text = result.CT;
            TxtX.Text = result.X;
            TxtRadiographicInterpretation.Text = result.RadiographicInterpretation;
        }

        private void FillInformation(GetPatientByIdResult patientInfoResult)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //var getPatientByIdRequest = new GetPatientByIdRequest
                //{
                //    PatientId = PatientId
                //};
                //Cursor.Current = Cursors.WaitCursor;
                //var patientInfoResult = _patientService.GetPatientById(_iMapper, getPatientByIdRequest);

                TxtName.Text = patientInfoResult.FullName;
                TxtIdentificationCard.Text = patientInfoResult.IdentificationCard;
                RbtMale.Checked = patientInfoResult.Gender == "M";
                RbtFemale.Checked = patientInfoResult.Gender == "F";
                DtpBirthDate.Value = patientInfoResult.BirthDate.GetValueOrDefault();
                NudAge.Text = patientInfoResult.Age.ToString();
                RbtInsuranceYes.Checked = patientInfoResult.HasInsurancePlan.Value;
                RbtInsuranceNo.Checked = !patientInfoResult.HasInsurancePlan.Value;
                DtpAdmissionDate.Value = patientInfoResult.AdmissionDate;
                TxtPhoneNumber.Text = patientInfoResult.PhoneNumber;
                RbtRural.Checked = !patientInfoResult.IsUrbanZone.Value;
                RbtUrban.Checked = patientInfoResult.IsUrbanZone.Value;
                TxtAddress.Text = patientInfoResult.Address;
                TxtSector.Text = patientInfoResult.Sector;
                TxtNss.Text = patientInfoResult.NSS;

                ChkHasBronchialAsthma.Checked = patientInfoResult.HasBronchialAsthma.Value;
                ChkHasRenalDisease.Checked = patientInfoResult.HasRenalDisease.Value;
                ChkHasAllergy.Checked = patientInfoResult.HasAllergy.Value;
                ChkHeartValve.Checked = patientInfoResult.HeartValve.Value;

                ChkIsEpileptic.Checked = patientInfoResult.IsEpileptic.Value;
                ChkHasHeartMurmur.Checked = patientInfoResult.HasHeartMurmur.Value;
                ChkHasAnemia.Checked = patientInfoResult.HasAnemia.Value;
                ChkHasDiabeticParents.Checked = patientInfoResult.HasDiabeticParents.Value;

                ChkHasTuberculosis.Checked = patientInfoResult.HasTuberculosis.Value;
                ChkHasBleeding.Checked = patientInfoResult.HasBleeding.Value;
                ChkHasHepatitis.Checked = patientInfoResult.HasHepatitis.Value;
                ChkHasAllergicReaction.Checked = patientInfoResult.HasAllergicReaction.Value;

                ChkHasBeenSickRecently.Checked = patientInfoResult.HasBeenSickRecently.Value;
                TxtDiseaseCause.Text = patientInfoResult.DiseaseCause;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChangeControlsOnSaveOrCancel()
        {
            BtnSaveGeneralInfo.Visible = false;
            BtnModifyGeneralInfo.Visible = true;

            TxtAdmissionDate.Visible = true;
            DtpAdmissionDate.Visible = false;
            TxtBirthDate.Visible = true;
            DtpBirthDate.Visible = false;
            TxtAdmissionDate.Text = DtpAdmissionDate.Value.ToString("dd/MM/yyyy");
            TxtBirthDate.Text = DtpBirthDate.Value.ToString("dd/MM/yyyy");

            TxtAge.Visible = true;
            NudAge.Visible = false;
            TxtAge.Text = NudAge.Text;
        }

        private void ListActivitiesPerformed(IReadOnlyCollection<GetAllActivitiesPerformedResultModel> activities)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //var getAllActivitiesPerformedRequest = new GetAllActivitiesPerformedRequest
                //{
                //    PatientId = PatientId,
                //    VisitId = GenericProperties.VisitId
                //};

                //var activities =
                //    _activityPerformedService.GetAllActivitiesPerformed(_iMapper, getAllActivitiesPerformedRequest);
                DgvActivitiesList.DataSource = activities;
                DgvActivitiesListHistory.DataSource = new List<GetAllActivitiesPerformedResultModel>();

                NameGridHeader(DgvActivitiesList, DgvActivitiesListHistory);
                InitializeModifyAndDeleteButtons();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void NameGridHeader(DataGridView dgv, DataGridView dgvHistory)
        {
            if (dgv == null) return;

            dgv.Columns["ActivityPerformedId"].Visible = false;
            dgv.Columns["VisitNumber"].Visible = false;
            dgv.Columns["Section"].HeaderText = "Cuadrante";
            dgv.Columns["Description"].HeaderText = "Actividad";
            dgv.Columns["Responsable"].HeaderText = "Responsable";
            dgv.Columns["Date"].HeaderText = "Fecha";
            dgv.Columns["InvoiceDetailId"].Visible = false;

            if (dgvHistory == null) return;

            dgvHistory.Columns["ActivityPerformedId"].Visible = false;
            dgvHistory.Columns["VisitNumber"].HeaderText = "# visita";
            dgvHistory.Columns["Section"].HeaderText = "Cuadrante";
            dgvHistory.Columns["Description"].HeaderText = "Actividad";
            dgvHistory.Columns["Responsable"].HeaderText = "Responsable";
            dgvHistory.Columns["Date"].HeaderText = "Fecha";
            dgvHistory.Columns["InvoiceDetailId"].Visible = false;
        }

        private static void NameOtherVisitActivitiesGridHeader(DataGridView dgvHistory)
        {
            if (dgvHistory == null) return;

            dgvHistory.Columns["ActivityPerformedId"].Visible = false;
            dgvHistory.Columns["VisitNumber"].HeaderText = "# visita";
            dgvHistory.Columns["Section"].HeaderText = "Cuadrante";
            dgvHistory.Columns["Description"].HeaderText = "Actividad";
            dgvHistory.Columns["Responsable"].HeaderText = "Responsable";
            dgvHistory.Columns["Date"].HeaderText = "Fecha";
            dgvHistory.Columns["InvoiceDetailId"].Visible = false;
        }

        private void FrmVisitManagement_Activated(object sender, EventArgs e)
        {
            if (!IsDetail) return;
            btnAddActivity.Visible = false;
            BtnModifyActivity.Visible = false;
            BtnDeleteActivity.Visible = false;
        }

        private void BtnDeleteActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (GenericProperties.VisitHasBeenBilled)
                {
                    MessageBox.Show(
                        "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (DgvActivitiesList.CurrentRow == null) return;

                var id = Convert.ToInt32(DgvActivitiesList.CurrentRow.Cells["ActivityPerformedId"].Value);
                var invoiceDetailId = Convert.ToInt32(DgvActivitiesList.CurrentRow?.Cells["InvoiceDetailId"].Value);

                var result = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;
                var deleteActivityPerformedRequest = new DeleteActivityPerformedRequest
                {
                    ActivityPerformedId = id,
                    InvoiceDetailId = invoiceDetailId,
                    VisitId = GenericProperties.VisitId,
                    Mapper = _iMapper
                };

                var activities = _activityPerformedService.DeleteActivityPerformed(deleteActivityPerformedRequest);

                ListActivitiesPerformed(activities.VisitActivities);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeModifyAndDeleteButtons()
        {
            if (DgvActivitiesList.RowCount < 1)
                BtnModifyActivity.Enabled = BtnDeleteActivity.Enabled = false;
            else
                BtnModifyActivity.Enabled = BtnDeleteActivity.Enabled = true;
        }

        private void BtnAddActivity_Click(object sender, EventArgs e)
        {
            if (GenericProperties.VisitHasBeenBilled)
            {
                MessageBox.Show(
                    "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var frm = new FrmActivityPerformedMaintenance(_iMapper, _activityPerformedService)
            {
                IsCreate = true,
                Text = "Agregar actividad realizada",
                DialogResult = DialogResult.None
            };
            frm.ShowDialog();

            GetAllActivitiesPerformedResult activities;

            if (frm.ActivityList == null)
            {
                var getAllActivitiesPerformedRequest = new GetAllActivitiesPerformedRequest
                {
                    PatientId = PatientId,
                    VisitId = GenericProperties.VisitId,
                    Mapper = _iMapper
                };

                activities = _activityPerformedService.GetAllActivitiesPerformed(getAllActivitiesPerformedRequest);
            }
            else
            {
                activities = frm.ActivityList;
            }

            ListActivitiesPerformed(activities.VisitActivities);
        }

        private void BtnModifyActivity_Click(object sender, EventArgs e)
        {
            if (GenericProperties.VisitHasBeenBilled)
            {
                MessageBox.Show(
                    "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var activityPerformedId = Convert.ToInt32(DgvActivitiesList.CurrentRow?.Cells["ActivityPerformedId"].Value);
            var section = DgvActivitiesList.CurrentRow?.Cells["Section"].Value.ToString();
            var description = DgvActivitiesList.CurrentRow?.Cells["Description"].Value.ToString();
            var responsable = DgvActivitiesList.CurrentRow?.Cells["Responsable"].Value.ToString();
            var date = Convert.ToDateTime(DgvActivitiesList.CurrentRow?.Cells["Date"].Value);

            var frm = new FrmActivityPerformedMaintenance(_iMapper, _activityPerformedService)
            {
                ActivityPerformedId = activityPerformedId,
                Section = section,
                Description = description,
                Responsable = responsable,
                Date = date,
                IsCreate = false,
                Text = "Modificar actividad realizada",
                DialogResult = DialogResult.None
            };
            frm.ShowDialog();

            GetAllActivitiesPerformedResult activities;

            if (frm.ActivityList == null)
            {
                var getAllActivitiesPerformedRequest = new GetAllActivitiesPerformedRequest
                {
                    PatientId = PatientId,
                    VisitId = GenericProperties.VisitId,
                    Mapper = _iMapper
                };

                activities = _activityPerformedService.GetAllActivitiesPerformed(getAllActivitiesPerformedRequest);
            }
            else
            {
                activities = frm.ActivityList;
            }

            ListActivitiesPerformed(activities.VisitActivities);
        }

        private void BtnEndVisit_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    "Está a punto de finalizar esta visita. Una vez ejecute esta acción, solo podrá realizar abonos a través del botón \"Ver deudas\" en el listado de pacientes",
                    "Información",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.OK) return;

                Cursor.Current = Cursors.WaitCursor;

                var endVisitRequest = new EndVisitRequest
                {
                    VisitId = GenericProperties.VisitId,
                    HasEnded = true
                };

                _visitService.EndVisit(_iMapper, endVisitRequest);
                Cursor.Current = Cursors.Default;
                _isClosing = true;
                Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FrmVisitManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!_isClosing && !IsDetail)
                {
                    var result = MessageBox.Show("¿Desea salir sin finalizar la visita?", "Información",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                e.Cancel = false;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GetInvoiceLists()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getInvoiceDetailByVisitIdRequest = new GetInvoiceDetailByVisitIdRequest
                {
                    VisitId = GenericProperties.VisitId,
                    PatientId = PatientId,
                    Mapper = _iMapper
                };

                var invoiceLists =
                    _invoiceDetailService.GetInvoiceDetailByVisitId(getInvoiceDetailByVisitIdRequest);
                DgvItemsToBill.DataSource = invoiceLists.ItemsToBill;

                DgvItemsToBillOtherVisits.DataSource = new List<GetInvoiceDetailFromOtherVisitsResultModel>();
                DgvAccountReceivableList.DataSource = invoiceLists.AccountsReceivable;

                NameItemsToBillGridHeader(DgvItemsToBill, DgvItemsToBillOtherVisits);
                NameAccountReceivableGridHeader(DgvAccountReceivableList);

                if (DgvAccountReceivableList.RowCount == 0) return;
                DgvAccountReceivableList.Rows[0].Selected = true;

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                ListPaymentsByAccountReceivableId(accountReceivableId);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void NameItemsToBillGridHeader(DataGridView dgv, DataGridView dgvOtherVisits)
        {
            if (dgv == null) return;
            dgv.ReadOnly = GenericProperties.VisitHasBeenBilled;
            dgv.Columns["InvoiceDetailId"].Visible = false;
            dgv.Columns["Section"].HeaderText = "Cuadrante";
            dgv.Columns["ActivityPerformed"].HeaderText = "Actividad";
            dgv.Columns["Price"].HeaderText = "Monto";

            dgv.Columns["Price"].ValueType = typeof(int);

            dgv.Columns["ActivityPerformed"].ReadOnly = true;
            dgv.Columns["Section"].ReadOnly = true;

            if (dgvOtherVisits == null) return;
            dgvOtherVisits.Columns["InvoiceDetailId"].Visible = false;
            dgvOtherVisits.Columns["VisitNumber"].HeaderText = "# visita";
            dgvOtherVisits.Columns["Section"].HeaderText = "Cuadrante";
            dgvOtherVisits.Columns["ActivityPerformed"].HeaderText = "Actividad";
            dgvOtherVisits.Columns["Price"].HeaderText = "Monto";
        }

        private static void NameOtherVisitItemsToBillGridHeader(DataGridView dgvOtherVisits)
        {
            if (dgvOtherVisits == null) return;
            dgvOtherVisits.Columns["InvoiceDetailId"].Visible = false;
            dgvOtherVisits.Columns["VisitNumber"].HeaderText = "# visita";
            dgvOtherVisits.Columns["Section"].HeaderText = "Cuadrante";
            dgvOtherVisits.Columns["ActivityPerformed"].HeaderText = "Actividad";
            dgvOtherVisits.Columns["Price"].HeaderText = "Monto";
        }

        private void DgvItemsToBill_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 3) return;
            if (int.TryParse(Convert.ToString(e.FormattedValue), out _) &&
                Convert.ToInt32(e.FormattedValue) >= 0) return;

            e.Cancel = true;
            MessageBox.Show("Ingrese solo números enteros positivos", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private void DgvItemsToBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateInvoiceDetail(e);
        }

        private void UpdateInvoiceDetail(DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var invoiceDetailId = Convert.ToInt32(DgvItemsToBill.Rows[e.RowIndex].Cells[0].Value);
                var price = Convert.ToInt32(DgvItemsToBill.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                var updateActivityPerformedRequest = new UpdateInvoiceDetailRequest
                {
                    InvoiceDetailId = invoiceDetailId,
                    Price = price,
                    Mapper = _iMapper
                };

                _invoiceDetailService.UpdateInvoiceDetail(updateActivityPerformedRequest);

                var invoiceDetailsCurrentVisit = (List<GetInvoiceDetailByVisitIdResultModel>)DgvItemsToBill.DataSource;
                var totalCurrentVisit = invoiceDetailsCurrentVisit.Sum(w => w.Price);
                LblTotalCurrentVisit.Text = $"Monto total de esta visita: RD{totalCurrentVisit:C}";

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ListReceivableByPatientId()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getAccountsReceivableByPatientIdRequest = new GetAccountsReceivableByPatientIdRequest
                {
                    PatientId = PatientId,
                    Mapper = _iMapper
                };

                var accountsReceivable =
                    _accountReceivableService.GetAccountsReceivableByPatientId(getAccountsReceivableByPatientIdRequest);

                DgvAccountReceivableList.DataSource = accountsReceivable.AccountsReceivable;

                NameAccountReceivableGridHeader(DgvAccountReceivableList);

                //InitializeModifyAndDeleteButtons();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void NameAccountReceivableGridHeader(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns["AccountsReceivableId"].Visible = false;
            dgv.Columns["VisitNumber"].HeaderText = "# visita";
            dgv.Columns["CreatedDate"].HeaderText = "Fecha";
            dgv.Columns["Total"].HeaderText = "Total";
            dgv.Columns["TotalPaid"].HeaderText = "Pagado";
            dgv.Columns["TotalPending"].HeaderText = "Pendiente";
        }

        private void BtnEndInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvItemsToBill.RowCount == 0)
                {
                    MessageBox.Show(
                        "No hay actividades que facturar. Agregue las actividades en la ventana de Actividades Realizadas",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (GenericProperties.VisitHasBeenBilled)
                {
                    MessageBox.Show(
                        "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                var result = MessageBox.Show(
                    "Está a punto de finalizar el proceso de asignación de precios. Una vez que ejecute esta acción, solo podrá realizar abonos",
                    "Información",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.OK) return;

                var total = Convert.ToInt32(LblTotalCurrentVisit.Text.Split('$')[1].Replace(",", "").Replace(".00", ""));

                var setVisitAsBilled = new SetVisitAsBilledRequest
                {
                    VisitId = GenericProperties.VisitId,
                    HasBeenBilled = true
                };

                var accountsReceivableRequest = new AddAccountsReceivableRequest
                {
                    AccountsReceivableId = GenericProperties.VisitId,
                    CreatedDate = DateTime.Now,
                    Total = total,
                    TotalPaid = 0,
                    PatientId = PatientId,
                    Mapper = _iMapper,
                    SetVisitAsBilledRequest = setVisitAsBilled
                };

                _accountReceivableService.AddAccountReceivable(accountsReceivableRequest);

                ListReceivableByPatientId();

                if (DgvAccountReceivableList.RowCount == 0) return;
                DgvAccountReceivableList.Rows[0].Selected = true;

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                ListPaymentsByAccountReceivableId(accountReceivableId);

                DgvItemsToBill.ReadOnly = true;
                GenericProperties.VisitHasBeenBilled = true;

                BtnAddPayment.Enabled = true;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnDeletePayment_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(DgvPaymentList.SelectedRows[0].Cells["PaymentId"].Value);

                var result = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                var totalPaid = Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["TotalPaid"].Value);
                var paymentTotalPaid = Convert.ToInt32(DgvPaymentList.SelectedRows[0].Cells["AmountPaid"].Value);

                var updateTotalPaidRequest = new UpdateTotalPaidRequest
                {
                    AccountsReceivableId = accountReceivableId,
                    TotalPaid = totalPaid - paymentTotalPaid
                };

                var deletePatientRequest = new DeletePaymentRequest
                {
                    DeletedOn = DateTime.Now,
                    Mapper = _iMapper,
                    PaymentId = id,
                    UpdateTotalPaidRequest = updateTotalPaidRequest
                };

                _paymentService.DeletePayment(deletePatientRequest);

                var rowIndex = DgvAccountReceivableList.SelectedRows[0].Index;
                ListReceivableByPatientId();

                DgvAccountReceivableList.Rows[rowIndex].Selected = true;

                ListPaymentsByAccountReceivableId(accountReceivableId);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                var totalPending = DgvAccountReceivableList.SelectedRows[0].Cells["TotalPending"].Value.ToString();

                if (Convert.ToInt32(totalPending) == 0)
                {
                    MessageBox.Show("Esta cuenta no tiene saldo pendiente", "Información", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);

                var totalPaid = Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["TotalPaid"].Value);

                Cursor.Current = Cursors.Default;

                var frm = new FrmAddPayment(_paymentService, _iMapper)
                {
                    AccountsReceivableId = accountReceivableId,
                    TotalPaid = totalPaid,
                    TotalPending = totalPending,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                var rowIndex = DgvAccountReceivableList.SelectedRows[0].Index;

                ListReceivableByPatientId();

                if (DgvAccountReceivableList.RowCount == 0)
                {
                    DgvPaymentList.DataSource = null;
                    BtnAddPayment.Enabled = false;
                    BtnDeletePayment.Enabled = false;
                    return;
                }

                if (rowIndex == DgvAccountReceivableList.RowCount) rowIndex -= 1;
                DgvAccountReceivableList.Rows[rowIndex].Selected = true;
                var accountId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                ListPaymentsByAccountReceivableId(accountId);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ListPaymentsByAccountReceivableId(int accountReceivableId)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getPaymentsByAccountReceivableIdRequest = new GetPaymentsByAccountReceivableIdRequest
                {
                    Mapper = _iMapper,
                    AccountsReceivableId = accountReceivableId
                };

                var payments =
                    _paymentService.GetPaymentsByAccountReceivableId(getPaymentsByAccountReceivableIdRequest);
                DgvPaymentList.DataSource = payments.PaymentList;

                NamePaymentGridHeader(DgvPaymentList);

                BtnDeletePayment.Enabled = false;
                if (DgvPaymentList.RowCount == 0) return;
                BtnDeletePayment.Enabled = true;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void NamePaymentGridHeader(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns["PaymentId"].Visible = false;
            dgv.Columns["AmountPaid"].HeaderText = "Abono";
            dgv.Columns["PaymentDate"].HeaderText = "Fecha";
        }

        private void DgvAccountReceivableList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var accountReceivableId =
                Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
            ListPaymentsByAccountReceivableId(accountReceivableId);
        }

        private void BtnDeletePayment_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(DgvPaymentList.SelectedRows[0].Cells["PaymentId"].Value);

                var result = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                var totalPaid = Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["TotalPaid"].Value);
                var paymentTotalPaid = Convert.ToInt32(DgvPaymentList.SelectedRows[0].Cells["AmountPaid"].Value);

                var updateTotalPaidRequest = new UpdateTotalPaidRequest
                {
                    AccountsReceivableId = accountReceivableId,
                    TotalPaid = totalPaid - paymentTotalPaid
                };

                var deletePatientRequest = new DeletePaymentRequest
                {
                    DeletedOn = DateTime.Now,
                    Mapper = _iMapper,
                    PaymentId = id,
                    UpdateTotalPaidRequest = updateTotalPaidRequest
                };

                _paymentService.DeletePayment(deletePatientRequest);

                var rowIndex = DgvAccountReceivableList.SelectedRows[0].Index;
                ListReceivableByPatientId();

                if (DgvAccountReceivableList.RowCount == 0)
                {
                    DgvPaymentList.DataSource = null;
                    return;
                }

                DgvAccountReceivableList.Rows[rowIndex].Selected = true;

                ListPaymentsByAccountReceivableId(accountReceivableId);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnModifyRegistration_Click(object sender, EventArgs e)
        {
            if (GenericProperties.VisitHasBeenBilled)
            {
                MessageBox.Show(
                    "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BtnSaveRegistration.Visible = true;
            BtnModifyRegistration.Visible = false;

            SetControlsStatus(true, PnlPlateRegistration);
        }

        private void BtnSaveRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                if (GenericProperties.VisitHasBeenBilled)
                {
                    MessageBox.Show(
                        "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    BtnModifyRegistration.Visible = true;
                    BtnSaveRegistration.Visible = false;

                    SetControlsStatus(false, PnlPlateRegistration);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                var updatePlateRegistrationRequest = new UpdatePlateRegistrationRequest
                {
                    PlateRegistrationId = PatientId,
                    RadiographicInterpretation = TxtRadiographicInterpretation.Text.Trim(),
                    N36 = TxtN36.Text.Trim(),
                    N11 = TxtN11.Text.Trim(),
                    N16 = TxtN16.Text.Trim(),
                    CT = TxtCt.Text.Trim(),
                    N32 = TxtN32.Text.Trim(),
                    PDB = TxtPdb.Text.Trim(),
                    X = TxtX.Text.Trim(),
                    N46 = TxtN46.Text.Trim(),
                    N26 = TxtN26.Text.Trim(),
                    Mapper = _iMapper
                };

                _plateRegistrationService.UpdatePlateRegistration(updatePlateRegistrationRequest);

                BtnModifyRegistration.Visible = true;
                BtnSaveRegistration.Visible = false;

                SetControlsStatus(false, PnlPlateRegistration);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnCancelRegistration_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            BtnModifyRegistration.Visible = true;
            BtnSaveRegistration.Visible = false;

            SetControlsStatus(false, PnlPlateRegistration);
        }

        private void SetInitialOdontogramButtonsFunctionality()
        {
            foreach (var control in PnlTeeth.Controls)
                if (control is Button button)
                    button.Click += OdontogramButtons_Click;
            //button.Click += delegate
            //{
            //    button.BackColor = button.BackColor == Color.Red ? SystemColors.Control : Color.Red;
            //};
        }

        private void SetInitialOdontogramButtonsStatus(bool isActive)
        {
            foreach (var control in PnlTeeth.Controls)
                if (control is Button button)
                {
                    button.Enabled = isActive;
                    button.BackColor = isActive ? Color.White : button.BackColor;
                }
        }

        private void SetTreatmentOdontogramButtonsStatus(bool isActive)
        {
            foreach (var control in PnlTreatmentOdontogramTeeth.Controls)
                if (control is Button button)
                    button.Enabled = isActive;
        }

        private void BtnSaveOdontogram_Click(object sender, EventArgs e)
        {
            try
            {
                if (GenericProperties.VisitHasBeenBilled)
                {
                    MessageBox.Show(
                        "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var result = MessageBox.Show("Una vez que guarde este odontograma, no podrá volver a modificarlo. " +
                                             "Solo podrá modificar el odontograma de tratamientos. " +
                                             "Para realizar algún cambio deberá crear uno nuevo", "Información",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (result != DialogResult.OK) return;

                Cursor.Current = Cursors.WaitCursor;

                var initialOdontogramButtonList = new List<OdontogramButtonsModel>();
                var treatmentOdontogramButtonList = new List<TreatmentOdontogramButtonsModel>();
                var buttonCount = 1;
                var cavitiesQuantity = 0;

                foreach (var control in PnlTeeth.Controls)
                {
                    if (!(control is Button button)) continue;

                    initialOdontogramButtonList.Add(new OdontogramButtonsModel
                    {
                        Id = Convert.ToInt32(button.Name.Split('_')[2]),
                        ButtonNumber = buttonCount,
                        ButtonName = button.Name,
                        HasCavities = button.BackColor == Color.Red,
                        TeethStatus = button.BackColor == Color.Red ? (int)TeethStatus.HasCavities : 0
                    });

                    treatmentOdontogramButtonList.Add(new TreatmentOdontogramButtonsModel
                    {
                        Id = Convert.ToInt32(button.Name.Split('_')[2]),
                        ButtonNumber = buttonCount,
                        ButtonName = button.Name.Replace('I', 'T'),
                        HasCavities = button.BackColor == Color.Red,
                        TeethStatus = button.BackColor == Color.Red ? (int)TeethStatus.HasCavities : 0
                    });

                    if (button.BackColor == Color.Red) cavitiesQuantity++;

                    buttonCount++;
                }

                var jsonInitialOdontogramButtonList = JsonConvert.SerializeObject(initialOdontogramButtonList);
                var jsonTreatmentOdontogramButtonList = JsonConvert.SerializeObject(treatmentOdontogramButtonList);

                var updateTreatmentOdontogramRequest = new UpdateTreatmentOdontogramRequest
                {
                    TreatmentOdontogramId = Convert.ToInt32(LblOdontogramId.Text),
                    Information = jsonTreatmentOdontogramButtonList,
                    CavitiesQuantity = cavitiesQuantity
                };

                var updateOdontogramRequest = new UpdateOdontogramRequest
                {
                    OdontogramId = Convert.ToInt32(LblOdontogramId.Text),
                    Information = jsonInitialOdontogramButtonList,
                    CavitiesQuantity = cavitiesQuantity,
                    TreatmentOdontogram = updateTreatmentOdontogramRequest,
                    Mapper = _iMapper
                };

                _odontogramService.UpdateOdontogram(updateOdontogramRequest);

                BtnNewOdontogram.Visible = true;
                BtnSaveOdontogram.Visible = false;
               
                SetInitialOdontogramButtonsStatus(false);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OdontogramButtons_Click(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;

            var totalCavities = Convert.ToInt32(LblTotalCavities.Text.Split(':')[1].Trim());
            if (button.BackColor == Color.Red)
            {
                button.BackColor = Color.White;
                totalCavities--;
            }
            else
            {
                button.BackColor = Color.Red;
                totalCavities++;
            }

            LblTotalCavities.Text = $"Total de caries: {totalCavities}";

            //button.BackColor = button.BackColor == Color.Red ? Color.White : Color.Red;
        }

        private void OdontogramButtonsDisabled_Click(object sender, EventArgs e)
        {
            if (sender is Button button) button.BackColor = button.BackColor;
        }

        private void GetInitialOdontogramInformation(GetOdontogramByVisitIdResultModel odontogramResult)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //var getOdontogramByVisitIdRequest = new GetOdontogramByVisitIdRequest
                //{
                //    VisitId = GenericProperties.VisitId,
                //    Mapper = _iMapper
                //};

                //Cursor.Current = Cursors.WaitCursor;
                //var odontogramResult = _odontogramService.GetOdontogramByVisitId(getOdontogramByVisitIdRequest);

                LblOdontogramId.Text = odontogramResult.OdontogramId.ToString();
                if (odontogramResult.HasInformation)
                {
                    BtnNewOdontogram.Visible = true;
                    BtnSaveOdontogram.Visible = false;
                   
                    LblTotalCavities.Text = $"Total de caries: {odontogramResult.CavitiesQuantity}";
                    var buttonList =
                        JsonConvert.DeserializeObject<List<OdontogramButtonsModel>>(odontogramResult
                            .Information);
                    SetInitialOdontogramButtonColors(buttonList);

                    SetInitialOdontogramButtonsStatus(false);
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GetTreatmentOdontogramInformation()
        {
            try
            {
                var getTreatmentOdontogramByOdontogramIdRequest = new GetTreatmentOdontogramByOdontogramIdRequest
                {
                    OdontogramId = Convert.ToInt32(LblOdontogramId.Text),
                    Mapper = _iMapper
                };

                Cursor.Current = Cursors.WaitCursor;
                var treatmentOdontogramResult =
                    _treatmentOdontogramService.GetTreatmentOdontogramByOdontogramId(
                        getTreatmentOdontogramByOdontogramIdRequest);

                LblTreatmentOdontogramId.Text =
                    treatmentOdontogramResult.TreatmentOdontogram.TreatmentOdontogramId.ToString();

                if (treatmentOdontogramResult.TreatmentOdontogram.HasInformation)
                {
                    var buttonList =
                        JsonConvert.DeserializeObject<List<TreatmentOdontogramButtonsModel>>(treatmentOdontogramResult
                            .TreatmentOdontogram.Information);
                    SetTreatmentOdontogramButtonColors(buttonList);
                }
                else
                {
                    SetTreatmentOdontogramButtonColors(isEmpty: true);
                }

                SetTreatmentOdontogramButtonsStatus(false);

                BtnModifyTreatment.Visible = true;
                BtnSaveTreatment.Visible = false;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetInitialOdontogramButtonColors(IReadOnlyCollection<OdontogramButtonsModel> buttonList = null,
            bool isEmpty = false)
        {
            foreach (var control in PnlTeeth.Controls)
            {
                if (!(control is Button button)) continue;

                if (!isEmpty)
                {
                    var btn = buttonList.FirstOrDefault(w => w.ButtonName == button.Name);
                    button.BackColor = btn != null && btn.HasCavities ? Color.Red : Color.White;
                }
                else
                {
                    button.BackColor = Color.White;
                }
            }
        }

        private void SetTreatmentOdontogramButtonColors(
            IReadOnlyCollection<TreatmentOdontogramButtonsModel> buttonList = null, bool isEmpty = false)
        {
            foreach (var control in PnlTreatmentOdontogramTeeth.Controls)
            {
                if (!(control is Button button)) continue;
                if (!isEmpty)
                {
                    var id = Convert.ToInt32(button.Name.Split('_')[2]);
                    var btn = buttonList.FirstOrDefault(w => w.Id == id);

                    if (btn == null) continue;

                    switch (btn.TeethStatus)
                    {
                        case 1:
                            button.BackgroundImage = null;
                            button.BackColor = Color.Red;
                            break;

                        case 2:
                            button.BackgroundImage = null;
                            button.BackColor = Color.Blue;
                            break;

                        case 3:
                            button.BackColor = Color.White;
                            var directory = Directory.GetCurrentDirectory();
                            button.BackgroundImage = Image.FromFile($@"{directory}\Images\3 lines.png");
                            button.BackgroundImageLayout = ImageLayout.Stretch;
                            break;

                        case 0:
                            button.BackgroundImage = null;
                            button.BackColor = Color.White;
                            break;
                    }
                }
                else
                {
                    button.BackgroundImage = null;
                    button.BackColor = Color.White;
                }
            }
        }

        private void BtnNewOdontogram_Click(object sender, EventArgs e)
        {
            try
            {
                if (GenericProperties.VisitHasBeenBilled)
                {
                    MessageBox.Show(
                        "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var result = MessageBox.Show("Si crea un nuevo odontograma se perderán los datos del anterior",
                    "Información",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (result != DialogResult.OK) return;

                Cursor.Current = Cursors.WaitCursor;

                var addTreatmentOdontogramRequest = new AddTreatmentOdontogramRequest
                {
                    Information = string.Empty,
                    CavitiesQuantity = 0
                };

                var addOdontogramRequest = new AddOdontogramRequest
                {
                    VisitId = GenericProperties.VisitId,
                    Information = string.Empty,
                    CavitiesQuantity = 0,
                    TreatmentOdontogram = addTreatmentOdontogramRequest,
                    Mapper = _iMapper
                };

                var odontogramResult = _odontogramService.AddOdontogram(addOdontogramRequest);

                LblOdontogramId.Text = odontogramResult.OdontogramId.ToString();
                LblTotalCavities.Text = "Total de caries: 0";
                LblTreatmentOdontogramId.Text = odontogramResult.OdontogramId.ToString();
                BtnSaveOdontogram.Visible = true;
                BtnNewOdontogram.Visible = false;
                SetInitialOdontogramButtonsStatus(true);
                SetInitialOdontogramButtonColors(isEmpty: true);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetOdontogramBtnNames()
        {
            var initialOdontogramControls = PnlTeeth.Controls;
            var treatmentOdontogramControls = PnlTreatmentOdontogramTeeth.Controls;

            var counter = 1;
            for (var i = 0; i < initialOdontogramControls.Count; i++)
            {
                if (!(initialOdontogramControls[i] is Button buttonI)) continue;
                var buttonT = treatmentOdontogramControls[i];
                var buttonIName = buttonI.Name.Split('_')[0];
                var buttonITeethNumber = Convert.ToInt32(buttonI.Name.Split('_')[1]);
                buttonI.Name = $"{buttonIName}I_{buttonITeethNumber}_{counter}";
                buttonT.Name = $"{buttonIName}T_{buttonITeethNumber}_{counter}";
                counter++;
            }
        }

        private void BtnCancelTreatment_Click(object sender, EventArgs e)
        {
            GetTreatmentOdontogramInformation();
        }

        private void BtnModifyTreatment_Click(object sender, EventArgs e)
        {
            if (GenericProperties.VisitHasBeenBilled)
            {
                MessageBox.Show(
                    "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BtnSaveTreatment.Visible = true;
            BtnModifyTreatment.Visible = false;

            SetTreatmentOdontogramButtonsStatus(true);
        }

        private void BtnSaveTreatment_Click(object sender, EventArgs e)
        {
            try
            {
                if (GenericProperties.VisitHasBeenBilled)
                {
                    MessageBox.Show(
                        "Usted ya finalizó el proceso de asignación de precios. Ahora solo puede realizar abonos",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                var buttonList = new List<TreatmentOdontogramButtonsModel>();
                var buttonCount = 1;
                var cavitiesQuantity = 0;

                foreach (var control in PnlTreatmentOdontogramTeeth.Controls)
                {
                    if (!(control is Button button)) continue;

                    buttonList.Add(new TreatmentOdontogramButtonsModel
                    {
                        Id = Convert.ToInt32(button.Name.Split('_')[2]),
                        ButtonNumber = buttonCount,
                        ButtonName = button.Name,
                        HasCavities = button.BackColor == Color.Red,
                        TeethStatus = button.BackColor == Color.Red
                            ? (int)TeethStatus.HasCavities
                            :
                            button.BackColor == Color.Blue
                                ? (int)TeethStatus.WasCured
                                :
                                button.BackColor == Color.White && button.BackgroundImage != null
                                    ?
                                    (int)TeethStatus.WasExtracted
                                    :
                                    0
                    });

                    if (button.BackColor == Color.Red) cavitiesQuantity++;

                    buttonCount++;
                }

                var jsonButtonList = JsonConvert.SerializeObject(buttonList);

                var updateTreatmentOdontogramRequest = new UpdateTreatmentOdontogramRequest
                {
                    TreatmentOdontogramId = Convert.ToInt32(LblOdontogramId.Text),
                    Information = jsonButtonList,
                    CavitiesQuantity = cavitiesQuantity,
                    Mapper = _iMapper
                };

                _treatmentOdontogramService.UpdateTreatmentOdontogram(updateTreatmentOdontogramRequest);

                BtnModifyTreatment.Visible = true;
                BtnSaveTreatment.Visible = false;

                SetTreatmentOdontogramButtonsStatus(false);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CuradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var button = ((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl;
            button.BackgroundImage = null;
            button.BackColor = Color.Blue;

            RemoveImageFromButtons(button);
        }

        private void ExtraídoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var button = ((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl;
            button.BackColor = Color.White;
            var directory = Directory.GetCurrentDirectory();
            button.BackgroundImage = Image.FromFile($@"{directory}\Images\3 lines.png");
            button.BackgroundImageLayout = ImageLayout.Stretch;

            foreach (var control in PnlTreatmentOdontogramTeeth.Controls)
            {
                if (!(control is Button btn)) continue;
                var btnName = btn.Name.Split('_')[0] + "_" + btn.Name.Split('_')[1];
                var btnFamilyNumber = button.Name.Split('_')[1];
                string[] btnNames =
                {
                    $"BtnToothCenterT_{btnFamilyNumber}",
                    $"BtnToothTopT_{btnFamilyNumber}",
                    $"BtnToothBottomT_{btnFamilyNumber}",
                    $"BtnToothRightT_{btnFamilyNumber}",
                    $"BtnToothLeftT_{btnFamilyNumber}"
                };

                if (!btnNames.Contains(btnName)) continue;

                btn.BackColor = Color.White;
                btn.BackgroundImage = Image.FromFile($@"{directory}\Images\3 lines.png");
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void CariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var button = ((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl;
            button.BackgroundImage = null;
            button.BackColor = Color.Red;

            RemoveImageFromButtons(button);
        }

        private void NingunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var button = ((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl;
            button.BackgroundImage = null;
            button.BackColor = Color.White;

            RemoveImageFromButtons(button);
        }

        private void RemoveImageFromButtons(Control button)
        {
            foreach (var control in PnlTreatmentOdontogramTeeth.Controls)
            {
                if (!(control is Button btn)) continue;
                var btnName = btn.Name.Split('_')[0] + "_" + btn.Name.Split('_')[1];
                var btnFamilyNumber = button.Name.Split('_')[1];
                string[] btnNames =
                {
                    $"BtnToothCenterT_{btnFamilyNumber}",
                    $"BtnToothTopT_{btnFamilyNumber}",
                    $"BtnToothBottomT_{btnFamilyNumber}",
                    $"BtnToothRightT_{btnFamilyNumber}",
                    $"BtnToothLeftT_{btnFamilyNumber}"
                };

                if (!btnNames.Contains(btnName)) continue;
                if (btn.BackgroundImage == null) continue;

                btn.BackColor = Color.White;
                btn.BackgroundImage = null;
            }
        }

        private void BtnListOtherVisitActivities_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getAllActivitiesPerformedRequest = new GetAllActivitiesPerformedRequest
                {
                    PatientId = PatientId,
                    VisitId = GenericProperties.VisitId,
                    Mapper = _iMapper
                };

                var activities =
                    _activityPerformedService.GetOtherVisitActivitiesPerformed(getAllActivitiesPerformedRequest);
                DgvActivitiesListHistory.DataSource = activities.PatientActivities;

                NameOtherVisitActivitiesGridHeader(DgvActivitiesListHistory);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnOtherVisitItemsToBill_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getInvoiceDetailFromOtherVisitsRequest = new GetInvoiceDetailFromOtherVisitsRequest
                {
                    PatientId = PatientId,
                    VisitId = GenericProperties.VisitId,
                    Mapper = _iMapper
                };

                var activities =
                    _invoiceDetailService.GetInvoiceDetailFromOtherVisits(getInvoiceDetailFromOtherVisitsRequest);
                DgvItemsToBillOtherVisits.DataSource = activities.InvoiceDetailFromOtherVisits;

                NameOtherVisitItemsToBillGridHeader(DgvItemsToBillOtherVisits);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}