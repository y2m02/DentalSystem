namespace DentalSystem.Entities.Requests.Visit
{
    public class EndVisitRequest
    {
        public int VisitId { get; set; }
        public int PatientId { get; set; }
        public bool? HasEnded { get; set; }
    }
}