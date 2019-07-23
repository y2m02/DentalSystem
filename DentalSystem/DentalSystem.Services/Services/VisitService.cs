using AutoMapper;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Visit;
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
            var visitNumber = _visitRepository.GetVisitNumber(request.PatientId);
            request.VisitNumber = visitNumber;

            var visit = iMapper.Map<Visit>(request);
            var visitResult = _visitRepository.AddVisit(visit);

            var addVisitResult = iMapper.Map<AddVisitResult>(visitResult);

            return addVisitResult;
        }

        public void EndVisit(IMapper iMapper, EndVisitRequest request)
        {
            var visit = iMapper.Map<Visit>(request);
            _visitRepository.EndVisit(visit);
        }

        public GetVisitNumberResult GetVisitNumber(GetVisitNumberRequest request)
        {
            var visitNumber = _visitRepository.GetVisitNumber(request.PatientId);

            var getVisitNumberResult = new GetVisitNumberResult
            {
                VisitNumber = visitNumber
            };

            return getVisitNumberResult;
        }
    }
}