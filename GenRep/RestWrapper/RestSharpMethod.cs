//-----------------------------------------------------------------------
// <copyright file="RestSharpMethod.cs" company="XXXXXXX">
// Copyright (c) XXXXXXX. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RestWrapper
{
    /// <summary>
    /// Http verbs enum
    /// </summary>
    public enum RestSharpMethod
    {
        /// <summary>
        /// Get method
        /// </summary>
        GET = 0,

        /// <summary>
        /// Post method
        /// </summary>
        POST = 1,

        /// <summary>
        /// Put method
        /// </summary>
        PUT = 2,

        /// <summary>
        /// Delete method
        /// </summary>
        DELETE = 3,

        /// <summary>
        /// Head method
        /// </summary>
        HEAD = 4,

        /// <summary>
        /// Options method
        /// </summary>
        OPTIONS = 5,

        /// <summary>
        /// Patch method
        /// </summary>
        PATCH = 6,

        /// <summary>
        /// Merge method
        /// </summary>
        MERGE = 7
    }
}
