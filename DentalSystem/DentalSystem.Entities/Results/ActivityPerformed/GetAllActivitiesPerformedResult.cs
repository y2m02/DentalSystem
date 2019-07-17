using System.Collections.Generic;

namespace DentalSystem.Entities.Results.ActivityPerformed
{
    public class GetAllActivitiesPerformedResult
    {
        public List<GetAllActivitiesPerformedResultModel> VisitActivities { get; set; }
        public List<GetAllActivitiesPerformedResultModel> PatientActivities { get; set; }
    }

    public class GetAllActivitiesPerformedResultModel
    {
        public int ActivityPerformedId { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public string Date { get; set; }
        public int InvoiceDetailId { get; set; }
    }
}