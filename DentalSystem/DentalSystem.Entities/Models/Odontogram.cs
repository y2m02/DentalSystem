using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class Odontogram
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OdontogramId { get; set; }
        [ForeignKey("Visit")] public int VisitId { get; set; }
        public string Information { get; set; }
        [Required] public int CavitiesQuantity { get; set; }

        public Visit Visit { get; set; }
        public TreatmentOdontogram TreatmentOdontogram { get; set; }
    }
}