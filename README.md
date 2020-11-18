# Multi-Tenant WebApp

This is example of Multi-Tenant app.
The MultiTenant project can be imported to any .Net Core 3.1 solution to support multitenancy.

## Usage

Add below code to Startup.ConfigureServices

```csharp
services.AddMultiTenancy<Tenant>()
                .WithResolutionStrategy<HeaderResolverStrategy>()
                .WithStore<InMemoryStore<Tenant>>(ServiceLifetime.Singleton);
            services.AddAutofacMultitenantRequestServices();
```

Add below code to Startup.Configure

```csharp
app.UseMultiTenancy<Tenant>();
```

Add below code to Program.cs

```csharp
Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(
                    new AutofacMultitenantServiceProviderFactory(DependencyResolver.RegisterServices));
```

## Tenant Resolver Strategies

1. HostResolverStrategy - Resolves tenant on Requests.Host.Host

2. HeaderResolverStrategy - Resolves tenant with 'x-tenant' header

If you need different strategy please implement ITenantResolverStrategy

## Tenant Store

1. InMemoryStore - InMemory Store to save tenant mapping

### Tenant context access

```csharp
HttpContext.GeTenantContext<Tenant>().Tenant
```

For more detailed description visit <https://dotnetbuilder.com/uncategorized/multi-tenant-net-core-application/>
