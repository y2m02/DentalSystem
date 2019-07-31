using System.Collections.Generic;
using DentalSystem.Entities.Results.ActivityPerformed;
using DentalSystem.Entities.Results.InvoiceDetail;
using DentalSystem.Entities.Results.Odontogram;
using DentalSystem.Entities.Results.PlateRegistration;
using DentalSystem.Entities.Results.TreatmentOdontogram;

namespace DentalSystem.Entities.Results.Patient
{
    public class GetPatientInformationResult
    {
        public GetPatientByIdResult PatientInformation { get; set; }
        public GetOdontogramByVisitIdResultModel Odontogram { get; set; }
        public GetTreatmentOdontogramByOdontogramIdResultModel TreatmentOdontogram { get; set; }
        public List<GetAllActivitiesPerformedResultModel> VisitActivities { get; set; }
        public GetPlateRegistrationByPatientIdResult PlateRegistration { get; set; }
    }
}