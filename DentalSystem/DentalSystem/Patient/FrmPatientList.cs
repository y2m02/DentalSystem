using System;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.GenericProperties;
using DentalSystem.MapperConfiguration;
using DentalSystem.VisitManagement;

namespace DentalSystem.Patient
{
    public partial class FrmPatientList : Form
    {
        private readonly IMapper _iMapper;
        private readonly IPatientService _patientService;

        public FrmPatientList(IPatientService patientService)
        {
            var config = new AutoMapperConfiguration().Configure();
            _iMapper = config.CreateMapper();

            _patientService = patientService;
            InitializeComponent();
        }

        private void FrmPatientList_Load(object sender, EventArgs e)
        {
            //ListPatients("", false);
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
            BtnDetails.Left = btnAdd.Left + 180;
            BtnCreateVisit.Left = BtnDetails.Left + 180;
            BtnDelete.Left = BtnCreateVisit.Left + 180;
        }

        private void ListPatients(string filter, bool isFilterByName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var patients = _patientService.GetAllPatients(_iMapper, filter, isFilterByName);
                DgvPatientList.DataSource = patients;

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
        }

        private void FrmPatientList_Activated(object sender, EventArgs e)
        {
            ListPatients("", false);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPatientList.CurrentRow == null) return;

                var id = Convert.ToInt32(DgvPatientList.CurrentRow.Cells["PatientId"].Value);

                var result = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;
                var deletePatientRequest = new DeletePatientRequest
                {
                    PatientId = id,
                    DeletedBy=GenericUserProperties.UserName
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
                BtnCreateVisit.Enabled = BtnDetails.Enabled = BtnDelete.Enabled = false;
            else
                BtnCreateVisit.Enabled = BtnDetails.Enabled = BtnDelete.Enabled = true;
        }

        private void BtnCreateVisit_Click(object sender, EventArgs e)
        {
            var patientId = Convert.ToInt32(DgvPatientList.CurrentRow?.Cells["PatientId"].Value);

            var frm = new FrmVisitManagement(_iMapper,_patientService )
            {
                PatientId= patientId,
                DialogResult =DialogResult.None
            };
            frm.ShowDialog();
        }
    }
}