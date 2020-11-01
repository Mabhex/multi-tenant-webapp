using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant.Abstraction
{
    public interface ITenantContextAccessor<TTenant> where TTenant:class ,ITenant
    {
        ITenantContext<TTenant> TenantContext { get; set; }
    }

    public interface ITenantContextAccessor
    {
        object TenantContext { get; set; }
    }
}
