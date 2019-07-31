using AutoMapper;

namespace DentalSystem.Entities.Requests.ActivityPerformed
{
    public class GetAllActivitiesPerformedRequest
    {
        public int VisitId { get; set; }
        public int PatientId { get; set; }
        public IMapper Mapper { get; set; }

    }
}