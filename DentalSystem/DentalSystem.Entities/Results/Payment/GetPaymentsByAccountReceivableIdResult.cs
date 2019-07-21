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
        public int AccountsReceivableId { get; set; }
        public int AmountPaid { get; set; }
        public int VisitNumber { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}