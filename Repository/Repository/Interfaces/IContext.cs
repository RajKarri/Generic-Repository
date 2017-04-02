//-----------------------------------------------------------------------
// <copyright file="IContext.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved
// </copyright>
//-----------------------------------------------------------------------
namespace Repository.Interfaces
{
    /// <summary>
    /// Context interface
    /// </summary>
    /// <typeparam name="T">Type of the source context</typeparam>
    public interface IContext<T> where T : class
    {
        /// <summary>
        /// Gets current context
        /// </summary>
        T CurrentContext { get; }

        /// <summary>
        /// Method to get source context
        /// </summary>
        /// <returns>Source context</returns>
        T GetContext();
    }
}
