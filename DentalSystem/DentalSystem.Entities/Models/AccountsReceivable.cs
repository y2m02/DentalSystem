using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class AccountsReceivable
    {
        [Key, ForeignKey("Patient")]
        public int AccountsReceivableId { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public int TotalPaid { get; set; }

        [Required] public DateTime CreatedDate { get; set; }

        public Patient Patient { get; set; }
    }
}