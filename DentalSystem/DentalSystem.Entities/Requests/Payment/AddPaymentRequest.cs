using System;
using AutoMapper;

namespace DentalSystem.Entities.Requests.Payment
{
    public class AddPaymentRequest
    {
        public int PaymentId { get; set; }
        public int AccountsReceivableId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }

        public IMapper Mapper { get; set; }
    }
}