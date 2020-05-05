namespace Chatter.Common.ConfigurationModels
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int RefreshTokenLifetime { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
