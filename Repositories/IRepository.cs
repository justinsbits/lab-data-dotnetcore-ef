using System.Collections.Generic;

namespace CommanderData.Repositories
{
    public interface IRepository<TEntity> 
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        bool SaveChanges();
        
    }
}
