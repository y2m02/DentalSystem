using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class AccountsReceivable
    {
        [Key] public int AccountsReceivableId { get; set; }
        [ForeignKey("Patient")] [Required] public int PatientId { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public int TotalPaid { get; set; }

        [Required] public DateTime CreatedDate { get; set; }

        public Patient Patient { get; set; }
    }
}