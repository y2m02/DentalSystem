using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Results.ActivityPerformed;

namespace DentalSystem.Services.Services
{
    public class ActivityPerformedService : IActivityPerformedService
    {
        private readonly IActivityPerformedRepository _activityPerformedRepository;

        public ActivityPerformedService(IActivityPerformedRepository activityPerformedRepository)
        {
            _activityPerformedRepository = activityPerformedRepository;
        }

        public List<GetAllActivitiesPerformedResult> GetAllActivitiesPerformed(IMapper iMapper, GetAllActivitiesPerformedRequest request)
        {
            var result = _activityPerformedRepository.GetAllActivitiesPerformed(request.VisitId);
            var activities = iMapper.Map<List<GetAllActivitiesPerformedResult>>(result);

            return activities;
        }

        public void AddActivityPerformed(IMapper iMapper, AddActivityPerformedRequest request)
        {
            var patient = iMapper.Map<ActivityPerformed>(request);
            _activityPerformedRepository.AddActivityPerformed(patient);
        }

        public void UpdateActivityPerformed(IMapper iMapper, UpdateActivityPerformedRequest request)
        {
            var activity = iMapper.Map<ActivityPerformed>(request);
            _activityPerformedRepository.UpdateActivityPerformed(activity);
        }

        public void DeleteActivityPerformed(DeleteActivityPerformedRequest request)
        {
            _activityPerformedRepository.DeleteActivityPerformed(request.ActivityPerformedId, request.DeletedBy);
        }
    }
}