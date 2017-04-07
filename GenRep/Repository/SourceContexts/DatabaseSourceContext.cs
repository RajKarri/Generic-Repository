//-----------------------------------------------------------------------
// <copyright file="DatabaseSourceContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.SourceContexts
{
    using System.Data.Common;

    /// <summary>
    /// Database source context
    /// </summary>
    public class DatabaseSourceContext
    {
        /// <summary>
        /// Gets or sets connection
        /// </summary>
        public DbConnection Conection { get; set; }

        // Add needed properties for database source context like DbCommand and etc.,.
    }
}
