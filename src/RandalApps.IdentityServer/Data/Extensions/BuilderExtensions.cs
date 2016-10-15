using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RandalApps.IdentityServer.Data;
using RandalApps.IdentityServer.Data.DbContexts;

namespace Microsoft.AspNetCore.Builder.Extensions
{
    public static class BuilderExtensions
    {
        public static void UseAppDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetRequiredService<IdentityServerDbContext>().Database.Migrate();

                app.SeedData(serviceScope.ServiceProvider);
            }
        }
    }
}
