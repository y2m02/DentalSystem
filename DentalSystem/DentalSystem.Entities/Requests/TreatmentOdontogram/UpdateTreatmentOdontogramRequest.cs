using AutoMapper;

namespace DentalSystem.Entities.Requests.TreatmentOdontogram
{
    public class UpdateTreatmentOdontogramRequest
    {
        public int TreatmentOdontogramId { get; set; }
        public string Information { get; set; }
        public int CavitiesQuantity { get; set; }
        public IMapper Mapper { get; set; }
    }
}