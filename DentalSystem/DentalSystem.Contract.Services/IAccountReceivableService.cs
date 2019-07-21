using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Results;
using DentalSystem.Entities.Results.AccountsReceivable;

namespace DentalSystem.Contract.Services
{
    public interface IAccountReceivableService
    {
        GetAccountsReceivableByPatientIdResult GetAccountsReceivableByPatientId(
            GetAccountsReceivableByPatientIdRequest request);

        void AddAccountReceivable(AddAccountsReceivableRequest request);
    }
}