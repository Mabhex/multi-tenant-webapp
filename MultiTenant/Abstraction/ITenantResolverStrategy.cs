using System.Threading.Tasks;

namespace MultiTenant.Abstraction
{
    public interface ITenantResolverStrategy
    {
        /// <summary>
        /// Method  to control how the identifier is determined.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<string> GetTenantIdentifierAsync(object context);
    }
}
