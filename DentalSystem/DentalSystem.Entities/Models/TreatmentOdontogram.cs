using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalSystem.Entities.Models
{
    public class TreatmentOdontogram
    {
        [Key,ForeignKey("Odontogram")] public int TreatmentOdontogramId { get; set; }
        [ForeignKey("Visit")] public int VisitId { get; set; }
        [Required] public string Information { get; set; }
        [Required] public int CavitiesQuantity { get; set; }

        public Visit Visit { get; set; }
        public Odontogram Odontogram { get; set; }
    }
}
