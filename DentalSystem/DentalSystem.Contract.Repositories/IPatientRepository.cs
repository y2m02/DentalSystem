using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients(string filter, bool isFilterByName);
        Patient GetPatientInformation(int patientId);
        Patient GetPatientById(int patientId);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
    }
}