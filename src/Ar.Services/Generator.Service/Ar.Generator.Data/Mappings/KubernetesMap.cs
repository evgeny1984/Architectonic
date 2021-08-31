using Ar.Generator.Data.Models.Deployments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class KubernetesMap
    {
        public KubernetesMap(EntityTypeBuilder<Kubernetes> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.EnvVars)
               .WithOne(e => e.Kubernetes)
               .HasForeignKey(e => e.KubernetesId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .HasOne(e => e.PVC)
               .WithOne(e => e.Kubernetes)
               .HasForeignKey<PersistentVolumeClaim>(e => e.KubernetesId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
