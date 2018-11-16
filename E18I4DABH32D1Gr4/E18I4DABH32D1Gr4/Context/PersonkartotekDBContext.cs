using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using E18I4DABH32D1Gr4.Models;

namespace E18I4DABH32D1Gr4.Context
{
    public class PersonkartotekDBContext : DbContext
    {
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Person>();
        //}

        public DbSet<Person> person { get; set; }
        public DbSet<Address> address { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<Email> email { get; set; }
    }
}
