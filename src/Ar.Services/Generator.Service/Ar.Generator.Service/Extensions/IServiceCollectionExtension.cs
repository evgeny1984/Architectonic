using Ar.Generator.Repository;
using Ar.Generator.Repository.Wrapper;
using Ar.Generator.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ar.Generator.Service.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPostgreDbContext(this IServiceCollection services, string connectionString = "")
        {
            services.AddDbContext<GeneratorDbContext>(options =>
               options.UseNpgsql(connectionString, builder =>
               {
                   builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
               }));

            return services;
        }

        public static IServiceCollection AddRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            return services;
        }

        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddTransient<ISolutionService, SolutionService>();

            return services;
        }

    }
}
