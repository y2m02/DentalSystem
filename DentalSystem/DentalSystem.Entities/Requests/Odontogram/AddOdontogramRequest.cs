using AutoMapper;
using DentalSystem.Entities.Requests.TreatmentOdontogram;

namespace DentalSystem.Entities.Requests.Odontogram
{
    public class AddOdontogramRequest
    {
        public int OdontogramId { get; set; }
        public int VisitId { get; set; }
        public string Information { get; set; }
        public int CavitiesQuantity { get; set; }
        public IMapper Mapper { get; set; }

        public AddTreatmentOdontogramRequest TreatmentOdontogram { get; set; }
    }
}