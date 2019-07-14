using System;

namespace DentalSystem.Entities.Requests.ActivityPerformed
{
    public class AddActivityPerformedRequest
    {
        public string Responsable { get; set; }
        public int VisitId { get; set; }
        public int Section { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}