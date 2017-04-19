using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.Contexts;

namespace Repository.Repositories
{
    public class ServiceRepository<T> : Interfaces.IRepository<T> where T : class
    {
        private ServiceContext<T> serviceContext;
        public IDictionary<string, object> Input { get; set; }

        public ServiceRepository(string key = "")
        {
            this.serviceContext = new ServiceContext<T>(key);
        }

        public IQueryable<T> GetAll()
        {
            return serviceContext.CurrentContext.ServiceProxy.Get();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return serviceContext.CurrentContext.ServiceProxy.Get(predicate);
        }

        public IQueryable<T> GetNEntities(int pageNumber, int count)
        {
            return serviceContext.CurrentContext.ServiceProxy.Get().Skip((pageNumber - 1) * count).Take(count);
        }

        public IQueryable<T> GetNEntities(Expression<Func<T, bool>> predicate, int pageNumber, int count)
        {
            return serviceContext.CurrentContext.ServiceProxy.Get(predicate).Skip((pageNumber - 1) * count).Take(count);
        }

        public T Get()
        {
            return serviceContext.CurrentContext.ServiceProxy.Get().FirstOrDefault();
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            return serviceContext.CurrentContext.ServiceProxy.Get(predicate).FirstOrDefault();
        }

        public dynamic Add(T entity)
        {
            return serviceContext.CurrentContext.ServiceProxy.Add(entity);
        }

        public dynamic Remove(T entity)
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }

        public dynamic Delete(dynamic id)
        {
            return serviceContext.CurrentContext.ServiceProxy.Delete(id);
        }

        public dynamic Update(T entity)
        {
            return serviceContext.CurrentContext.ServiceProxy.Update(entity);
        }

        public void SaveChanges()
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }
    }
}
