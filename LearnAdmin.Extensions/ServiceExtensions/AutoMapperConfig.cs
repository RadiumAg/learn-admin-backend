using AutoMapper;

namespace LearnAdmin.Extensions.ServiceExtensions
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserInfoProfile());
            });

        }
    }
}
