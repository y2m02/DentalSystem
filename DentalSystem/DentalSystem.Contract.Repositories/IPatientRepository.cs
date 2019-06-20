using DentalSystem.Entities.Models;
using System.Collections.Generic;

namespace DentalSystem.Contract.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(int patientId);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
    }
}