﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Requests.InvoiceDetail;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.InvoiceDetail;

namespace DentalSystem.VisitManagement
{
    public partial class FrmVisitManagement : Form
    {
        private readonly IAccountReceivableService _accountReceivableService;
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IMapper _iMapper;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IPatientService _patientService;
        private readonly IPaymentService _paymentService;
        private readonly IVisitService _visitService;
        private bool _isClosing;

        public FrmVisitManagement(IMapper iMapper, IPatientService patientService,
            IActivityPerformedService activityPerformedService, IVisitService visitService,
            IInvoiceDetailService invoiceDetailService, IAccountReceivableService accountReceivableService,
            IPaymentService paymentService)
        {
            _iMapper = iMapper;
            _patientService = patientService;
            _activityPerformedService = activityPerformedService;
            _visitService = visitService;
            _invoiceDetailService = invoiceDetailService;
            _accountReceivableService = accountReceivableService;
            _paymentService = paymentService;
            InitializeComponent();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        private void FrmVisitManagement_Load(object sender, EventArgs e)
        {
            InitializeControlPositions();
            FillInformation();
            DtpBirthDate.MaxDate = DtpAdmissionDate.MaxDate = DateTime.Now;
            TxtAdmissionDate.Text = DtpAdmissionDate.Value.ToString("dd/MM/yyyy");
            TxtBirthDate.Text = DtpBirthDate.Value.ToString("dd/MM/yyyy");
            TxtAge.Text = NudAge.Text;
            LblPatientNameInitialOdontogram.Text = LblPatientNameTreatmentOdontogram.Text =
                LblPatientNameActivitiesPerformed.Text = LblPatientNameInvoice.Text = "Paciente: " + PatientName;

            SetControlsStatus(false, PnlInformation, PnlGender, PnlZone, PnlInsurance, PnlPatientHealth);
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
            GetInvoiceLists();
            var invoiceDetailsCurrentVisit = (List<GetInvoiceDetailByVisitIdResultModel>) DgvItemsToBill.DataSource;
            var totalCurrentVisit = invoiceDetailsCurrentVisit.Sum(w => w.Price);
            LblTotalCurrentVisit.Text = "Monto total de esta visita: RD$" + totalCurrentVisit;
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
                    break;
                case 3:
                    ChangeButtonSelectedStatus(BtnActivitiesPerformed);
                    break;
                case 4:
                    ChangeButtonSelectedStatus(BtnInvoice);
                    GetInvoiceLists();
                    var invoiceDetailsCurrentVisit =
                        (List<GetInvoiceDetailByVisitIdResultModel>) DgvItemsToBill.DataSource;
                    var totalCurrentVisit = invoiceDetailsCurrentVisit.Sum(w => w.Price);
                    LblTotalCurrentVisit.Text = "Monto total de esta visita: RD$" + totalCurrentVisit;
                    BtnAddPayment.Enabled = DgvAccountReceivableList.RowCount != 0;
                    BtnDeletePayment.Enabled = DgvAccountReceivableList.RowCount != 0 && DgvPaymentList.RowCount != 0;
                    break;
            }
        }

        private void ChangeButtonSelectedStatus(Button button)
        {
            button.Font = button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control control in Controls)
            {
                if (!(control is Button)) continue;
                if (control.Name == button.Name) continue;

                control.Font = new Font(control.Font, FontStyle.Regular);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
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
                    Age = (int) NudAge.Value,
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
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char) Keys.Back || e.KeyChar == (char) Keys.Enter) return;

            MessageBox.Show("Solo se permiten números", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            e.Handled = true;
        }

        private void InitializeControlPositions()
        {
            TclVisitManagement.Width = Width - 158;

            BtnModifyGeneralInfo.Location = new Point(BtnSaveGeneralInfo.Location.X, BtnSaveGeneralInfo.Location.Y);
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

        private void FillInformation()
        {
            try
            {
                var getPatientByIdRequest = new GetPatientByIdRequest
                {
                    PatientId = PatientId
                };
                Cursor.Current = Cursors.WaitCursor;
                var patientInfoResult = _patientService.GetPatientById(_iMapper, getPatientByIdRequest);

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

        private void ListActivitiesPerformed()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getAllActivitiesPerformedRequest = new GetAllActivitiesPerformedRequest
                {
                    PatientId = PatientId,
                    VisitId = GenericProperties.VisitId
                };

                var activities =
                    _activityPerformedService.GetAllActivitiesPerformed(_iMapper, getAllActivitiesPerformedRequest);
                DgvActivitiesList.DataSource = activities.VisitActivities;
                DgvActivitiesListHistory.DataSource = activities.PatientActivities;

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
            dgv.Columns["Section"].HeaderText = "Sección de trabajo";
            dgv.Columns["Description"].HeaderText = "Actividad realizada";
            dgv.Columns["Responsable"].HeaderText = "Responsable";
            dgv.Columns["Date"].HeaderText = "Fecha";
            dgv.Columns["InvoiceDetailId"].Visible = false;

            if (dgvHistory == null) return;

            dgvHistory.Columns["ActivityPerformedId"].Visible = false;
            dgvHistory.Columns["VisitNumber"].HeaderText = "# visita";
            dgvHistory.Columns["Section"].HeaderText = "Sección de trabajo";
            dgvHistory.Columns["Description"].HeaderText = "Actividad realizada";
            dgvHistory.Columns["Responsable"].HeaderText = "Responsable";
            dgvHistory.Columns["Date"].HeaderText = "Fecha";
            dgvHistory.Columns["InvoiceDetailId"].Visible = false;
        }

        private void FrmVisitManagement_Activated(object sender, EventArgs e)
        {
            ListActivitiesPerformed();
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
                    InvoiceDetailId = invoiceDetailId
                };

                _activityPerformedService.DeleteActivityPerformed(deleteActivityPerformedRequest);
                ListActivitiesPerformed();
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
        }

        private void BtnEndVisit_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    "Está a punto de finalizar esta visita. Una vez ejecute esta acción, solo podrá realizar abonos a través del módulo \"Cuentas por cobrar\"",
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
                if (!_isClosing)
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

                DgvItemsToBillOtherVisits.DataSource = invoiceLists.InvoiceDetailFromOtherVisits;
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
            dgv.Columns["ActivityPerformed"].HeaderText = "Actividad";
            dgv.Columns["Section"].HeaderText = "Sección";
            dgv.Columns["Price"].HeaderText = "Monto";

            dgv.Columns["Price"].ValueType = typeof(int);

            dgv.Columns["ActivityPerformed"].ReadOnly = true;
            dgv.Columns["Section"].ReadOnly = true;

            if (dgvOtherVisits == null) return;
            dgvOtherVisits.Columns["InvoiceDetailId"].Visible = false;
            dgvOtherVisits.Columns["VisitNumber"].HeaderText = "# visita";
            dgvOtherVisits.Columns["ActivityPerformed"].HeaderText = "Actividad";
            dgvOtherVisits.Columns["Section"].HeaderText = "Sección";
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

                var invoiceDetailsCurrentVisit = (List<GetInvoiceDetailByVisitIdResultModel>) DgvItemsToBill.DataSource;
                var totalCurrentVisit = invoiceDetailsCurrentVisit.Sum(w => w.Price);
                LblTotalCurrentVisit.Text = "Monto total de esta visita: RD$" + totalCurrentVisit;

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

                var total = Convert.ToInt32(LblTotalCurrentVisit.Text.Split('$')[1]);

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
    }
}