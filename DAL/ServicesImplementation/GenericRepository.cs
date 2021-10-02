using CoreLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.ServicesImplementation
{
    public class GenericRepository<TEntity> : IGenericIRepository<TEntity> where TEntity : class
    {
        private readonly PortDbContext _context;
        private readonly DbSet<TEntity> _entity;

        public GenericRepository(PortDbContext dbContext)
        {
            _context = dbContext;
            _entity = _context.Set<TEntity>();
        }

        public bool Delete(object Id)
        {
            try
            {
                var exsitingEntity = GetById(Id);
                _entity.Remove(exsitingEntity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entity.ToList();
        }

        public TEntity GetById(object Id)
        {
            return _entity.Find(Id);
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                _entity.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }       
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _entity.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
