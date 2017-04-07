//-----------------------------------------------------------------------
// <copyright file="ApiRepository.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Newtonsoft.Json;
    using Repository.Contexts;
    using Repository.Interfaces;
    using RestWrapper;

    /// <summary>
    /// API Repository
    /// </summary>
    /// <typeparam name="T">Type of API repository</typeparam>
    public class ApiRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// API context
        /// </summary>
        private ApiContext<T> apiContext;

        public IDictionary<string, string> jSonInput { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRepository{T}"/> class.
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="verb">Verb</param>
        public ApiRepository(string url)
        {
            this.apiContext = new ApiContext<T>(url);
        }

        /// <summary>
        /// Get all objects of type T
        /// </summary>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetAll()
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri, RestSharpMethod.GET);
            var apiResponse = RestSharpCall.MakeAsync<List<object>>(jSonInput);

            IList<T> response = new List<T>();

            apiResponse.ForEach(x =>
            {
                response.Add(JsonConvert.DeserializeObject<T>(x.ToString()));
            });

            return response.AsQueryable();
        }

        /// <summary>
        /// Get all objects of type T after filtration
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IList<T> response = new List<T>();
            response = this.GetAll().Where(predicate).ToList();
            return response.AsQueryable();
        }

        public T GetOne()
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri, RestSharpMethod.GET);
            var apiResponse = RestSharpCall.MakeAsync<object>(jSonInput);

            T response = JsonConvert.DeserializeObject<T>(apiResponse.ToString());
            return response;
        }

        /// <summary>
        /// Get N objects of type T from a particular page 
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="count">Number of entities</param>
        /// <returns>Response of objects</returns>
        public IQueryable<T> GetNEntities(int pageNumber, int count)
        {
            List<T> response = new List<T>();
            response = this.GetAll().Skip((pageNumber - 1) * count).Take(count).ToList();
            return response.AsQueryable();
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
            List<T> response = new List<T>();
            response = this.GetAll().Where(predicate).Skip((pageNumber - 1) * count).Take(count).ToList();
            return response.AsQueryable();
        }

        /// <summary>
        /// Get object by
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Response of objects</returns>
        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            T response = this.GetAll().Where(predicate).FirstOrDefault();
            return response;
        }

        /// <summary>
        /// Adds object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after addition</returns>
        public T Add(T entity)
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri, RestSharpMethod.POST);
            //var apiResponse = RestSharpCall.MakeAsync<object>(jSonInput);

            return entity;
        }

        /// <summary>
        /// Removes object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after removals</returns>
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
            RestSharpCall.Init(apiContext.CurrentContext.Uri, RestSharpMethod.DELETE);
            var response = RestSharpCall.MakeAsync<object>(jSonInput);

            return response;
        }

        /// <summary>
        /// Updates object of type T
        /// </summary>
        /// <param name="entity">Entity of type T</param>
        /// <returns>Response after update</returns>
        public dynamic Update(T entity)
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri, RestSharpMethod.POST);
            var response = RestSharpCall.MakeAsync<object>(jSonInput);

            return response;
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
