using System.Collections.Generic;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.User;
using DentalSystem.Entities.Results.User;

namespace DentalSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public GetAllUserResult GetAllUser(GetAllUserRequest request)
        {
            var result = _userRepository.GetAllUser(request.SearchParameter);
            var users = request.Mapper.Map<List<GetAllUserResultModel>>(result);

            var getAllUserResult = new GetAllUserResult
            {
                UserList = users
            };

            return getAllUserResult;
        }

        public GetUsersToCbxResult GetUsersToCbx(GetUsersToCbxRequest request)
        {
            var result = _userRepository.GetUsersToCbx(request.FullName);
            var users = request.Mapper.Map<List<GetUsersToCbxResultModel>>(result);

            var getUsersToCbxResult = new GetUsersToCbxResult
            {
                UserList = users
            };

            return getUsersToCbxResult;
        }

        public GetUserByUserIdResult GetUserByUserId(GetUserByUserIdRequest request)
        {
            var result = _userRepository.GetUserByUserId(request.UserId);
            var user = request.Mapper.Map<GetUserByUserIdResultModel>(result);

            var getUserByUserIdResult = new GetUserByUserIdResult
            {
                UserModel = user
            };

            return getUserByUserIdResult;
        }

        public void AddUser(AddUserRequest request)
        {
            var user = request.Mapper.Map<User>(request);
            _userRepository.AddUser(user);
        }

        public void UpdateUser(UpdateUserRequest request)
        {
            var user = request.Mapper.Map<User>(request);
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(DeleteUserRequest request)
        {
            var user = request.Mapper.Map<User>(request);
            _userRepository.DeleteUser(user);
        }
    }
}