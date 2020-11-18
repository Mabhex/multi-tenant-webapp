using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace multi_tenant_webapp.Abstractions
{
    /// <summary>
    /// Service layer interface for Multi-Tenant Service demo
    /// </summary>
    public interface IService
    {
        Task<int> CalculateAsync(int a, int b);
    }
}
