using Ar.Generator.Data.Models.SolutionAppConfig;
using Ar.Generator.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ar.Generator.Repository.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                EnsureSeedData(services.GetRequiredService<GeneratorDbContext>()).Wait();
            }

            return host;
        }

        private static async Task EnsureSeedData(GeneratorDbContext context)
        {
            //context.Database.EnsureCreated();

            #region Seed Data

            // Check if DB has been already seeded
            if (context.Solutions.Any())
            {
                return;
            }

            #region Example

            var solutions = new List<Solution>()
            {
                new Solution()
                {
                    Name = "Test solution",
                    RepositoryName = "https://github.com/username/testrepository.git",
                    Description = "Test solution description",
                    AdlContent = "",
                    AddedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                }
            };

            await context.Solutions.AddRangeAsync(solutions);
            await context.SaveChangesAsync();

            #endregion

            #endregion

        }

    }
}