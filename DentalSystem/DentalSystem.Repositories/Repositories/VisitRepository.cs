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

        public bool ValidateIfVisitHasBeenBilled(int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var hasBeenBilled = context.Visits.Where(w => w.VisitId == visitId).Select(w => w.HasBeenBilled);

                return hasBeenBilled.FirstOrDefault();

            }
        }
    }
}