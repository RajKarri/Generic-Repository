using Repository.Interfaces;
using Repository.SourceContexts;
using EFCodeFirst;

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
            EntityFrameworkSourceContext sourceContext = new EntityFrameworkSourceContext();

            if (key == "InventoryContext")
            {
                sourceContext.DbContext = new InventoryContext();
            }

            return sourceContext;
        }
    }
}
