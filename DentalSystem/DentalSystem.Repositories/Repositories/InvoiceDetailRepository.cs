using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        public List<InvoiceDetail> GetInvoiceDetailByVisitId(int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var invoiceDetails = context.InvoiceDetails.Include(w => w.ActivityPerformed)
                    .Where(w => w.ActivityPerformed.VisitId == visitId && w.DeletedOn == null)
                    .OrderByDescending(w => w.InvoiceDetailId).ToList();

                return invoiceDetails;
            }
        }

        public void AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            using (var context = new DentalSystemContext())
            {
                context.InvoiceDetails.Add(invoiceDetail);
                context.SaveChanges();
            }
        }

        public void UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            using (var context = new DentalSystemContext())
            {
                var invoiceDetailToModify = context.InvoiceDetails.FirstOrDefault(w =>
                    w.InvoiceDetailId == invoiceDetail.InvoiceDetailId && w.DeletedOn == null);

                if (invoiceDetailToModify == null) return;

                context.Entry(invoiceDetailToModify).CurrentValues.SetValues(invoiceDetail);
                context.SaveChanges();
            }
        }

        public void DeleteInvoiceDetail(int invoiceDetailId)
        {
            using (var context = new DentalSystemContext())
            {
                var invoiceDetail = context.InvoiceDetails.FirstOrDefault(w =>
                    w.InvoiceDetailId == invoiceDetailId && w.DeletedOn == null);

                if (invoiceDetail == null) return;

                invoiceDetail.DeletedOn = DateTime.Now;
                context.SaveChanges();
            }
        }

        public List<InvoiceDetail> GetInvoiceDetailFromOtherVisits(int visitId, int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var invoiceDetails = context.InvoiceDetails.Include(w => w.ActivityPerformed).Include(w => w.ActivityPerformed.Visit).Where(w =>
                          w.ActivityPerformed.Visit.PatientId == patientId && w.ActivityPerformed.VisitId != visitId &&
                          w.DeletedOn == null)
                    .OrderByDescending(w => w.InvoiceDetailId).ToList();

                return invoiceDetails;
            }
        }
    }
}