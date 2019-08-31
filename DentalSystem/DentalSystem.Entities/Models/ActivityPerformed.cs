using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class ActivityPerformed
    {
        [Key] public int ActivityPerformedId { get; set; }

        [ForeignKey("User")] public int UserId { get; set; }

        [Required] [ForeignKey("Visit")] public int VisitId { get; set; }
        [Required] public int Section { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] [StringLength(100)] public string Description { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Visit Visit { get; set; }
        public virtual InvoiceDetail InvoiceDetail { get; set; }
        public virtual User User { get; set; }
    }
}