using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class TreatmentOdontogram
    {
        [Key] [ForeignKey("Odontogram")] public int TreatmentOdontogramId { get; set; }
        public string Information { get; set; }
        [Required] public int CavitiesQuantity { get; set; }

        public Odontogram Odontogram { get; set; }
    }
}