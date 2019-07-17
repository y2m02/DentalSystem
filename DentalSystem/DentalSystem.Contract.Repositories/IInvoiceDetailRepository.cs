using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IInvoiceDetailRepository
    {
        List<InvoiceDetail> GetInvoiceDetailByVisitId(int visitId);
        List<InvoiceDetail> GetInvoiceDetailFromOtherVisits(int visitId, int patientId);
        void AddInvoiceDetail(InvoiceDetail invoiceDetail);
        void UpdateInvoiceDetail(InvoiceDetail invoiceDetail);
        void DeleteInvoiceDetail(int invoiceDetailId);
    }
}