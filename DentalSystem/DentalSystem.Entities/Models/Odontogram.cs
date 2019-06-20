using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class Odontogram
    {
        [Key] public int OdontogramId { get; set; }

        [Required] [ForeignKey("Patient")] public int PatientId { get; set; }

        [Required] public string Information { get; set; }

        [Required] public int CavitiesQuantity { get; set; }

        public Patient Patient { get; set; }
    }
}