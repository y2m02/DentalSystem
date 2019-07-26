using System.Data.Entity;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class OdontogramRepository : IOdontogramRepository
    {
        public Odontogram GetOdontogramByVisitId(int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var odontogram = context.Odontograms.Include(w => w.TreatmentOdontogram)
                    .OrderByDescending(w => w.OdontogramId)
                    .FirstOrDefault(w => w.VisitId == visitId);

                return odontogram;
            }
        }

        public bool ValidateIfVisitHasOdontogram(int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var odontograms = context.Odontograms
                    .Where(w => w.VisitId == visitId).ToList();

                var hasOdontograms = odontograms.Any();

                return hasOdontograms;
            }
        }

        public void AddOdontogram(Odontogram odontogram)
        {
            using (var context = new DentalSystemContext())
            {
                context.Odontograms.Add(odontogram);
                context.SaveChanges();
            }
        }

        public void UpdateOdontogram(Odontogram odontogram)
        {
            using (var context = new DentalSystemContext())
            {
                context.Odontograms.Attach(odontogram);
                context.Entry(odontogram).Property(x => x.Information).IsModified = true;
                context.Entry(odontogram).Property(x => x.CavitiesQuantity).IsModified = true;
                context.Entry(odontogram.TreatmentOdontogram).Property(x => x.Information).IsModified = true;
                context.Entry(odontogram.TreatmentOdontogram).Property(x => x.CavitiesQuantity).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}