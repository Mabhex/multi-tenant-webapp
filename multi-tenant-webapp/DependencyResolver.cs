using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Multitenant;
using Microsoft.AspNetCore.Http;
using multi_tenant_webapp.Abstractions;
using multi_tenant_webapp.Services;
using MultiTenant.Models;
using MultiTenant.TenantResolverStrategy;

namespace multi_tenant_webapp
{
    public class DependencyResolver
    {
        /// <summary>
        /// Register all tenant specific services
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static MultitenantContainer RegisterServices(IContainer container)
        {
            var strategy = container.Resolve<ITenantIdentificationStrategy>();
            var tenantContainer=new MultitenantContainer(strategy,container);
            tenantContainer.ConfigureTenant("tenant1", cd=>cd.RegisterType<Tenant1Service>().As<IService>());
            tenantContainer.ConfigureTenant("tenant2", cd=>cd.RegisterType<Tenant2Service>().As<IService>());

            return tenantContainer;
        }
    }
}
