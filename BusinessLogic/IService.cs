using System;
using System.Linq;

namespace BusinessLogic
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity get(object id);
        IQueryable<TEntity> Get();
        void Add(TEntity entity);
        void Update(object id, TEntity entity);
        int Save();
    }
}
