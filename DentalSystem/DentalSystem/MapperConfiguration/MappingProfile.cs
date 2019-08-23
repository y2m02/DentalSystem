using System;
using System.Linq;
using AutoMapper;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.ActivityPerformed;
using DentalSystem.Entities.Requests.InvoiceDetail;
using DentalSystem.Entities.Requests.Odontogram;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Entities.Requests.PlateRegistration;
using DentalSystem.Entities.Requests.TreatmentOdontogram;
using DentalSystem.Entities.Requests.Visit;
using DentalSystem.Entities.Results.AccountsReceivable;
using DentalSystem.Entities.Results.ActivityPerformed;
using DentalSystem.Entities.Results.InvoiceDetail;
using DentalSystem.Entities.Results.Odontogram;
using DentalSystem.Entities.Results.Patient;
using DentalSystem.Entities.Results.Payment;
using DentalSystem.Entities.Results.PlateRegistration;
using DentalSystem.Entities.Results.TreatmentOdontogram;
using DentalSystem.Entities.Results.Visit;

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
                    y => y.MapFrom(r => r.AdmissionDate != null ? r.AdmissionDate.ToString("d/M/yyyy") : ""))
                .ForMember(w => w.LastVisitDate,
                    y => y.MapFrom(r =>
                        r.Visits != null && r.Visits.Count != 0
                            ? r.Visits.OrderByDescending(w => w.VisitId).Select(w => w.CreatedOn).FirstOrDefault()
                                .ToString("d/M/yyyy")
                            : ""))
                .ForMember(w => w.VisitHasBeenBilled,
                    y => y.MapFrom(r =>
                        r.Visits != null && r.Visits.Count != 0 && r.Visits.OrderByDescending(w => w.VisitId)
                            .Select(w => w.HasBeenBilled).FirstOrDefault()))
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
                .ForMember(w => w.Date, y => y.MapFrom(r => r.Date.ToString("d/M/yyyy")))
                .ForMember(w => w.VisitNumber, y => y.MapFrom(r => r.Visit.VisitNumber))
                .ForMember(w => w.InvoiceDetailId, y => y.MapFrom(r => r.InvoiceDetail.InvoiceDetailId))
                .ForMember(w => w.Section,
                    y => y.MapFrom(r =>
                        r.Section == 1 ? "Primer" :
                        r.Section == 2 ? "Segundo" :
                        r.Section == 3 ? "Tercer" : "Cuarto"));

            CreateMap<InvoiceDetail, GetInvoiceDetailByVisitIdResultModel>()
                .ForMember(w => w.ActivityPerformed, y => y.MapFrom(r => r.ActivityPerformed.Description))
                .ForMember(w => w.Section,
                    y => y.MapFrom(r =>
                        r.ActivityPerformed.Section == 1 ? "Primer" :
                        r.ActivityPerformed.Section == 2 ? "Segundo" :
                        r.ActivityPerformed.Section == 3 ? "Tercer" : "Cuarto"));

            CreateMap<InvoiceDetail, GetInvoiceDetailFromOtherVisitsResultModel>()
                .ForMember(w => w.ActivityPerformed, y => y.MapFrom(r => r.ActivityPerformed.Description))
                .ForMember(w => w.VisitNumber, y => y.MapFrom(r => r.ActivityPerformed.Visit.VisitNumber))
                .ForMember(w => w.Section,
                    y => y.MapFrom(r =>
                        r.ActivityPerformed.Section == 1 ? "Primer" :
                        r.ActivityPerformed.Section == 2 ? "Segundo" :
                        r.ActivityPerformed.Section == 3 ? "Tercer" : "Cuarto"));

            CreateMap<AccountsReceivable, GetAccountsReceivableByPatientIdResultModel>()
                .ForMember(w => w.TotalPending, y => y.MapFrom(r => r.Total - r.TotalPaid))
                .ForMember(w => w.CreatedDate, y => y.MapFrom(r => r.CreatedDate.ToString("d/M/yyyy")))
                .ForMember(w => w.VisitNumber, y => y.MapFrom(r => r.Visit.VisitNumber));

            CreateMap<AccountsReceivable, GetAllAccountsReceivableByPatientIdResultModel>()
                .ForMember(w => w.TotalPending, y => y.MapFrom(r => r.Total - r.TotalPaid))
                .ForMember(w => w.CreatedDate, y => y.MapFrom(r => r.CreatedDate.ToString("d/M/yyyy")))
                .ForMember(w => w.VisitNumber, y => y.MapFrom(r => r.Visit.VisitNumber));

            CreateMap<Payment, GetPaymentsByAccountReceivableIdResultModel>()
                .ForMember(w => w.PaymentDate, y => y.MapFrom(r => r.PaymentDate.ToString("d/M/yyyy")));

            CreateMap<Visit, GetVisitsByPatientIdResultModel>()
                .ForMember(w => w.CreatedOn, y => y.MapFrom(r => r.CreatedOn.ToString("d/M/yyyy")))
                .ForMember(w => w.Status,
                    y => y.MapFrom(r =>
                        r.HasEnded != null ? (bool) r.HasEnded ? "Finalizada" : "En progreso" : "En progreso"));

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

            CreateMap<PlateRegistration, GetPlateRegistrationByPatientIdResult>();

            CreateMap<Entities.Models.Odontogram, GetOdontogramByVisitIdResultModel>()
                .ForMember(w => w.HasInformation, y => y.MapFrom(r => !string.IsNullOrEmpty(r.Information)));

            CreateMap<AccountsReceivable, GetPrintingDetailsByVisitIdResultModel>()
                .ForMember(w => w.VisitNumber, y => y.MapFrom(r => r.Visit.VisitNumber))
                .ForMember(w => w.VisitDate, y => y.MapFrom(r => r.Visit.CreatedOn.ToString("d/M/yyyy")))
                .ForMember(w => w.TotalPending, y => y.MapFrom(r => r.Total - r.TotalPaid));

            CreateMap<TreatmentOdontogram, GetTreatmentOdontogramByOdontogramIdResultModel>()
                .ForMember(w => w.HasInformation, y => y.MapFrom(r => !string.IsNullOrEmpty(r.Information)));
            // ADD
            CreateMap<AddPatientRequest, Entities.Models.Patient>()
                .ForMember(w => w.PlateRegistration, y => y.MapFrom(r => new PlateRegistration()));
            CreateMap<AddPatientHealthRequest, PatientHealth>();
            CreateMap<AddActivityPerformedRequest, ActivityPerformed>();
            CreateMap<AddVisitRequest, Visit>();
            CreateMap<AddInvoiceDetailRequest, InvoiceDetail>();
            CreateMap<AddAccountsReceivableRequest, AccountsReceivable>();
            CreateMap<AddPaymentRequest, Payment>();
            CreateMap<AddOdontogramRequest, Entities.Models.Odontogram>();
            CreateMap<AddTreatmentOdontogramRequest, TreatmentOdontogram>();

            CreateMap<Visit, AddVisitResult>();


            // UPDATE
            CreateMap<UpdatePatientRequest, Entities.Models.Patient>();
            CreateMap<UpdatePatientHealthRequest, PatientHealth>();
            CreateMap<UpdateActivityPerformedRequest, ActivityPerformed>();
            CreateMap<EndVisitRequest, Visit>();
            CreateMap<UpdateInvoiceDetailRequest, InvoiceDetail>();
            CreateMap<UpdateTotalPaidRequest, AccountsReceivable>();
            CreateMap<SetVisitAsBilledRequest, Visit>();
            CreateMap<UpdatePlateRegistrationRequest, PlateRegistration>();
            CreateMap<UpdateOdontogramRequest, Entities.Models.Odontogram>();
            CreateMap<UpdateTreatmentOdontogramRequest, TreatmentOdontogram>();

            //DELETE
            CreateMap<DeletePaymentRequest, Payment>();
        }
    }
}