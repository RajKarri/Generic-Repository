using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        // GET api/customer
        [HttpGet]
        public IEnumerable<Customer> Get()
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

        // GET api/customer/5
        [HttpGet]
        public Customer Get(int id)
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

        // POST api/customer
        [HttpPost]
        public string Post(Customer customer)
        {
            return "Customer " + customer.FName + " details added";
        }

        // PUT api/customer/5
        [HttpPut]
        public string Put(int id, Customer customer)
        {
            return "Customer " + customer.FName + " details updated";
        }


        // DELETE api/customer/5
        [HttpDelete]
        public string Delete(int id)
        {
            return "Customer record deleted";
        }
    }
}