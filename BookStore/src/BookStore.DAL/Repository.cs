using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace BookStore.DAL
{
    using System.Data.Entity;

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context = new Context();
        private bool _disposed;

        protected IDbSet<T> _objectset;

        protected IDbSet<T> DbSet => this._objectset ?? (this._objectset = this.Context.Set<T>());

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Get(int id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public T Insert(T item)
        {
            try
            {
                T entity = DbSet.Add(item);
                CommitChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Update(T entity)
        {
            try
            {
                DbSet.Attach(entity);

                Context.Entry(entity).State = EntityState.Modified;
                CommitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                T entity = Get(id);
                if (entity == null) return false;

                DbSet.Remove(entity);
                CommitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void CommitChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<T> All()
        {
            try
            {
                return DbSet.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return DbSet.Where(predicate).AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        Context.Dispose();
                    }
                }
                _disposed = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }

}
