using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IPlateRegistrationRepository
    {
        void UpdatePlateRegistration(PlateRegistration plateRegistration);
    }
}