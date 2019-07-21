using System;
using System.Collections.Generic;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public List<Payment> GetPaymentsByAccountReceivableId(int accountReceivableId)
        {
            using (var context = new DentalSystemContext())
            {
                var payments = context.Payments.Where(w =>
                        w.AccountsReceivableId == accountReceivableId && w.DeletedOn == null)
                    .OrderByDescending(w => w.PaymentId).ToList();

                return payments;
            }
        }

        public void AddPayment(Payment payment)
        {
            using (var context = new DentalSystemContext())
            {
                context.Payments.Add(payment);
                context.SaveChanges();
            }
        }

        public void DeletePayment(int paymentId)
        {
            using (var context = new DentalSystemContext())
            {
                var payment = context.Payments.FirstOrDefault(w =>
                    w.PaymentId == paymentId && w.DeletedOn == null);

                if (payment == null) return;

                payment.DeletedOn = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}