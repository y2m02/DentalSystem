using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Odontogram;
using DentalSystem.Entities.Results.Odontogram;

namespace DentalSystem.Services.Services
{
    public class OdontogramService : IOdontogramService
    {
        private readonly IOdontogramRepository _odontogramRepository;

        public OdontogramService(IOdontogramRepository odontogramRepository)
        {
            _odontogramRepository = odontogramRepository;
        }

        public GetOdontogramByVisitIdResult GetOdontogramByVisitId(GetOdontogramByVisitIdRequest request)
        {
            var result = _odontogramRepository.GetOdontogramByVisitId(request.VisitId);
            var odontogram = request.Mapper.Map<GetOdontogramByVisitIdResultModel>(result);

            var getOdontogramByVisitIdResult = new GetOdontogramByVisitIdResult
            {
                Odontogram = odontogram
            };
            return getOdontogramByVisitIdResult;
        }

        public ValidateIfVisitHasOdontogramsResult ValidateIfVisitHasOdontogram(ValidateIfVisitHasOdontogramsRequest request)
        {
            var hasOdontogram = _odontogramRepository.ValidateIfVisitHasOdontogram(request.VisitId);

            var result = new ValidateIfVisitHasOdontogramsResult
            {
                HasOdontogram = hasOdontogram
            };

            return result;
        }

        public void AddOdontogram(AddOdontogramRequest request)
        {
            var odontogram = request.Mapper.Map<Odontogram>(request);
            _odontogramRepository.AddOdontogram(odontogram);
        }

        public void UpdateOdontogram(UpdateOdontogramRequest request)
        {
            var odontogram = request.Mapper.Map<Odontogram>(request);
            _odontogramRepository.UpdateOdontogram(odontogram);
        }
    }
}