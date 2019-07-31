using System;
using AutoMapper;

namespace DentalSystem.Entities.Requests.ActivityPerformed
{
    public class UpdateActivityPerformedRequest
    {
        public int ActivityPerformedId { get; set; }
        public string Responsable { get; set; }
        public int VisitId { get; set; }
        public int Section { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public IMapper Mapper { get; set; }
    }
}