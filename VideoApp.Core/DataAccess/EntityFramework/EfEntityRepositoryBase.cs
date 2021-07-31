using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VideoApp.Core.Entities;

namespace VideoApp.Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : EntityBase, new()
        where TContext : DbContext
    {
        protected readonly TContext Context;

        protected EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return Context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? Context.Set<TEntity>().ToList()
                : Context.Set<TEntity>().Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            var entry = Context.Entry(entity);
            entry.State = EntityState.Added;
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
