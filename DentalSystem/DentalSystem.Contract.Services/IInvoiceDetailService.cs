using AutoMapper;
using DentalSystem.Entities.Requests.InvoiceDetail;
using DentalSystem.Entities.Results.InvoiceDetail;

namespace DentalSystem.Contract.Services
{
    public interface IInvoiceDetailService
    {
        GetInvoiceDetailByVisitIdResult GetInvoiceDetailByVisitId(GetInvoiceDetailByVisitIdRequest request);
        GetInvoiceDetailFromOtherVisitsResult GetInvoiceDetailFromOtherVisits(GetInvoiceDetailFromOtherVisitsRequest request);
        void UpdateInvoiceDetail(UpdateInvoiceDetailRequest request);
    }
}