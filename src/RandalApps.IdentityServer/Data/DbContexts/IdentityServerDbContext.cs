using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RandalApps.IdentityServer.Data.DbContexts
{
    public class IdentityServerDbContext : DbContext, IConfigurationDbContext, IPersistedGrantDbContext
    {
        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }

        public DbSet<Scope> Scopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configureStoreOptions = new ConfigurationStoreOptions();
            var operationStoreOptions = new OperationalStoreOptions();

            modelBuilder.ConfigureClientContext(configureStoreOptions);
            modelBuilder.ConfigureScopeContext(configureStoreOptions);
            modelBuilder.ConfigurePersistedGrantContext(operationStoreOptions);

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
