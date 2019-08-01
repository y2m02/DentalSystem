using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Results.ActivityPerformed;
using DentalSystem.Entities.Results.Odontogram;
using DentalSystem.Entities.Results.Patient;
using DentalSystem.Entities.Results.PlateRegistration;
using DentalSystem.Entities.Results.TreatmentOdontogram;

namespace DentalSystem.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        //public void AddPatient(IMapper iMapper, AddPatientRequest request)
        //{
        //    var patient = iMapper.Map<Patient>(request);
        //    _patientRepository.AddPatient(patient);
        //}

        public List<GetAllPatientsResult> GetAllPatients(IMapper iMapper, string filter, bool isFilterByName,
            DateTime? from, DateTime? to)
        {
            var result = _patientRepository.GetAllPatients(filter, isFilterByName, from, to);
            var patients = iMapper.Map<List<GetAllPatientsResult>>(result);

            return patients;
        }

        public GetPatientByIdResult GetPatientById(IMapper iMapper, GetPatientByIdRequest request)
        {
            var result = _patientRepository.GetPatientById(request.PatientId);
            var patient = iMapper.Map<GetPatientByIdResult>(result);

            return patient;
        }

        public GetPatientInformationResult GetPatientInformation(GetPatientInformationRequest request)
        {
            var result = _patientRepository.GetPatientInformation(request.PatientId);
            var patient = request.Mapper.Map<GetPatientByIdResult>(result);
            var plateRegistration = request.Mapper.Map<GetPlateRegistrationByPatientIdResult>(result.PlateRegistration);
            var activities = request.Mapper.Map<List<GetAllActivitiesPerformedResultModel>>(result.Visits
                .FirstOrDefault(w => w.VisitId == request.VisitId)?.ActivitiesPerformed);
            var odontogram = request.Mapper.Map<GetOdontogramByVisitIdResultModel>(result.Visits
                .FirstOrDefault(w => w.VisitId == request.VisitId)?.Odontograms.OrderByDescending(w => w.OdontogramId)
                .FirstOrDefault());
            var treatmentOdontogram = request.Mapper.Map<GetTreatmentOdontogramByOdontogramIdResultModel>(result.Visits
                .FirstOrDefault(w => w.VisitId == request.VisitId)?.Odontograms.OrderByDescending(w => w.OdontogramId)
                .FirstOrDefault()?.TreatmentOdontogram);

            var getPatientInformationResult = new GetPatientInformationResult
            {
                PatientInformation = patient,
                Odontogram = odontogram,
                TreatmentOdontogram = treatmentOdontogram,
                VisitActivities = activities,
                PlateRegistration = plateRegistration
            };

            return getPatientInformationResult;
        }

        public List<GetAllPatientsResult> AddPatient(AddPatientRequest request)
        {
            var patient = request.Mapper.Map<Patient>(request);
            _patientRepository.AddPatient(patient);

            var result = request.WithDateFilter ? _patientRepository.GetAllPatients("", false, request.From, request.To) :
                _patientRepository.GetAllPatients("", false, null, null);
            var patients = request.Mapper.Map<List<GetAllPatientsResult>>(result);

            return patients;
        }

        public void UpdatePatient(IMapper iMapper, UpdatePatientRequest request)
        {
            var patient = iMapper.Map<Patient>(request);
            _patientRepository.UpdatePatient(patient);
        }

        //public void DeletePatient(DeletePatientRequest request)
        //{
        //    _patientRepository.DeletePatient(request.PatientId);
        //}

        public List<GetAllPatientsResult> DeletePatient(DeletePatientRequest request)
        {
            _patientRepository.DeletePatient(request.PatientId);

            var result = request.WithDateFilter ? _patientRepository.GetAllPatients("", false, request.From, request.To):
             _patientRepository.GetAllPatients("", false, null, null);
            var patients = request.Mapper.Map<List<GetAllPatientsResult>>(result);

            return patients;
        }
    }
}