using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repository.Interfaces;
using Repository.Repositories;
using WcfService;
using System;

namespace Tests
{
    [TestClass]
    public class WcfServiceTests
    {
        public WcfServiceTests()
        {
        }

        [TestMethod]
        public void WcfService_CreateCustomerTest()
        {
            IRepository<Customer> customersRepository = new ServiceRepository<Customer>();
            Customer customer = new Customer()
            {
                FName = "Dave" + DateTime.Now,
                LName = "Richardson",
                Address1 = "605 Sharview Cir",
                Address2 = "#1735",
                State = "NC",
                Country = "USA",
                Zipcode = "28217",
                Phone = "1234567890",
                Email = "a@a.com"
            };
            var response = customersRepository.Add(customer);
        }

        [TestMethod]
        public void WcfService_RetrieveCustomersTest()
        {
            IRepository<Customer> customersRepository = new ServiceRepository<Customer>();
            var customers = customersRepository.GetAll().ToList();
        }

        [TestMethod]
        public void WcfService_UpdateCustomerTest()
        {
            IRepository<Customer> customersRepository = new ServiceRepository<Customer>();
            var customer = customersRepository.GetBy(x => x.Id == 1);
            customer.FName = "Andy";
            var response = customersRepository.Update(customer);
        }

        [TestMethod]
        public void WcfService_DeleteCustomerTest()
        {
            IRepository<Customer> customersRepository = new ServiceRepository<Customer>();
            var response = customersRepository.Delete(1);
        }
    }
}
