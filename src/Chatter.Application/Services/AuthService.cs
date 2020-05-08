using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Authorization;
using Chatter.Application.DataTransferObjects.Tokens;
using Chatter.Application.Helpers;
using Chatter.Application.Infrastructure;
using Chatter.Common.ConfigurationModels;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;
        private readonly ITokenRepository _tokenRepository;

        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IOptions<JwtSettings> jwtSettings,
            ITokenRepository tokenRepository)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
            _tokenRepository = tokenRepository ?? throw new ArgumentNullException(nameof(tokenRepository));
        }

        public async Task<AuthenticationResult> LoginAsync(LoginModel model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user != null)
            {
                bool passwordCorrect = SecurePasswordHasher.Verify(model.Password, user.HashedPassword);

                if (passwordCorrect)
                {
                    var result = await _tokenService.GenerateAuthenticationResultForUserAsync(user);
                    return result;
                }
            }

            return AuthenticationResult.Failed();
        }

        public async Task<AuthenticationResult> RefreshTokensAsync(RefreshTokensModel model)
        {
            var principal = JwtHelper.GetPrincipalFromExpiredToken(model.AccessToken, _jwtSettings);

            var token = await _tokenRepository.GetTokenAsync(model.RefreshToken);

            bool tokenValid = IsTokenValid(principal, token);

            if (tokenValid)
            {
                await _tokenRepository.UseRefreshTokenAsync(token.Token);

                var userId = Convert.ToInt64(principal.Claims.Single(x => x.Type == Constants.CustomClaims.UserIdentifier).Value);
                var user = await _userRepository.GetAsync(userId);

                if (user == null)
                    return AuthenticationResult.Failed();

                var result = await _tokenService.GenerateAuthenticationResultForUserAsync(user);

                return result;
            }

            return AuthenticationResult.Failed();
        }

        private bool IsTokenValid(ClaimsPrincipal principal, RefreshTokenModel token)
        {
            if (principal == null)
            {
                return false;
            }

            var expiryDateUnix =
                long.Parse(principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            var jti = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            return expiryDateTimeUtc > DateTime.UtcNow || token == null ||
                DateTime.UtcNow > token.ExpiryDate || token.Used || token.JwtId != jti;
        }
    }
}
