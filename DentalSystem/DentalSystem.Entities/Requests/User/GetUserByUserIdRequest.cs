using AutoMapper;

namespace DentalSystem.Entities.Requests.User
{
    public class GetUserByUserIdRequest
    {
        public int UserId { get; set; }
        public IMapper Mapper { get; set; }
    }
}