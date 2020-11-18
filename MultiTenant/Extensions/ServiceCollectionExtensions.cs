using Autofac.Multitenant;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Abstraction;
using MultiTenant.Models;
using MultiTenant.TenantResolverStrategy;

namespace MultiTenant.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the multi-tenant services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static TenantBuilder<TTenant> AddMultiTenancy<TTenant>(this IServiceCollection services) where TTenant:class,ITenant,new()
        {
            services.AddScoped<ITenantContext<TTenant>,TenantContext<TTenant>>();
            services.AddScoped<ITenant, TTenant>();
            services.AddScoped<ITenantIdentificationStrategy, MultiTenantResolverStrategy<TTenant>>();
            services.AddSingleton<ITenantContextAccessor<TTenant>, TenantContextAccessor<TTenant>>();

            return new TenantBuilder<TTenant>(services);
        }

    }
}