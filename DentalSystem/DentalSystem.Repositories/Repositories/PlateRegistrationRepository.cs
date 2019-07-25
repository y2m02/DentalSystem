using System.Data.Entity;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class PlateRegistrationRepository : IPlateRegistrationRepository
    {
        public void UpdatePlateRegistration(PlateRegistration plateRegistration)
        {
            using (var context = new DentalSystemContext())
            {
                context.PlateRegistrations.Attach(plateRegistration);
                context.Entry(plateRegistration).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}