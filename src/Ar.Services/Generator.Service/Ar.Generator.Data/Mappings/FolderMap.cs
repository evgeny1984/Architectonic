using Ar.Generator.Data.Models.SolutionAppConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ar.Generator.Data.Mappings
{
    public class FolderMap
    {
        public FolderMap(EntityTypeBuilder<Folder> modelBuilder)
        {
            modelBuilder
               .HasMany(e => e.SubFolders)
               .WithOne(e => e.ParentFolder)
               .HasForeignKey(e => e.ParentFolderId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
