using System;

namespace DentalSystem.Entities.Results.AccountsReceivable
{
    public class GetPrintingDetailsByVisitIdResult
    {
        public GetPrintingDetailsByVisitIdResultModel PrintingDetail { get; set; }
    }

    public class GetPrintingDetailsByVisitIdResultModel
    {
        public int VisitNumber { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalPending { get; set; }
    }
}