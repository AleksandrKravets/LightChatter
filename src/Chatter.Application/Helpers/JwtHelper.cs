using Chatter.Common.ConfigurationModels;
using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chatter.Application.Helpers
{
    public static class JwtHelper
    {
        public static Maybe<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token, JwtSettings jwtSettings)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                ValidateLifetime = true,
                RequireExpirationTime = true, 
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;
            
            var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return Maybe<ClaimsPrincipal>.None;

            return principal;
        }
    }
}
