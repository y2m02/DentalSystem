using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Results.AccountsReceivable;

namespace DentalSystem.Contract.Services
{
    public interface IAccountReceivableService
    {
        GetAccountsReceivableByPatientIdResult GetAccountsReceivableByPatientId(
            GetAccountsReceivableByPatientIdRequest request);

        GetAllAccountsReceivableByPatientIdResult GetAllAccountsReceivableByPatientId(
            GetAllAccountsReceivableByPatientIdRequest request);

        void AddAccountReceivable(AddAccountsReceivableRequest request);
    }
}