using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions.Concrete
{
    public static class ClaimPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal principal, string claimType)
        {
            var result = principal?.FindAll(claimType)?.Select(c => c.Value).ToList();

            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal principal)
        {
            var result = principal?.Claims(ClaimTypes.Role);

            return result;
        }
    }
}
