using CoreLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ServicesImplementation
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private readonly PortDbContext _context;

        private readonly IGenericIRepository<TEntity> _repo;
        // define peoperty on GenericRepo class to using Body expression property
        public IGenericIRepository<TEntity> GenericIRepository => _repo?? new GenericRepository<TEntity>(_context) ;

        public UnitOfWork(PortDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
