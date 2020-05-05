using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Chatter.WebUI.Infrastructure
{
    internal class JwtAuthParameters : TokenValidationParameters
    {

        public JwtAuthParameters(IConfiguration configuration)
        {
            ValidateAudience = true;
            ValidAudience = configuration["JwtSettings:Audience"];
            ValidateIssuer = true;
            ValidIssuer = configuration["JwtSettings:Issuer"];
            ValidateIssuerSigningKey = true;
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSettings:SecretKey"]));
            RequireExpirationTime = true;
            ValidateLifetime = true;
            ClockSkew = TimeSpan.Zero;
        }
    }
}
