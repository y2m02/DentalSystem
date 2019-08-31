using System;
using AutoMapper;

namespace DentalSystem.Entities.Requests.User
{
    public class DeleteUserRequest
    {
        public int UserId { get; set; }
        public DateTime? DeletedOn { get; set; }
        public IMapper Mapper { get; set; }
    }
}