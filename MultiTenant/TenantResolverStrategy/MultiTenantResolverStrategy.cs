
using Autofac.Multitenant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Abstraction;

namespace MultiTenant.TenantResolverStrategy
{
    /// <summary>
    /// Autofac tenant identification strategy. 
    /// </summary>
    internal class MultiTenantResolverStrategy<T>:ITenantIdentificationStrategy where T:class,ITenant, new()
    {
        private readonly ITenantResolverStrategy _strategy;
        private readonly IHttpContextAccessor _httpContext;

        public MultiTenantResolverStrategy(IHttpContextAccessor httpContext, ITenantResolverStrategy strategy)
        {
            _httpContext = httpContext;
            _strategy = strategy;
        }

        /// <summary>
        /// Get Tenant identifier based on the Tenant Resolver Strategy
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public bool TryIdentifyTenant(out object tenantId)
        {
            tenantId = null;
            if (_httpContext.HttpContext != null)
            {
                tenantId = _strategy.GetTenantIdentifierAsync(_httpContext.HttpContext).GetAwaiter().GetResult();
            }

            
            return tenantId!=null;
        }
    }
}
