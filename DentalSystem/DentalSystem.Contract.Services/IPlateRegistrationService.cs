using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalSystem.Entities.Requests.PlateRegistration;

namespace DentalSystem.Contract.Services
{
    public interface IPlateRegistrationService
    {
        void UpdatePlateRegistration(UpdatePlateRegistrationRequest request);
    }
}
