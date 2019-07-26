using AutoMapper;
using DentalSystem.Entities.Requests.TreatmentOdontogram;

namespace DentalSystem.Entities.Requests.Odontogram
{
    public class UpdateOdontogramRequest
    {
        public int OdontogramId { get; set; }
        public string Information { get; set; }
        public int CavitiesQuantity { get; set; }
        public IMapper Mapper { get; set; }

        public UpdateTreatmentOdontogramRequest TreatmentOdontogram { get; set; }
    }
}