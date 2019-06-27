using System;
using System.Drawing;
using System.Windows.Forms;

namespace DentalSystem.VisitManagement
{
    public partial class FrmVisitManagement : Form
    {
        public FrmVisitManagement()
        {
            InitializeComponent();
        }

        private void FrmVisitManagement_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void FrmVisitManagement_SizeChanged(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void BtnGeneralInfo_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 0;
            ChangeButtonSelectedStatus(BtnGeneralInfo);
        }

        private void BtnInitialOdontogram_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 1;
            ChangeButtonSelectedStatus(BtnInitialOdontogram);
        }

        private void BtnTreatmentOdontogram_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 2;
            ChangeButtonSelectedStatus(BtnTreatmentOdontogram);
        }

        private void BtnActivitiesPerformed_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 3;
            ChangeButtonSelectedStatus(BtnActivitiesPerformed);
        }

        private void BtnInvoice_Click(object sender, EventArgs e)
        {
            TclVisitManagement.SelectedIndex = 4;
            ChangeButtonSelectedStatus(BtnInvoice);
        }

        private void InitializeControls()
        {
            TclVisitManagement.Width = Width - 158;
        }

        private void ChangeButtonSelectedStatus(Button button)
        {
            button.Font = button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control control in Controls)
            {
                if (!(control is Button)) continue;
                if (control.Name == button.Name) continue;

                control.Font = new Font(control.Font, FontStyle.Regular);
            }
        }

        private void TclVisitManagement_Click(object sender, EventArgs e)
        {
            switch (TclVisitManagement.SelectedIndex)
            {
                case 0:
                    ChangeButtonSelectedStatus(BtnGeneralInfo);
                    break;
                case 1:
                    ChangeButtonSelectedStatus(BtnInitialOdontogram);
                    break;
                case 2:
                    ChangeButtonSelectedStatus(BtnTreatmentOdontogram);
                    break;
                case 3:
                    ChangeButtonSelectedStatus(BtnActivitiesPerformed);
                    break;
                case 4:
                    ChangeButtonSelectedStatus(BtnInvoice);
                    break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnModify_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}