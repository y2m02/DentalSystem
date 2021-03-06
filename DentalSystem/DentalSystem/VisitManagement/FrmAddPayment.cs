using System;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Utility;

namespace DentalSystem.VisitManagement
{
    public partial class FrmAddPayment : Form
    {
        private readonly IMapper _iMapper;

        private readonly IPaymentService _paymentService;

        public int AccountsReceivableId { get; set; }
        public string TotalPending { get; set; }
        public decimal TotalPaid { get; set; }

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
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char) Keys.Back || e.KeyChar == (char) Keys.Enter || e.KeyChar == '.') return;

            CustomMessage.ExclamationMessage("Solo se permiten números");
            e.Handled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAddPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPayment.Text.Trim()) || Convert.ToDecimal(TxtPayment.Text.Trim()) == 0)
            {
                CustomMessage.ExclamationMessage("Debe ingresar un monto");
                DialogResult = DialogResult.None;
                return;
            }

            if (!decimal.TryParse(TxtPayment.Text.Trim(),out _))
            {
                CustomMessage.ExclamationMessage("Debe ingresar un monto válido");
                DialogResult = DialogResult.None;
                return;
            }

            if (Convert.ToDecimal(TxtPayment.Text) > Convert.ToDecimal(TxtTotalPending.Text))
            {
                CustomMessage.ExclamationMessage("El monto ingresado es mayor que el monto pendiente");
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var updateTotalPaidRequest = new UpdateTotalPaidRequest
                {
                    AccountsReceivableId = AccountsReceivableId,
                    TotalPaid = TotalPaid + Convert.ToDecimal(TxtPayment.Text)
                };

                var addPaymentRequest = new AddPaymentRequest
                {
                    Mapper = _iMapper,
                    AccountsReceivableId = AccountsReceivableId,
                    PaymentDate = DateTime.Now,
                    Month = DateTime.Now.Month,
                    AmountPaid = Convert.ToDecimal(TxtPayment.Text),
                    UpdateTotalPaidRequest = updateTotalPaidRequest
                };

                _paymentService.AddPayment(addPaymentRequest);

                Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
                    
                DialogResult = DialogResult.None;
            }
        }
    }
}