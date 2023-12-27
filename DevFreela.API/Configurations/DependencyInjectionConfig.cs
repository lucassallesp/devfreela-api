using System;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependecyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISkillService, SkillService>();
            
            return services;
        }
    }
}
