using AutoMapper;

namespace DentalSystem.Entities.Requests.Odontogram
{
    public class GetOdontogramByVisitIdRequest
    {
        public int VisitId { get; set; }
        public IMapper Mapper { get; set; }
    }
}