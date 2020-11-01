using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MultiTenant.Abstraction;

namespace MultiTenant
{
    public class TenantContext<TTenant>:ITenantContext<TTenant> where TTenant:class,ITenant
    {
        public TTenant Tenant { get; set; }
    }
}