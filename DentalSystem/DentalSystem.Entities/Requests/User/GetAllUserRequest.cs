using AutoMapper;

namespace DentalSystem.Entities.Requests.User
{
    public class GetAllUserRequest
    {
        public string SearchParameter { get; set; }
        public IMapper Mapper { get; set; }
    }
}