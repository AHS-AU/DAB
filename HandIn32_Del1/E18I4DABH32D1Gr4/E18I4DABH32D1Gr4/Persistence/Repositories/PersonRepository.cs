using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E18I4DABH32D1Gr4.Core.IRepositories;
using E18I4DABH32D1Gr4.Models;
using E18I4DABH32D1Gr4.Persistence;
using E18I4DABH32D1Gr4.Contexts;

namespace E18I4DABH32D1Gr4.Persistence.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonContext context) : base(context)
        {
        }

    }
}
