using System.Collections.Generic;
using InventoryService.Models;

namespace InventoryService
{
    public class InventoryService : IInventoryService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            IList<Customer> customers = new List<Customer>();

            customers.Add(new Customer()
            {
                Id = 1,
                FName = "David",
                LName = "Hoffman",
                Address1 = "605 Sharview Cir",
                Address2 = "#1735",
                State = "NC",
                Country = "USA",
                Zipcode = "28217",
                Email = "demo1@mail.com",
                Phone = "1112223333"
            });
            customers.Add(new Customer()
            {
                Id = 2,
                FName = "Andy",
                LName = "Hoffman",
                Address1 = "605 Sharview Cir",
                Address2 = "#1735",
                State = "NC",
                Country = "USA",
                Zipcode = "28217",
                Email = "demo2@mail.com",
                Phone = "4442223333"
            });

            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = new Customer()
            {
                Id = id,
                FName = "Andy",
                LName = "Hoffman",
                Address1 = "605 Sharview Cir",
                Address2 = "#1735",
                State = "NC",
                Country = "USA",
                Zipcode = "28217",
                Email = "demo2@mail.com",
                Phone = "4442223333"
            };

            return customer;
        }

        public string AddCustomer(Customer customer)
        {
            return "Customer " + customer.FName + " details added";
        }

        public string UpdateCustomer(int id, Customer customer)
        {
            return "Customer " + customer.FName + " details updated";
        }

        public string DeleteCustomer(int id)
        {
            return "Customer " + id.ToString() + " record deleted";
        }
    }
}
