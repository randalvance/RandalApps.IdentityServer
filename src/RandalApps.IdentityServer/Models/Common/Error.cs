using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandalApps.IdentityServer.Models.Common
{
    public class Error
    {
        public Error(string message, string property = null)
        {
            Message = message;
            Property = property;
        }

        public string Property { get; set; }
        public string Message { get; set; }
    }
}
