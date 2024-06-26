﻿using AzarDataNetTestAPI.Modules.Common.Domain.Interfaces.Repositories;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<KeyValueEntity> KeyValuesEntity { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Company>().HasMany(c => c.JobOffers).WithOne(jo => jo.Company)
            //    .HasForeignKey(jo => jo.CompanyId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.ConfigurKeyValueEntity();













































































            ApplyQueryFilter(modelBuilder);
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {


















            //alireza
















        }

        public void SetIsModified(object entity, List<string> propertiesName)
        {
            foreach (var PropName in propertiesName)
            {
                Entry(entity).Property(PropName).IsModified = true;
            }
        }

        // enable this method when we want to print any thing happen in efcore till SaveChanges()
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.LogTo(Console.WriteLine);

    }


}