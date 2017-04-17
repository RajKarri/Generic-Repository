using System.Collections.Generic;
using System.ServiceModel;
using InventoryService.Models;

namespace InventoryService
{
    [ServiceContract]
    public interface IInventoryService
    {
        [OperationContract]
        IEnumerable<Customer> GetCustomers();

        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        string AddCustomer(Customer customer);

        [OperationContract]
        string UpdateCustomer(int id, Customer customer);

        [OperationContract]
        string DeleteCustomer(int id);
    }
}
