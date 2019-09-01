using AutoMapper;

namespace DentalSystem.Entities.Requests.AdminPassword
{
    public class UpdatePasswordRequest
    {
        public int PasswordId { get; set; }
        public string Password { get; set; }
        public IMapper Mapper { get; set; }
    }
}