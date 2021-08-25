using Ar.Generator.Data.Models.ArchitecturalPatterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class ProcessInstanceMap
    {
        public ProcessInstanceMap(EntityTypeBuilder<ProcessInstance> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.BpmnActivities)
               .WithOne(e => e.ProcessInstance)
               .HasForeignKey(e => e.ProcessInstanceId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
