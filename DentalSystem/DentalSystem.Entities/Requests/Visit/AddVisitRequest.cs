using System;

namespace DentalSystem.Entities.Requests.Visit
{
    public class AddVisitRequest
    {
        public int PatientId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? HasEnded { get; set; }
    }
}