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
    using System.Configuration;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

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

        private string jSonInput = string.Empty;

        private ApiSourceContext apiSourceContext = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContext{T}"/> class.
        /// </summary>        
        /// <param name="key">API key</param>
        public ApiContext(string key)
        {
            this.key = key;
            this.apiSourceContext = GetContext();
        }

        /// <summary>
        /// Gets current context
        /// </summary>
        public ApiSourceContext CurrentContext
        {
            get
            {
                return this.apiSourceContext;
            }
        }

        /// <summary>
        /// Method to get source context
        /// </summary>
        /// <returns>Source context</returns>
        public ApiSourceContext GetContext()
        {
            ApiSourceContext sourceContext = new ApiSourceContext();
            string gitUserKey = ConfigurationManager.AppSettings["GitUserApi"];
            string gitUsersKey = ConfigurationManager.AppSettings["GitUsersApi"];

            if (!string.IsNullOrEmpty(this.key))
            {
                if (key == gitUserKey)
                {
                    sourceContext.Uri = gitUserKey;
                    sourceContext.Verb = "GET";
                }
                else if (key == gitUsersKey)
                {
                    sourceContext.Uri = gitUsersKey;
                    sourceContext.Verb = "GET";
                }
            }

            return sourceContext;
        }
    }
}
