using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class Odontogram
    {
        [Key,ForeignKey("Visit")] public int OdontogramId { get; set; }
        //[Required] [ForeignKey("Visit")] public int VisitId { get; set; }
        [Required] public string Information { get; set; }
        [Required] public int CavitiesQuantity { get; set; }

        public Visit Visit { get; set; }
    }
}