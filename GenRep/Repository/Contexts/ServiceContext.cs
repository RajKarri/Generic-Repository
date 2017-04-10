using System;
using Repository.Interfaces;
using Repository.SourceContexts;

namespace Repository.Contexts
{
    public class ServiceContext<T> : IContext<ServiceSourceContext>
    {
        private string key = string.Empty;

        public ServiceContext(string key)
        {
            this.key = key;
        }

        public ServiceSourceContext CurrentContext
        {
            get
            {
                return this.GetContext();
            }
        }

        public ServiceSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return API source context
            throw new NotImplementedException();
        }
    }
}
