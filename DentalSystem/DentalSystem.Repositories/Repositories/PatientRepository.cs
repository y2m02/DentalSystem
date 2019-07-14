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
        public Patient GetPatientById(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var patient = context.Patients.Include(w => w.PatientHealth)
                    .FirstOrDefault(w => w.PatientId == patientId && w.DeletedOn == null);

                return patient;
            }
        }

        public void AddPatient(Patient patient)
        {
            using (var context = new DentalSystemContext())
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }
        }

        public void UpdatePatient(Patient patient)
        {
            using (var context = new DentalSystemContext())
            {
                var patientToModify = context.Patients.Include(w => w.PatientHealth)
                    .FirstOrDefault(w => w.PatientId == patient.PatientId && w.DeletedOn == null);

                if (patientToModify == null) return;

                context.Entry(patientToModify.PatientHealth).CurrentValues.SetValues(patient.PatientHealth);
                context.Entry(patientToModify).CurrentValues.SetValues(patient);
                context.SaveChanges();
            }
        }

        public void DeletePatient(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var patient = context.Patients.FirstOrDefault(w => w.PatientId == patientId && w.DeletedOn == null);

                if (patient == null) return;

                patient.DeletedOn = DateTime.Now;
                context.SaveChanges();
            }
        }

        public List<Patient> GetAllPatients(string filter, bool isFilterByName)
        {
            var patients = new List<Patient>();

            using (var context = new DentalSystemContext())
            {
                if (string.IsNullOrEmpty(filter.Trim()))

                    patients = context.Patients.Where(w => w.DeletedOn == null).Include(w => w.Visits)
                        .ToList();

                else
                    switch (isFilterByName)
                    {
                        case true:
                            patients = context.Patients
                                .Where(w => w.DeletedOn == null && w.FullName.Contains(filter.Trim()))
                                .Include(w => w.Visits).OrderBy(w => w.FullName).ToList();
                            break;

                        case false:
                            patients = context.Patients
                                .Where(w => w.DeletedOn == null && w.IdentificationCard.Contains(filter.Trim()))
                                .Include(w => w.Visits).OrderBy(w => w.FullName).ToList();
                            break;
                    }
            }
            return patients;
        }
    }
}