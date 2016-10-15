using System;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationAllowedGrantType
    {
        public Guid ApplicationAllowedGrantTypeId { get; set; }
        public Guid ApplicationGrantTypeId { get; set; }
        public Guid ApplicationClientId { get; set; }
        public ApplicationClient Client { get; set; }
        public ApplicationGrantType GrantType { get; set; }
    }
}
