using System;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationAllowedScope
    {
        public Guid ApplicationAllowedScopeId { get; set; }
        public Guid ApplicationScopeId { get; set; }
        public ApplicationScope Scope { get; set; }
    }
}
