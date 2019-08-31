using System;
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
        public List<AccountsReceivable> GetAllAccountsReceivableByPatientId(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var accountsReceivable =
                    context.AccountsReceivables.Include(w => w.Visit)
                        .Where(w => w.Patient.PatientId == patientId)
                        .OrderByDescending(w => w.Total - w.TotalPaid).ThenByDescending(w => w.Visit.VisitNumber)
                        .ToList();

                return accountsReceivable;
            }
        }

        public void AddAccountReceivable(AccountsReceivable accountsReceivable)
        {
            using (var context = new DentalSystemContext())
            {
                context.AccountsReceivables.Add(accountsReceivable);
                context.SaveChanges();
            }
        }

        public void UpdateTotalPaid(AccountsReceivable accountsReceivable)
        {
            using (var context = new DentalSystemContext())
            {
                context.AccountsReceivables.Attach(accountsReceivable);
                context.Entry(accountsReceivable).Property(x => x.TotalPaid).IsModified = true;
                context.SaveChanges();
            }
        }

        public AccountsReceivable GetPrintingDetailsByVisitId(int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var accountsReceivable =
                    context.AccountsReceivables
                        .Include(w => w.Visit).FirstOrDefault(w => w.Visit.VisitId == visitId);

                return accountsReceivable;
            }
        }

        public List<AccountsReceivable> GetAllAccountReceivableForReport(DateTime? from, DateTime? to, bool includeDate)
        {
            using (var context = new DentalSystemContext())
            {
                List<AccountsReceivable> accountsReceivable;

                if (includeDate)
                {
                    accountsReceivable = context.AccountsReceivables.Include(w => w.Visit).Include(w => w.Visit.Patient)
                        .Where(w => w.Total > w.TotalPaid && w.CreatedDate >= from.Value && w.CreatedDate <= to.Value)
                        .OrderBy(w => w.Visit.VisitNumber)
                        .ToList();
                }
                else
                {
                    accountsReceivable = context.AccountsReceivables.Include(w => w.Visit).Include(w => w.Visit.Patient)
                        .Where(w => w.Total > w.TotalPaid)
                        .OrderBy(w => w.Visit.VisitNumber)
                        .ToList();
                }
                return accountsReceivable;
            }
        }

        public List<AccountsReceivable> GetAccountsReceivableByPatientId(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var accountsReceivable =
                    context.AccountsReceivables.Include(w => w.Visit)
                        .Where(w => w.Patient.PatientId == patientId && w.Total != w.TotalPaid)
                        .OrderByDescending(w => w.Visit.VisitNumber).ToList();

                return accountsReceivable;
            }
        }
    }
}