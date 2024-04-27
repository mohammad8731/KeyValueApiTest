using Microsoft.EntityFrameworkCore;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities
{
    public static class KeyValueEntityConfig
    {
        public static void ConfigurKeyValueEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KeyValueEntity>()
                .HasIndex(u => new { u.Key })
                .IsUnique();
        }
    }
}
