using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        public Visit AddVisit(Visit visit)
        {
            using (var context = new DentalSystemContext())
            {
                context.Visits.Add(visit);
                context.SaveChanges();

                return visit;
            }
        }

        public void EndVisit(Visit visit)
        {
            using (var context = new DentalSystemContext())
            {
                context.Visits.Attach(visit);
                context.Entry(visit).Property(x => x.HasEnded).IsModified = true;
                context.SaveChanges();
            }
        }

        public void SetVisitAsBilled(Visit visit)
        {
            using (var context = new DentalSystemContext())
            {
                context.Visits.Attach(visit);
                context.Entry(visit).Property(x => x.HasBeenBilled).IsModified = true;
                context.SaveChanges();
            }
        }

        public int GetVisitNumber(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var totalVisit = context.Visits.Count(w => w.PatientId == patientId);

                var visitNumber = totalVisit + 1;

                return visitNumber;
            }
        }

        public int GetVisitId(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var visit = context.Visits.OrderByDescending(w=>w.VisitId).FirstOrDefault(w => w.PatientId == patientId);

                if (visit == null) return 0;

                var visitId = visit.VisitId;

                return visitId;

            }
        }

        public bool ValidateIfVisitHasBeenBilled(int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var hasBeenBilled = context.Visits.Where(w => w.VisitId == visitId).Select(w => w.HasBeenBilled);

                return hasBeenBilled.FirstOrDefault();
            }
        }

        public List<Visit> GetVisitsByPatientId(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var visit = context.Visits.Where(w => w.PatientId == patientId).OrderByDescending(w => w.VisitId)
                    .ToList();

                return visit;
            }
        }
    }
}