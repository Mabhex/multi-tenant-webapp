using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using MultiTenant.Abstraction;

namespace MultiTenant.Extensions
{
    /// <summary>
    /// Add multi-tenant middleware
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseMultiTenancy<TTenant>(this IApplicationBuilder builder)
            where TTenant : class, ITenant,new()
            => builder.UseMiddleware<MultiTenantMiddleware<TTenant>>();
    }
}
