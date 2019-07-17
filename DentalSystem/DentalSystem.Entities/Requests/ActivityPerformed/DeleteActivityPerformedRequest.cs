namespace DentalSystem.Entities.Requests.ActivityPerformed
{
    public class DeleteActivityPerformedRequest
    {
        public int ActivityPerformedId { get; set; }
        public int InvoiceDetailId { get; set; }
    }
}