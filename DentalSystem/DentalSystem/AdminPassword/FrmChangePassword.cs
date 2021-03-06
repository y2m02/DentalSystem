using System;
using System.Drawing;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Entities.Requests.AdminPassword;
using DentalSystem.Utility;

namespace DentalSystem.AdminPassword
{
    public partial class FrmChangePassword : Form
    {
        private readonly IAdminPasswordService _adminPasswordService;
        private readonly IMapper _mapper;

        public FrmChangePassword(IAdminPasswordService adminPasswordService, IMapper mapper)
        {
            _adminPasswordService = adminPasswordService;
            _mapper = mapper;
            InitializeComponent();
        }

        public bool IsModify { get; set; }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            var requiredFields = string.Empty;
            var isValid = true;

            if (IsModify && string.IsNullOrEmpty(TxtCurrentPassword.Text.Trim()))
            {
                isValid = false;
                requiredFields += "\nContraseña actual";
            }

            if (string.IsNullOrEmpty(TxtNewPassword.Text.Trim()))
            {
                isValid = false;
                requiredFields += "\nNueva contraseña";
            }

            if (string.IsNullOrEmpty(TxtConfirmNewPassword.Text.Trim()))
            {
                isValid = false;
                requiredFields += "\nConfirmar nueva contraseña";
            }

            if (!isValid)
            {
                CustomMessage.ExclamationMessage($"Campos requeridos:\n{requiredFields}");
                return;
            }

            if (IsModify && !TxtCurrentPassword.Text.Trim().Equals(GenericProperties.AdminPassword))
            {
                CustomMessage.ExclamationMessage("La contraseña actual suministrada es incorrecta");
                return;
            }

            if (!TxtNewPassword.Text.Trim().Equals(TxtConfirmNewPassword.Text.Trim()))
            {
                CustomMessage.ExclamationMessage("Los campos \"Nueva contraseña\" y \"Confirmar nueva contraseña\" no coinciden");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string message;
                if (IsModify)
                {
                    var updatePasswordRequest = new UpdatePasswordRequest
                    {
                        PasswordId = GenericProperties.AdminPasswordId,
                        Password = TxtNewPassword.Text.Trim(),
                        Mapper = _mapper
                    };

                    _adminPasswordService.UpdatePassword(updatePasswordRequest);
                    message = "Contraseña actualizada con éxito";
                }
                else
                {
                    var addAdminPasswordRequest = new AddAdminPasswordRequest
                    {
                        Password = TxtNewPassword.Text.Trim(),
                        Mapper = _mapper
                    };

                    var result = _adminPasswordService.AddPassword(addAdminPasswordRequest);
                    GenericProperties.AdminPasswordId = result.AdminPassword.AdminPasswordId;
                    message = "Contraseña creada con éxito";
                }

                CustomMessage.InformationMessage(message);
                GenericProperties.AdminPassword = TxtNewPassword.Text.Trim();
                Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            if (IsModify)
            {
                Text = "Actualizar contraseña";
                BtnSave.Text = "Actualizar";
                return;
            }

            Text = "Crear contraseña";
            BtnSave.Text = "Crear";

            BtnCancel.Visible = false;

            PnlCurrentPassword.Visible = false;

            BtnSave.Location = new Point(
                PnlNewPassword.ClientSize.Width / 2 - BtnSave.Size.Width / 2,
                BtnSave.Location.Y);

            PnlNewPassword.Location = new Point(
                ClientSize.Width / 2 - PnlNewPassword.Size.Width / 2,
                ClientSize.Height / 2 - PnlNewPassword.Size.Height / 2);
        }

        private void FrmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModify || !string.IsNullOrEmpty(GenericProperties.AdminPassword)) return;

            Application.Exit();
        }
    }
}