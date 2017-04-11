using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repository.Interfaces;
using Repository.Repositories;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ApiTests
    {
        const string UserKey = "GitUserApi";
        const string UsersKey = "GitUsersApi";
        const string CustomerKey = "CustomerApi";

        [TestMethod]
        public void GitHubUsersGetAllTest()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "since", "135" }
            };
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("Parameters", parameters);

            IRepository<GitUser> usersRepository = new ApiRepository<GitUser>(UsersKey);
            usersRepository.Input = input;
            List<GitUser> gitUsers = usersRepository.GetAll().ToList();
        }

        [TestMethod]
        public void GitHubUserGetTest()
        {
            IRepository<GitUser> userRepository = new ApiRepository<GitUser>(UserKey);
            var gitUser = userRepository.Get();
        }

        [TestMethod]
        public void CustomersGetTest()
        {
            IRepository<Customer> customerRepository = new ApiRepository<Customer>(CustomerKey);
            List<Customer> customers = customerRepository.GetAll().ToList();
        }

        [TestMethod]
        public void CustomerGetTest()
        {
            IList<string> urlValues = new List<string>() { "1" };
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("UrlValues", urlValues);

            IRepository<Customer> customerRepository = new ApiRepository<Customer>(CustomerKey);
            customerRepository.Input = input;
            Customer customer = customerRepository.Get();
        }

        [TestMethod]
        public void CustomerPostTest()
        {
            IRepository<Customer> customerRepository = new ApiRepository<Customer>(CustomerKey);
            Customer customer = customerRepository.Add(new Customer() { Id = 55, FName = "User1" });
        }

        [TestMethod]
        public void CustomerUpdateTest()
        {
            IList<string> urlValues = new List<string>() { "55" };
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("UrlValues", urlValues);

            IRepository<Customer> customerRepository = new ApiRepository<Customer>(CustomerKey);
            customerRepository.Input = input;
            dynamic response = customerRepository.Update(new Customer() { Id = 55, FName = "User2" });
        }

        [TestMethod]
        public void CustomerDeleteTest()
        {
            IRepository<Customer> customerRepository = new ApiRepository<Customer>(CustomerKey);
            var response = customerRepository.Delete(2);
        }
    }
}
