using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Abstraction;

namespace MultiTenant.Extensions
{
    /// <summary>
    /// Get current tenant from HttpContext
    /// </summary>
    public static class HttpContextExtension
    {
        public static ITenantContext<TTenant> GeTenantContext<TTenant>(this HttpContext context) where TTenant:class,ITenant,new()
        {
            return context.RequestServices.GetRequiredService<ITenantContextAccessor<TTenant>>()?.TenantContext;
        }
    }
}
