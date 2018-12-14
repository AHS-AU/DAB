using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E18I4DABH4Gr4.Models
{
    public class SmartGridDBContext : DbContext
    {
        public SmartGridDBContext(DbContextOptions<SmartGridDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmartGrid>().HasMany(p => p.Consumers).WithOne();
            modelBuilder.Entity<SmartGrid>().HasMany(p => p.Producers).WithOne();
        }

        public DbSet<SmartGrid> SmartGrids { get; set; }
        //public DbSet<Prosumer> Prosumers { get; set; }
    }
}
