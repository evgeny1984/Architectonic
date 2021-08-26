using Ar.Generator.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
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
            //if (context.Rights.Any())
            //{
            //    return;
            //}

            #region Example

            //var categories = new List<OrderItemCategory>()
            //{
            //    new OrderItemCategory()
            //    {
            //        ID=1,
            //        Category= "Halteverbotszonen"
            //    }
            //};

            //await context.OrderItemCategories.AddRangeAsync(categories);
            //await context.SaveChangesAsync();
            //var savedCategories = context.OrderItemCategories.ToDictionary(v => v.Category, v => v.ID);

            #endregion

            #endregion

        }

    }
}