using System;
using System.Collections.Generic;

namespace DentalSystem.Entities.Results.AccountsReceivable
{
    public class GetAllAccountReceivableForReportResult
    {
        public List<GetAllAccountReceivableForReportResultModel> AccountsReceivable { get; set; }
    }

    public class GetAllAccountReceivableForReportResultModel
    {
        public int AccountsReceivableId { get; set; }
        public int VisitNumber { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalPending { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PatientName { get; set; }
    }
}