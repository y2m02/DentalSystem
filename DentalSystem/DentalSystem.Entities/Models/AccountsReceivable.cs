using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class AccountsReceivable
    {
        [Key, ForeignKey("Visit")]
        public int AccountsReceivableId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal TotalPaid { get; set; }

        [Required] public DateTime CreatedDate { get; set; }

        public Patient Patient { get; set; }
        public List<Payment> Payments { get; set; }

        public Visit Visit { get; set; }
    }
}