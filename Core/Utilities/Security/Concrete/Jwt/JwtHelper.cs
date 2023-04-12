using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Extensions.Concrete;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Helpers.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Concrete.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        
        private readonly TokenOptions _tokenOptions;
        private readonly DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateAccessToken(User user, List<OperationClaimDto> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(user: user, operationClaims: operationClaims, signingCredentials: signingCredentials, tokenOptions: _tokenOptions);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(User user, List<OperationClaimDto> operationClaims, SigningCredentials signingCredentials, TokenOptions tokenOptions)
        {
            var token = new JwtSecurityToken(
                    signingCredentials: signingCredentials,
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    notBefore: DateTime.Now,
                    expires: _accessTokenExpiration,
                    claims: SetClaims(user, operationClaims)
                );

            return token;
        }

        public IEnumerable<Claim> SetClaims(User user, List<OperationClaimDto> operationClaimDtos)
        {
            var claims = new List<Claim>();

            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaimDtos.Select(o => o.Name).ToArray());

            return claims;
        }

    }
}
