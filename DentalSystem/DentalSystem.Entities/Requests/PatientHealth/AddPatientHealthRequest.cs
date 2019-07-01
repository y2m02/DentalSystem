namespace DentalSystem.Entities.Requests.PatientHealth
{
    public class AddPatientHealthRequest
    {
        public bool? HasBronchialAsthma { get; set; }
        public bool? HasRenalDisease { get; set; }
        public bool? HasBeenSickRecently { get; set; }
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
    }
}