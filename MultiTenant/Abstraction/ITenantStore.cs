using System.Threading.Tasks;
using MultiTenant.Models;

namespace MultiTenant.Abstraction
{
    /// <summary>
    /// Tenant store implementation definition
    /// </summary>
    public interface ITenantStore<TTenant> where TTenant:class,ITenant,new()
    {
        /// <summary>
        /// Retrieve the Tenant for a given identifier.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        Task<TTenant> TryGetByIdentifierAsync(string identifier);

        /// <summary>
        /// Retrieve the Tenant for a given tenant Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TTenant> TryGetAsync(string id);

        /// <summary>
        /// Add tenant data to tenant store
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <returns></returns>
        Task<bool> TryAddAsync(TTenant tenantInfo);
    }
}
