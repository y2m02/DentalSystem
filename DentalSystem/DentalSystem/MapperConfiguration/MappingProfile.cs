﻿using System;
using System.Linq;
using AutoMapper;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.ActivityPerformed;
using DentalSystem.Entities.Results.Patient;
using DentalSystem.Entities.Results.Visit;

//using DentalSystem.Entities.Results.Patient;

namespace DentalSystem.MapperConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // GET
            CreateMap<Entities.Models.Patient, GetAllPatientsResult>()
                .ForMember(w => w.HasInsurancePlan,
                    y => y.MapFrom(r => r.HasInsurancePlan != null ? (bool) r.HasInsurancePlan ? "Sí" : "No" : ""))
                .ForMember(w => w.AdmissionDate,
                    y => y.MapFrom(r => r.AdmissionDate != null ? r.AdmissionDate.ToShortDateString() : ""))
                .ForMember(w => w.LastVisitDate,
                    y => y.MapFrom(r =>
                        r.Visits != null && r.Visits.Count != 0
                            ? r.Visits.OrderByDescending(w => w.VisitId).Select(w => w.CreatedOn).FirstOrDefault()
                                .ToString("dd/MM/yyyy")
                            : ""))
                .ForMember(w => w.VisitHasEnded,
                    y => y.MapFrom(r =>
                        r.Visits != null && r.Visits.Count != 0
                            ? r.Visits.OrderByDescending(w => w.VisitId).Select(w => w.HasEnded).FirstOrDefault()
                            : null))
                .ForMember(w => w.VisitId,
                    y => y.MapFrom(r =>
                        r.Visits != null && r.Visits.Count != 0
                            ? r.Visits.OrderByDescending(w => w.VisitId).Select(w => w.VisitId).FirstOrDefault()
                            : 0))
                .ForMember(w => w.PhoneNumber,
                    y => y.MapFrom(r =>
                        !string.IsNullOrEmpty(r.PhoneNumber)
                            ? Convert.ToDouble(r.PhoneNumber).ToString("(###) ###-####")
                            : ""));
            //.ForMember(w => w.IdentificationCard,
            //y => y.MapFrom(r => !string.IsNullOrEmpty(r.IdentificationCard) ? Convert.ToDouble(r.IdentificationCard).ToString("###-#######-#") : ""));

            CreateMap<ActivityPerformed, GetAllActivitiesPerformedResultModel>()
                .ForMember(w => w.Date, y => y.MapFrom(r => r.Date.ToString("dd/MM/yyyy")))
                .ForMember(w => w.Section,
                    y => y.MapFrom(r =>
                        r.Section == 1 ? "Primer" : r.Section == 2 ? "Segundo" : r.Section == 3 ? "Tercer" : "Cuarto"));

            // GETBYID
            CreateMap<Entities.Models.Patient, GetPatientByIdResult>()
                .ForMember(w => w.DiseaseCause, y => y.MapFrom(r => r.PatientHealth.DiseaseCause))
                .ForMember(w => w.HasAnemia, y => y.MapFrom(r => r.PatientHealth.HasAnemia))
                .ForMember(w => w.HasAllergicReaction, y => y.MapFrom(r => r.PatientHealth.HasAllergicReaction))
                .ForMember(w => w.HasAllergy, y => y.MapFrom(r => r.PatientHealth.HasAllergy))
                .ForMember(w => w.HasBeenSickRecently, y => y.MapFrom(r => r.PatientHealth.HasBeenSickRecently))
                .ForMember(w => w.HasBleeding, y => y.MapFrom(r => r.PatientHealth.HasBleeding))
                .ForMember(w => w.HasBronchialAsthma, y => y.MapFrom(r => r.PatientHealth.HasBronchialAsthma))
                .ForMember(w => w.HasDiabeticParents, y => y.MapFrom(r => r.PatientHealth.HasDiabeticParents))
                .ForMember(w => w.HasHeartMurmur, y => y.MapFrom(r => r.PatientHealth.HasHeartMurmur))
                .ForMember(w => w.HasHepatitis, y => y.MapFrom(r => r.PatientHealth.HasHepatitis))
                .ForMember(w => w.HasRenalDisease, y => y.MapFrom(r => r.PatientHealth.HasRenalDisease))
                .ForMember(w => w.HasTuberculosis, y => y.MapFrom(r => r.PatientHealth.HasTuberculosis))
                .ForMember(w => w.HeartValve, y => y.MapFrom(r => r.PatientHealth.HeartValve))
                .ForMember(w => w.IsEpileptic, y => y.MapFrom(r => r.PatientHealth.IsEpileptic));

            // ADD
            CreateMap<AddPatientRequest, Entities.Models.Patient>();
            CreateMap<AddPatientHealthRequest, PatientHealth>();
            CreateMap<AddActivityPerformedRequest, ActivityPerformed>();
            CreateMap<AddVisitRequest, Visit>();

            // UPDATE
            CreateMap<UpdatePatientRequest, Entities.Models.Patient>();
            CreateMap<UpdatePatientHealthRequest, PatientHealth>();
            CreateMap<UpdateActivityPerformedRequest, ActivityPerformed>();
            CreateMap<EndVisitRequest, Visit>();
        }
    }
}