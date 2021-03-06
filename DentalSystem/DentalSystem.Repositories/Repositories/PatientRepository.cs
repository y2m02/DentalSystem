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
        public Patient GetPatientInformation(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var patient = context.Patients
                    .Include(w => w.Visits)
                    .Include(w => w.Visits.Select(c => c.Odontograms))
                    .Include(w => w.Visits.Select(c => c.Odontograms.Select(x => x.TreatmentOdontogram)))
                    .Include(w => w.Visits.Select(c => c.ActivitiesPerformed))
                    .Include(w => w.Visits.Select(c => c.ActivitiesPerformed.Select(x => x.InvoiceDetail)))
                    .Include(w => w.Visits.Select(c => c.ActivitiesPerformed.Select(x => x.User)))
                    .Include(w => w.PatientHealth)
                    .Include(w => w.PlateRegistration)
                    .FirstOrDefault(w => w.PatientId == patientId && w.DeletedOn == null);

                return patient;
            }
        }

        public Patient GetPatientById(int patientId)
        {
            using (var context = new DentalSystemContext())
            {
                var patient = context.Patients.Include(w => w.PatientHealth).Include(w => w.PlateRegistration)
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

        public List<Patient> GetAllPatients(string filter, bool isFilterByName, DateTime? from, DateTime? to)
        {
            using (var context = new DentalSystemContext())
            {
                IEnumerable<Patient> patients = new List<Patient>();
                if (string.IsNullOrEmpty(filter.Trim()))
                    patients = context.Patients.Where(w => w.DeletedOn == null).Include(w => w.Visits);
                else
                    switch (isFilterByName)
                    {
                        case true:
                            patients = context.Patients
                                .Where(w => w.DeletedOn == null && w.FullName.Contains(filter.Trim()))
                                .Include(w => w.Visits);
                            break;

                        case false:
                            patients = context.Patients
                                .Where(w => w.DeletedOn == null && w.IdentificationCard.Contains(filter.Trim()))
                                .Include(w => w.Visits);
                            break;
                    }

                var patientToShow = from == null
                    ? patients
                    : patients.Where(w =>
                        w.AdmissionDate.Date <= Convert.ToDateTime(to).Date &&
                        w.AdmissionDate.Date >= Convert.ToDateTime(from).Date);

                return patientToShow.OrderBy(w => w.FullName).ToList();
            }
        }
    }
}