//-----------------------------------------------------------------------
// <copyright file="ApiContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Contexts
{
    using System;
    using Repository.Interfaces;
    using SourceContexts;

    /// <summary>
    /// API context class
    /// </summary>
    /// <typeparam name="T">Type of the API context</typeparam>
    public class ApiContext<T> : IContext<ApiSourceContext>
    {
        /// <summary>
        /// API key 
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContext{T}"/> class.
        /// </summary>        
        /// <param name="key">API key</param>
        public ApiContext(string key)
        {
            this.key = key;
        }

        /// <summary>
        /// Gets current context
        /// </summary>
        public ApiSourceContext CurrentContext
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
        public ApiSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return API source context
            throw new NotImplementedException();
        }
    }
}
