using System.Collections;
using System.Collections.Generic;
using MultiTenant.Abstraction;

namespace MultiTenant.Models
{
    /// <summary>
    /// Tenant Information
    /// </summary>
    public class Tenant:ITenant
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public IDictionary<string,object> Items { get; private set; }=new Dictionary<string, object>();
    }
}
