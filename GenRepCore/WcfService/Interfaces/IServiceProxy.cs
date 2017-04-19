using System;
using System.Linq;
using System.Linq.Expressions;

namespace WcfService.Interfaces
{
    public interface IServiceProxy<T> where T : class
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        dynamic Add(T entity);
        dynamic Update(T entity);
        dynamic Delete(dynamic id);
    }
}
