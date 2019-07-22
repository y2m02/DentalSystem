using AutoMapper;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class UpdateTotalPaidRequest
    {
        public int AccountsReceivableId { get; set; }
        public int TotalPaid { get; set; }
    }
}