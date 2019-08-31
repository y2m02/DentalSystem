using System.Collections.Generic;

namespace DentalSystem.Entities.Results.User
{
    public class GetAllUserResult
    {
        public List<GetAllUserResultModel> UserList { get; set; }
    }

    public class GetAllUserResultModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}