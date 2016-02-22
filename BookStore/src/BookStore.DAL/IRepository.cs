using System;
using System.Collections.Generic;

namespace BookStore.DAL
{
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        void Dispose();
        T Get(int id);
        T Insert(T item);
        bool Update(T entity);
        bool Delete(int id);
        void CommitChanges();
        List<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
