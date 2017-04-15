using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.Contexts;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class FileSystemRepository<T> : IRepository<T> where T : class
    {
        private FileSystemContext<T> fileSystemContext;
        public IDictionary<string, object> Input { get; set; }

        public FileSystemRepository(string key = "")
        {
            this.fileSystemContext = new FileSystemContext<T>(key);
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetNEntities(int pageNumber, int count)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetNEntities(Expression<Func<T, bool>> predicate, int pageNumber, int count)
        {
            throw new NotImplementedException();
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public dynamic Remove(T entity)
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }

        public dynamic Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public dynamic Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }
    }
}
