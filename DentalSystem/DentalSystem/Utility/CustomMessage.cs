using System.Windows.Forms;

namespace DentalSystem.Utility
{
    public static class CustomMessage
    {
        public static void InformationMessage(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ExclamationMessage(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult QuestionMessage(string message)
        {
            var result = MessageBox.Show(message, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }

        public static DialogResult WarningMessage(string message)
        {
            var result = MessageBox.Show(message, "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return result;
        }

        public static void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}