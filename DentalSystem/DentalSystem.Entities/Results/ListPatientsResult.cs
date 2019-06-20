﻿using System;

namespace DentalSystem.Entities.Results
{
    public class ListPatientsResult
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Sector { get; set; }
        public bool HasInsurancePlan { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}