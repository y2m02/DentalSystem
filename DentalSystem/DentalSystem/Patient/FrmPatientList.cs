using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.AccountReceivable;
using DentalSystem.AdminPassword;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.AdminPassword;
using DentalSystem.Entities.Requests.BackUp;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.Patient;
using DentalSystem.MapperConfiguration;
using DentalSystem.User;
using DentalSystem.Utility;
using DentalSystem.VisitManagement;

namespace DentalSystem.Patient
{
    public partial class FrmPatientList : Form
    {
        private readonly IAccountReceivableService _accountReceivableService;
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IBackUpService _backUpService;
        private readonly IMapper _iMapper;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IOdontogramService _odontogramService;
        private readonly IPatientService _patientService;
        private readonly IPaymentService _paymentService;
        private readonly IPlateRegistrationService _plateRegistrationService;
        private readonly ITreatmentOdontogramService _treatmentOdontogramService;
        private readonly IUserService _userService;
        private readonly IAdminPasswordService _adminPasswordService;

        private readonly IVisitService _visitService;
        //private bool _alreadyLoaded;

        public FrmPatientList(IPatientService patientService, IActivityPerformedService activityPerformedService,
            IVisitService visitService, IInvoiceDetailService invoiceDetailService,
            IAccountReceivableService accountReceivableService, IPaymentService paymentService,
            IPlateRegistrationService plateRegistrationService, IOdontogramService odontogramService,
            ITreatmentOdontogramService treatmentOdontogramService, IBackUpService backUpService, IUserService userService, IAdminPasswordService adminPasswordService)
        {
            var config = new AutoMapperConfiguration().Configure();
            _iMapper = config.CreateMapper();

            _patientService = patientService;
            _activityPerformedService = activityPerformedService;
            _visitService = visitService;
            _invoiceDetailService = invoiceDetailService;
            _accountReceivableService = accountReceivableService;
            _paymentService = paymentService;
            _plateRegistrationService = plateRegistrationService;
            _odontogramService = odontogramService;
            _treatmentOdontogramService = treatmentOdontogramService;
            _backUpService = backUpService;
            _userService = userService;
            _adminPasswordService = adminPasswordService;
            InitializeComponent();
        }

        private void FrmPatientList_Load(object sender, EventArgs e)
        {
            var getAdminPasswordRequest = new GetAdminPasswordRequest
            {
                Mapper = _iMapper
            };

            var adminPasswordResult = _adminPasswordService.GetAdminPassword(getAdminPasswordRequest);

            if (adminPasswordResult.AdminPassword == null)
            {
                CustomMessage.InformationMessage("Esta es la primera vez que se accede al sistema, " +
                                                 "por lo que debe crear una contraseña que le servirá para " +
                                                 "poder acceder a algunas opciones de este");

                var frm = new FrmChangePassword(_adminPasswordService, _iMapper)
                {
                    IsModify = false
                };

                frm.ShowDialog();
            }
            else
            {
                GenericProperties.AdminPasswordId = adminPasswordResult.AdminPassword.AdminPasswordId;
                GenericProperties.AdminPassword = adminPasswordResult.AdminPassword.Password;
            }

            PnlLogo.Height += 15;
            DtpFrom.Value = DateTime.Now.AddDays(-15).Date;
            var patients = _patientService.GetAllPatients(_iMapper, "", false, DtpFrom.Value.Date, DtpTo.Value.Date);
            ListPatients(patients);

            if (DgvPatientList.RowCount == 0) return;
            DgvPatientList.Rows[0].Selected = true;
        }

        private void FrmPatientList_SizeChanged(object sender, EventArgs e)
        {
            DgvPatientList.Width = Width - 100;
            DgvPatientList.Height = Height - 320;
            DgvPatientList.Location = new Point(
                ClientSize.Width / 2 - DgvPatientList.Size.Width / 2,
                ClientSize.Height / 3 - DgvPatientList.Size.Height / 3 + 170);
            DgvPatientList.Anchor = AnchorStyles.None;

            LblTitle.Location = new Point(
                ClientSize.Width / 2 - LblTitle.Size.Width / 2,
                LblTitle.Location.Y);

            btnAdd.Left = DgvPatientList.Left;
            BtnCreateVisit.Left = btnAdd.Left + 180;
            BtnVisits.Left = BtnCreateVisit.Left + 180;
            BtnDelete.Left = BtnVisits.Left + 180;
            BtnAccountReceivable.Left = BtnDelete.Left + 180;
            //BtnBackToVisit.Location = new Point(BtnCreateVisit.Location.X, BtnCreateVisit.Location.Y);
            PnlLogo.Left = PnlSearch.Left + 980;
            PnlLogo.Width = Width - 1020;

            PbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ListPatients(IReadOnlyCollection<GetAllPatientsResult> patientList)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //_alreadyLoaded = false;
                //var patients = _patientService.GetAllPatients(_iMapper, filter, isFilterByName);
                DgvPatientList.DataSource = patientList;
                //_alreadyLoaded = true;
                NameGridHeader(DgvPatientList);

                InitializeButtons();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private static void NameGridHeader(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns["PatientId"].Visible = false;
            dgv.Columns["FullName"].HeaderText = "Nombre";
            dgv.Columns["IdentificationCard"].HeaderText = "Cédula";
            dgv.Columns["Age"].HeaderText = "Edad (años)";
            dgv.Columns["Gender"].HeaderText = "Género";
            dgv.Columns["PhoneNumber"].HeaderText = "Teléfono";
            dgv.Columns["HasInsurancePlan"].HeaderText = "¿Asegurado?";
            dgv.Columns["AdmissionDate"].HeaderText = "Fecha de registro";
            dgv.Columns["LastVisitDate"].HeaderText = "Última visita";
            dgv.Columns["VisitHasEnded"].Visible = false;
            dgv.Columns["VisitId"].Visible = false;
            dgv.Columns["VisitHasBeenBilled"].Visible = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (ChkDateRange.Checked && DtpTo.Value.Date < DtpFrom.Value.Date)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ExclamationMessage("La fecha \"Desde\" no puede ser mayor que la fecha \"Hasta\"");
                DtpFrom.Value = DateTime.Now.AddDays(-15);
                DtpTo.Value = DateTime.Now.Date;
                return;
            }

            var patients = ChkDateRange.Checked
                ? _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, DtpFrom.Value.Date,
                    DtpTo.Value.Date)
                : _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, null, null);
            ListPatients(patients);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            DtpFrom.Value = DateTime.Now.AddDays(-15).Date;
            DtpTo.Value = DateTime.Now.Date;
            var patients = ChkDateRange.Checked
                ? _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, DtpFrom.Value.Date,
                    DtpTo.Value.Date)
                : _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, null, null);
            ListPatients(patients);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddPatient(_iMapper, _patientService)
            {
                WithDateFilter = ChkDateRange.Checked,
                From = DtpFrom.Value.Date,
                To = DtpTo.Value.Date,
                DialogResult = DialogResult.None
            };
            frm.ShowDialog();

            var patients = frm.PatientList ?? (ChkDateRange.Checked
                               ? _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked,
                                   DtpFrom.Value.Date,
                                   DtpTo.Value.Date)
                               : _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, null,
                                   null));

            ListPatients(patients);
        }

        private void FrmPatientList_Activated(object sender, EventArgs e)
        {
            //var rowIndex = DgvAccountReceivableList.SelectedRows[0].Index;
            //ListReceivableByPatientId();

            //DgvAccountReceivableList.Rows[rowIndex].Selected = true;
            //if (DgvPatientList.RowCount == 0) return;
            //DgvPatientList.Rows[0].Selected = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var frmConfirmPassword = new FrmConfirmPassword();
                frmConfirmPassword.ShowDialog();
                var isValidPassword = frmConfirmPassword.IsValidPassword;

                if (!isValidPassword) return;

                var id = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["PatientId"].Value);
  
                var result = CustomMessage.QuestionMessage("¿Seguro que desea eliminar este registro?");

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;
                var deletePatientRequest = new DeletePatientRequest
                {
                    PatientId = id,
                    WithDateFilter = ChkDateRange.Checked,
                    From = DtpFrom.Value.Date,
                    To = DtpTo.Value.Date,
                    Mapper = _iMapper
                };

                var patients = _patientService.DeletePatient(deletePatientRequest);

                ListPatients(patients);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private void InitializeButtons()
        {
            if (DgvPatientList.RowCount < 1)
                BtnCreateVisit.Enabled = BtnBackToVisit.Enabled =
                    BtnVisits.Enabled = BtnAccountReceivable.Enabled = BtnDelete.Enabled = false;
            else
                BtnCreateVisit.Enabled = BtnBackToVisit.Enabled =
                    BtnVisits.Enabled = BtnAccountReceivable.Enabled = BtnDelete.Enabled = true;

            //ValidateIfVisitFinished();
        }

        private void ValidateIfVisitFinished()
        {
            if (DgvPatientList.RowCount == 0)
            {
                BtnCreateVisit.Visible = true;
                BtnBackToVisit.Visible = false;
                return;
            }

            var visitHasEnded = DgvPatientList.SelectedRows[0].Cells["VisitHasEnded"].Value;

            var visitHasFinished = (bool?)visitHasEnded ?? true;

            BtnCreateVisit.Visible = visitHasFinished;
            BtnBackToVisit.Visible = !visitHasFinished;
        }

        private void BtnCreateVisit_Click(object sender, EventArgs e)
        {
            try
            {
                var visitHasEnded = DgvPatientList.SelectedRows[0].Cells["VisitHasEnded"].Value;

                var visitHasFinished = (bool?)visitHasEnded ?? true;

                if (!visitHasFinished)
                {
                    var selectedRow = DgvPatientList.SelectedRows[0].Index;
                    CustomMessage.InformationMessage("Actualmente, este paciente tiene una visita activa");
                    DgvPatientList.Rows[selectedRow].Selected = true;
                    BackToVisit();
                    return;
                }

                var patientId = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["PatientId"].Value);
                var patientName = DgvPatientList.SelectedRows[0].Cells["FullName"].Value.ToString();

                Cursor.Current = Cursors.WaitCursor;

                var addVisitRequest = new AddVisitRequest
                {
                    PatientId = patientId,
                    HasEnded = false,
                    CreatedOn = DateTime.Now,
                    HasBeenBilled = false
                };

                var addVisitResult = _visitService.AddVisit(_iMapper, addVisitRequest);

                GenericProperties.VisitId = addVisitResult.VisitId;
                GenericProperties.VisitHasBeenBilled = addVisitResult.HasBeenBilled;

                Cursor.Current = Cursors.Default;

                var frm = new FrmVisitManagement(_iMapper, _patientService, _activityPerformedService, _visitService,
                    _invoiceDetailService, _accountReceivableService, _paymentService, _plateRegistrationService,
                    _odontogramService, _treatmentOdontogramService, _userService)
                {
                    PatientId = patientId,
                    PatientName = patientName,
                    IsDetail = false,
                    //VisitHasOdontograms = false,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                var rowIndex = DgvPatientList.SelectedRows[0].Index;

                var patients = ChkDateRange.Checked
                    ? _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked,
                        DtpFrom.Value.Date,
                        DtpTo.Value.Date)
                    : _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, null, null);

                ListPatients(patients);

                if (DgvPatientList.RowCount == 0) return;
                DgvPatientList.Rows[rowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private void BtnBackToVisit_Click(object sender, EventArgs e)
        {
            BackToVisit();
        }

        private void BackToVisit()
        {
            try
            {
                var patientId = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["PatientId"].Value);
                var visitId = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["VisitId"].Value);
                var patientName = DgvPatientList.SelectedRows[0].Cells["FullName"].Value.ToString();
                var visitHasBeenBilled =
                    Convert.ToBoolean(DgvPatientList.SelectedRows[0].Cells["VisitHasBeenBilled"].Value);

                GenericProperties.VisitId = visitId;
                GenericProperties.VisitHasBeenBilled = visitHasBeenBilled;
                Cursor.Current = Cursors.Default;

                var frm = new FrmVisitManagement(_iMapper, _patientService, _activityPerformedService, _visitService,
                    _invoiceDetailService, _accountReceivableService, _paymentService, _plateRegistrationService,
                    _odontogramService, _treatmentOdontogramService, _userService)
                {
                    PatientId = patientId,
                    PatientName = patientName,
                    IsDetail = false,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                var rowIndex = DgvPatientList.SelectedRows[0].Index;

                var patients = ChkDateRange.Checked
                    ? _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked,
                        DtpFrom.Value.Date,
                        DtpTo.Value.Date)
                    : _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, null, null);

                ListPatients(patients);

                if (DgvPatientList.RowCount == 0) return;
                DgvPatientList.Rows[rowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private void DgvPatientList_SelectionChanged(object sender, EventArgs e)
        {
            //if (_alreadyLoaded) ValidateIfVisitFinished();
        }

        private void BtnAccountReceivable_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var patientId = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["PatientId"].Value);
                var name = DgvPatientList.SelectedRows[0].Cells["FullName"].Value.ToString();

                var getAllAccountsReceivableByPatientIdRequest = new GetAllAccountsReceivableByPatientIdRequest
                {
                    PatientId = patientId,
                    Mapper = _iMapper
                };

                var accountsReceivable =
                    _accountReceivableService.GetAllAccountsReceivableByPatientId(
                        getAllAccountsReceivableByPatientIdRequest);
                Cursor.Current = Cursors.Default;

                if (!accountsReceivable.AccountsReceivable.Any())
                {
                    Cursor.Current = Cursors.Default;
                    CustomMessage.ExclamationMessage("Este paciente aún no tiene ningún registro monetario");
                    return;
                }

                var frm = new FrmAccountReceivableList(_accountReceivableService, _iMapper, _paymentService)
                {
                    PatientId = patientId,
                    AccountReceivableList = accountsReceivable,
                    PatientName = name,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private void BtnVisits_Click(object sender, EventArgs e)
        {
            try
            {
                var patientId = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["PatientId"].Value);
                var patientName = DgvPatientList.SelectedRows[0].Cells["FullName"].Value.ToString();

                var frm = new FrmVisitsList(_visitService, _iMapper, _accountReceivableService,
                    _activityPerformedService,
                    _invoiceDetailService, _patientService, _paymentService, _plateRegistrationService,
                    _odontogramService, _treatmentOdontogramService, _userService)
                {
                    PatientId = patientId,
                    PatientName = patientName,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                var rowIndex = DgvPatientList.SelectedRows[0].Index;

                var patients = ChkDateRange.Checked
                    ? _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked,
                        DtpFrom.Value.Date,
                        DtpTo.Value.Date)
                    : _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, null, null);

                ListPatients(patients);

                if (DgvPatientList.RowCount == 0) return;
                DgvPatientList.Rows[rowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private void ChkDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDateRange.Checked)
            {
                DtpFrom.Value = DateTime.Now.AddDays(-15).Date;
                DtpTo.Value = DateTime.Now.Date;
            }

            DtpFrom.Enabled = DtpTo.Enabled = ChkDateRange.Checked;

            //var patients = ChkDateRange.Checked
            //    ? _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked,
            //        DtpFrom.Value.Date,
            //        DtpTo.Value.Date)
            //    : _patientService.GetAllPatients(_iMapper, TxtSearch.Text.Trim(), RbtName.Checked, null, null);

            //ListPatients(patients);
        }

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               var result = CustomMessage.WarningMessage("Está a punto de realizar una copia de seguridad de los datos");

                if (result != DialogResult.OK) return;

                Cursor.Current = Cursors.WaitCursor;

                var path = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["BackUpDiskName"])
                    ? ""
                    : ConfigurationSettings.AppSettings["BackUpDiskName"];

                var sqlServerName = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["SqlServerName"])
                    ? ""
                    : ConfigurationSettings.AppSettings["SqlServerName"];

                var createBackUpRequest = new CreateBackUpRequest
                {
                    Path = path,
                    SqlServerName = sqlServerName
                };

                _backUpService.CreateBackUp(createBackUpRequest);

                CustomMessage.InformationMessage("BackUp generado exitosamente." +
                                                 $"\nUbicación: {path}\\DentalSystemDBBackUp".Replace(@"\\", @"\"));

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
                    
            }
        }

        private void CuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmConfirmPassword = new FrmConfirmPassword();
            frmConfirmPassword.ShowDialog();
            var isValidPassword = frmConfirmPassword.IsValidPassword;

            if (!isValidPassword) return;

            var frm = new FrmDateRange(true, _iMapper, _accountReceivableService, _paymentService);
            frm.ShowDialog();
        }

        private void IngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmConfirmPassword = new FrmConfirmPassword();
            frmConfirmPassword.ShowDialog();
            var isValidPassword = frmConfirmPassword.IsValidPassword;

            if (!isValidPassword) return;

            var frm = new FrmDateRange(false, _iMapper, _accountReceivableService, _paymentService);
            frm.ShowDialog();
        }

        private void GestionarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmEmployeeList(_userService, _iMapper);
            frm.ShowDialog();
        }

        private void CambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmChangePassword(_adminPasswordService, _iMapper)
            {
                IsModify = true
            };
            frm.ShowDialog();
        }
    }
}