using System.Collections.Generic;

namespace DentalSystem.Entities.Results.User
{
    public class GetUsersToCbxResult
    {
        public List<GetUsersToCbxResultModel> UserList { get; set; }
    }
    public class GetUsersToCbxResultModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
    }
}