using AutoMapper;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class GetAccountsReceivableByPatientIdRequest
    {
        public int PatientId { get; set; }
        public IMapper Mapper { get; set; }
    }
}