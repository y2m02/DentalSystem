using System;
using System.Collections.Generic;

namespace DentalSystem.Entities.Requests.Visit
{
    public class AddVisitRequest
    {
        public int PatientId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? HasEnded { get; set; }
        public int VisitNumber { get; set; }
        public bool HasBeenBilled { get; set; }

        public List<Models.Odontogram> Odontograms { get; set; }
    }
}