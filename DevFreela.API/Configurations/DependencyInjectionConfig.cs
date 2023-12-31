using System;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence.Repositories;
using DevFreela.Infrastructure.Repositories;

namespace DevFreela.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependecyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IGeralRepository, GeralRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
