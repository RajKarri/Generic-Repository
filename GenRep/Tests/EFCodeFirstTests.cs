using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Interfaces;
using Repository.Repositories;
using EFCodeFirst.Models;

namespace Tests
{
    [TestClass]
    public class EFCodeFirstTests
    {
        public EFCodeFirstTests()
        {
        }

        [TestMethod]
        public void GetAllCustomersTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>("InventoryContext");
            var customers = customersRepository.GetAll();
        }
    }
}
