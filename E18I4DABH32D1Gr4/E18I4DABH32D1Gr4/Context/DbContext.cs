using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E18I4DABH32D1Gr4.Models;
using Microsoft.EntityFrameworkCore;

namespace E18I4DABH32D1Gr4.Context
{
    class DBContext : DbContext
    {

        public void DbContext(){

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Personkartotek;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(cn);

            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>()
        //        .Property(u => u.fullName)
        //        .HasColumnName("display_name");
        //}


        public DbSet<Person> persons { get; set; }

        public DbSet<Address> address { get; set; }

        public DbSet<City> city { get; set; }

        public DbSet<Email> emailAddress { get; set; }
    }
}

