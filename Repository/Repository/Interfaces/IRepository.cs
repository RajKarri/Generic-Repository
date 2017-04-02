//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Repository of objects
    /// </summary>
    /// <typeparam name="T">Type of the item</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all objects of type T
        /// </summary>
        /// <returns>Response of objects</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get all objects of type T after filtration
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get N objects of type T from a particular page 
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="count">Number of entities</param>
        /// <returns>Response of objects</returns>
        IQueryable<T> GetNEntities(int pageNumber, int count);

        /// <summary>
        /// Get N objects of type T from a particular page after filtration
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="count">Number of entities</param>
        /// <returns>Response of objects</returns>
        IQueryable<T> GetNEntities(Expression<Func<T, bool>> predicate, int pageNumber, int count);

        /// <summary>
        /// Get object by
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        T GetBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response of object</returns>
        T Add(T entity);

        /// <summary>
        /// Removes object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after removal</returns>
        dynamic Remove(T entity);

        /// <summary>
        /// Deletes the object 
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>Response after deletion</returns>
        dynamic Delete(dynamic id);

        /// <summary>
        /// Updates object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after update</returns>
        dynamic Update(T entity);

        /// <summary>
        /// Saves the changes into source
        /// </summary>
        void SaveChanges();
    }
}
