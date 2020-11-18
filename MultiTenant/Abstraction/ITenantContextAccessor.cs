using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant.Abstraction
{
    /// <summary>
    /// Tenant information access similar to IHttpContextAccessor 
    /// </summary>
    /// <typeparam name="TTenant"></typeparam>
    public interface ITenantContextAccessor<TTenant> where TTenant:class ,ITenant
    {
        ITenantContext<TTenant> TenantContext { get; set; }
    }
}
