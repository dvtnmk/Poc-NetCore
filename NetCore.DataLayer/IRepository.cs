using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.DataLayer
{
    public interface IRepository<TEntity> where TEntity :class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        int SaveChange();
        IQueryable<TEntity> GetQuery();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyContext _context;
        public Repository(MyContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Entities
        {
            get { return _context.Set<TEntity>(); }
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return Entities.AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);

        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
