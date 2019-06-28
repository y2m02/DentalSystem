using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DentalSystem.Contract.Services;

namespace DentalSystem.FormFunctions
{
    public class GeneralInformation
    {
        private readonly IMapper _iMapper;
        private readonly IPatientService _patientService;

        public GeneralInformation(IMapper iMapper, IPatientService patientService)
        {
            _iMapper = iMapper;
            _patientService = patientService;
        }
    }
}
