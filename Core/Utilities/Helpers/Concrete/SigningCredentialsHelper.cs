using Core.Entities.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Concrete
{
    public class SigningCredentialsHelper : IHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            return signingCredentials;
        }
    }
}
