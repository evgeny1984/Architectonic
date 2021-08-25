using Ar.Generator.Data.Models.Deployments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class DockerComposeServiceMap
    {
        public DockerComposeServiceMap(EntityTypeBuilder<DockerComposeService> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.EnvVars)
               .WithMany(e => e.DockerComposeServices)
               .UsingEntity(e => e.ToTable("ServiceToEnvVars"));
        }
    }
}
