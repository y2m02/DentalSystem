using System.Collections.Generic;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.InvoiceDetail;
using DentalSystem.Entities.Results.AccountsReceivable;
using DentalSystem.Entities.Results.InvoiceDetail;

namespace DentalSystem.Services.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IAccountReceivableRepository _accountReceivableRepository;
        private readonly IVisitRepository _visitRepository;

        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository, IAccountReceivableRepository accountReceivableRepository, IVisitRepository visitRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _accountReceivableRepository = accountReceivableRepository;
            _visitRepository = visitRepository;
        }

        public GetInvoiceDetailByVisitIdResult GetInvoiceDetailByVisitId(GetInvoiceDetailByVisitIdRequest request)
        {
            var result = _invoiceDetailRepository.GetInvoiceDetailByVisitId(request.VisitId);
            var itemsToBill = request.Mapper.Map<List<GetInvoiceDetailByVisitIdResultModel>>(result);

            var resultFromOtherVisits = _invoiceDetailRepository.GetInvoiceDetailFromOtherVisits(request.VisitId, request.PatientId);
            var invoiceDetailFromOtherVisits = request.Mapper.Map<List<GetInvoiceDetailFromOtherVisitsResultModel>>(resultFromOtherVisits);

            var resultGetAccountsReceivableByPatientId = _accountReceivableRepository.GetAccountsReceivableByPatientId(request.PatientId);
            var accountsReceivable = request.Mapper.Map<List<GetAccountsReceivableByPatientIdResultModel>>(resultGetAccountsReceivableByPatientId);

            var hasBeenBilled = _visitRepository.ValidateIfVisitHasBeenBilled(request.VisitId);

            var getItemsToBillByVisitIdResult = new GetInvoiceDetailByVisitIdResult
            {
                ItemsToBill = itemsToBill,
                AccountsReceivable = accountsReceivable,
                InvoiceDetailFromOtherVisits = invoiceDetailFromOtherVisits,
                VisitHasBeenBilled = hasBeenBilled
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