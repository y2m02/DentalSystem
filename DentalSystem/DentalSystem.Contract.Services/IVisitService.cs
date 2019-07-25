using AutoMapper;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.Visit;

namespace DentalSystem.Contract.Services
{
    public interface IVisitService
    {
        AddVisitResult AddVisit(IMapper iMapper, AddVisitRequest request);
        void EndVisit(IMapper iMapper, EndVisitRequest request);
        GetVisitNumberResult GetVisitNumber(GetVisitNumberRequest request);
        GetVisitsByPatientIdResult GetVisitsByPatientId(GetVisitsByPatientIdRequest request);
    }
}