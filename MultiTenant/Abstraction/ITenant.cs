using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant.Abstraction
{
    /// <summary>
    /// Tenant Information
    /// </summary>
    public interface ITenant
    {
        /// <summary>
        /// Tenant Id
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// Tenant Information
        /// </summary>
        string Identifier { get; set; }
        /// <summary>
        /// Tenant Items
        /// </summary>
        IDictionary<string, object> Items { get; }
    }
}
