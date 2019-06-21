using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Results.Patient;

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

        public List<GetAllPatientsResult> GetAllPatients(IMapper iMapper)
        {
            var result = _patientRepository.GetAllPatients();
            var patients = iMapper.Map<List<GetAllPatientsResult>>(result);

            return patients;
        }

        public GetPatientByIdResult GetPatientById(IMapper iMapper, GetPatientByIdRequest request)
        {
            var result = _patientRepository.GetPatientById(request.PatientId);
            var patient = iMapper.Map<GetPatientByIdResult>(result);

            return patient;
        }

        public void UpdatePatient(IMapper iMapper, UpdatePatientRequest request)
        {
            var patient = iMapper.Map<Patient>(request);
            _patientRepository.UpdatePatient(patient);
        }

        public void DeletePatient(DeletePatientRequest request)
        {
            _patientRepository.DeletePatient(request.PatientId);
        }
    }
}