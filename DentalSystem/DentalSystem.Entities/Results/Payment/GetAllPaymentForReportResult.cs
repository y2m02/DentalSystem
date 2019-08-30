using System;
using System.Collections.Generic;

namespace DentalSystem.Entities.Results.Payment
{
    public class GetAllPaymentForReportResult
    {
        public List<GetAllPaymentForReportResultModel> PaymentList { get; set; }
    }

    public class GetAllPaymentForReportResultModel
    {
        public int PaymentId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Month { get; set; }
    }
}