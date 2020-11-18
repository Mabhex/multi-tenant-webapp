using System.Threading;
using MultiTenant.Abstraction;

namespace MultiTenant
{
    
    public class TenantContextAccessor<TTenant> : ITenantContextAccessor<TTenant> where TTenant : class, ITenant
    {
        internal static AsyncLocal<ITenantContext<TTenant>> AsyncLocalContext = new AsyncLocal<ITenantContext<TTenant>>();
        public ITenantContext<TTenant> TenantContext
        {
            get => AsyncLocalContext.Value;
            set => AsyncLocalContext.Value = value;
        }
    }
}
