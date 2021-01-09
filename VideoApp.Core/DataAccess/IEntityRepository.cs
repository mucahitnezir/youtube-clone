using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VideoApp.Core.Entities;

namespace VideoApp.Core.DataAccess
{
    public interface IEntityRepository<T> where T: EntityBase, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}