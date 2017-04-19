using Models;
using System;
using System.Collections.Generic;
using System.Text;
using WcfService.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using WcfService.Transfomations;

namespace WcfService
{
    public class CustomerServiceProxy<T> : IServiceProxy<T> where T : class
    {
        InventoryService.InventoryServiceClient client = new InventoryService.InventoryServiceClient();

        public dynamic Add(T entity)
        {
            InventoryService.Customer customer = AutoMap.ConvertTo<InventoryService.Customer, Models.Customer>(entity as Models.Customer);
            var response = client.AddCustomerAsync(customer);
            return response.Result;
        }

        public dynamic Delete(dynamic id)
        {
            var response = client.DeleteCustomerAsync(id);
            return response.Result;
        }

        public IQueryable<T> Get()
        {
            var response = client.GetCustomersAsync();
            var output = AutoMap.ConvertTo<List<T>, List<InventoryService.Customer>>(response.Result);
            return output.AsQueryable();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            var response = client.GetCustomersAsync();
            var output = AutoMap.ConvertTo<List<T>, List<InventoryService.Customer>>(response.Result);
            return output.AsQueryable().Where(predicate);
        }

        public dynamic Update(T entity)
        {
            InventoryService.Customer customer = AutoMap.ConvertTo<InventoryService.Customer, Models.Customer>(entity as Models.Customer);
            var response = client.UpdateCustomerAsync(customer.Id, customer);
            return response.Result;
        }
    }
}
