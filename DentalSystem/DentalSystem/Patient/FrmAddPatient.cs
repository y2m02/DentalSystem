using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Results.Patient;

namespace DentalSystem.Patient
{
    public partial class FrmAddPatient : Form
    {
        private readonly IMapper _iMapper;
        private readonly IPatientService _patientService;

        public FrmAddPatient(IMapper iMapper, IPatientService patientService)
        {
            _iMapper = iMapper;
            _patientService = patientService;
            InitializeComponent();
        }

        public List<GetAllPatientsResult> PatientList { get; set; }

        private void FrmAddPatient_Load(object sender, EventArgs e)
        {
            //DtpBirthDate.MaxDate = DtpAdmissionDate.MaxDate = DateTime.Now;

            LblGeneralInfo.Location = new Point(
                ClientSize.Width / 2 - LblGeneralInfo.Size.Width / 2,
                LblGeneralInfo.Location.Y);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var requiredFields = string.Empty;
            var isValid = true;

            if (string.IsNullOrEmpty(TxtName.Text.Trim()))
            {
                isValid = false;
                requiredFields = "\nEl campo Nombre es requerido.\n";
            }

            if (DtpBirthDate.Value.Date > DateTime.Now.Date)
            {
                isValid = false;
                requiredFields += "\nLa fecha de nacimiento no puede ser mayor que la fecha actual.\n";
            }

            if (DtpAdmissionDate.Value.Date > DateTime.Now.Date)
            {
                isValid = false;
                requiredFields += "\nLa fecha de registro no puede ser mayor que la fecha actual.";
            }

            if (!isValid)
            {
                MessageBox.Show("Validaciones:\n" + requiredFields, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var addPatientHealth = new AddPatientHealthRequest
                {
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

                var addPatient = new AddPatientRequest
                {
                    PatientHealth = addPatientHealth,
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
                    Gender = RbtMale.Checked ? "M" : "F",
                    Mapper = _iMapper
                };

                var patients = _patientService.AddPatient(addPatient);
                PatientList = patients;

                Cursor.Current = Cursors.Default;
                Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            var years = Convert.ToInt32(DateTime.Now.Year - DtpBirthDate.Value.Year);
            if (DtpBirthDate.Value > DateTime.Now.AddYears(-years)) years--;

            NudAge.Value = years < 0 ? 0 : years;

            //var years = Convert.ToInt32(DateTime.Now.Year - DtpBirthDate.Value.Year);
            //if (DtpBirthDate.Value > DateTime.Now.AddYears(-years)) years--;

            //NudAge.Value = years;
        }

        private void ChkHasBeenSickRecently_CheckedChanged(object sender, EventArgs e)
        {
            TxtDiseaseCause.ReadOnly = !ChkHasBeenSickRecently.Checked;
        }

        private void TxtIdentificationCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOnlyNumbers(e);
        }

        public void ValidateOnlyNumbers(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char) Keys.Back || e.KeyChar == (char) Keys.Enter) return;

            MessageBox.Show("Solo se permiten números", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            e.Handled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DtpBirthDate_Leave(object sender, EventArgs e)
        {
            //var years = Convert.ToInt32(DateTime.Now.Year - DtpBirthDate.Value.Year);
            //if (DtpBirthDate.Value > DateTime.Now.AddYears(-years)) years--;

            //NudAge.Value = years < 0 ? 0 : years;
        }
    }
}