using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Services
{
    public interface IGenericIRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object Id);

        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(object Id);

    }

}
