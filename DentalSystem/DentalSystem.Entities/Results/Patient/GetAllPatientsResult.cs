using System;

namespace DentalSystem.Entities.Results.Patient
{
    public class GetAllPatientsResult
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string HasInsurancePlan { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string LastVisitDate { get; set; }
        public bool? VisitHasEnded { get; set; }
        public int VisitId { get; set; }
    }
}