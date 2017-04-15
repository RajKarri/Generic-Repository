using System;
using Repository.Interfaces;
using Repository.SourceContexts;

namespace Repository.Contexts
{
    public class DatabaseContext<T> : IContext<DatabaseSourceContext>
    {
        private string key = string.Empty;

        public DatabaseContext(string key)
        {
            this.key = key;
        }

        public DatabaseSourceContext CurrentContext
        {
            get
            {
                return this.GetContext();
            }
        }

        public DatabaseSourceContext GetContext()
        {
            throw new NotImplementedException();
        }
    }
}
