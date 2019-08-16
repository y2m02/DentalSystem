using DentalSystem.Entities.Requests.BackUp;

namespace DentalSystem.Contract.Services
{
    public interface IBackUpService
    {
        void CreateBackUp(CreateBackUpRequest request);
    }
}