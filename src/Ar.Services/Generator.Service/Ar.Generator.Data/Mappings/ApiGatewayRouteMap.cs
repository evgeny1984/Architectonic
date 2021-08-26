using Ar.Generator.Data.Comparer;
using Ar.Generator.Data.Converters;
using Ar.Generator.Data.Models.Applications;
using Architect.Dto.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class GatewayRouteMap
    {
        public GatewayRouteMap(EntityTypeBuilder<GatewayRoute> modelBuilder)
        {
            var converter = new EnumCollectionJsonValueConverter<RequestType>();
            var comparer = new CollectionValueComparer<RequestType>();

            modelBuilder
              .Property(e => e.UpstreamHttpMethods)
              .HasConversion(converter)
              .Metadata.SetValueComparer(comparer);

        }
    }
}
