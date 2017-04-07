//-----------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Contexts
{
    using System;
    using System.Data.Common;
    using Repository.Interfaces;
    using SourceContexts;

    /// <summary>
    /// Database context class
    /// </summary>
    /// <typeparam name="T">Type of the database context</typeparam>
    public class DatabaseContext<T> : IContext<DatabaseSourceContext>
    {
        /// <summary>
        /// Database key
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext{T}"/> class.
        /// </summary>        
        /// <param name="key">Database key</param>
        public DatabaseContext(string key)
        {
            this.key = key;
        }

        /// <summary>
        /// Gets current context
        /// </summary>
        public DatabaseSourceContext CurrentContext
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
        public DatabaseSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return database source context
            throw new NotImplementedException();
        }
    }
}
