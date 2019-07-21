using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class Visit
    {
        [Key] public int VisitId { get; set; }
        public int VisitNumber { get; set; }
        [ForeignKey("Patient")] public int PatientId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? HasEnded { get; set; }
        public bool HasBeenBilled { get; set; }

        public Patient Patient { get; set; }
        public virtual Odontogram Odontogram { get; set; }
        public virtual AccountsReceivable AccountsReceivable { get; set; }
        public virtual ICollection<ActivityPerformed> ActivitiesPerformed { get; set; }
        //public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}