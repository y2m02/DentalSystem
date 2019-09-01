using System.Xml.Serialization;
using DentalSystem.Entities.Requests.AdminPassword;
using DentalSystem.Entities.Results.AdminPassword;

namespace DentalSystem.Contract.Services
{
    public interface IAdminPasswordService
    {
        GetAdminPasswordResult GetAdminPassword(GetAdminPasswordRequest request);
        void UpdatePassword(UpdatePasswordRequest request);
        AddAdminPasswordResult AddPassword(AddAdminPasswordRequest request);
    }
}