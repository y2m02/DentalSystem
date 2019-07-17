using AutoMapper;

namespace DentalSystem.Entities.Requests.InvoiceDetail
{
    public class UpdateInvoiceDetailRequest
    {
        public int InvoiceDetailId { get; set; }
        public int Price { get; set; }
        public IMapper Mapper { get; set; }
    }
}