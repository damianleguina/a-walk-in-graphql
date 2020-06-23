using GraphQLNetCore.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GraphQLNetCore.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        bool Delete(int id);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(int id, string includeProperties = "");

        TEntity Update(TEntity entity, TEntity newValues);

        TEntity Random();
    }
}
