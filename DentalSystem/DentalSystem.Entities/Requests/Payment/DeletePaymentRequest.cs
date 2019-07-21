using AutoMapper;

namespace DentalSystem.Entities.Requests.Payment
{
    public class DeletePaymentRequest
    {
        public int PaymentId { get; set; }
        public IMapper Mapper { get; set; }
    }
}