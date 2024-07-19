using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace LearnAdmin.Extensions.ServiceExtensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(typeof(AutoMapperConfig));
        }

        public static void ConfigureServices(IServiceCollection services)
        {
        }
    }

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
