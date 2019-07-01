using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IActivityPerformedRepository
    {
        List<ActivityPerformed> GetAllActivitiesPerformed(int visitId);
        void AddActivityPerformed(ActivityPerformed activityPerformed);
        void UpdateActivityPerformed(ActivityPerformed activityPerformed);
        void DeleteActivityPerformed(int activityPerformedId, string deletedBy);
        List<ActivityPerformed> GetAllActivitiesPerformedByPatientId(int patientId, int visitId);
    }
}