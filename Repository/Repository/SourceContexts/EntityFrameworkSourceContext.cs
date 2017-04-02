//-----------------------------------------------------------------------
// <copyright file="EntityFrameworkSourceContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.SourceContexts
{
    using System.Data.Entity;

    /// <summary>
    /// Entity framework source context
    /// </summary>
    public class EntityFrameworkSourceContext
    {
        /// <summary>
        /// Gets or sets DB context
        /// </summary>
        public DbContext DbContext { get; set; }

        // Add needed properties for entity framework source context
    }
}
