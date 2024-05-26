using System.Data;
using Authentication.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Authentication.CrossCutting.Configurations
{
    public static class ConfigureEntities
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.AddSingleton<IDbConnection>((connection) => new NpgsqlConnection(
                connectionString
            ));

            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
            
            return services;
        }
    }
}