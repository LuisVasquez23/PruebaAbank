using AbankApi.Application.Configuration;
using AbankApi.Application.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AbankApi.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            // ADD MEDIATR 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // MAPPER SINGLETON 
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());
            services.AddScoped<JwtService>();


            return services;
        }
    }
}
