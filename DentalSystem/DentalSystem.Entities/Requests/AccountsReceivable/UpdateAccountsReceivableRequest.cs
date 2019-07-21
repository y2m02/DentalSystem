using AutoMapper;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class UpdateAccountsReceivableRequest
    {
        public int AccountsReceivableId { get; set; }
        public int Total { get; set; }
        public int TotalPaid { get; set; }
        public IMapper Mapper { get; set; }
    }
}