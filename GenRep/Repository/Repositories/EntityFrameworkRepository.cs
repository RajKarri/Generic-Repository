using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Contexts;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private IDbSet<T> databaseSet;
        private DbContext databaseContext;
        public IDictionary<string, object> Input { get; set; }

        public EntityFrameworkRepository(string key = "")
        {
            this.databaseContext = new EntityFrameworkContext<T>(key).CurrentContext.DbContext;
            this.databaseSet = this.databaseContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().Where(predicate);
        }

        public IQueryable<T> GetNEntities(int pageNumber, int count)
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().Skip((pageNumber - 1) * count).Take(count);
        }

        public IQueryable<T> GetNEntities(Expression<Func<T, bool>> predicate, int pageNumber, int count)
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().Where(predicate).Skip((pageNumber - 1) * count).Take(count);
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            this.databaseSet.Add(entity);
            return entity;
        }

        public dynamic Remove(T entity)
        {
            this.databaseSet.Remove(entity);
            this.databaseContext.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public dynamic Delete(dynamic id)
        {
            throw new NotSupportedException("This method is not supported in entity framework.");
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().FirstOrDefault(predicate);
        }

        public dynamic Update(T entity)
        {
            this.databaseSet.Attach(entity);
            this.databaseContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void SaveChanges()
        {
            this.databaseContext.SaveChanges();
        }
    }
}
