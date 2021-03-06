using System;
using AutoMapper;
using DentalSystem.Entities.Requests.AccountsReceivable;

namespace DentalSystem.Entities.Requests.Payment
{
    public class AddPaymentRequest
    {
        public int AccountsReceivableId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Month { get; set; }
        public IMapper Mapper { get; set; }

        public UpdateTotalPaidRequest UpdateTotalPaidRequest { get; set; }
    }
}