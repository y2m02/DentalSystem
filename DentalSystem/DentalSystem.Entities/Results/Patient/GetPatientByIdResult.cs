using System;
using DentalSystem.Entities.Results.PlateRegistration;

namespace DentalSystem.Entities.Results.Patient
{
    public class GetPatientByIdResult
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Sector { get; set; }
        public bool? IsUrbanZone { get; set; }
        public bool? HasInsurancePlan { get; set; }
        // ReSharper disable once InconsistentNaming
        public string NSS { get; set; }
        public DateTime AdmissionDate { get; set; }

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

        //public GetPlateRegistrationByPatientIdResult PlateRegistration { get; set; }
    }
}