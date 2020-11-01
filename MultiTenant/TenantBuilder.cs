using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Abstraction;

namespace MultiTenant
{
    /// <summary>
    /// Configure tenant services
    /// </summary>
    public class TenantBuilder<TTenant> where TTenant: class,ITenant,new()
    {
        private readonly IServiceCollection _services;

        public TenantBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// Register the tenant resolver strategy
        /// </summary>
        /// <param name="lifetime"></param>
        /// <typeparam name="TStrategy"></typeparam>
        /// <returns></returns>
        public TenantBuilder<TTenant> WithResolutionStrategy<TStrategy>(
            ServiceLifetime lifetime = ServiceLifetime.Transient) where TStrategy : class, ITenantResolverStrategy
        {
            _services.Add(ServiceDescriptor.Describe(typeof(ITenantResolverStrategy),typeof(TStrategy),lifetime));
            return this;
        }

        /// <summary>
        /// Register the tenant store
        /// </summary>
        /// <param name="lifetime"></param>
        /// <typeparam name="TStore"></typeparam>
        /// <returns></returns>
        public TenantBuilder<TTenant> WithStore<TStore>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TStore : class, ITenantStore<TTenant>
        {
            _services.Add(ServiceDescriptor.Describe(typeof(ITenantStore<TTenant>),typeof(TStore),lifetime));
            return this;
        }

    }
}