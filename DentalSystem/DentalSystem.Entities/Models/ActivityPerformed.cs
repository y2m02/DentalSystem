using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class ActivityPerformed
    {
        [Key] public int ActivityPerformedId { get; set; }

        [Required] [ForeignKey("User")] public int UserId { get; set; }

        [Required] [ForeignKey("Patient")] public int PatientId { get; set; }

        [Required] [StringLength(30)] public string Section { get; set; }

        [Required] public DateTime Date { get; set; }

        [Required] [StringLength(100)] public string Description { get; set; }

        public User User { get; set; }

        public Patient Patient { get; set; }
    }
}