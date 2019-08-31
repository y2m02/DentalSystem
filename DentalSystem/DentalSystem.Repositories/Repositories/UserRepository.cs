using System.Collections.Generic;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUser(string filter)
        {
            using (var context = new DentalSystemContext())
            {
                IEnumerable<User> users;

                if (string.IsNullOrEmpty(filter.Trim()))
                    users = context.Users.Where(w => w.DeletedOn == null);
                else
                    users = context.Users
                        .Where(w => w.DeletedOn == null &&
                                    (w.FullName.Contains(filter.Trim()) ||
                                     w.IdentificationCard.Contains(filter.Trim())));


                return users.OrderBy(w => w.FullName).ToList();
            }
        }

        public List<User> GetUsersToCbx(string fullName)
        {
            using (var context = new DentalSystemContext())
            {
                var users = context.Users.Where(w =>
                    w.DeletedOn == null || w.DeletedOn == null && w.FullName == fullName);


                return users.OrderBy(w => w.FullName).ToList();
            }
        }

        public User GetUserByUserId(int userId)
        {
            using (var context = new DentalSystemContext())
            {
                var user = context.Users.FirstOrDefault(w => w.DeletedOn == null);
                return user;
            }
        }

        public void AddUser(User user)
        {
            using (var context = new DentalSystemContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (var context = new DentalSystemContext())
            {
                context.Users.Attach(user);
                context.Entry(user).Property(w => w.FullName).IsModified = true;
                context.Entry(user).Property(w => w.IdentificationCard).IsModified = true;
                context.Entry(user).Property(w => w.PhoneNumber).IsModified = true;
                context.Entry(user).Property(w => w.Address).IsModified = true;
                context.Entry(user).Property(w => w.Gender).IsModified = true;
                context.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            using (var context = new DentalSystemContext())
            {
                //context.Users.Attach(user);
                var userToDelete = context.Users.Find(user.UserId);
                userToDelete.DeletedOn = user.DeletedOn;

                context.SaveChanges();
            }
        }
    }
}