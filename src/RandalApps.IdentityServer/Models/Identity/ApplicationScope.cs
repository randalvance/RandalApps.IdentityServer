using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationScope
    {
        public ApplicationScope()
        {

        }
        public ApplicationScope(string name)
        {
            Name = name;
        }
        public Guid ApplicationScopeId { get; set; }
        public string ClaimsRule { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public bool Emphasize { get; set; }
        public bool Enabled { get; set; }
        public bool IncludeAllClaimsForUser { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public ScopeType Type { get; set; }
        
        public List<ApplicationSecret> ScopeSecrets { get; set; } = new List<ApplicationSecret>();
        public List<ApplicationScopeClaim> Claims { get; set; } = new List<ApplicationScopeClaim>();
    }
}
