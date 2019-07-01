using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class AccountsReceivable
    {
        [Key] public int AccountsReceivableId { get; set; }
        [ForeignKey("User")] public int? UserId { get; set; }
        [ForeignKey("Patient")] [Required] public int PatientId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Total { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal TotalPaid { get; set; }

        [Required] public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public Patient Patient { get; set; }
    }
}