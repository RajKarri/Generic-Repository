using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repository.Interfaces;
using Repository.Repositories;

namespace Tests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void RetrieveGitUserTest()
        {
            IRepository<GitUser> userRepository = new ApiRepository<GitUser>("GitUserApi");
            var gitUser = userRepository.Get();
        }

        [TestMethod]
        public void RetrieveAllGitUserTest()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>() { { "since", "135" } };
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("Parameters", parameters);

            IRepository<GitUser> usersRepository = new ApiRepository<GitUser>("GitUsersApi");
            usersRepository.Input = input;
            List<GitUser> gitUsers = usersRepository.GetAll().ToList();
        }

        [TestMethod]
        public void RetrieveAllCustomersTest()
        {
            IRepository<Customer> customerRepository = new ApiRepository<Customer>("CustomerApi");
            List<Customer> customers = customerRepository.GetAll().ToList();
        }

        [TestMethod]
        public void RetrieveCustomerTest()
        {
            IList<string> urlValues = new List<string>() { "1" };
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("UrlValues", urlValues);

            IRepository<Customer> customerRepository = new ApiRepository<Customer>("CustomerApi");
            customerRepository.Input = input;
            Customer customer = customerRepository.Get();
        }

        [TestMethod]
        public void CreateCustomerTest()
        {
            IRepository<Customer> customerRepository = new ApiRepository<Customer>("CustomerApi");
            Customer customer = customerRepository.Add(new Customer() { Id = 55, FName = "User1" });
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            IList<string> urlValues = new List<string>() { "55" };
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("UrlValues", urlValues);

            IRepository<Customer> customerRepository = new ApiRepository<Customer>("CustomerApi");
            customerRepository.Input = input;
            dynamic response = customerRepository.Update(new Customer() { Id = 55, FName = "User2" });
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            IRepository<Customer> customerRepository = new ApiRepository<Customer>("CustomerApi");
            var response = customerRepository.Delete(2);
        }
    }
}
