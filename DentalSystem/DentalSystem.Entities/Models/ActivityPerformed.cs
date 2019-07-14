using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class ActivityPerformed
    {
        [Key] public int ActivityPerformedId { get; set; }
        [StringLength(100)] public string Responsable { get; set; }
        [Required] [ForeignKey("Visit")] public int VisitId { get; set; }
        [Required] public int Section { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] [StringLength(100)] public string Description { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Visit Visit { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}