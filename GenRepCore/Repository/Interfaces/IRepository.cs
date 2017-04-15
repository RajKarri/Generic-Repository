using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IDictionary<string, object> Input { get; set; }
        T Get();
        IQueryable<T> GetNEntities(int pageNumber, int count);
        IQueryable<T> GetNEntities(Expression<Func<T, bool>> predicate, int pageNumber, int count);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        dynamic Update(T entity);
        dynamic Remove(T entity);
        dynamic Delete(dynamic id);
        void SaveChanges();
    }
}
