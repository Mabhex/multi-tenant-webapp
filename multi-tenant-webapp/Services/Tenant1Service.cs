using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using multi_tenant_webapp.Abstractions;

namespace multi_tenant_webapp.Services
{

    /// <summary>
    /// Tenant1 wants the inputs to be calculated with addition
    /// </summary>
    public class Tenant1Service:IService
    {
        public async Task<int> CalculateAsync(int a, int b)
            => await Task.FromResult(a + b);
    }
}
