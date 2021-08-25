using Ar.Generator.Data.Models.SolutionAppConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class SolutionMap
    {
        public SolutionMap(EntityTypeBuilder<Solution> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.Applications)
               .WithOne(e => e.Solution)
               .HasForeignKey(e => e.SolutionId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .HasMany(e => e.Patterns)
               .WithOne(e => e.Solution)
               .HasForeignKey(e => e.SolutionId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .HasMany(e => e.SolutionStructure)
               .WithOne(e => e.Solution)
               .HasForeignKey(e => e.SolutionId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
