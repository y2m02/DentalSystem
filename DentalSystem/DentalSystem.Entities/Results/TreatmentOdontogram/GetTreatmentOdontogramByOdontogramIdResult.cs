namespace DentalSystem.Entities.Results.TreatmentOdontogram
{
    public class GetTreatmentOdontogramByOdontogramIdResult
    {
        public GetTreatmentOdontogramByOdontogramIdResultModel TreatmentOdontogram { get; set; }
    }

    public class GetTreatmentOdontogramByOdontogramIdResultModel
    {
        public int TreatmentOdontogramId { get; set; }
        public string Information { get; set; }
        public int CavitiesQuantity { get; set; }
        public bool HasInformation { get; set; }
    }
}