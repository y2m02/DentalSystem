using AutoMapper;

namespace DentalSystem.Entities.Requests.AdminPassword
{
    public class AddAdminPasswordRequest
    {
        public string Password { get; set; }
        public IMapper Mapper { get; set; }
    }
}