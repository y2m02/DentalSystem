﻿using System;

namespace DentalSystem.Entities.Requests.Patient
{
    public class DeletePatientRequest
    {
        public int PatientId { get; set; }
        public string DeletedBy { get; set; }
    }
}