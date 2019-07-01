using System;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Requests.Visit;

namespace DentalSystem.VisitManagement
{
    public partial class FrmVisitManagement : Form
    {
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IMapper _iMapper;
        private readonly IPatientService _patientService;
        private readonly IVisitService _visitService;
        private bool _isClosing;

        public FrmVisitManagement(IMapper iMapper, IPatientService patientService,
            IActivityPerformedService activityPerformedService, IVisitService visitService)
        {
            _iMapper = iMapper;
            _patientService = patientService;
            _activityPerformedService = activityPerformedService;
            _visitService = visitService;
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
                LblPatientNameActivitiesPerformed.Text = LblPatientNameInvoice.Text = PatientName;

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
                    Age = (int)NudAge.Value,
                    BirthDate = DtpBirthDate.Value,
                    HasInsurancePlan = RbtInsuranceYes.Checked,
                    NSS = TxtNss.Text.Trim(),
                    Address = TxtAddress.Text.Trim(),
                    IsUrbanZone = RbtUrban.Checked,
                    Gender = RbtMale.Checked ? "M" : "F",
                    UserId = GenericProperties.UserId
                };

                _patientService.UpdatePatient(_iMapper, updatePatientRequest);

                ChangeControlsOnSaveOrCancel();
                SetControlsStatus(false, PnlInformation, PnlGender, PnlZone, PnlInsurance, PnlPatientHealth);

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
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Enter) return;

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

                NameGridHeader(DgvActivitiesList);
                NameGridHeader(DgvActivitiesListHistory);
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

        private static void NameGridHeader(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns["ActivityPerformedId"].Visible = false;
            dgv.Columns["Section"].HeaderText = "Sección de trabajo";
            dgv.Columns["Description"].HeaderText = "Actividad realizada";
            dgv.Columns["Responsable"].HeaderText = "Responsable";
            dgv.Columns["Date"].HeaderText = "Fecha";
        }

        private void FrmVisitManagement_Activated(object sender, EventArgs e)
        {
            ListActivitiesPerformed();
        }

        private void BtnDeleteActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvActivitiesList.CurrentRow == null) return;

                var id = Convert.ToInt32(DgvActivitiesList.CurrentRow.Cells["ActivityPerformedId"].Value);

                var result = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;
                var deleteActivityPerformedRequest = new DeleteActivityPerformedRequest
                {
                    ActivityPerformedId = id,
                    DeletedBy = GenericProperties.UserName
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
                var result = MessageBox.Show("Está a punto de finalizar esta visita", "Información",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (result != DialogResult.OK) return;
                //if (BtnSaveGeneralInfo.Visible)
                //{
                //    result = MessageBox.Show(
                //        "Los datos generales del paciente no han sido guardados. Si continúa, se perderá la información que ingresó.",
                //        "Información",
                //        MessageBoxButtons.OKCancel,
                //        MessageBoxIcon.Information);

                //    if (result != DialogResult.OK)
                //    {
                //        TclVisitManagement.SelectedIndex = 0;
                //        return;
                //    }

                //}

                Cursor.Current = Cursors.WaitCursor;

                var endVisitRequest = new EndVisitRequest
                {
                    VisitId = GenericProperties.VisitId,
                    PatientId = PatientId,
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

                    //if (BtnSaveGeneralInfo.Visible)
                    //{
                    //    result = MessageBox.Show(
                    //        "Los datos generales del paciente no han sido guardados. Si continúa, se perderá la información que ingresó.",
                    //        "Información",
                    //        MessageBoxButtons.OKCancel,
                    //        MessageBoxIcon.Information);

                    //    if (result != DialogResult.OK)
                    //    {
                    //        e.Cancel = true;
                    //        TclVisitManagement.SelectedIndex = 0;
                    //        return;
                    //    }
                    //}
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
    }
}