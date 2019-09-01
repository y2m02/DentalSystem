using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.AdminPassword;
using DentalSystem.Entities.Results.AdminPassword;

namespace DentalSystem.Services.Services
{
    public class AdminPasswordService : IAdminPasswordService
    {
        private readonly IAdminPasswordRepository _adminPasswordRepository;

        public AdminPasswordService(IAdminPasswordRepository adminPasswordRepository)
        {
            _adminPasswordRepository = adminPasswordRepository;
        }

        public GetAdminPasswordResult GetAdminPassword(GetAdminPasswordRequest request)
        {
            var result = _adminPasswordRepository.GetAdminPassword();
            var adminPassword = request.Mapper.Map<GetAdminPasswordResultModel>(result);

            var getAdminPasswordResult = new GetAdminPasswordResult
            {
                AdminPassword = adminPassword
            };

            return getAdminPasswordResult;
        }

        public void UpdatePassword(UpdatePasswordRequest request)
        {
            var result = request.Mapper.Map<AdminPassword>(request);
            _adminPasswordRepository.UpdatePassword(result);
        }

        public AddAdminPasswordResult AddPassword(AddAdminPasswordRequest request)
        {
            var result = request.Mapper.Map<AdminPassword>(request);
            var password = _adminPasswordRepository.AddPassword(result);
            var adminPassword = request.Mapper.Map<AddAdminPasswordResultModel>(password);

            var addOrUpdateAdminPasswordResult = new AddAdminPasswordResult
            {
                AdminPassword = adminPassword
            };

            return addOrUpdateAdminPasswordResult;
        }
    }
}