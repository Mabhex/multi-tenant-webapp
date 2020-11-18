using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using multi_tenant_webapp.Abstractions;

namespace multi_tenant_webapp.Services
{
    /// <summary>
    /// Tenant 2 wants the input to be calculated with multiplication
    /// </summary>
    public class Tenant2Service:IService
    {
        public async Task<int> CalculateAsync(int a, int b)
            => await Task.FromResult(a * b);
    }
}
