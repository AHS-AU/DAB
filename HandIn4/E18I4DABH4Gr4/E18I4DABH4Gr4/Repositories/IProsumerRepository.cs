using E18I4DABH4Gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH4Gr4.Repositories
{
    public interface IProsumerRepository<TEntity> where TEntity : class
    {
        Prosumer GetProsumer(string id);
        Task<TEntity> Get(int id);

        IEnumerable<TEntity> GetAll();

        Task Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);
    
        Task Set(TEntity entity);

        Task Remove(TEntity entity);

        Task RemoveRange(IEnumerable<TEntity> entities);

    }
}
