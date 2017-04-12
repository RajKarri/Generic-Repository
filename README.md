# Repository
Generic repository to get domain objects from any of the sources (Database, Entity framework, File system and etc.,.)

Repository patteren is one of the nicest patterns of all time and here is the generic repository pattern template. By making use of this template one can avoid lot of boilerplate code.

## Goal of this template
As mentioned earlier, goal of this template is to reduce lot of boilerplate code and business access layer will never bother about underlying data source. Underlying datasource could be anything like Database (ADO.Net), Entity framework, API, File system, Web service and etc.,.

Business layer just see eveything as objects comes out of repository.

## How this works?
    yet to update
## Api repository

Api repository GET call looks like

        [TestMethod]
        public void GitHubUserGetTest()
        {
            IRepository<GitUser> userRepository = new ApiRepository<GitUser>(UserKey);
            var gitUser = userRepository.Get();
        }
Api repository GET call with URL parameters looks like

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
## Entity framework code first repository
    yet to update
## Entity framework database first repository
    yet to update
## Database(ADO.Net) repository
    yet to update
## Web service repository
    yet to update
## File system repository
    yet to update

