//-----------------------------------------------------------------------
// <copyright file="DatabaseRepository.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Repository.Contexts;
    using Repository.Interfaces;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Database repository
    /// </summary>
    /// <typeparam name="T">Type of database repository</typeparam>
    public class DatabaseRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Database context
        /// </summary>
        private DatabaseContext<T> databaseContext;

        public IDictionary<string, string> jSonInput { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRepository{T}"/> class.
        /// </summary>
        /// <param name="key">Database key</param>
        public DatabaseRepository(string key = "")
        {
            this.databaseContext = new DatabaseContext<T>(key);
        }

        /// <summary>
        /// Get all objects of type T
        /// </summary>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all objects of type T after filtration
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get N objects of type T from a particular page 
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="count">Number of entities</param>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetNEntities(int pageNumber, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get N objects of type T from a particular page after filtration
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="count">Number of entities</param>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetNEntities(Expression<Func<T, bool>> predicate, int pageNumber, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get object by
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after addition</returns>
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after removal</returns>
        public dynamic Remove(T entity)
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }

        /// <summary>
        /// Deletes the object 
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>Response after deletion</returns>
        public dynamic Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after update</returns>
        public dynamic Update(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the changes into source
        /// </summary>
        public void SaveChanges()
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }
    }
}
