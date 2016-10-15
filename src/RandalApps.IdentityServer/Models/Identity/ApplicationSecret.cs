using System;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationSecret
    {
        public Guid ApplicationSecretId { get; set; }
        public string Description { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
