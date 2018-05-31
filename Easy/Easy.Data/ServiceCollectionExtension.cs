using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Easy.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection UseEntityFramework(this IServiceCollection services, DbContextConfiguration setup)
        {

            return services.AddSingleton(setup).AddScoped<IRepository, Repository>();
        }

        public static IConfigurationBuilder AddEntityFrameworkConfig(
            this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        {
            return builder.Add(null);
        }
    }
}
