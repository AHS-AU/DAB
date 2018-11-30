using E18I4DABH32D1Gr4.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH32D1Gr4.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository People { get; }
        int Complete();
    }
}
