using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MultiTenant.Abstraction;

namespace MultiTenant.TenantResolverStrategy
{
    /// <summary>
    /// Resolves Header "x-tenant" to identifier
    /// </summary>
    public class HeaderResolverStrategy : ITenantResolverStrategy
    {
        public async Task<string> GetTenantIdentifierAsync(object context)
        {
            if (!(context is HttpContext))
                throw new MultiTenantException(null,
                    new ArgumentException($"\"{nameof(context)}\" type must be of type HttpContext", nameof(context)));

            if (((HttpContext) context).Request.Headers.TryGetValue("x-tenant", out var identifier))
                throw new ArgumentException("Tenant header is missing");

            return await Task.FromResult(identifier);
        }
    }
}
