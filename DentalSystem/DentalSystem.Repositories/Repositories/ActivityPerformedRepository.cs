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
        private readonly DentalSystemContext _context;

        public ActivityPerformedRepository(DentalSystemContext context)
        {
            _context = context;
        }

        public List<ActivityPerformed> GetAllActivitiesPerformed(int visitId)
        {
            var activities = _context.ActivitiesPerformed.Where(w => w.VisitId == visitId && w.DeletedOn == null)
                .OrderByDescending(w => w.Date).ToList();

            return activities;
        }

        public void AddActivityPerformed(ActivityPerformed activityPerformed)
        {
            _context.ActivitiesPerformed.Add(activityPerformed);
            _context.SaveChanges();
        }

        public void UpdateActivityPerformed(ActivityPerformed activityPerformed)
        {
            var activityToModify = _context.ActivitiesPerformed.FirstOrDefault(w =>
                w.ActivityPerformedId == activityPerformed.ActivityPerformedId && w.DeletedOn == null);

            if (activityToModify == null) return;

            _context.Entry(activityToModify).CurrentValues.SetValues(activityPerformed);
            _context.SaveChanges();
        }

        public void DeleteActivityPerformed(int activityPerformedId, string deletedBy)
        {
            var activity = _context.ActivitiesPerformed.FirstOrDefault(w =>
                w.ActivityPerformedId == activityPerformedId && w.DeletedOn == null);

            if (activity == null) return;

            activity.DeletedOn = DateTime.Now;
            activity.DeletedBy = deletedBy;
            _context.SaveChanges();
        }
    }
}