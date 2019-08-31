using AutoMapper;

namespace DentalSystem.Entities.Requests.User
{
    public class UpdateUserRequest
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public IMapper Mapper { get; set; }
    }
}