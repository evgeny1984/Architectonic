using Ar.Generator.Data.Models.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class DbEngineMap
    {
        public DbEngineMap(EntityTypeBuilder<DbEngine> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.DbEntities)
               .WithOne(e => e.DbEngine)
               .HasForeignKey(e => e.DbEngineId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
              .HasMany(e => e.Microservices)
              .WithOne(e => e.DatabaseEngine)
              .HasForeignKey(e => e.DbEngineId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
