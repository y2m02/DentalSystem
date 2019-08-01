using System;
using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Results.Patient;

namespace DentalSystem.Contract.Services
{
    public interface IPatientService
    {
        List<GetAllPatientsResult> GetAllPatients(IMapper iMapper, string filter, bool isFilterByName, DateTime? from, DateTime? to);
        GetPatientByIdResult GetPatientById(IMapper iMapper, GetPatientByIdRequest request);
        GetPatientInformationResult GetPatientInformation(GetPatientInformationRequest request);
        List<GetAllPatientsResult> AddPatient(AddPatientRequest request);
        void UpdatePatient(IMapper iMapper, UpdatePatientRequest request);
        List<GetAllPatientsResult> DeletePatient(DeletePatientRequest request);
    }
}