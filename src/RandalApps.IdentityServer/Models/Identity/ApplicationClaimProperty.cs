using System;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationClaimProperty
    {
        public Guid ApplicationClaimPropertyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
