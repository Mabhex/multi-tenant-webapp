using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MultiTenant.Extensions;
using MultiTenant.Models;
using MultiTenant.TenantResolverStrategy;
using MultiTenant.TenantStorage;

namespace multi_tenant_webapp
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddMultiTenancy<Tenant>()
                .WithResolutionStrategy<HeaderResolverStrategy>()
                .WithStore<InMemoryStore<Tenant>>(ServiceLifetime.Singleton);
            services.AddSingleton<TenantStoreSeed>();
            services.AddAutofacMultitenantRequestServices();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,TenantStoreSeed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            seeder.Seed();
            app.UseMultiTenancy<Tenant>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
