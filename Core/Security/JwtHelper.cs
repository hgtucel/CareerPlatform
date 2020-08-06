using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace Core.Security
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration _configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securitykey = SecurityHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            var signinCredentials = SecurityHelper.CreateSigningCredentials(securitykey);

            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials: signinCredentials
                );

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
            string[] roles = operationClaims.Select(x => x.Name).ToArray();
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));


            return claims;
        }
    }
}
