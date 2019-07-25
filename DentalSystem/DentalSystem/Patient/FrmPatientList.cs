﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.AccountReceivable;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.MapperConfiguration;
using DentalSystem.VisitManagement;

namespace DentalSystem.Patient
{
    public partial class FrmPatientList : Form
    {
        private readonly IAccountReceivableService _accountReceivableService;
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IMapper _iMapper;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IPatientService _patientService;
        private readonly IPaymentService _paymentService;
        private readonly IPlateRegistrationService _plateRegistrationService;

        private readonly IVisitService _visitService;
        //private bool _alreadyLoaded;

        public FrmPatientList(IPatientService patientService, IActivityPerformedService activityPerformedService,
            IVisitService visitService, IInvoiceDetailService invoiceDetailService,
            IAccountReceivableService accountReceivableService, IPaymentService paymentService,
            IPlateRegistrationService plateRegistrationService)
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
            InitializeComponent();
        }

        private void FrmPatientList_Load(object sender, EventArgs e)
        {
            ListPatients("", false);
        }

        private void FrmPatientList_SizeChanged(object sender, EventArgs e)
        {
            DgvPatientList.Width = Width - 100;
            DgvPatientList.Height = Height - 300;
            DgvPatientList.Location = new Point(
                ClientSize.Width / 2 - DgvPatientList.Size.Width / 2,
                ClientSize.Height / 3 - DgvPatientList.Size.Height / 3 + 120);
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
        }

        private void ListPatients(string filter, bool isFilterByName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //_alreadyLoaded = false;
                var patients = _patientService.GetAllPatients(_iMapper, filter, isFilterByName);
                DgvPatientList.DataSource = patients;
                //_alreadyLoaded = true;
                NameGridHeader(DgvPatientList);

                InitializeButtons();
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
            ListPatients(TxtSearch.Text.Trim(), RbtName.Checked);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            ListPatients("", false);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddPatient(_iMapper, _patientService)
            {
                DialogResult = DialogResult.None
            };
            frm.ShowDialog();

            ListPatients("", false);
        }

        private void FrmPatientList_Activated(object sender, EventArgs e)
        {
            if (DgvPatientList.RowCount == 0) return;
            DgvPatientList.Rows[0].Selected = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["PatientId"].Value);

                var result = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;
                var deletePatientRequest = new DeletePatientRequest
                {
                    PatientId = id
                };

                _patientService.DeletePatient(deletePatientRequest);

                ListPatients("", false);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeButtons()
        {
            if (DgvPatientList.RowCount < 1)
                BtnCreateVisit.Enabled = BtnBackToVisit.Enabled = BtnVisits.Enabled = BtnDelete.Enabled = false;
            else
                BtnCreateVisit.Enabled = BtnBackToVisit.Enabled = BtnVisits.Enabled = BtnDelete.Enabled = true;

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
                    MessageBox.Show("Actualmente, este paciente tiene una visita activa", "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

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
                    _invoiceDetailService, _accountReceivableService, _paymentService, _plateRegistrationService)
                {
                    PatientId = patientId,
                    PatientName = patientName,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                ListPatients("", false);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                    _invoiceDetailService, _accountReceivableService, _paymentService, _plateRegistrationService)
                {
                    PatientId = patientId,
                    PatientName = patientName,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                ListPatients("", false);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                    MessageBox.Show("Este paciente aún no tiene ningún registro monetario", "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnVisits_Click(object sender, EventArgs e)
        {
            try
            {
                var patientId = Convert.ToInt32(DgvPatientList.SelectedRows[0].Cells["PatientId"].Value);
                var patientName = DgvPatientList.SelectedRows[0].Cells["FullName"].Value.ToString();

                var frm = new FrmVisitsList(_visitService, _iMapper, _accountReceivableService, _activityPerformedService,
                    _invoiceDetailService, _patientService, _paymentService, _plateRegistrationService)
                {
                    PatientId = patientId,
                    PatientName = patientName,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                ListPatients("", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}