using System;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.TreatmentOdontogram;
using DentalSystem.Entities.Results.TreatmentOdontogram;

namespace DentalSystem.Services.Services
{
    public class TreatmentOdontogramService : ITreatmentOdontogramService
    {
        private readonly ITreatmentOdontogramRepository _treatmentOdontogramRepository;

        public TreatmentOdontogramService(ITreatmentOdontogramRepository treatmentOdontogramRepository)
        {
            _treatmentOdontogramRepository = treatmentOdontogramRepository;
        }

        public GetTreatmentOdontogramByOdontogramIdResult GetTreatmentOdontogramByOdontogramId(
            GetTreatmentOdontogramByOdontogramIdRequest request)
        {
            var result = _treatmentOdontogramRepository.GetTreatmentOdontogramByOdontogramId(request.OdontogramId);
            var treatmentOdontogram = request.Mapper.Map<GetTreatmentOdontogramByOdontogramIdResultModel>(result);

            var treatmentOdontogramByOdontogramIdResult = new GetTreatmentOdontogramByOdontogramIdResult
            {
                TreatmentOdontogram = treatmentOdontogram
            };
            return treatmentOdontogramByOdontogramIdResult;
        }

        public void AddTreatmentOdontogram(AddTreatmentOdontogramRequest request)
        {
            throw new NotImplementedException();
        }

        public void UpdateTreatmentOdontogram(UpdateTreatmentOdontogramRequest request)
        {
            var treatmentOdontogram = request.Mapper.Map<TreatmentOdontogram>(request);
            _treatmentOdontogramRepository.UpdateTreatmentOdontogram(treatmentOdontogram);
        }
    }
}