using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using E18I4DABH32D1Gr4.Contexts;
using E18I4DABH32D1Gr4.Core.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace E18I4DABH32D1Gr4.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PersonContext db = null;

        public Repository(PersonContext context)
        {
            db = context;
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
        }

        public TEntity Get(long id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public virtual void Set(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }

        //void IRepository<TEntity> RemoveRange(IEnumerable<TEntity> entities){

        //}
        public IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> isFound)
        {
            return db.Set<TEntity>().Where(isFound);
        }

        public void Put(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }

        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().Select(x => x);
        }
    }
}
