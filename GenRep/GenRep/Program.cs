using Models;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenRep
{
    class Program
    {
        static void Main(string[] args)
        {
            string gitUserKey = ConfigurationManager.AppSettings["GitUserApi"];
            string gitUsersKey = ConfigurationManager.AppSettings["GitUsersApi"];
            string customerKey = ConfigurationManager.AppSettings["CustomerApi"]; 

            IDictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "since", "135" }
            };

            IRepository<GitUser> rep1 = new ApiRepository<GitUser>(gitUsersKey);
            rep1.jSonInput = parameters;
            List<GitUser> gitUsers = rep1.GetAll().ToList();

            IRepository<Customer> repository2 = new ApiRepository<Customer>(customerKey);          
            List<Customer> customers = repository2.GetAll().ToList();            
                        
            ApiRepository<GitUser> api2 = new ApiRepository<GitUser>(gitUserKey);
            GitUser gitUser = api2.GetOne();
        }
    }
}
