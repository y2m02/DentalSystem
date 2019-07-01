using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class InvoiceDetail
    {
        [Key] public int InvoiceDetailId { get; set; }
        //[ForeignKey("User")] public int UserId { get; set; }
        //[ForeignKey("Visit")] public int VisitId { get; set; }
        [ForeignKey("ActivityPerformed")] public int ActivityPerformedId { get; set; }
        public decimal Price { get; set; }
        [StringLength(50)] public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        //public virtual User User { get; set; }
        //public virtual Visit Visit { get; set; }
        public virtual ActivityPerformed ActivityPerformed { get; set; }
    }
}