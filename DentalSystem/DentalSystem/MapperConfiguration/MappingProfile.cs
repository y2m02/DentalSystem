using AutoMapper;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Results;

namespace DentalSystem.MapperConfiguration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // GET
            CreateMap<Patient, ListPatientsResult>();

            //ADD, UPDATE
            CreateMap<ListPatientsResult, Patient>();

            //.ForMember(p => p.StatusDescription, d => d.MapFrom(s => s.Status.Description));
        }
    }
}