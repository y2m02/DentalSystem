using System;
using AutoMapper;
using DentalSystem.Entities.Requests.AccountsReceivable;

namespace DentalSystem.Entities.Requests.Payment
{
    public class DeletePaymentRequest
    {
        public int PaymentId { get; set; }
        public DateTime DeletedOn { get; set; }
        public IMapper Mapper { get; set; }
        public UpdateTotalPaidRequest UpdateTotalPaidRequest { get; set; }
    }
}