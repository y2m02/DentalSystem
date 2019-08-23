using AutoMapper;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class UpdateTotalPaidRequest
    {
        public int AccountsReceivableId { get; set; }
        public decimal TotalPaid { get; set; }
    }
}