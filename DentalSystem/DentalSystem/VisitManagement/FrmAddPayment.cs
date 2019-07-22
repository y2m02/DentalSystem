using System;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.Payment;

namespace DentalSystem.VisitManagement
{
    public partial class FrmAddPayment : Form
    {
        private readonly IMapper _iMapper;

        private readonly IPaymentService _paymentService;

        public int AccountsReceivableId { get; set; }
        public string TotalPending { get; set; }
        public int TotalPaid { get; set; }

        public FrmAddPayment(IPaymentService paymentService, IMapper iMapper)
        {
            _paymentService = paymentService;
            _iMapper = iMapper;
            InitializeComponent();
        }

        private void FrmAddPayment_Load(object sender, EventArgs e)
        {
            TxtTotalPending.Text = TotalPending;
        }

        private void TxtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char) Keys.Back || e.KeyChar == (char) Keys.Enter) return;

            MessageBox.Show("Solo se permiten números", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            e.Handled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAddPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPayment.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar un monto", "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
                return;
            }

            if (Convert.ToInt32(TxtPayment.Text) > Convert.ToInt32(TxtTotalPending.Text))
            {
                MessageBox.Show("El monto ingresado es mayor que el monto pendiente", "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var updateTotalPaidRequest = new UpdateTotalPaidRequest
                {
                    AccountsReceivableId = AccountsReceivableId,
                    TotalPaid = TotalPaid + Convert.ToInt32(TxtPayment.Text)
                };

                var addPaymentRequest = new AddPaymentRequest
                {
                    Mapper = _iMapper,
                    AccountsReceivableId = AccountsReceivableId,
                    PaymentDate = DateTime.Now,
                    AmountPaid = Convert.ToInt32(TxtPayment.Text),
                    UpdateTotalPaidRequest = updateTotalPaidRequest
                };

                _paymentService.AddPayment(addPaymentRequest);

                Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}