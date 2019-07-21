using System.Collections.Generic;
using DentalSystem.Entities.Results.AccountsReceivable;

namespace DentalSystem.Entities.Results.InvoiceDetail
{
    public class GetInvoiceDetailByVisitIdResult
    {
        public List<GetInvoiceDetailByVisitIdResultModel> ItemsToBill { get; set; }
        public List<GetInvoiceDetailFromOtherVisitsResultModel> InvoiceDetailFromOtherVisits { get; set; }
        public List<GetAccountsReceivableByPatientIdResultModel> AccountsReceivable { get; set; }
        public bool VisitHasBeenBilled { get; set; }
    }

    public class GetInvoiceDetailByVisitIdResultModel
    {
        public int InvoiceDetailId { get; set; }
        public string ActivityPerformed { get; set; }
        public string Section { get; set; }
        public int Price { get; set; }
    }
}