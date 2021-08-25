using Ar.Generator.Data.Models.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class DbEntityMap
    {
        public DbEntityMap(EntityTypeBuilder<DbEntity> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.DbEntityRelationships)
               .WithOne(e => e.ToEntity)
               .HasForeignKey(e => e.ToEntityId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
              .HasMany(e => e.DbEntityFields)
              .WithOne(e => e.DbEntity)
              .HasForeignKey(e => e.DbEntityId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
