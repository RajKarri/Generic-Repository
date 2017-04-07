using Models;
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
            string gitUsersKey = ConfigurationManager.AppSettings["GitUsersApi"];

            IDictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "since", "135" }
            };

            ApiRepository<GitUser> repository = new ApiRepository<GitUser>(gitUsersKey);
            repository.jSonInput = parameters;
            var gitUsers = repository.GetAll();

            string gitUserKey = ConfigurationManager.AppSettings["GitUserApi"];
            ApiRepository<GitUser> api2 = new ApiRepository<GitUser>(gitUserKey);
            var result2 = api2.GetOne();
        }
    }
}
