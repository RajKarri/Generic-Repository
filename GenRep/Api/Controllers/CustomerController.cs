using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            IList<Customer> customers = new List<Customer>();

            customers.Add(new Customer() { Id = 1, FName = "David", LName = "Hoffman", Address1 = "605 Sharview Cir", Address2 = "#1735",
                          State = "NC", Country = "USA", Zipcode = "28217", Email = "demo1@mail.com", Phone = "1112223333" });
            customers.Add(new Customer() { Id = 2, FName = "Andy", LName = "Hoffman", Address1 = "605 Sharview Cir", Address2 = "#1735",
                          State = "NC", Country = "USA", Zipcode = "28217", Email = "demo2@mail.com", Phone = "4442223333" });

            return customers;
        }

        // GET api/customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/customer
        public void Post([FromBody]string value)
        {
        }

        // PUT api/customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customer/5
        public void Delete(int id)
        {
        }
    }
}
