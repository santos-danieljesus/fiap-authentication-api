using Microsoft.Extensions.DependencyInjection;
using Authentication.Domain.Repository;
using Authentication.Infrastructure.Repository;
using Template.Application.Services;
using Template.Domain.Services;
using Authentication.Domain.Services;
using Authentication.Application.Services;
using Template.Domain.Entities;

namespace Authentication.CrossCutting.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService<AuthenticateUser>, AuthenticationService>();
            services.AddScoped<IReadRepository<AuthenticateUser>, ReadRepository>();
            services.AddScoped<IWriteRepository, WriteRepository>();
            services.AddScoped<ITokenService, TokenService>();
            
            return services;
        }
    }
}