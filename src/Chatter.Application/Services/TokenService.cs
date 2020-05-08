using Chatter.Application.Contracts.Factories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Authorization;
using Chatter.Application.DataTransferObjects.Users;
using System;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenFactory _tokenFactory;

        public TokenService(ITokenFactory tokenFactory)
        {
            _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));
        }

        public async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(UserModel model)
        {
            var tokens = await _tokenFactory.GetTokensAsync(model);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokens.AccessToken,
                RefreshToken = tokens.RefreshToken
            };
        }
    }
}
