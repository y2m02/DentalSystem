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

        public void DeletePayment(Payment payment)
        {
            using (var context = new DentalSystemContext())
            {
                context.Payments.Attach(payment);
                context.Entry(payment).Property(x => x.DeletedOn).IsModified = true;
                context.SaveChanges();
            }
        }

        public List<Payment> GetAllPaymentForReport(DateTime? from, DateTime? to)
        {
            using (var context = new DentalSystemContext())
            {
                var payments = context.Payments.Where(w => from==null
                        ?w.DeletedOn == null
                         : w.DeletedOn == null &&
                           w.PaymentDate.Date>=from.Value.Date&&
                           w.PaymentDate.Date<=to.Value.Date)
                    .OrderBy(w => w.Month).ToList();

                return payments;
            }
        }
    }
}