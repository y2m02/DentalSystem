using System;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.User;
using DentalSystem.Utility;

namespace DentalSystem.User
{
    public partial class FrmUserMaintenance : Form
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public FrmUserMaintenance(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            InitializeComponent();
        }

        public bool IsModify { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUserMaintenance_Load(object sender, EventArgs e)
        {
            if (!IsModify) return;

            TxtName.Text = FullName;
            TxtIdentificationCard.Text = IdentificationCard;
            RbtMale.Checked = Gender.Equals("M");
            RbtFemale.Checked = !Gender.Equals("M");
            TxtPhoneNumber.Text = PhoneNumber;
            TxtAddress.Text = Address;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var requiredFields = string.Empty;
            var isValid = true;

            if (string.IsNullOrEmpty(TxtName.Text.Trim()))
            {
                isValid = false;
                requiredFields = "\nNombre";
            }

            if (!isValid)
            {
                CustomMessage.ExclamationMessage($"Campos requeridos:\n{requiredFields}");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (IsModify)
                {
                    var updateUserRequest = new UpdateUserRequest
                    {
                        UserId = UserId,
                        FullName = TxtName.Text.Trim(),
                        IdentificationCard = TxtIdentificationCard.Text.Trim(),
                        Gender = RbtMale.Checked ? "M" : "F",
                        Address = TxtAddress.Text.Trim(),
                        PhoneNumber = TxtPhoneNumber.Text.Trim(),
                        Mapper = _mapper
                    };

                    _userService.UpdateUser(updateUserRequest);
                }
                else
                {
                    var addUserRequest = new AddUserRequest
                    {
                        FullName = TxtName.Text.Trim(),
                        IdentificationCard = TxtIdentificationCard.Text.Trim(),
                        Gender = RbtMale.Checked ? "M" : "F",
                        Address = TxtAddress.Text.Trim(),
                        PhoneNumber = TxtPhoneNumber.Text.Trim(),
                        Mapper = _mapper
                    };

                    _userService.AddUser(addUserRequest);
                }

                Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
                    
            }
        }

        public void ValidateOnlyNumbers(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char) Keys.Back || e.KeyChar == (char) Keys.Enter) return;

            e.Handled = true;
        }

        private void TxtIdentificationCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateOnlyNumbers(e);
        }
    }
}