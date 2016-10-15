using System;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationPostLogoutRedirectUri
    {
        public ApplicationPostLogoutRedirectUri()
        {

        }
        public ApplicationPostLogoutRedirectUri(string redirectUri)
        {
            PostLogoutRedirectUri = redirectUri;
        }
        public Guid ApplicationPostLogoutRedirectUriId { get; set; }
        public string PostLogoutRedirectUri { get; set; }
    }
}
