using System;
using DentalSystem.Entities.Requests.PatientHealth;

namespace DentalSystem.Entities.Requests.Patient
{
    public class UpdatePatientRequest
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public int? Age { get; set; }
        public char? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Sector { get; set; }
        public bool? IsUrbanZone { get; set; }
        public bool? HasInsurancePlan { get; set; }
        // ReSharper disable once InconsistentNaming
        public string NSS { get; set; }
        public DateTime AdmissionDate { get; set; }

        public UpdatePatientHealthRequest PatientHealth { get; set; }
    }
}