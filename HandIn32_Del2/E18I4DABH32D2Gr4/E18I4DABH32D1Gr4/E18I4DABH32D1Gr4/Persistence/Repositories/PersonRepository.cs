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
        public PersonRepository() : base("personDatabase", "peopleCollection")
        {

        }

        public Person GetPerson(string fullName)
        {
            return GetQuery().Where(x => x.FullName.ToLower() == fullName.ToLower()).ToList().FirstOrDefault();
        }

        protected override string getId(Person entity)
        {
            return entity.PersonId;
        }

        protected override void setId(Person entity, string id)
        {
            entity.PersonId = id;
        }
    }
}
