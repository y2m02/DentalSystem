using System;
using AutoMapper;

namespace DentalSystem.Entities.Requests.Patient
{
    public class DeletePatientRequest
    {
        public int PatientId { get; set; }
        public bool WithDateFilter { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public IMapper Mapper { get; set; }
    }
}