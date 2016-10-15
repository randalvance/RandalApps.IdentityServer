using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Stores;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using RandalApps.IdentityServer.Data.DbContexts;
using RandalApps.IdentityServer.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddCustomIdentityServer(this IIdentityServerBuilder builder, string connectionString)
        {
            builder.Services.AddDbContext<IdentityServerDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IConfigurationDbContext, IdentityServerDbContext>();
            builder.Services.AddScoped<IPersistedGrantDbContext, IdentityServerDbContext>();

            builder.Services.AddTransient<IProfileService, AspNetIdentityProfileService>();
            builder.Services.AddTransient<IClientStore, ClientStore>();
            builder.Services.AddTransient<IScopeStore, ScopeStore>();
            builder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();

            return builder;
        }
    }
}
