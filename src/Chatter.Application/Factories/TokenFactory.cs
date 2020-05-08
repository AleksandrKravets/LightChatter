using Chatter.Application.Contracts.Factories;
using Chatter.Application.Contracts.Repositories;
using Chatter.Application.DataTransferObjects.Tokens;
using Chatter.Application.DataTransferObjects.Users;
using Chatter.Application.Infrastructure;
using Chatter.Common.ConfigurationModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chatter.Application.Factories
{
    public class TokenFactory : ITokenFactory
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ITokenRepository _tokenRepository;

        public TokenFactory(IOptions<JwtSettings> jwtSettings, ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository ?? throw new ArgumentNullException(nameof(tokenRepository));
            _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
        }

        private string GenerateRefreshToken(int size = 32)
        {
            var randomNumber = new byte[size];

            using var rng = RandomNumberGenerator.Create();
                rng.GetBytes(randomNumber);

            var token = Convert.ToBase64String(randomNumber);

            return token; 
        }

        public async Task<TokensModel> GetTokensAsync(UserModel user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(Constants.CustomClaims.UserIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var algorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(key, algorithm);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenLifetime),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string accessToken = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            await _tokenRepository.CreateAsync(new RefreshTokenDto
            {
                JwtId = token.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshTokenLifetime),
                Token = refreshToken,
                UserId = user.Id
            });

            return new TokensModel 
            { 
                AccessToken = accessToken, 
                RefreshToken = refreshToken 
            };
        }
    }
}
