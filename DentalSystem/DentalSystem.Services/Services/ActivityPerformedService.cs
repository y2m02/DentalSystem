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
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public ActivityPerformedService(IActivityPerformedRepository activityPerformedRepository,
            IInvoiceDetailRepository invoiceDetailRepository)
        {
            _activityPerformedRepository = activityPerformedRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public GetAllActivitiesPerformedResult GetAllActivitiesPerformed(IMapper iMapper,
            GetAllActivitiesPerformedRequest request)
        {
            var result = _activityPerformedRepository.GetAllActivitiesPerformed(request.VisitId);
            var visitActivities = iMapper.Map<List<GetAllActivitiesPerformedResultModel>>(result);

            result = _activityPerformedRepository.GetAllActivitiesPerformedByPatientId(request.PatientId,
                request.VisitId);
            var patientActivities = iMapper.Map<List<GetAllActivitiesPerformedResultModel>>(result);

            var getAllActivitiesPerformedResult = new GetAllActivitiesPerformedResult
            {
                VisitActivities = visitActivities,
                PatientActivities = patientActivities
            };

            return getAllActivitiesPerformedResult;
        }

        public void AddActivityPerformed(IMapper iMapper, AddActivityPerformedRequest request)
        {
            var activityPerformed = iMapper.Map<ActivityPerformed>(request);
            _activityPerformedRepository.AddActivityPerformed(activityPerformed);
        }

        public void UpdateActivityPerformed(IMapper iMapper, UpdateActivityPerformedRequest request)
        {
            var activity = iMapper.Map<ActivityPerformed>(request);
            _activityPerformedRepository.UpdateActivityPerformed(activity);
        }

        public void DeleteActivityPerformed(DeleteActivityPerformedRequest request)
        {
            _activityPerformedRepository.DeleteActivityPerformed(request.ActivityPerformedId);
            _invoiceDetailRepository.DeleteInvoiceDetail(request.InvoiceDetailId);
        }
    }
}