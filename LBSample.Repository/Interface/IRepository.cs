using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LBSample.Repository.Interface
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TKey id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void PatchUpdate(TEntity entity, string[] fieldsToUpdate);
        void SetModified(TEntity entity);
        bool IsDetached(TEntity entity);
        void Detach(TEntity entity);
    }
}
