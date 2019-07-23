using AutoMapper;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class GetAllAccountsReceivableByPatientIdRequest
    {
        public int PatientId { get; set; }
        public IMapper Mapper { get; set; }
    }
}