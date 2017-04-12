# Repository
Generic repository to get domain objects from any of the sources (Database, Entity framework, File system and etc.,.)

Repository patteren is one of the nicest patterns of all time and here is the generic repository pattern template. By making use of this template one can avoid lot of boilerplate code.

## Goal of this template
As mentioned earlier, goal of this template is to reduce lot of boilerplate code and business access layer will never bother about underlying data source. Underlying datasource could be anything like Database (ADO.Net), Entity framework, API, File system, Web service and etc.,.

Business layer just see eveything as objects comes out of repository.

## How this works?
Fork or Download GitHub repository("GenRep") to see how this works in action.
    
## Api repository

Api repository GET call looks like

        public void RetrieveGitUserTest()
        {
            IRepository<GitUser> userRepository = new ApiRepository<GitUser>("GitUserApi");
            var gitUser = userRepository.Get();
        }
Api repository GET call with URL parameters looks like

        public void RetrieveAllGitUserTest()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>() { { "since", "135" } };
            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("Parameters", parameters);

            IRepository<GitUser> usersRepository = new ApiRepository<GitUser>("GitUsersApi");
            usersRepository.Input = input;
            List<GitUser> gitUsers = usersRepository.GetAll().ToList();
        }
## Entity framework code first repository

EF code first repository call looks like

        public void RetrieveCustomersTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>("InventoryContext");
            var customers = customersRepository.GetAll().ToList();
        }
EF code first repository call for creation looks like
       
        public void CreateCustomerTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>("InventoryContext");
            Customer customer = new Customer()
            {
                FName = "Dave",
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
            customersRepository.SaveChanges();
        }
EF code first repository call for updation looks like   
    
        public void UpdateCustomerTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>("InventoryContext");
            var customer = customersRepository.GetBy(x => x.Id == 1);
            customer.FName = "Andy";
            var response = customersRepository.Update(customer);
            customersRepository.SaveChanges();
        }
        
## Entity framework database first repository
    yet to update (This one is similar to code frist approach)
## Database(ADO.Net) repository
    yet to update
## Web service repository
    yet to update
## File system repository
    yet to update

