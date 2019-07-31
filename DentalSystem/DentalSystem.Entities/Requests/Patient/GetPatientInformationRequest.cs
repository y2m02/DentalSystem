using AutoMapper;

namespace DentalSystem.Entities.Requests.Patient
{
    public class GetPatientInformationRequest
    {
        public int PatientId { get; set; }
        public int VisitId { get; set; }
        public IMapper Mapper { get; set; }
    }
}