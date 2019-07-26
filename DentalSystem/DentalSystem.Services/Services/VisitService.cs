using System;
using System.Collections.Generic;
using AutoMapper;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.Odontogram;
using DentalSystem.Entities.Results.Visit;

namespace DentalSystem.Services.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IOdontogramRepository _odontogramRepository;

        public VisitService(IVisitRepository visitRepository, IOdontogramRepository odontogramRepository)
        {
            _visitRepository = visitRepository;
            _odontogramRepository = odontogramRepository;
        }

        public AddVisitResult AddVisit(IMapper iMapper, AddVisitRequest request)
        {
            var lastVisitId = _visitRepository.GetVisitId(request.PatientId);

            List<Odontogram> odontograms;
            if (lastVisitId > 0)
            {
                var result = _odontogramRepository.GetOdontogramByVisitId(lastVisitId);

                if (result == null)
                {
                    odontograms = new List<Odontogram>
                    {
                        new Odontogram
                        {
                            CavitiesQuantity = 0,
                            Information = string.Empty,
                            TreatmentOdontogram = new TreatmentOdontogram()
                            {
                                Information = string.Empty,
                                CavitiesQuantity = 0
                            }
                        }
                    };
                }
                else
                {
                    odontograms = new List<Odontogram>
                    {
                        new Odontogram
                        {
                            CavitiesQuantity = result.CavitiesQuantity,
                            Information = result.Information,
                            TreatmentOdontogram = result.TreatmentOdontogram
                        }
                    };
                }
            }
            else
            {
                odontograms = new List<Odontogram>
                {
                    new Odontogram
                    {
                        CavitiesQuantity = 0,
                        Information = string.Empty,
                        TreatmentOdontogram = new TreatmentOdontogram
                        {
                            Information = string.Empty,
                            CavitiesQuantity = 0
                        }
                    }
                };
            }

            var visitNumber = _visitRepository.GetVisitNumber(request.PatientId);
            request.VisitNumber = visitNumber;

            var visit = iMapper.Map<Visit>(request);
            visit.Odontograms = odontograms;
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

        public GetVisitsByPatientIdResult GetVisitsByPatientId(GetVisitsByPatientIdRequest request)
        {
            var result = _visitRepository.GetVisitsByPatientId(request.PatientId);
            var visits = request.Mapper.Map<List<GetVisitsByPatientIdResultModel>>(result);

            var getVisitsByPatientIdResult = new GetVisitsByPatientIdResult
            {
                Visits = visits
            };
            return getVisitsByPatientIdResult;
        }
    }
}