using System.Data.Entity;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        public int AddVisit(Visit visit)
        {
            using (var context = new DentalSystemContext())
            {
                context.Visits.Add(visit);
                context.SaveChanges();

                return visit.VisitId;
            }
        }

        public void EndVisit(Visit visit)
        {
            using (var context = new DentalSystemContext())
            {
                var visitToModify = context.Visits.Include(w => w.Patient)
                    .FirstOrDefault(w => w.VisitId == visit.VisitId);

                if (visitToModify == null) return;

                visit.CreatedOn = visitToModify.CreatedOn;

                context.Entry(visitToModify).CurrentValues.SetValues(visit);
                context.SaveChanges();
            }
        }
    }
}