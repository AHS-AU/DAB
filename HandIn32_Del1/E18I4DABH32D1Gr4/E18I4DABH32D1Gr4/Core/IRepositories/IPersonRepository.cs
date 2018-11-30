using E18I4DABH32D1Gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH32D1Gr4.Core.IRepositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        // Person GetPersonWithAddresses(int id);
    }
}
