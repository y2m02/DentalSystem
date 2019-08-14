using AutoMapper;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class GetPrintingDetailsByVisitIdRequest
    {
        public int VisitId { get; set; }
        public IMapper Mapper { get; set; }
    }
}