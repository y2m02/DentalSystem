﻿using System;
using System.Linq;
using AutoMapper;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Results.Patient;

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
                    y => y.MapFrom(r => r.Visits.OrderBy(w => w.VisitId).Select(w => w.CreatedOn).LastOrDefault()))
                .ForMember(w => w.PhoneNumber,
                    y => y.MapFrom(r =>
                        !string.IsNullOrEmpty(r.PhoneNumber)
                            ? Convert.ToDouble(r.PhoneNumber).ToString("(###) ###-####")
                            : ""));
            //.ForMember(w => w.IdentificationCard,
            //y => y.MapFrom(r => !string.IsNullOrEmpty(r.IdentificationCard) ? Convert.ToDouble(r.IdentificationCard).ToString("###-#######-#") : ""));

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
            CreateMap<UpdatePatientRequest, Entities.Models.Patient>();

            // UPDATE
            CreateMap<AddPatientHealthRequest, PatientHealth>();
            CreateMap<UpdatePatientHealthRequest, PatientHealth>();
        }
    }
}