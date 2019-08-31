using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class PatientHealth
    {
        [Key,  ForeignKey("Patient")]
        public int PatientHealthId { get; set; }
        public bool? HasBronchialAsthma { get; set; }
        public bool? HasRenalDisease { get; set; }
        public bool? HasBeenSickRecently { get; set; }

        [StringLength(200)]
        public string DiseaseCause { get; set; }
        public bool? HasAllergy { get; set; }
        public bool? HeartValve { get; set; }
        public bool? IsEpileptic { get; set; }
        public bool? HasHeartMurmur { get; set; }
        public bool? HasAnemia { get; set; }
        public bool? HasDiabeticParents { get; set; }
        public bool? HasTuberculosis { get; set; }
        public bool? HasBleeding { get; set; }
        public bool? HasHepatitis { get; set; }
        public bool? HasAllergicReaction { get; set; }

        public virtual Patient Patient { get; set; }
    }
}