using System.Collections.Generic;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Results.AccountsReceivable;

namespace DentalSystem.Services.Services
{
    public class AccountReceivableService : IAccountReceivableService
    {
        private readonly IAccountReceivableRepository _accountReceivableRepository;
        private readonly IVisitRepository _visitRepository;

        public AccountReceivableService(IAccountReceivableRepository accountReceivableRepository,
            IVisitRepository visitRepository)
        {
            _accountReceivableRepository = accountReceivableRepository;
            _visitRepository = visitRepository;
        }

        public GetAccountsReceivableByPatientIdResult
            GetAccountsReceivableByPatientId(GetAccountsReceivableByPatientIdRequest request)
        {
            var result = _accountReceivableRepository.GetAccountsReceivableByPatientId(request.PatientId);
            var accountsReceivable = request.Mapper.Map<List<GetAccountsReceivableByPatientIdResultModel>>(result);

            var getAccountsReceivableByPatientIdResult = new GetAccountsReceivableByPatientIdResult
            {
                AccountsReceivable = accountsReceivable
            };
            return getAccountsReceivableByPatientIdResult;
        }

        public GetAllAccountsReceivableByPatientIdResult GetAllAccountsReceivableByPatientId(
            GetAllAccountsReceivableByPatientIdRequest request)
        {
            var result = _accountReceivableRepository.GetAllAccountsReceivableByPatientId(request.PatientId);
            var accountsReceivable = request.Mapper.Map<List<GetAllAccountsReceivableByPatientIdResultModel>>(result);

            var getAllAccountsReceivableByPatientIdResult = new GetAllAccountsReceivableByPatientIdResult
            {
                AccountsReceivable = accountsReceivable
            };
            return getAllAccountsReceivableByPatientIdResult;
        }

        public void AddAccountReceivable(AddAccountsReceivableRequest request)
        {
            var accountReceivable = request.Mapper.Map<AccountsReceivable>(request);
            _accountReceivableRepository.AddAccountReceivable(accountReceivable);

            var visit = request.Mapper.Map<Visit>(request.SetVisitAsBilledRequest);
            _visitRepository.SetVisitAsBilled(visit);
        }

        public GetPrintingDetailsByVisitIdResult GetPrintingDetailsByVisitId(GetPrintingDetailsByVisitIdRequest request)
        {
            var result = _accountReceivableRepository.GetPrintingDetailsByVisitId(request.VisitId);
            var printingDetail = request.Mapper.Map<GetPrintingDetailsByVisitIdResultModel>(result);

            var getAllAccountsReceivableByPatientIdResult = new GetPrintingDetailsByVisitIdResult
            {
                PrintingDetail = printingDetail
            };
            return getAllAccountsReceivableByPatientIdResult;
        }
    }
}