using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Entities.Results.Payment;

namespace DentalSystem.Contract.Services
{
    public interface IPaymentService
    {
        GetPaymentsByAccountReceivableIdResult GetPaymentsByAccountReceivableId(
            GetPaymentsByAccountReceivableIdRequest request);

        void AddPayment(AddPaymentRequest request);
        DeletePaymentResult DeletePayment(DeletePaymentRequest request);
    }
}