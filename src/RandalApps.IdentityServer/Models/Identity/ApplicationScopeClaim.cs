using System;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationScopeClaim 
    {
        public Guid ApplicationScopeClaimId { get; set; }
        public bool AlwaysIncludeInIdToken { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
