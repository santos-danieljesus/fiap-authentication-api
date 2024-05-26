using Microsoft.Extensions.DependencyInjection;
using Authentication.Domain.Repository;
using Authentication.Infrastructure.Repository;
using Template.Application.Services;
using Template.Domain.Services;

namespace Authentication.CrossCutting.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IReadRepository, ReadRepository>();
            services.AddScoped<IWriteRepository, WriteRepository>();
            
            return services;
        }
    }
}