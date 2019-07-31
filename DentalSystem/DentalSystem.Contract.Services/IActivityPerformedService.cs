using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Results.ActivityPerformed;

namespace DentalSystem.Contract.Services
{
    public interface IActivityPerformedService
    {
        GetAllActivitiesPerformedResult GetAllActivitiesPerformed(GetAllActivitiesPerformedRequest request);
        GetAllActivitiesPerformedResult GetOtherVisitActivitiesPerformed(GetAllActivitiesPerformedRequest request);

        GetAllActivitiesPerformedResult AddActivityPerformed(AddActivityPerformedRequest request);
        GetAllActivitiesPerformedResult UpdateActivityPerformed(UpdateActivityPerformedRequest request);
        GetAllActivitiesPerformedResult DeleteActivityPerformed(DeleteActivityPerformedRequest request);
    }
}