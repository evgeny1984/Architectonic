using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class BpmnActivityMap
    {
        public BpmnActivityMap(EntityTypeBuilder<BpmnActivity> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.BpmnActivityVars)
               .WithOne(e => e.BpmnActivity)
               .HasForeignKey(e => e.BpmnActivityId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(e => e.ActivityHandler)
                .WithOne(e => e.BpmnActivity)
                .HasForeignKey<BpmnActivity>(e => e.ActivityHandlerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
