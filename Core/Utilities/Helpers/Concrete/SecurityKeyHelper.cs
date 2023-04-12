using Core.Entities.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Helpers.Concrete
{
    public class SecurityKeyHelper : IHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            return key;
        }
    }
}
