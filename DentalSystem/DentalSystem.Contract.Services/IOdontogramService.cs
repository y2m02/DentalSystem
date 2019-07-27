using DentalSystem.Entities.Requests.Odontogram;
using DentalSystem.Entities.Results.Odontogram;

namespace DentalSystem.Contract.Services
{
    public interface IOdontogramService
    {
        GetOdontogramByVisitIdResult GetOdontogramByVisitId(GetOdontogramByVisitIdRequest request);
        ValidateIfVisitHasOdontogramsResult ValidateIfVisitHasOdontogram(ValidateIfVisitHasOdontogramsRequest request);
        AddOdontogramResult AddOdontogram(AddOdontogramRequest request);
        void UpdateOdontogram(UpdateOdontogramRequest request);
    }
}