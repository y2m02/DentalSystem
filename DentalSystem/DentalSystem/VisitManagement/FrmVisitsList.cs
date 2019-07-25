﻿using System;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.Visit;

namespace DentalSystem.VisitManagement
{
    public partial class FrmVisitsList : Form
    {
        private readonly IAccountReceivableService _accountReceivableService;
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IMapper _iMapper;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IPatientService _patientService;
        private readonly IPaymentService _paymentService;
        private readonly IVisitService _visitService;
        private readonly IPlateRegistrationService _plateRegistrationService;
        private bool _alreadyLoaded;

        public FrmVisitsList(IVisitService visitService, IMapper iMapper,
            IAccountReceivableService accountReceivableService, IActivityPerformedService activityPerformedService,
            IInvoiceDetailService invoiceDetailService, IPatientService patientService, IPaymentService paymentService,
            IPlateRegistrationService plateRegistrationService)
        {
            _visitService = visitService;
            _iMapper = iMapper;
            _accountReceivableService = accountReceivableService;
            _activityPerformedService = activityPerformedService;
            _invoiceDetailService = invoiceDetailService;
            _patientService = patientService;
            _paymentService = paymentService;
            _plateRegistrationService = plateRegistrationService;
            InitializeComponent();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        private void FrmVisitsList_Load(object sender, EventArgs e)
        {
            LblPatientName.Text = "Paciente: " + PatientName;

            BtnVisitDetails.Location = new Point(BtnBackToVisit.Location.X, BtnBackToVisit.Location.Y);
            ListVisits();
        }

        private void ListVisits()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getVisitsByPatientIdRequest = new GetVisitsByPatientIdRequest
                {
                    PatientId = PatientId,
                    Mapper = _iMapper
                };

                _alreadyLoaded = false;
                var result = _visitService.GetVisitsByPatientId(getVisitsByPatientIdRequest);
                DgvVisitList.DataSource = result.Visits;
                _alreadyLoaded = true;

                NameGridHeader(DgvVisitList);
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

            dgv.Columns["VisitId"].Visible = false;
            dgv.Columns["VisitNumber"].HeaderText = "# visita";
            dgv.Columns["CreatedOn"].HeaderText = "Fecha";
            dgv.Columns["Status"].HeaderText = "Estado";
            dgv.Columns["HasEnded"].Visible = false;
            dgv.Columns["HasBeenBilled"].Visible = false;
        }

        private void FrmVisitsList_Activated(object sender, EventArgs e)
        {
            if (DgvVisitList.RowCount == 0) return;
            DgvVisitList.Rows[0].Selected = true;
        }

        private void BackToVisit()
        {
            try
            {
                var visitId = Convert.ToInt32(DgvVisitList.SelectedRows[0].Cells["VisitId"].Value);
                var patientName = LblPatientName.Text.Split(':')[1].Trim();
                var visitHasBeenBilled =
                    Convert.ToBoolean(DgvVisitList.SelectedRows[0].Cells["HasBeenBilled"].Value);

                GenericProperties.VisitId = visitId;
                GenericProperties.VisitHasBeenBilled = visitHasBeenBilled;

                var frm = new FrmVisitManagement(_iMapper, _patientService, _activityPerformedService, _visitService,
                    _invoiceDetailService, _accountReceivableService, _paymentService, _plateRegistrationService)
                {
                    PatientId = PatientId,
                    PatientName = patientName,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                ListVisits();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnBackToVisit_Click(object sender, EventArgs e)
        {
            BackToVisit();
        }
        private void InitializeButtons()
        {
            if (DgvVisitList.RowCount < 1)
                BtnBackToVisit.Enabled = BtnVisitDetails.Enabled = false;
            else
                BtnBackToVisit.Enabled = BtnVisitDetails.Enabled = true;

            ValidateIfVisitFinished();
        }
        private void BtnVisitDetails_Click(object sender, EventArgs e)
        {
        }

        private void DgvVisitList_SelectionChanged(object sender, EventArgs e)
        {
            if (_alreadyLoaded) ValidateIfVisitFinished();
        }

        private void ValidateIfVisitFinished()
        {
            if (DgvVisitList.RowCount == 0)
            {
                BtnBackToVisit.Visible = true;
                BtnVisitDetails.Visible = false;
                return;
            }

            var visitHasEnded = DgvVisitList.SelectedRows[0].Cells["HasEnded"].Value;

            var visitHasFinished = (bool?) visitHasEnded ?? true;

            BtnBackToVisit.Visible = !visitHasFinished;
            BtnVisitDetails.Visible = visitHasFinished;
        }
    }
}