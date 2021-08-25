using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Ar.Generator.Data.Models.Deployments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class DockerComposeMap
    {
        public DockerComposeMap(EntityTypeBuilder<DockerCompose> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.DockerComposeServices)
               .WithOne(e => e.DockerCompose)
               .HasForeignKey(e => e.DockerComposeId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
