using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IOdontogramRepository
    {
        Odontogram GetOdontogramByVisitId(int visitId);
        bool ValidateIfVisitHasOdontogram(int visitId);
        //Odontogram ValidateIfVisitHasOdontograms(int visitId);
        int AddOdontogram(Odontogram odontogram);
        void UpdateOdontogram(Odontogram odontogram);
    }
}