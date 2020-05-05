using System;

namespace Chatter.Common.ConfigurationModels
{
    public class JwtIssuerOptions
    {
        // iss
        public string Issuer { get; set; }
        // sub
        public string Subject { get; set; }
        // aud
        public string Audience { get; set; }
        // exp
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        // nbf
        public DateTime NotBefore => DateTime.UtcNow;
        // iat
        public DateTime IssuedAt => DateTime.UtcNow;
        // ?
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);
    }
}
