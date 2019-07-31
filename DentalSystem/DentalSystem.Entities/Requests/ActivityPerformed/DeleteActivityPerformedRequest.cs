using AutoMapper;

namespace DentalSystem.Entities.Requests.ActivityPerformed
{
    public class DeleteActivityPerformedRequest
    {
        public int ActivityPerformedId { get; set; }
        public int InvoiceDetailId { get; set; }
        public int VisitId { get; set; }
        public IMapper Mapper { get; set; }
    }
}