using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandalApps.IdentityServer.Models.Identity
{
    public class ApplicationGrantType
    {
        public ApplicationGrantType()
        {

        }
        public ApplicationGrantType(string grantType)
        {
            GrantType = grantType;
        }

        public Guid ApplicationGrantTypeId { get; set; }
        public string GrantType { get; set; }
    }
}
