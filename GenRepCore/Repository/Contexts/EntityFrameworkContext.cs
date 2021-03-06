﻿using EFCodeFirst;
using Microsoft.Extensions.Configuration;
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
            EntityFrameworkSourceContext sourceContext = new EntityFrameworkSourceContext();
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot Configuration = builder.Build();

            if (typeof(T).Equals(typeof(Models.Customer)))
            {
                string connection = Configuration["InventoryContext"];
                sourceContext.DbContext = new InventoryContext(connection);
            }

            return sourceContext;
        }
    }
}
