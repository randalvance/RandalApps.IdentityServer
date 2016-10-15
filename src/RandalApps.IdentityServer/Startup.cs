using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using RandalApps.IdentityServer.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using RandalApps.IdentityServer.Models.Identity;
using IdentityModel;
using RandalApps.IdentityServer.Services;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Builder.Extensions;

namespace RandalApps.IdentityServer
{
    public class Startup
    {
        private IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            _environment = env;
        }

        private IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(x => Configuration);

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.ClaimsIdentity.UserIdClaimType = JwtClaimTypes.Subject;
                options.ClaimsIdentity.UserNameClaimType = JwtClaimTypes.Name;
                options.ClaimsIdentity.RoleClaimType = JwtClaimTypes.Role;
            })
            .AddEntityFrameworkStores<ApplicationDbContext, Guid>()
            .AddDefaultTokenProviders();

            var identityServerBuilder = services.AddIdentityServer()
                                            .AddCustomIdentityServer(connectionString)
                                            .AddAspNetIdentity<ApplicationUser>()
                                            .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            if (File.Exists(Path.Combine(_environment.ContentRootPath, "idsvr3test.pfx")))
            {
                var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "idsvr3test.pfx"), "idsrv3test");
                identityServerBuilder.SetSigningCredential(cert);
            }
            else
            {
                identityServerBuilder.SetTemporarySigningCredential();
            }

            services.AddApplicationServices();
            services.AddAutoMapper();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAppDatabase();

            app.UseStaticFiles();


            //app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            //{
            //    // TODO: Put this in appsettings.json
            //    Authority = "http://myidentityserver.azurewebsites.net/",
            //    RequireHttpsMetadata = false,

            //    ScopeName = "MyScope",
            //    AutomaticAuthenticate = true
            //});


            //app.UseGoogleAuthentication(new GoogleOptions
            //{
            //    AuthenticationScheme = "Google",
            //    ClientId = "google_client_id",
            //    ClientSecret = "google_client_secret"
            //});

            app.UseIdentity();
            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
