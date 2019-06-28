using System;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.GenericProperties;

namespace DentalSystem.VisitManagement
{
    public partial class FrmActivityPerformedMaintenance : Form
    {
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IMapper _iMapper;

        public FrmActivityPerformedMaintenance(IMapper iMapper, IActivityPerformedService activityPerformedService)
        {
            _activityPerformedService = activityPerformedService;
            _iMapper = iMapper;
            InitializeComponent();
        }

        public int ActivityPerformedId { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public DateTime Date { get; set; }
        public bool IsCreate { get; set; }

        private void FrmActivityPerformedMaintenance_Load(object sender, EventArgs e)
        {
            BtnModifyActivity.Location = new Point(BtnSaveActivity.Location.X, BtnSaveActivity.Location.Y);
            BtnSaveActivity.Visible = IsCreate;
            BtnModifyActivity.Visible = !IsCreate;
            DtpActivityDate.MaxDate = DateTime.Now;

            if (IsCreate)
            {
                CbxSection.SelectedIndex = 0;
                TxtActivityDescription.Clear();
                DtpActivityDate.Value = DateTime.Now;
                TxtActivityResponsable.Clear();
                AcceptButton = BtnSaveActivity;
            }
            else
            {
                CbxSection.SelectedItem = Section;
                TxtActivityDescription.Text = Description;
                DtpActivityDate.Value = Date;
                TxtActivityResponsable.Text = Responsable;
                AcceptButton = BtnModifyActivity;
            }
        }

        private void BtnSaveActivity_Click(object sender, EventArgs e)
        {
            var requiredFields = string.Empty;
            var isValid = true;

            if (string.IsNullOrEmpty(TxtActivityDescription.Text.Trim()))
            {
                isValid = false;
                requiredFields = "\nActividad Realizada";
            }

            if (string.IsNullOrEmpty(TxtActivityResponsable.Text.Trim()))
            {
                isValid = false;
                requiredFields += "\nResponsable";
            }

            if (!isValid)
            {
                MessageBox.Show("Campos requeridos:\n" + requiredFields, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var addActivityPerformedRequest = new AddActivityPerformedRequest
                {
                    VisitId = GenericUserProperties.VisitId,
                    Section = CbxSection.SelectedIndex + 1,
                    Date = DtpActivityDate.Value,
                    Description = TxtActivityDescription.Text,
                    Responsable = TxtActivityResponsable.Text,
                    UserId = GenericUserProperties.UserId
                };

                _activityPerformedService.AddActivityPerformed(_iMapper, addActivityPerformedRequest);

                Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnModifyActivity_Click(object sender, EventArgs e)
        {
            var requiredFields = string.Empty;
            var isValid = true;

            if (string.IsNullOrEmpty(TxtActivityDescription.Text.Trim()))
            {
                isValid = false;
                requiredFields = "\nActividad Realizada";
            }

            if (string.IsNullOrEmpty(TxtActivityResponsable.Text.Trim()))
            {
                isValid = false;
                requiredFields += "\nResponsable";
            }

            if (!isValid)
            {
                MessageBox.Show("Campos requeridos:\n" + requiredFields, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var updateActivityPerformedRequest = new UpdateActivityPerformedRequest
                {
                    ActivityPerformedId = ActivityPerformedId,
                    VisitId = GenericUserProperties.VisitId,
                    Section = CbxSection.SelectedIndex + 1,
                    Date = DtpActivityDate.Value,
                    Description = TxtActivityDescription.Text,
                    Responsable = TxtActivityResponsable.Text,
                    UserId = GenericUserProperties.UserId
                };

                _activityPerformedService.UpdateActivityPerformed(_iMapper, updateActivityPerformedRequest);

                Close();

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