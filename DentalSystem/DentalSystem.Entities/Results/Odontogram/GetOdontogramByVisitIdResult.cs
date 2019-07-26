using DentalSystem.Entities.Results.TreatmentOdontogram;

namespace DentalSystem.Entities.Results.Odontogram
{
    public class GetOdontogramByVisitIdResult
    {
        public GetOdontogramByVisitIdResultModel Odontogram { get; set; }
    }

    public class GetOdontogramByVisitIdResultModel
    {
        public int OdontogramId { get; set; }
        public string Information { get; set; }
        public int CavitiesQuantity { get; set; }
        public bool HasInformation { get; set; }
        //public GetTreatmentOdontogramByOdontogramIdResultModel TreatmentOdontogram { get; set; }
    }
}