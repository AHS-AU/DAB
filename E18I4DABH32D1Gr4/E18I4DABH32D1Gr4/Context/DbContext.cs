using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E18I4DABH32D1Gr4.Models;
using Microsoft.EntityFrameworkCore;

namespace E18I4DABH32D1Gr4.Context
{
    public class DBContext : DbContext
    {
        // Default Constructor
        //public void DbContext()
        //{

        //}

        // Base Constructor
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        // On Config
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string cn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Personkartotek;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    optionsBuilder.UseSqlServer(cn);
            
        //    base.OnConfiguring(optionsBuilder);
        //}

        // Variables
        public virtual DbSet<Person> people { get; set; }

        public virtual DbSet<Address> address { get; set; }

        public virtual DbSet<City> city { get; set; }

        public virtual DbSet<Email> emailAddress { get; set; }
    }
}

