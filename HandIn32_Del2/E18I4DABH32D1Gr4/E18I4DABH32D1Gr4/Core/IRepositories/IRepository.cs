using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace E18I4DABH32D1Gr4.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);

        Task Set(TEntity entity);

        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);

    }
}
