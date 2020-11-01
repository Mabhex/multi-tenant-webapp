using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant.Abstraction
{
    public interface ITenantContext<TTenant> where TTenant:class,ITenant
    {
        TTenant Tenant { get; set; }
    }
}
