using System;
using Repository.Interfaces;
using Repository.SourceContexts;
using WcfService;

namespace Repository.Contexts
{
    public class ServiceContext<T> : IContext<ServiceSourceContext<T>> where T : class
    {
        private string key = string.Empty;

        public ServiceContext(string key)
        {
            this.key = key;
        }

        public ServiceSourceContext<T> CurrentContext
        {
            get
            {
                return this.GetContext();
            }
        }

        public ServiceSourceContext<T> GetContext()
        {
            ServiceSourceContext<T> sourceContext = new ServiceSourceContext<T>();

            if (typeof(T).Equals(typeof(Models.Customer)))
            {
                sourceContext.ServiceProxy = new CustomerServiceProxy<T>();
            }

            return sourceContext;
        }
    }
}
