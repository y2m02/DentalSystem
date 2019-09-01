using System;
using System.Drawing;
using System.Windows.Forms;
using DentalSystem.Entities.GenericProperties;
using DentalSystem.Utility;

namespace DentalSystem.AdminPassword
{
    public partial class FrmConfirmPassword : Form
    {
        public FrmConfirmPassword()
        {
            InitializeComponent();
        }

        public bool IsValidPassword { get; private set; }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            var requiredFields = string.Empty;
            var isValid = true;

            if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                isValid = false;
                requiredFields = "\nContraseña";
            }

            if (!isValid)
            {
                CustomMessage.ExclamationMessage($"Campos requeridos:\n{requiredFields}");
                return;
            }

            var password = TxtPassword.Text.Trim();

            if (!password.Equals(GenericProperties.AdminPassword))
            {
                CustomMessage.ExclamationMessage("Contraseña inválida");
                return;
            }

            IsValidPassword = true;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            IsValidPassword = false;
            Close();
        }

        private void FrmConfirmPassword_Load(object sender, EventArgs e)
        {
            PnlPasswordCenter.Location = new Point(
                PnlPassword.ClientSize.Width / 2 - PnlPasswordCenter.Size.Width / 2,
                PnlPasswordCenter.Location.Y);

            LblPassword.Location = new Point(
                PnlPassword.ClientSize.Width / 2 - LblPassword.Size.Width / 2,
                LblPassword.Location.Y);

            PnlPassword.Location = new Point(
                ClientSize.Width / 2 - PnlPassword.Size.Width / 2,
                PnlPassword.Location.Y);
        }
    }
}