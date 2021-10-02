using System;

namespace CoreLayer.Services
{
    public interface IUnitOfWork <TRepository> where TRepository : class
    {
        public IGenericIRepository<TRepository> GenericIRepository{ get; }

        void Save();
    }

}
