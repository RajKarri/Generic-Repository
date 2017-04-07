//-----------------------------------------------------------------------
// <copyright file="ServiceContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Contexts
{
    using System;
    using Repository.Interfaces;
    using SourceContexts;

    /// <summary>
    /// Service context class
    /// </summary>
    /// <typeparam name="T">Type of the service context</typeparam>
    public class ServiceContext<T> : IContext<ServiceSourceContext>
    {
        /// <summary>
        /// Service key
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceContext{T}"/> class.
        /// </summary>        
        /// <param name="key">Service key</param>
        public ServiceContext(string key)
        {
            this.key = key;
        }

        /// <summary>
        /// Gets current context
        /// </summary>
        public ServiceSourceContext CurrentContext
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
        public ServiceSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return API source context
            throw new NotImplementedException();
        }
    }
}
