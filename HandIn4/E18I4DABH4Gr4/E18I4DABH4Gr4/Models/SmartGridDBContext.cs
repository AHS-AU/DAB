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
            //modelBuilder.Entity<Prosumer>().HasOne(p => p.ProsumerId).WithMany(p => p);
            //modelBuilder.Entity<SmartGrid>().HasAlternateKey(p => p.Consumers);
        }

        public DbSet<SmartGrid> SmartGrids { get; set; }
        //public DbSet<Prosumer> Prosumers { get; set; }
    }
}
