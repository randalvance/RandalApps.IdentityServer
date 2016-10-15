using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Stores;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using RandalApps.IdentityServer.Data.DbContexts;
using RandalApps.IdentityServer.Services;
using RandalApps.IdentityServer;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddCustomIdentityServer(this IIdentityServerBuilder identityServerBuilder, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            identityServerBuilder.AddConfigurationStore(builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)))
                                 .AddOperationalStore(builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)));

            identityServerBuilder.Services.AddTransient<IProfileService, AspNetIdentityProfileService>();
            identityServerBuilder.Services.AddTransient<IClientStore, ClientStore>();
            identityServerBuilder.Services.AddTransient<IScopeStore, ScopeStore>();
            identityServerBuilder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();

            return identityServerBuilder;
        }
    }
}
