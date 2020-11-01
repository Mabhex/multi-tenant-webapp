using System.Threading;
using MultiTenant.Abstraction;

namespace MultiTenant
{
    public class TenantContextAccessor<TTenant> : ITenantContextAccessor<TTenant>,ITenantContextAccessor where TTenant : class, ITenant
    {
        internal static AsyncLocal<ITenantContext<TTenant>> AsyncLocalContext = new AsyncLocal<ITenantContext<TTenant>>();
        public ITenantContext<TTenant> TenantContext
        {
            get => AsyncLocalContext.Value;
            set => AsyncLocalContext.Value = value;
        }

        object ITenantContextAccessor.TenantContext
        {
            get => TenantContext;
            set => TenantContext = value as ITenantContext<TTenant> ?? TenantContext;
        }
    }
}
