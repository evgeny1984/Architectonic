using Ar.Generator.Data.Models.Applications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class MicroserviceMap
    {
        public MicroserviceMap(EntityTypeBuilder<Microservice> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.ApiEndpoints)
               .WithOne(e => e.Microservice)
               .HasForeignKey(e => e.MicroserviceId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
