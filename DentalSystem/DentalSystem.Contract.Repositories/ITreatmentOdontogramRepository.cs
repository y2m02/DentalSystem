using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface ITreatmentOdontogramRepository
    {
        TreatmentOdontogram GetTreatmentOdontogramByOdontogramId(int odontogramId);
        void AddTreatmentOdontogram(TreatmentOdontogram treatmentOdontogram);
        void UpdateTreatmentOdontogram(TreatmentOdontogram treatmentOdontogram);
    }
}