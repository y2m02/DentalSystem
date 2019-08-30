using System;
using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IPaymentRepository
    {
        List<Payment> GetPaymentsByAccountReceivableId(int accountReceivableId);
        void AddPayment(Payment payment);
        void DeletePayment(Payment payment);
        List<Payment> GetAllPaymentForReport(DateTime? from, DateTime? to);
    }
}