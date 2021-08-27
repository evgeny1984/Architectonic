using Microsoft.EntityFrameworkCore;

namespace Ar.Generator.Repository.Helpers
{
    public static class DatabaseMigrationExtension
    {
        public static void Migrate(GeneratorDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
