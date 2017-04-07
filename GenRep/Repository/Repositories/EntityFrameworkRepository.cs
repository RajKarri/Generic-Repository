//-----------------------------------------------------------------------
// <copyright file="EntityFrameworkRepository.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Repository.Contexts;
    using Repository.Interfaces;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Entity framework repository
    /// </summary>
    /// <typeparam name="T">Type of the entity framework repository</typeparam>
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Database set
        /// </summary>
        private IDbSet<T> databaseSet;

        /// <summary>
        /// Database context
        /// </summary>
        private DbContext databaseContext;

        public IDictionary<string, string> jSonInput { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkRepository{T}"/> class.
        /// </summary>
        /// <param name="key">Entity framework key</param>
        public EntityFrameworkRepository(string key = "")
        {
            this.databaseContext = new EntityFrameworkContext<T>(key).CurrentContext.DbContext;
            this.databaseSet = this.databaseContext.Set<T>();
        }

        /// <summary>
        /// Get all objects of type T
        /// </summary>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetAll()
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable<T>();
        }

        /// <summary>
        /// Get all objects of type T after filtration
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().Where(predicate);
        }

        /// <summary>
        /// Get N objects of type T from a particular page 
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="count">Number of entities</param>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetNEntities(int pageNumber, int count)
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().Skip((pageNumber - 1) * count).Take(count);
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
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().Where(predicate).Skip((pageNumber - 1) * count).Take(count);
        }

        /// <summary>
        /// Adds object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after addition</returns>
        public T Add(T entity)
        {
            this.databaseSet.Add(entity);
            return entity;
        }

        /// <summary>
        /// Removes object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after removal</returns>
        public dynamic Remove(T entity)
        {
            this.databaseSet.Remove(entity);
            this.databaseContext.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        /// <summary>
        /// Deletes the object 
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>Response after deletion</returns>
        public dynamic Delete(dynamic id)
        {
            throw new NotSupportedException("This method is not supported in entity framework.");
        }

        /// <summary>
        /// Get object by
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> set = this.databaseSet;
            return set.AsQueryable().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Updates object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after update</returns>
        public dynamic Update(T entity)
        {
            this.databaseSet.Attach(entity);
            this.databaseContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Saves the changes into source
        /// </summary>
        public void SaveChanges()
        {
            this.databaseContext.SaveChanges();
        }
    }
}
