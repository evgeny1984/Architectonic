using Ar.Generator.Data.Models.Applications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class ApiGatewayMap
    {
        public ApiGatewayMap(EntityTypeBuilder<ApiGateway> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.GatewayRoutes)
               .WithOne(e => e.Gateway)
               .HasForeignKey(e => e.ApiGatewayId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
