using AutoMapper;

namespace DentalSystem.Entities.Requests.InvoiceDetail
{
    public class GetInvoiceDetailByVisitIdRequest
    {
        public int VisitId { get; set; }
        public int PatientId { get; set; }
        public IMapper Mapper { get; set; }
    }
}