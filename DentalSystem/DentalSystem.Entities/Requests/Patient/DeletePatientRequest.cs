﻿using AutoMapper;

namespace DentalSystem.Entities.Requests.Patient
{
    public class DeletePatientRequest
    {
        public int PatientId { get; set; }
        public IMapper Mapper { get; set; }
    }
}