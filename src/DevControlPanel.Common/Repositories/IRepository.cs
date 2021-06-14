using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevControlPanel.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> contitions = null);

        TEntity Get(Expression<Func<TEntity, bool>> whereCondition);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
