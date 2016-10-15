using AutoMapper;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using RandalApps.IdentityServer.Models.Identity;
using RandalApps.IdentityServer.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Builder
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersistedGrant, ApplicationPersistedGrant>().ReverseMap();
                cfg.CreateMap<Scope, ApplicationScope>().ReverseMap();
                cfg.CreateMap<ScopeClaim, ApplicationScopeClaim>().ReverseMap();
                cfg.CreateMap<Secret, ApplicationSecret>().ReverseMap();
                cfg.CreateMap<Client, ApplicationClient>().ReverseMap();

                cfg.CreateMap<IDictionary<string, string>, List<ApplicationClaimProperty>>().ConstructUsing(dictionary =>
                {
                    var props = new List<ApplicationClaimProperty>();

                    foreach (var item in dictionary)
                    {
                        var prop = new ApplicationClaimProperty()
                        {
                            Key = item.Key,
                            Value = item.Value
                        };
                        props.Add(prop);
                    }

                    return props;
                }).ReverseMap().ConstructUsing(props =>
                {
                    var dictionary = new Dictionary<string, string>();

                    foreach (var prop in props)
                    {
                        dictionary[prop.Key] = prop.Value;
                    }

                    return dictionary;
                });

                cfg.CreateMap<Claim, ApplicationClaim>().ReverseMap();

                cfg.CreateMap<ClaimsIdentity, ApplicationClaimsIdentity>().ReverseMap();

                cfg.CreateMap<string, ApplicationAllowedGrantType>()
                    .ConstructUsing(s => new ApplicationAllowedGrantType() { GrantType = new ApplicationGrantType(s) })
                    .ReverseMap()
                    .ConstructUsing(aag => aag.GrantType?.GrantType);

                cfg.CreateMap<string, ApplicationAllowedScope>()
                    .ConstructUsing(s => new ApplicationAllowedScope() { Scope = new ApplicationScope(s) })
                    .ReverseMap()
                    .ConstructUsing(allowedScope => allowedScope.Scope?.Name);

                cfg.CreateMap<string, ApplicationGrantType>().ConstructUsing(s => new ApplicationGrantType(s))
                    .ReverseMap().ConstructUsing(gt => gt.GrantType);

                cfg.CreateMap<string, ApplicationRedirectUri>().ConstructUsing(s => new ApplicationRedirectUri(s))
                    .ReverseMap().ConstructUsing(r => r.RedirectUri);

                cfg.CreateMap<string, ApplicationPostLogoutRedirectUri>().ConstructUsing(s => new ApplicationPostLogoutRedirectUri(s))
                    .ReverseMap().ConstructUsing(r => r.PostLogoutRedirectUri);
            });

            services.AddTransient(sp => config.CreateMapper());
        }
    }
}
