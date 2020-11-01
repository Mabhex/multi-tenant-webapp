using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MultiTenant.Abstraction;

namespace MultiTenant.TenantResolverStrategy
{
    /// <summary>
    /// Resolves Host to tenant identifier
    /// </summary>
    public class HostResolverStrategy:ITenantResolverStrategy
    {
        public async Task<string> GetTenantIdentifierAsync(object context)
        {
            if (!(context is HttpContext))
                throw new MultiTenantException(null,
                    new ArgumentException($"\"{nameof(context)}\" type must be of type HttpContext", nameof(context)));
            return await Task.FromResult(((HttpContext)context).Request.Host.Host);
        }
        
    }
}
