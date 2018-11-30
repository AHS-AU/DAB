using E18I4DABH32D1Gr4.Contexts;
using E18I4DABH32D1Gr4.Core.IRepositories;
using E18I4DABH32D1Gr4.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH32D1Gr4.Persistence
{
    public class UnitOfWork
    {
        //public ICityRepository CityRepository { get; }
        public IPersonRepository PersonRepository { get; }
        //public IAddressRepository AddresseRepository { get; }
        //public IEmailRepository EmailRepository { get; }

        private readonly PersonContext mContext;

        public UnitOfWork(PersonContext context)
        {
            mContext = context;
            //CityRepository = new CityRepository(mContext);
            PersonRepository = new PersonRepository(mContext);
            //AddresseRepository = new AddresseRepository(mContext);
            //EmailRepository = new EmailRepository(mContext);
        }

        public void Complete()
        {
            mContext.SaveChanges();
        }

        public void Dispose()
        {
            mContext?.Dispose();
        }
    }
}
