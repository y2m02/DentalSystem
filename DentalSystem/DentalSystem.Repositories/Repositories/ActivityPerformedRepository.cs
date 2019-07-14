using System;
using System.Collections.Generic;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class ActivityPerformedRepository : IActivityPerformedRepository
    {
        public List<ActivityPerformed> GetAllActivitiesPerformed(int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var activities = context.ActivitiesPerformed.Where(w => w.VisitId == visitId && w.DeletedOn == null)
                    .OrderByDescending(w => w.ActivityPerformedId).ToList();

                return activities;
            }
        }

        public void AddActivityPerformed(ActivityPerformed activityPerformed)
        {
            using (var context = new DentalSystemContext())
            {
                context.ActivitiesPerformed.Add(activityPerformed);
                context.SaveChanges();
            }
        }

        public void UpdateActivityPerformed(ActivityPerformed activityPerformed)
        {
            using (var context = new DentalSystemContext())
            {
                var activityToModify = context.ActivitiesPerformed.FirstOrDefault(w =>
                    w.ActivityPerformedId == activityPerformed.ActivityPerformedId && w.DeletedOn == null);

                if (activityToModify == null) return;

                context.Entry(activityToModify).CurrentValues.SetValues(activityPerformed);
                context.SaveChanges();
            }
        }

        public void DeleteActivityPerformed(int activityPerformedId)
        {
            using (var context = new DentalSystemContext())
            {
                var activity = context.ActivitiesPerformed.FirstOrDefault(w =>
                    w.ActivityPerformedId == activityPerformedId && w.DeletedOn == null);

                if (activity == null) return;

                activity.DeletedOn = DateTime.Now;
                context.SaveChanges();
            }
        }

        public List<ActivityPerformed> GetAllActivitiesPerformedByPatientId(int patientId, int visitId)
        {
            using (var context = new DentalSystemContext())
            {
                var activities = context.ActivitiesPerformed.Where(w =>
                        w.Visit.Patient.PatientId == patientId && w.VisitId != visitId && w.DeletedOn == null)
                    .OrderByDescending(w => w.ActivityPerformedId).ToList();

                return activities;
            }
        }
    }
}