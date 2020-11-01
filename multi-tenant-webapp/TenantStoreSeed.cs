using MultiTenant.Abstraction;
using MultiTenant.Models;

namespace multi_tenant_webapp
{
    public class TenantStoreSeed
    {
        private readonly ITenantStore<Tenant> _tenantStore;

        public TenantStoreSeed(ITenantStore<Tenant> tenantStore)
        {
            _tenantStore = tenantStore;
        }

        public void Seed()
        {
            _tenantStore.TryAddAsync(new Tenant()
            {
                Id = "44a7419d-0a6d-4a58-98ca-02bb07be3ddd",
                Identifier = "localhost"
            });
        }
    }
}
