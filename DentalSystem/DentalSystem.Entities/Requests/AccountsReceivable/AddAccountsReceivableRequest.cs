using System;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class AddAccountsReceivableRequest
    {
        public int Total { get; set; }
        public int TotalPaid { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}