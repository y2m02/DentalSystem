using System.Collections.Generic;

namespace DentalSystem.Entities.Results.InvoiceDetail
{
    public class GetInvoiceDetailByVisitIdResult
    {
        public List<GetInvoiceDetailByVisitIdResultModel> ItemsToBill { get; set; }
    }

    public class GetInvoiceDetailByVisitIdResultModel
    {
        public int InvoiceDetailId { get; set; }
        public string ActivityPerformed { get; set; }
        public string Section { get; set; }
        public int Price { get; set; }
    }
}