using System;
using AutoMapper;

namespace DentalSystem.Entities.Requests.Payment
{
    public class GetAllPaymentForReportRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public bool IncludeDate { get; set; }
        public IMapper Mapper { get; set; }
    }
}