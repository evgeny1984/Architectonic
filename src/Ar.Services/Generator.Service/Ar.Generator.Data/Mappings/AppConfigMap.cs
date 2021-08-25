using Ar.Generator.Data.Models.SolutionAppConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class AppConfigMap
    {
        public AppConfigMap(EntityTypeBuilder<AppConfig> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.Applications)
               .WithOne(e => e.Configuration)
               .HasForeignKey(e => e.ConfigurationId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
