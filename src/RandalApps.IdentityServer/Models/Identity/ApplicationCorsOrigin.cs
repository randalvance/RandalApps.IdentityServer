using System;
using System.ComponentModel.DataAnnotations;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationCorsOrigin
    {
        public Guid ApplicationCorsOriginId { get; set; }
        public string CorsOrigin { get; set; }
    }
}
