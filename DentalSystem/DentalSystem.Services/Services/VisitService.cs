using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.Patient;
using DentalSystem.Entities.Results.Visit;

namespace DentalSystem.Services.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;

        public VisitService(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public AddVisitResult AddVisit(IMapper iMapper, AddVisitRequest request)
        {
            var visit = iMapper.Map<Visit>(request);
            var visitId = _visitRepository.AddVisit(visit);

            var addVisitResult = new AddVisitResult
            {
                VisitId = visitId
            };

            return addVisitResult;
        }

        public void EndVisit(IMapper iMapper, EndVisitRequest request)
        {
            var visit = iMapper.Map<Visit>(request);
           _visitRepository.EndVisit(visit);
        }
    }
}