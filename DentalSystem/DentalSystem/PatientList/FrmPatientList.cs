using System;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.MapperConfiguration;

namespace DentalSystem.PatientList
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
            ListPatients("", false);
        }

        private void FrmPatientList_Shown(object sender, EventArgs e)
        {
        }

        private void FrmPatientList_SizeChanged(object sender, EventArgs e)
        {
            btnAdd.Left = Left + 50;

            DgvPatientList.Width = Width - 100;
            DgvPatientList.Height = Height - 300;
            DgvPatientList.Location = new Point(
                ClientSize.Width / 2 - DgvPatientList.Size.Width / 2,
                ClientSize.Height / 3 - DgvPatientList.Size.Height / 3 + 120);
            DgvPatientList.Anchor = AnchorStyles.None;
        }

        private void ListPatients(string filter, bool isFilterByName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var patients = _patientService.GetAllPatients(_iMapper, filter, isFilterByName);
                DgvPatientList.DataSource = patients;

                NameGridHeader(DgvPatientList);
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
            dgv.Columns["Age"].HeaderText = "Edad";
            dgv.Columns["PhoneNumber"].HeaderText = "Teléfono";
            dgv.Columns["Sector"].HeaderText = "Barrio";
            dgv.Columns["HasInsurancePlan"].HeaderText = "¿Asegurado?";
            dgv.Columns["AdmissionDate"].HeaderText = "Fecha de adimisión";
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

        }
    }
}