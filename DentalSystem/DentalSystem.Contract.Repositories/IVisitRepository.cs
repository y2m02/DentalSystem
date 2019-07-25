using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IVisitRepository
    {
        Visit AddVisit(Visit visit);
        void EndVisit(Visit visit);
        void SetVisitAsBilled(Visit visit);
        int GetVisitNumber(int patientId);
        bool ValidateIfVisitHasBeenBilled(int visitId);
        List<Visit> GetVisitsByPatientId(int patientId);
    }
}