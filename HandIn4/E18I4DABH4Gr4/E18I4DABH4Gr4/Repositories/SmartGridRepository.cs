using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E18I4DABH4Gr4.Models;
using System.Linq.Expressions;

namespace E18I4DABH4Gr4.Repositories
{
    public class SmartGridRepository
    {
        private readonly SmartGridDBContext context;

        public SmartGridRepository(SmartGridDBContext c)
        {
            context = c;
        }
        public List<SmartGrid> getAll()
        {
            return context.SmartGrids.ToList();
        }
        public SmartGrid getById(int id)
        {
            return context.SmartGrids.Find(id);
        }
        public IEnumerable<SmartGrid> Find(Expression<Func<SmartGrid, bool>> match)
        {
            return context.SmartGrids.Where(match);
        }
        public void Add(SmartGrid s)
        {
            context.SmartGrids.Add(s);
            Save();
        }
        public void Update(SmartGrid s)
        {
            context.SmartGrids.Update(s);
            Save();
        }
        public void Delete(SmartGrid s)
        {
            context.SmartGrids.Remove(s);
            Save();
        }
        private void Save()
        {
            context.SaveChanges();
        }
    }
}
