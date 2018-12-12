using E18I4DABH4Gr4.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH4Gr4.Repositories
{
    public class ProsumerRepository : Repository<Prosumer>, IProsumerRepository
    {
        public ProsumerRepository() : base("prosumerDatabase", "prosumerCollection")
        {

        }
        public Prosumer GetProsumer(string name)
        {
            return GetQuery().Where(x => x.Name.ToLower() == name.ToLower()).ToList().FirstOrDefault();
        }
        protected override string getId(Prosumer entity)
        {
            return entity.ProsumerId;
        }

        protected override void setId(Prosumer entity, string id)
        {
            entity.ProsumerId = id;
        }
    }
}
