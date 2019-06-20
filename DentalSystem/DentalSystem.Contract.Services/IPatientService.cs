using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Entities.Requests;
using DentalSystem.Entities.Results;

namespace DentalSystem.Contract.Services
{
    public interface IPatientService
    {
        List<ListPatientsResult> GetAllPatients(IMapper iMapper);
        void AddPatient(IMapper iMapper, AddPatientRequest request);
    }
}