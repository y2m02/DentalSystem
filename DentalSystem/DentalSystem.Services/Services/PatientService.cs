using AutoMapper;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests;
using DentalSystem.Entities.Results;
using System;
using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void AddPatient(IMapper iMapper, AddPatientRequest request)
        {
            var patient = iMapper.Map<Patient>(request);
            _patientRepository.AddPatient(patient);
        }

        public List<ListPatientsResult> GetAllPatients(IMapper iMapper)
        {
            var result = _patientRepository.GetAllPatients();
            var patients = iMapper.Map<List<ListPatientsResult>>(result);

            return patients;
        }
    }
}