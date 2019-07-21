using System.Collections.Generic;

namespace DentalSystem.Entities.Results.InvoiceDetail
{
    public class GetInvoiceDetailFromOtherVisitsResult
    {
        public List<GetInvoiceDetailFromOtherVisitsResultModel> InvoiceDetailFromOtherVisits { get; set; }
    }

    public class GetInvoiceDetailFromOtherVisitsResultModel
    {
        public int InvoiceDetailId { get; set; }
        public int VisitNumber { get; set; }
        public string ActivityPerformed { get; set; }
        public string Section { get; set; }
        public int Price { get; set; }
    }
}