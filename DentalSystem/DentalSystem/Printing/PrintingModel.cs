using System;
using System.Collections.Generic;
using DentalSystem.Entities.Results.InvoiceDetail;

namespace DentalSystem.Printing
{
    public class PrintingModel
    {
        public List<GetInvoiceDetailByVisitIdResultModel> ItemsToBill { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitNumber { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Pending { get; set; }
    }
}