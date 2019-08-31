using System;
using AutoMapper;
using DentalSystem.Entities.Requests.InvoiceDetail;

namespace DentalSystem.Entities.Requests.ActivityPerformed
{
    public class AddActivityPerformedRequest
    {
        public int UserId { get; set; }
        public int VisitId { get; set; }
        public int Section { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public IMapper Mapper { get; set; }

        public AddInvoiceDetailRequest InvoiceDetail { get; set; }
    }
}