using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

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
            var patient = _context.Patients.Include(w => w.PatientHealth)
                .FirstOrDefault(w => w.PatientId == patientId && w.DeletedOn == null);

            return patient;
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            var patientToModify = _context.Patients.Include(w => w.PatientHealth)
                .FirstOrDefault(w => w.PatientId == patient.PatientId && w.DeletedOn == null);

            if (patientToModify != null)
            {
                patientToModify.Address = patient.Address;
                patientToModify.AdmissionDate = patient.AdmissionDate;
                patientToModify.Age = patient.Age;
                patientToModify.BirthDate = patient.BirthDate;
                patientToModify.DeletedBy = patient.DeletedBy;
                patientToModify.DeletedOn = patient.DeletedOn;
                patientToModify.FullName = patient.FullName;
                patientToModify.HasInsurancePlan = patient.HasInsurancePlan;
                patientToModify.IdentificationCard = patient.IdentificationCard;
                patientToModify.IsUrbanZone = patient.IsUrbanZone;
                patientToModify.NSS = patient.NSS;
                patientToModify.PatientHealth = patient.PatientHealth;
                patientToModify.PhoneNumber = patient.PhoneNumber;
                patientToModify.Sector = patient.Sector;
            }

            //_context.Entry(patient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePatient(int patientId, string deletedBy)
        {
            var patient = _context.Patients.FirstOrDefault(w => w.PatientId == patientId);

            if (patient == null) return;

            patient.DeletedOn = DateTime.Now;
            patient.DeletedBy = deletedBy;
            _context.SaveChanges();
        }

        //public List<Patient> GetAllPatients()
        //{
        //    var patients = _context.Patients.Where(w => w.DeletedOn == null).OrderBy(w => w.FullName).ToList();

        //    return patients;
        //}


        public List<Patient> GetAllPatients(string filter, bool isFilterByName)
        {
            var patients = new List<Patient>();

            if (string.IsNullOrEmpty(filter.Trim()))
                patients = _context.Patients.Where(w => w.DeletedOn == null).Include(w => w.Visits)
                    .OrderBy(w => w.FullName).ToList();
            else
                switch (isFilterByName)
                {
                    case true:
                        patients = _context.Patients
                            .Where(w => w.DeletedOn == null && w.FullName.Contains(filter.Trim()))
                            .Include(w => w.Visits).OrderBy(w => w.FullName).ToList();
                        break;

                    case false:
                        patients = _context.Patients
                            .Where(w => w.DeletedOn == null && w.IdentificationCard.Contains(filter.Trim()))
                            .Include(w => w.Visits).OrderBy(w => w.FullName).ToList();
                        break;
                }

            return patients;
        }
    }
}