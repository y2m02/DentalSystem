using AutoMapper;

namespace DentalSystem.Entities.Requests.InvoiceDetail
{
    public class GetInvoiceDetailByVisitIdRequest
    {
        public int VisitId { get; set; }
        public IMapper Mapper { get; set; }
    }
}