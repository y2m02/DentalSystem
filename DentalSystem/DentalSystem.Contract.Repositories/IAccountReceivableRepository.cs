using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IAccountReceivableRepository
    {
        List<AccountsReceivable> GetAccountsReceivableByPatientId(int patientId);
        void AddAccountReceivable(AccountsReceivable accountsReceivable);
    }
}