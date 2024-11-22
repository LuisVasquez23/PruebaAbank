using AbankApi.Application.Repositories;
using AbankApi.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace AbankApi.Persistence
{
    public static class DependencyInjectionService
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            // ADD CONNECTION STRING 
            services.AddTransient<IDbConnection>(sp =>
                new NpgsqlConnection(configuration.GetConnectionString("AbankConnection")));

            // ADD REPOSITORIES
            services.AddTransient<IUserRepository, UserRepository>();

            // RETURN SERVICES 
            return services;
        }

    }
}
