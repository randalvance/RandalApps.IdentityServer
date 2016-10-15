using System;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationRedirectUri
    {
        public ApplicationRedirectUri()
        {

        }
        public ApplicationRedirectUri(string redirectUri)
        {
            RedirectUri = redirectUri;
        }
        public Guid ApplicationRedirectUriId { get; set; }
        public string RedirectUri { get; set; }
    }
}
