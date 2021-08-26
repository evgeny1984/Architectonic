using Microsoft.AspNetCore.Hosting;
using Ar.Common.Helpers;
using Ar.Generator.Repository;
using Ar.Generator.Repository.Helpers;

namespace Ar.Generator.Service.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext(this IWebHost webHost)
        {
            webHost.MigrateDbContext<GeneratorDbContext>(context
                   => DatabaseMigrationExtension.Migrate(context));

            webHost.SeedData();

            return webHost;

        }

    }
}
