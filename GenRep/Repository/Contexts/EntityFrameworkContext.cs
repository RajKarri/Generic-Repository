//-----------------------------------------------------------------------
// <copyright file="EntityFrameworkContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Contexts
{
    using System;
    using System.Data.Entity;
    using Repository.Interfaces;
    using SourceContexts;

    /// <summary>
    /// Entity framework context class
    /// </summary>
    /// <typeparam name="T">Type of the entity framework context</typeparam>
    public class EntityFrameworkContext<T> : IContext<EntityFrameworkSourceContext>
    {
        /// <summary>
        /// Entity framework key
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkContext{T}"/> class.
        /// </summary>        
        /// <param name="key">Entity framework key</param>
        public EntityFrameworkContext(string key)
        {
            this.key = key;
        }

        /// <summary>
        /// Gets current context
        /// </summary>
        public EntityFrameworkSourceContext CurrentContext
        {
            get
            {
                return this.GetContext();
            }
        }

        /// <summary>
        /// Method to get source context
        /// </summary>
        /// <returns>Source context</returns>
        public EntityFrameworkSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return API source context
            throw new NotImplementedException();
        }
    }
}
