using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class AccountReceivableRepository : IAccountReceivableRepository
    {
        public void AddAccountReceivable(AccountsReceivable accountsReceivable)
        {
            using (var context = new DentalSystemContext())
            {
                context.AccountsReceivables.Add(accountsReceivable);
                context.SaveChanges();
            }
        }

        public List<AccountsReceivable> GetAccountsReceivableByPatientId(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var accountsReceivable =
                    context.AccountsReceivables.Include(w => w.Visit).Where(w => w.Patient.PatientId == patientId)
                        .OrderByDescending(w => w.Visit.VisitNumber).ToList();

                return accountsReceivable;
            }
        }
    }
}