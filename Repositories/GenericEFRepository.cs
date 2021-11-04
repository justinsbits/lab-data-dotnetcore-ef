using System;
using Microsoft.EntityFrameworkCore;
using CommanderData;
using System.Linq;
using CommanderData.Entities;
using System.Collections.Generic;

namespace CommanderData.Repositories
{
    public class GenericEFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericEFRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        void IRepository<TEntity>.Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Add(entity);
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            return _dbSet.ToList();
        }

        TEntity IRepository<TEntity>.GetById(int id)
        {
            return _dbSet.FirstOrDefault(e => e.Id == id);
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbSet.Remove(entity);
        }

        void IRepository<TEntity>.Update(TEntity entity)
        {
        
        }

        bool IRepository<TEntity>.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
