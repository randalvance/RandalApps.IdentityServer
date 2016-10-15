using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using RandalApps.IdentityServer.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServerEF = IdentityServer4.EntityFramework.Entities;

namespace RandalApps.IdentityServer.Data
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            var dbContext = (IdentityServerDbContext)serviceProvider.GetService(typeof(IdentityServerDbContext));

            if (dbContext.Clients.Count() > 0)
            {
                return;
            }

            var scopes = AddInitialScopes(dbContext);
            var clients = AddInitialClients(dbContext, scopes);

            dbContext.Scopes.AddRange(scopes);
            dbContext.Clients.AddRange(clients);

            dbContext.SaveChanges();
        }

        private static List<IdentityServerEF.Scope> AddInitialScopes(IdentityServerDbContext dbContext)
        {
            var scopes = new List<IdentityServerEF.Scope>()
            {
                new IdentityServerEF.Scope()
                {
                    Name = "CentBucket.Api",
                    DisplayName = "CentBucket API",
                    Description = "Access to CentBucket API",
                    Enabled = true,
                    Type = (int)ScopeType.Resource
                },
                StandardScopes.OpenId.ToEntity(),
                StandardScopes.Profile.ToEntity(),
                StandardScopes.OfflineAccess.ToEntity()
            };

            dbContext.Scopes.AddRange(scopes);

            return scopes;
        }

        private static List<IdentityServerEF.Client> AddInitialClients(IdentityServerDbContext dbContext, List<IdentityServerEF.Scope> scopes)
        {
            var implicitGrantType = new IdentityServerEF.ClientGrantType() { GrantType = "implicit" };
            var hybridGrantType = new IdentityServerEF.ClientGrantType() { GrantType = "hybrid" };
            var clientCredentialsGrantType = new IdentityServerEF.ClientGrantType() { GrantType = "client_credentials" };
            var authCodeGrantType = new IdentityServerEF.ClientGrantType() { GrantType = "authorization_code" };
            var resourceOwnerGrantType = new IdentityServerEF.ClientGrantType() { GrantType = "password" };
            var grantTypes = new List<IdentityServerEF.ClientGrantType>()
            {
                hybridGrantType,
                clientCredentialsGrantType,
                implicitGrantType,
                authCodeGrantType,
                resourceOwnerGrantType
            };

            var clients = new List<IdentityServerEF.Client>()
            {
                new IdentityServerEF.Client()
                {
                    ClientId = "97008f0b-2922-4819-9e38-78951bbe5c9",
                    ClientName = "CentBucket.Web",
                    ClientSecrets = new List<IdentityServerEF.ClientSecret>
                    {
                        new IdentityServerEF.ClientSecret() { Value = "?V-WwrWHdb*R3Q%gF4X_gZX9pHV#kyU^V+Kyr&3NHHr@aT-DMyq3ydnQwz-S+vr7f^tW+K%+pyZ+6".Sha256() }
                    },
                    Enabled = true,
                    AllowedGrantTypes = new List<IdentityServerEF.ClientGrantType>()
                    {
                        hybridGrantType,
                        clientCredentialsGrantType
                    },
                    AllowedScopes = scopes.Select(s => new IdentityServerEF.ClientScope() { Scope = s.Name }).ToList(),
                    RequireConsent = true,
                    RedirectUris = new List<IdentityServerEF.ClientRedirectUri>()
                    {
                        new IdentityServerEF.ClientRedirectUri() { RedirectUri = "http://localhost:1111/signin-oidc" }
                    },
                    PostLogoutRedirectUris = new List<IdentityServerEF.ClientPostLogoutRedirectUri>()
                    {
                        new IdentityServerEF.ClientPostLogoutRedirectUri() { PostLogoutRedirectUri = "http://localhost:1111" }
                    },
                    // The following are in seconds as I verified in the IdentityServer code
                    // Default to 1 hour
                    AccessTokenLifetime = 3600,
                    AuthorizationCodeLifetime = 3600,
                    IdentityTokenLifetime = 3600
                },
                new IdentityServerEF.Client()
                {
                    ClientId = "7ab41cdd-26f0-4f6f-b610-d46c8089ecb4",
                    ClientName = "CentBucket.MobileBackend",
                    ClientSecrets = new List<IdentityServerEF.ClientSecret>
                    {
                        new IdentityServerEF.ClientSecret() { Value = "Yy6KS5cL7gPBSmhx#EKJ#rMy^+&^s^kjWLDSnN8SDRUB3M4$dJ@syJaRskVez+FQ=d5jfg2cZUBk6".Sha256() }
                    },
                    Enabled = true,
                    AllowedGrantTypes = new List<IdentityServerEF.ClientGrantType>()
                    {
                        hybridGrantType,
                        clientCredentialsGrantType
                    },
                    AllowedScopes = scopes.Select(s => new IdentityServerEF.ClientScope() { Scope = s.Name }).ToList(),
                    RequireConsent = true,
                    RedirectUris = new List<IdentityServerEF.ClientRedirectUri>()
                    {
                        new IdentityServerEF.ClientRedirectUri() { RedirectUri = "http://localhost:1111/signin-oidc" }
                    },
                    PostLogoutRedirectUris = new List<IdentityServerEF.ClientPostLogoutRedirectUri>()
                    {
                        new IdentityServerEF.ClientPostLogoutRedirectUri() { PostLogoutRedirectUri = "http://localhost:1111" }
                    },
                    // The following are in seconds as I verified in the IdentityServer code
                    // Default to 1 hour
                    AccessTokenLifetime = 3600,
                    AuthorizationCodeLifetime = 3600,
                    IdentityTokenLifetime = 3600
                },
                new IdentityServerEF.Client()
                {
                    ClientId = "524bdbb8-19f6-471b-a969-19ec3a0d6654",
                    ClientName = "CentBucket.Android",
                    ClientSecrets = new List<IdentityServerEF.ClientSecret>
                    {
                        new IdentityServerEF.ClientSecret() { Value = "AQ@XDdn&LvW6Y$B-uBXvve#_L^sTTvhj#yP&fu*%p99ZQn2Jr6^H%S2jtnJ#E=gC8gD5*T-4w9M3@".Sha256() }
                    },
                    Enabled = true,
                    AllowedGrantTypes = new List<IdentityServerEF.ClientGrantType>()
                    {
                        resourceOwnerGrantType
                    },
                    AllowedScopes = scopes.Select(s => new IdentityServerEF.ClientScope() { Scope = s.Name }).ToList(),
                    RequireConsent = true,
                    RedirectUris = new List<IdentityServerEF.ClientRedirectUri>()
                    {
                        new IdentityServerEF.ClientRedirectUri() { RedirectUri = "http://codequasar.com/redirect" }
                    },
                    PostLogoutRedirectUris = new List<IdentityServerEF.ClientPostLogoutRedirectUri>()
                    {
                        new IdentityServerEF.ClientPostLogoutRedirectUri() { PostLogoutRedirectUri = "http://codequasar.com/logout-redirect" }
                    },
                    AllowAccessTokensViaBrowser = true,
                    // The following are in seconds as I verified in the IdentityServer code
                    // Default to 1 hour
                    AccessTokenLifetime = 3600,
                    AbsoluteRefreshTokenLifetime = 86400, // 1 day
                    AuthorizationCodeLifetime = 3600,
                    IdentityTokenLifetime = 3600
                }
            };

            return clients;
        }
    }
}
