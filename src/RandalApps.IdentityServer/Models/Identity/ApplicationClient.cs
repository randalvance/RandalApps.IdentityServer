using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationClient
    {
        public Guid ApplicationClientId { get; set; }
        public int AbsoluteRefreshTokenLifetime { get; set; }
        public int AccessTokenLifetime { get; set; }
        public AccessTokenType AccessTokenType { get; set; }
        public bool AllowAccessToAllScopes { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public bool AllowRememberConsent { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public int AuthorizationCodeLifetime { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientUri { get; set; }
        public bool Enabled { get; set; }
        public bool EnableLocalLogin { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public bool IncludeJwtId { get; set; }
        public string LogoUri { get; set; }
        public bool LogoutSessionRequired { get; set; }
        public string LogoutUri { get; set; }
        public bool PrefixClientClaims { get; set; }
        public TokenExpiration RefreshTokenExpiration { get; set; }
        public TokenUsage RefreshTokenUsage { get; set; }
        public bool RequireClientSecret { get; set; }
        public bool RequireConsent { get; set; }
        public bool RequirePkce { get; set; }
        public int SlidingRefreshTokenLifetime { get; set; }
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        public List<ApplicationSecret> ClientSecrets { get; set; }
        public List<ApplicationClaim> Claims { get; set; }
        public List<ApplicationRedirectUri> RedirectUris { get; set; }
        public List<ApplicationPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }
        public List<ApplicationCorsOrigin> AllowedCorsOrigins { get; set; }
        public List<ApplicationAllowedGrantType> AllowedGrantTypes { get; set; } = new List<ApplicationAllowedGrantType>();
        public List<ApplicationAllowedScope> AllowedScopes { get; set; }
        public List<ApplicationIdentityProviderRestriction> IdentityProviderRestrictions { get; set; }
    }
}
