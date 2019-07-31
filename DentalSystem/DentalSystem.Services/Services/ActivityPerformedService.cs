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

        public GetAllActivitiesPerformedResult GetAllActivitiesPerformed(GetAllActivitiesPerformedRequest request)
        {
            var result = _activityPerformedRepository.GetAllActivitiesPerformed(request.VisitId);
            var visitActivities = request.Mapper.Map<List<GetAllActivitiesPerformedResultModel>>(result);

            var getAllActivitiesPerformedResult = new GetAllActivitiesPerformedResult
            {
                VisitActivities = visitActivities
            };

            return getAllActivitiesPerformedResult;
        }

        public GetAllActivitiesPerformedResult GetOtherVisitActivitiesPerformed(GetAllActivitiesPerformedRequest request)
        {
           var result = _activityPerformedRepository.GetAllActivitiesPerformedByPatientId(request.PatientId,
                request.VisitId);
            var patientActivities = request.Mapper.Map<List<GetAllActivitiesPerformedResultModel>>(result);

            var getAllActivitiesPerformedResult = new GetAllActivitiesPerformedResult
            {
                PatientActivities = patientActivities
            };

            return getAllActivitiesPerformedResult;
        }

        public GetAllActivitiesPerformedResult AddActivityPerformed(AddActivityPerformedRequest request)
        {
            var activityPerformed = request.Mapper.Map<ActivityPerformed>(request);
            _activityPerformedRepository.AddActivityPerformed(activityPerformed);

            var result = _activityPerformedRepository.GetAllActivitiesPerformed(request.VisitId);
            var visitActivities = request.Mapper.Map<List<GetAllActivitiesPerformedResultModel>>(result);

            var getAllActivitiesPerformedResult = new GetAllActivitiesPerformedResult
            {
                VisitActivities = visitActivities
            };

            return getAllActivitiesPerformedResult;
        }

        public GetAllActivitiesPerformedResult UpdateActivityPerformed(UpdateActivityPerformedRequest request)
        {
            var activity = request.Mapper.Map<ActivityPerformed>(request);
            _activityPerformedRepository.UpdateActivityPerformed(activity);

            var result = _activityPerformedRepository.GetAllActivitiesPerformed(request.VisitId);
            var visitActivities = request.Mapper.Map<List<GetAllActivitiesPerformedResultModel>>(result);

            var getAllActivitiesPerformedResult = new GetAllActivitiesPerformedResult
            {
                VisitActivities = visitActivities
            };

            return getAllActivitiesPerformedResult;
        }

        public GetAllActivitiesPerformedResult DeleteActivityPerformed(DeleteActivityPerformedRequest request)
        {
            _activityPerformedRepository.DeleteActivityPerformed(request.ActivityPerformedId);
            _invoiceDetailRepository.DeleteInvoiceDetail(request.InvoiceDetailId);

            var result = _activityPerformedRepository.GetAllActivitiesPerformed(request.VisitId);
            var visitActivities = request.Mapper.Map<List<GetAllActivitiesPerformedResultModel>>(result);

            var getAllActivitiesPerformedResult = new GetAllActivitiesPerformedResult
            {
                VisitActivities = visitActivities
            };

            return getAllActivitiesPerformedResult;
        }
    }
}