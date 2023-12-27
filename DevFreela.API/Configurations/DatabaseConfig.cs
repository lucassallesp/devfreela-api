using System;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDevFreelaDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DevFreelaDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DevFreelaCs"))
            );

            return services;
        }
    }
}
