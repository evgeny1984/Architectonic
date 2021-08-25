using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class WorkflowEngineMap
    {
        public WorkflowEngineMap(EntityTypeBuilder<WorkflowEngine> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.ProcessInstances)
               .WithOne(e => e.WorkflowEngine)
               .HasForeignKey(e => e.WorkflowEngineId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(e => e.SagaPattern)
                .WithOne(e => e.WorkflowEngine)
                .HasForeignKey<WorkflowEngine>(e => e.SagaPatternId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
