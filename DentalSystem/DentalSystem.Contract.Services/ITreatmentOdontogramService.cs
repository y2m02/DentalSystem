using DentalSystem.Entities.Requests.TreatmentOdontogram;
using DentalSystem.Entities.Results.TreatmentOdontogram;

namespace DentalSystem.Contract.Services
{
    public interface ITreatmentOdontogramService
    {
        GetTreatmentOdontogramByOdontogramIdResult GetTreatmentOdontogramByOdontogramId(
            GetTreatmentOdontogramByOdontogramIdRequest request);

        void AddTreatmentOdontogram(AddTreatmentOdontogramRequest request);
        void UpdateTreatmentOdontogram(UpdateTreatmentOdontogramRequest request);
    }
}