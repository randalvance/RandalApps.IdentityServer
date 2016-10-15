using System;
using System.Collections.Generic;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationClaimsIdentity
    {
        public Guid ApplicationClaimsIdentityId { get; set; }
        public ApplicationClaimsIdentity Actor { get; set; }
        public virtual string AuthenticationType { get; }
        public virtual List<ApplicationClaim> Claims { get; } = new List<ApplicationClaim>();
        public virtual bool IsAuthenticated { get; }
        public string Label { get; set; }
        public virtual string Name { get; }
        public string NameClaimType { get; }
        public string RoleClaimType { get; }
    }
}
