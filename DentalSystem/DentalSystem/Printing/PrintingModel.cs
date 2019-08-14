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
        public int Total { get; set; }
        public int Paid { get; set; }
        public int Pending { get; set; }
    }
}