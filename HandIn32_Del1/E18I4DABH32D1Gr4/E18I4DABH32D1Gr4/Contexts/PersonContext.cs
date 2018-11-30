using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using E18I4DABH32D1Gr4.Models;

namespace E18I4DABH32D1Gr4.Contexts
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        public DbSet<Email> Email { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<City> City { get; set; }
    }
}
