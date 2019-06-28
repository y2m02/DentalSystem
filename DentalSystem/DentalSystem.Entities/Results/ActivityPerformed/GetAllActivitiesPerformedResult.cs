using System;

namespace DentalSystem.Entities.Results.ActivityPerformed
{
    public class GetAllActivitiesPerformedResult
    {
        public int ActivityPerformedId { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public string Date { get; set; }
   
    }
}