namespace DentalSystem.Entities.Requests.Visit
{
    public class SetVisitAsBilledRequest
    {
        public int VisitId { get; set; }
        public bool HasBeenBilled { get; set; }
    }
}