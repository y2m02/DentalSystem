using System.Collections.Generic;
using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUser(string filter);
        User GetUserByUserId(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}