using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Results.ActivityPerformed;

namespace DentalSystem.Contract.Services
{
    public interface IActivityPerformedService
    {
        List<GetAllActivitiesPerformedResult> GetAllActivitiesPerformed(IMapper iMapper, GetAllActivitiesPerformedRequest request);
        void AddActivityPerformed(IMapper iMapper, AddActivityPerformedRequest request);
        void UpdateActivityPerformed(IMapper iMapper, UpdateActivityPerformedRequest request);
        void DeleteActivityPerformed(DeleteActivityPerformedRequest request);
    }
}