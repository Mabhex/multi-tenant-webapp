using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant
{
    /// <summary>
    /// Derived exception for Multi-Tenant project
    /// </summary>
    public class MultiTenantException:Exception
    {
        public MultiTenantException(string message, Exception innerException=null)
            :base(message, innerException) { }
    }
}
