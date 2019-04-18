using Microsoft.EntityFrameworkCore;
using NetCore.DataLayer.Entity;
using NetCoreLibrary;
using System;

namespace NetCore.DataLayer
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(Configurator.SqlConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProvinceConfig());
            modelBuilder.ApplyConfiguration(new AumphurConfig());
            base.OnModelCreating(modelBuilder);

        }
    }
}
