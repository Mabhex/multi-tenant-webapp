using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Abstraction;

namespace MultiTenant
{
    internal class MultiTenantMiddleware<TTenant> where TTenant : class, ITenant, new()
    {
        private readonly RequestDelegate _next;

        public MultiTenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var accessor = context.RequestServices.GetRequiredService<ITenantContextAccessor<TTenant>>();

            if (accessor.TenantContext == null)
            {
                var strategy = context.RequestServices.GetRequiredService<ITenantResolverStrategy>();
                var identifier = await strategy.GetTenantIdentifierAsync(context);
                var store = context.RequestServices.GetRequiredService<ITenantStore<TTenant>>();
                accessor.TenantContext = new TenantContext<TTenant>()
                {
                    Tenant = await store.TryGetByIdentifierAsync(identifier)
                };
            }

            if (_next != null)
            {
                await _next(context);
            }
        }
    }
}
