using System;
using AutoMapper;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class GetAllAccountReceivableForReportRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public IMapper Mapper { get; set; }
    }
}