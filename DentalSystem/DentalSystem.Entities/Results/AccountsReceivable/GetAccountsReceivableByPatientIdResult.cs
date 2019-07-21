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
        public DateTime CreatedDate { get; set; }
        public int Total { get; set; }
        public int TotalPaid { get; set; }
        public int TotalPending { get; set; }
    }
}