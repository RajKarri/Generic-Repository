//-----------------------------------------------------------------------
// <copyright file="FileSystemContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Contexts
{
    using System;
    using Repository.Interfaces;
    using SourceContexts;

    /// <summary>
    /// FIle system context class
    /// </summary>
    /// <typeparam name="T">Type of the file system context</typeparam>
    public class FileSystemContext<T> : IContext<FileSystemSourceContext>
    {
        /// <summary>
        /// File system key
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemContext{T}"/> class.
        /// </summary>        
        /// <param name="key">File system key</param>
        public FileSystemContext(string key)
        {
            this.key = key;
        }

        /// <summary>
        /// Gets current context
        /// </summary>
        public FileSystemSourceContext CurrentContext
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
        public FileSystemSourceContext GetContext()
        {
            // Use key or T or both to get the context
            // Implement logic to return API source context
            throw new NotImplementedException();
        }
    }
}
