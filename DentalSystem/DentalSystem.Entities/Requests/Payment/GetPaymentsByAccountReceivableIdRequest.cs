using AutoMapper;

namespace DentalSystem.Entities.Requests.Payment
{
    public class GetPaymentsByAccountReceivableIdRequest
    {
        public int AccountsReceivableId { get; set; }
        public IMapper Mapper { get; set; }
    }
}