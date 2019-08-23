using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class InvoiceDetail
    {
        [Key, ForeignKey("ActivityPerformed")]
        public int InvoiceDetailId { get; set; }
        //[ForeignKey("Visit")] public int VisitId { get; set; }
        //[ForeignKey("ActivityPerformed")] public int ActivityPerformedId { get; set; }
    
        public decimal Price { get; set; }
        public DateTime? DeletedOn { get; set; }

        //public virtual Visit Visit { get; set; }
        public virtual ActivityPerformed ActivityPerformed { get; set; }
    }
}