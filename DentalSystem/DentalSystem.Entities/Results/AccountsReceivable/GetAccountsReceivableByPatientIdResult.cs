using System;
using System.Collections.Generic;

namespace DentalSystem.Entities.Results.AccountsReceivable
{
    public class GetAccountsReceivableByPatientIdResult
    {
        public List<GetAccountsReceivableByPatientIdResultModel> AccountsReceivable { get; set; }
    }

    public class GetAccountsReceivableByPatientIdResultModel
    {
        public int AccountsReceivableId { get; set; }
        public int VisitNumber { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalPending { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}