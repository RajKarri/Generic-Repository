using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Repository.Contexts;
using Repository.Interfaces;
using RestWrapper;

namespace Repository.Repositories
{
    public class ApiRepository<T> : IRepository<T> where T : class
    {
        private ApiContext<T> apiContext;

        private IDictionary<string, string> parameters
        {
            get
            {
                return Input != null ? (Input.ContainsKey("Parameters") ? Input["Parameters"] as IDictionary<string, string> : null) : null;
            }
        }

        private IDictionary<string, string> headers
        {
            get
            {
                return Input != null ? (Input.ContainsKey("Headers") ? Input["Headers"] as IDictionary<string, string> : null) : null;
            }
        }

        private string urlValues
        {
            get
            {
                return Input != null ? (Input.ContainsKey("UrlValues") ? "/" + string.Join("/", (List<string>)Input["UrlValues"]) : null) : null;
            }
        }

        public IDictionary<string, object> Input { get; set; }

        public ApiRepository(string key)
        {
            this.apiContext = new ApiContext<T>(key);
        }

        public IQueryable<T> GetAll()
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri + urlValues, RestSharpMethod.GET);
            var apiResponse = RestSharpCall.MakeAsync<List<object>>(parameters, headers);

            IList<T> response = new List<T>();

            if (apiResponse != null)
            {
                apiResponse.ForEach(x =>
                            {
                                response.Add(JsonConvert.DeserializeObject<T>(x.ToString()));
                            });
            }

            return response.AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IList<T> response = new List<T>();
            response = this.GetAll().Where(predicate).ToList();
            return response.AsQueryable();
        }

        public IQueryable<T> GetNEntities(int pageNumber, int count)
        {
            List<T> response = new List<T>();
            response = this.GetAll().Skip((pageNumber - 1) * count).Take(count).ToList();
            return response.AsQueryable();
        }

        public IQueryable<T> GetNEntities(Expression<Func<T, bool>> predicate, int pageNumber, int count)
        {
            List<T> response = new List<T>();
            response = this.GetAll().Where(predicate).Skip((pageNumber - 1) * count).Take(count).ToList();
            return response.AsQueryable();
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            T response = this.GetAll().Where(predicate).FirstOrDefault();
            return response;
        }

        public T Add(T entity)
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri + urlValues, RestSharpMethod.POST);
            var apiResponse = RestSharpCall.MakeAsync<object>(parameters, headers, null, null, null, entity);

            return entity;
        }

        public dynamic Remove(T entity)
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }

        public dynamic Delete(dynamic id)
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri + "/" + id, RestSharpMethod.DELETE);
            var response = RestSharpCall.MakeAsync<object>(null, headers);

            return response;
        }

        public dynamic Update(T entity)
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri + urlValues, RestSharpMethod.PUT);
            var response = RestSharpCall.MakeAsync<object>(parameters, headers, null, null, null, entity);

            return response;
        }

        public void SaveChanges()
        {
            throw new NotSupportedException("This method is supported only in entity framework");
        }

        public T Get()
        {
            RestSharpCall.Init(apiContext.CurrentContext.Uri + urlValues, RestSharpMethod.GET);
            var apiResponse = RestSharpCall.MakeAsync<object>(parameters, headers, null, null, null, null);

            if (apiResponse != null)
            {
                T response = JsonConvert.DeserializeObject<T>(apiResponse.ToString());
                return response;
            }
            return null;
        }
    }
}
