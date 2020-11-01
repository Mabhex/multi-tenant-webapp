using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Abstraction;
using MultiTenant.Models;

namespace MultiTenant.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the services (default tenant class)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static TenantBuilder<TTenant> AddMultiTenancy<TTenant>(this IServiceCollection services) where TTenant:class,ITenant,new()
        {
            services.AddScoped<ITenantContext<TTenant>,TenantContext<TTenant>>();
            services.AddScoped<ITenant, TTenant>();
            services.AddSingleton<ITenantContextAccessor<TTenant>, TenantContextAccessor<TTenant>>();

            return new TenantBuilder<TTenant>(services);
        }

    }
}