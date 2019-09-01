using DentalSystem.Entities.Models;

namespace DentalSystem.Contract.Repositories
{
    public interface IAdminPasswordRepository
    {
        AdminPassword GetAdminPassword();
        AdminPassword AddPassword(AdminPassword password);
        void UpdatePassword(AdminPassword password);
    }
}