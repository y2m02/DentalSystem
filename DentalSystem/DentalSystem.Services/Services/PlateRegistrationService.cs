using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.PlateRegistration;

namespace DentalSystem.Services.Services
{
    public class PlateRegistrationService : IPlateRegistrationService
    {
        private readonly IPlateRegistrationRepository _plateRegistrationRepository;

        public PlateRegistrationService(IPlateRegistrationRepository plateRegistrationRepository)
        {
            _plateRegistrationRepository = plateRegistrationRepository;
        }

        public void UpdatePlateRegistration(UpdatePlateRegistrationRequest request)
        {
            var plateRegistration = request.Mapper.Map<PlateRegistration>(request);
            _plateRegistrationRepository.UpdatePlateRegistration(plateRegistration);
        }
    }
}