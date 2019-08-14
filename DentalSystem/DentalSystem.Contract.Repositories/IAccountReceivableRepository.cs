using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IAccountReceivableRepository
    {
        List<AccountsReceivable> GetAccountsReceivableByPatientId(int patientId);
        List<AccountsReceivable> GetAllAccountsReceivableByPatientId(int patientId);
        void AddAccountReceivable(AccountsReceivable accountsReceivable);
        void UpdateTotalPaid(AccountsReceivable accountsReceivable);
        AccountsReceivable GetPrintingDetailsByVisitId(int visitId);
    }
}