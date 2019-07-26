using AutoMapper;

namespace DentalSystem.Entities.Requests.TreatmentOdontogram
{
    public class GetTreatmentOdontogramByOdontogramIdRequest
    {
        public int OdontogramId { get; set; }
        public IMapper Mapper { get; set; }
    }
}