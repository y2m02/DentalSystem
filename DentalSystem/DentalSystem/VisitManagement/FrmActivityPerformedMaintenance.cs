using System;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Requests.InvoiceDetail;
using DentalSystem.Entities.Requests.User;
using DentalSystem.Entities.Results.ActivityPerformed;
using DentalSystem.Utility;

namespace DentalSystem.VisitManagement
{
    public partial class FrmActivityPerformedMaintenance : Form
    {
        private readonly IActivityPerformedService _activityPerformedService;
        private readonly IUserService _userService;
        private readonly IMapper _iMapper;

        public FrmActivityPerformedMaintenance(IMapper iMapper, IActivityPerformedService activityPerformedService, IUserService userService)
        {
            _activityPerformedService = activityPerformedService;
            _userService = userService;
            _iMapper = iMapper;
            InitializeComponent();
        }

        public int ActivityPerformedId { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public DateTime Date { get; set; }
        public bool IsCreate { get; set; }
        public GetAllActivitiesPerformedResult ActivityList { get; set; }

        private void FrmActivityPerformedMaintenance_Load(object sender, EventArgs e)
        {
            BtnModifyActivity.Location = new Point(BtnSaveActivity.Location.X, BtnSaveActivity.Location.Y);
            BtnSaveActivity.Visible = IsCreate;
            BtnModifyActivity.Visible = !IsCreate;

            var getUsersToCbxRequest = new GetUsersToCbxRequest
            {
                FullName = Responsable,
                Mapper = _iMapper
            };

            var users = _userService.GetUsersToCbx(getUsersToCbxRequest);
            
            CbxActivityResponsable.DataSource = users.UserList;
            CbxActivityResponsable.DisplayMember = "FullName";
            CbxActivityResponsable.ValueMember = "UserId";

            if (IsCreate)
            {
                CbxSection.SelectedIndex = 0;
                TxtActivityDescription.Clear();
                DtpActivityDate.Value = DateTime.Now.Date;
                //if (CbxActivityResponsable.Items.Count > 0) CbxActivityResponsable.SelectedIndex = 0;
                AcceptButton = BtnSaveActivity;
            }
            else
            {
                CbxSection.SelectedItem = Section.Split(' ')[0];
                TxtActivityDescription.Text = Description;
                DtpActivityDate.Value = Date;
                CbxActivityResponsable.Text = Responsable;
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

            if (CbxActivityResponsable.SelectedIndex < 0)
            {
                isValid = false;
                requiredFields += "\nResponsable";
            }

            if (!isValid)
            {
                CustomMessage.ExclamationMessage($"Campos requeridos:\n{requiredFields}");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var addInvoiceDetailRequests = new AddInvoiceDetailRequest
                {
                    Price = 0
                };

                var addActivityPerformedRequest = new AddActivityPerformedRequest
                {
                    VisitId = GenericProperties.VisitId,
                    Section = CbxSection.SelectedIndex + 1,
                    Date = DtpActivityDate.Value.Date,
                    Description = TxtActivityDescription.Text,
                    UserId = (int) CbxActivityResponsable.SelectedValue,
                    InvoiceDetail = addInvoiceDetailRequests,
                    Mapper = _iMapper
                };

                ActivityList = _activityPerformedService.AddActivityPerformed(addActivityPerformedRequest);

                Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
                    
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

            if (CbxActivityResponsable.SelectedIndex < 0)
            {
                isValid = false;
                requiredFields += "\nResponsable";
            }

            if (!isValid)
            {
                CustomMessage.ExclamationMessage($"Campos requeridos:\n{requiredFields}");
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var updateActivityPerformedRequest = new UpdateActivityPerformedRequest
                {
                    ActivityPerformedId = ActivityPerformedId,
                    VisitId = GenericProperties.VisitId,
                    Section = CbxSection.SelectedIndex + 1,
                    Date = DtpActivityDate.Value.Date,
                    Description = TxtActivityDescription.Text,
                    UserId = (int) CbxActivityResponsable.SelectedValue,
                    Mapper = _iMapper
                };

                ActivityList = _activityPerformedService.UpdateActivityPerformed(updateActivityPerformedRequest);

                Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
                    
            }
        }
    }
}