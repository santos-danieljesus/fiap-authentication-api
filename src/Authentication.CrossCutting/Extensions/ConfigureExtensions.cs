using System;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.CrossCutting.Extensions
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => 
            {
                var assemblies = AppDomain.CurrentDomain.Load("Authentication.Application");
                cfg.RegisterServicesFromAssemblies(assemblies);
            });

            return services;
        } 
    }
}