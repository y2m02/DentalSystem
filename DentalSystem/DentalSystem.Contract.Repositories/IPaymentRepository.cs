using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IPaymentRepository
    {
        List<Payment> GetPaymentsByAccountReceivableId(int accountReceivableId);
        void AddPayment(Payment payment);
        void DeletePayment(int paymentId);
    }
}