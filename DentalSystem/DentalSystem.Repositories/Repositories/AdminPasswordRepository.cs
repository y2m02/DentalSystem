using System.Data.Entity;
using System.Linq;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;
using DentalSystem.Entities.Models;

namespace DentalSystem.Repositories.Repositories
{
    public class AdminPasswordRepository : IAdminPasswordRepository
    {
        public AdminPassword GetAdminPassword()
        {
            using (var context = new DentalSystemContext())
            {
                var adminPassword = context.AdminPasswords.OrderByDescending(w => w.AdminPasswordId).FirstOrDefault();
                return adminPassword;
            }
        }

        public AdminPassword AddPassword(AdminPassword password)
        {
            using (var context = new DentalSystemContext())
            {
                context.AdminPasswords.Add(password);
                context.SaveChanges();
                return password;
            }
        }

        public void UpdatePassword(AdminPassword password)
        {
            using (var context = new DentalSystemContext())
            {
                context.Entry(password).State = EntityState.Modified;
            }
        }
    }
}