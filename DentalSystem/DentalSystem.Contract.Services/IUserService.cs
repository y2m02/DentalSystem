using DentalSystem.Entities.Requests.User;
using DentalSystem.Entities.Results.User;

namespace DentalSystem.Contract.Services
{
    public interface IUserService
    {
        GetAllUserResult GetAllUser(GetAllUserRequest request);
        GetUserByUserIdResult GetUserByUserId(GetUserByUserIdRequest request);
        void AddUser(AddUserRequest request);
        void UpdateUser(UpdateUserRequest request);
        void DeleteUser(DeleteUserRequest request);
    }
}