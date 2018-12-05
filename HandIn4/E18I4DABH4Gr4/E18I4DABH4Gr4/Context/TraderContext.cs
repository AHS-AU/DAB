using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E18I4DABH4Gr4.Models;
using Microsoft.EntityFrameworkCore;

namespace E18I4DABH4Gr4.Context
{
    public class TraderContext : DbContext
    {
        public TraderContext(DbContextOptions<TraderContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbName = "TraderDb";
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=" + dbName + ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Trader> Traders { get; set; }

    }
}
