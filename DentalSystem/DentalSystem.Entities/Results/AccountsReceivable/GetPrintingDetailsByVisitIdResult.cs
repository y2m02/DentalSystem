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
        public int Total { get; set; }
        public int TotalPaid { get; set; }
        public int TotalPending { get; set; }
    }
}