using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients(string filter, bool isFilterByName);
        Patient GetPatientById(int patientId);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId, string deletedBy);
    }
}