using System;
using System.Collections.Generic;

namespace DentalSystem.Entities.Results.Payment
{
    public class GetPaymentsByAccountReceivableIdResult
    {
        public List<GetPaymentsByAccountReceivableIdResultModel> PaymentList { get; set; }
    }

    public class GetPaymentsByAccountReceivableIdResultModel
    {
        public int PaymentId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}