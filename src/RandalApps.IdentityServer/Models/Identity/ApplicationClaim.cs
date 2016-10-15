using System;
using System.Collections.Generic;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationClaim
    {
        public Guid ApplicationClaimId { get; set; }
        public string Issuer { get; }
        public string OriginalIssuer { get; }
        public string Type { get; }
        public string Value { get; }
        public string ValueType { get; }

        public List<ApplicationClaimProperty> Properties { get; } = new List<ApplicationClaimProperty>();
        public ApplicationClaimsIdentity Subject { get; }
    }
}
