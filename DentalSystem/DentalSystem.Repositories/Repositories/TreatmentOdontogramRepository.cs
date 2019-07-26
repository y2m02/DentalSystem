using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class TreatmentOdontogramRepository: ITreatmentOdontogramRepository
    {
        public TreatmentOdontogram GetTreatmentOdontogramByOdontogramId(int odontogramId)
        {
            using (var context = new DentalSystemContext())
            {
                var treatmentOdontogram = context.TreatmentOdontograms
                    .FirstOrDefault(w => w.Odontogram.OdontogramId == odontogramId);

                return treatmentOdontogram;
            }
        }

        public void AddTreatmentOdontogram(TreatmentOdontogram treatmentOdontogram)
        {
            using (var context = new DentalSystemContext())
            {
                context.TreatmentOdontograms.Add(treatmentOdontogram);
                context.SaveChanges();
            }
        }

        public void UpdateTreatmentOdontogram(TreatmentOdontogram treatmentOdontogram)
        {
            using (var context = new DentalSystemContext())
            {
                context.TreatmentOdontograms.Attach(treatmentOdontogram);
                context.Entry(treatmentOdontogram).Property(x => x.Information).IsModified = true;
                context.Entry(treatmentOdontogram).Property(x => x.CavitiesQuantity).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
