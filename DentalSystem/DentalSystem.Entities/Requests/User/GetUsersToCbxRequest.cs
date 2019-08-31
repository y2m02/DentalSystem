using AutoMapper;

namespace DentalSystem.Entities.Requests.User
{
    public class GetUsersToCbxRequest
    {
        public string FullName { get; set; }
        public IMapper Mapper { get; set; }
    }
}