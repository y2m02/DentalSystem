namespace DentalSystem.MapperConfiguration
{
    public class AutoMapperConfiguration
    {
        public AutoMapper.MapperConfiguration Configure()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config;
        }
    }
}