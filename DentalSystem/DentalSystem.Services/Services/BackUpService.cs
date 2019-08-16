using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.BackUp;

namespace DentalSystem.Services.Services
{
    public class BackUpService : IBackUpService
    {
        private readonly IBackUpRepository _backUpRepository;

        public BackUpService(IBackUpRepository backUpRepository)
        {
            _backUpRepository = backUpRepository;
        }

        public void CreateBackUp(CreateBackUpRequest request)
        {
            _backUpRepository.CreateBackUp(request.Path);
        }
    }
}