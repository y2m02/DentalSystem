﻿using System;

namespace DentalSystem.Entities.Requests
{
    public class AddPatientRequest
    {
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Sector { get; set; }
        public bool IsUrbanZone { get; set; }
        public bool HasInsurancePlan { get; set; }
        // ReSharper disable once InconsistentNaming
        public string NSS { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}