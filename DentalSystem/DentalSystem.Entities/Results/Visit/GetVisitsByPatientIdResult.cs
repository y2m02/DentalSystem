using System;
using System.Collections.Generic;

namespace DentalSystem.Entities.Results.Visit
{
    public class GetVisitsByPatientIdResult
    {
        public List<GetVisitsByPatientIdResultModel> Visits { get; set; }
    }

    public class GetVisitsByPatientIdResultModel
    {
        public int VisitId { get; set; }
        public int VisitNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }
        public bool? HasEnded { get; set; }
        public bool HasBeenBilled { get; set; }
    }
}