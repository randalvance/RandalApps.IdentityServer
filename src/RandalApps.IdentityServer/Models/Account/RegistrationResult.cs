using RandalApps.IdentityServer.Models.Common;
using System.Collections.Generic;

namespace RandalApps.IdentityServer.Models.Account
{
    public class RegistrationResult
    {
        public bool IsSuccess { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>();
    }
}
