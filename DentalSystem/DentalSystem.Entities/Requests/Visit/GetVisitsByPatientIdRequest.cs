using AutoMapper;

namespace DentalSystem.Entities.Requests.Visit
{
    public class GetVisitsByPatientIdRequest
    {
        public int PatientId { get; set; }
        public IMapper Mapper { get; set; }
    }
}