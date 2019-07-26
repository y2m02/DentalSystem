namespace DentalSystem.Entities.Requests.TreatmentOdontogram
{
    public class AddTreatmentOdontogramRequest
    {
        public int TreatmentOdontogramId { get; set; }
        public string Information { get; set; }
        public int CavitiesQuantity { get; set; }
    }
}