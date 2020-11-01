using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using MultiTenant.Abstraction;

namespace MultiTenant.TenantStorage
{
    public class InMemoryStore<TTenant>:ITenantStore<TTenant> where TTenant:class,ITenant,new()
    {
        private readonly ConcurrentDictionary<string, TTenant> _tenantMap;

        public InMemoryStore()
        {
            _tenantMap = new ConcurrentDictionary<string, TTenant>();
        }

        public async Task<TTenant> TryGetByIdentifierAsync(string identifier)
        {
            _tenantMap.TryGetValue(identifier, out var result);
            return await Task.FromResult(result);
        }

        public async Task<TTenant> TryGetAsync(string id)
        {
            var result = _tenantMap.Values.SingleOrDefault(x => x.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<bool> TryAddAsync(TTenant tenantInfo)
        {
            var result = _tenantMap.TryAdd(tenantInfo.Identifier, tenantInfo);

            return await Task.FromResult(result);
        }
    }
}
