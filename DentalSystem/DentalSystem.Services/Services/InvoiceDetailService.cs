using System.Collections.Generic;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.InvoiceDetail;
using DentalSystem.Entities.Results.InvoiceDetail;

namespace DentalSystem.Services.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public GetInvoiceDetailByVisitIdResult GetInvoiceDetailByVisitId(GetInvoiceDetailByVisitIdRequest request)
        {
            var result = _invoiceDetailRepository.GetInvoiceDetailByVisitId(request.VisitId);
            var itemsToBill = request.Mapper.Map<List<GetInvoiceDetailByVisitIdResultModel>>(result);

            var getItemsToBillByVisitIdResult = new GetInvoiceDetailByVisitIdResult
            {
                ItemsToBill = itemsToBill
            };

            return getItemsToBillByVisitIdResult;
        }

        public GetInvoiceDetailFromOtherVisitsResult GetInvoiceDetailFromOtherVisits(GetInvoiceDetailFromOtherVisitsRequest request)
        {
            var result = _invoiceDetailRepository.GetInvoiceDetailFromOtherVisits(request.VisitId, request.PatientId);
            var invoiceDetailFromOtherVisits = request.Mapper.Map<List<GetInvoiceDetailFromOtherVisitsResultModel>>(result);

            var getInvoiceDetailFromOtherVisitsResult = new GetInvoiceDetailFromOtherVisitsResult
            {
                InvoiceDetailFromOtherVisits = invoiceDetailFromOtherVisits
            };

            return getInvoiceDetailFromOtherVisitsResult;
        }

        public void UpdateInvoiceDetail(UpdateInvoiceDetailRequest request)
        {
            var invoiceDetail = request.Mapper.Map<InvoiceDetail>(request);
            _invoiceDetailRepository.UpdateInvoiceDetail(invoiceDetail);
        }
    }
}