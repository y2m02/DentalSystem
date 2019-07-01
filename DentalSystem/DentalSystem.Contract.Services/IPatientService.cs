using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Results.Patient;

namespace DentalSystem.Contract.Services
{
    public interface IPatientService
    {
        List<GetAllPatientsResult> GetAllPatients(IMapper iMapper, string filter, bool isFilterByName);
        GetPatientByIdResult GetPatientById(IMapper iMapper, GetPatientByIdRequest request);
        void AddPatient(IMapper iMapper, AddPatientRequest request);
        void UpdatePatient(IMapper iMapper, UpdatePatientRequest request);
        void DeletePatient(DeletePatientRequest request);
    }
}