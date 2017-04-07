//-----------------------------------------------------------------------
// <copyright file="ApiSourceContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Repository.SourceContexts
{
    /// <summary>
    /// API source context
    /// </summary>
    public class ApiSourceContext
    {
        /// <summary>
        /// Gets or sets API uri
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets API verb
        /// </summary>
        public string Verb { get; set; }
       // Add needed properties for API source context
    }
}
