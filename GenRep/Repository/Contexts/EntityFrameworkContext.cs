using System;
using Repository.Interfaces;
using Repository.SourceContexts;

namespace Repository.Contexts
{
    public class EntityFrameworkContext<T> : IContext<EntityFrameworkSourceContext>
    {
        private string key = string.Empty;

        public EntityFrameworkContext(string key)
        {
            this.key = key;
        }

        public EntityFrameworkSourceContext CurrentContext
        {
            get
            {
                return this.GetContext();
            }
        }

        public EntityFrameworkSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return API source context
            throw new NotImplementedException();
        }
    }
}
