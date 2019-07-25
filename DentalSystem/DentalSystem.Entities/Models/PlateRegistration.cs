using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class PlateRegistration
    {
        [Key] [ForeignKey("Patient")] public int PlateRegistrationId { get; set; }

        [StringLength(30)]
        public string PDB { get; set; }
        [StringLength(30)]
        public string N16 { get; set; }
        [StringLength(30)]
        public string N11 { get; set; }
        [StringLength(30)]
        public string N26 { get; set; }
        [StringLength(30)]
        public string N36 { get; set; }
        [StringLength(30)]
        public string N32 { get; set; }
        [StringLength(30)]
        public string N46 { get; set; }
        [StringLength(30)]
        public string CT { get; set; }
        [StringLength(30)]
        public string X { get; set; }
        [StringLength(400)]
        public string RadiographicInterpretation { get; set; }

        public virtual Patient Patient { get; set; }
    }
}