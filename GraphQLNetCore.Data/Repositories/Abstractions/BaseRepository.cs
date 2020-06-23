using GraphQLNetCore.Data.Repositories.Interfaces;
using GraphQLNetCore.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GraphQLNetCore.Data.Repositories.Abstractions
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly GraphQLContext context;
        private readonly DbSet<TEntity> dbSet;

        #endregion Fields

        #region Constructors

        public BaseRepository(GraphQLContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        #endregion Constructors

        #region Public Methods

        public virtual TEntity Add(TEntity entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual bool Delete(int id)
        {
            TEntity entity = this.dbSet.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                this.dbSet.Remove(entity);
                return true;
            }
            return false;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(int id, string includeProperties = "")
        {
            return this.dbSet
                //.Include(includeProperties)
                .FirstOrDefault(x => x.Id == id);
        }

        public virtual TEntity Update(TEntity entity, TEntity newValues)
        {
            context.Entry(entity).CurrentValues.SetValues(newValues);
            return entity;
        }

        public virtual TEntity Random()
        {
            return this.dbSet.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();
        }

        #endregion Public Methods
    }
}