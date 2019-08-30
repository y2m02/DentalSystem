using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Entities.Results.Payment;

namespace DentalSystem.Contract.Services
{
    public interface IPaymentService
    {
        GetPaymentsByAccountReceivableIdResult GetPaymentsByAccountReceivableId(
            GetPaymentsByAccountReceivableIdRequest request);
        GetAllPaymentForReportResult GetAllPaymentForReport(
            GetAllPaymentForReportRequest request);
        void AddPayment(AddPaymentRequest request);
        void DeletePayment(DeletePaymentRequest request);
    }
}