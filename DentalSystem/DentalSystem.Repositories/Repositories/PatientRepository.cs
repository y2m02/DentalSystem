using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace DentalSystem.Repositories.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DentalSystemContext _context;

        public PatientRepository(DentalSystemContext context)
        {
            _context = context;
        }

        public Patient GetPatientById(int patientId)
        {
            throw new System.NotImplementedException();
        }

        public void AddPatient(Patient patient)
        {
           _context.Patients.Add(patient);
           _context.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePatient(int patientId)
        {
            throw new System.NotImplementedException();
        }

        public List<Patient> GetAllPatients()
        {
            var patients = _context.Patients.ToList();

            return patients;
        }
    }
}