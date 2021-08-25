using Ar.Generator.Data.Models.SolutionAppConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class ApplicationMap
    {
        public ApplicationMap(EntityTypeBuilder<Application> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.Deployments)
               .WithOne(e => e.Application)
               .HasForeignKey(e => e.ApplicationId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasMany(e => e.BpmnActivityHandlers)
                .WithOne(e => e.ResponsibleApplication)
                .HasForeignKey(e => e.ResponsibleApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
