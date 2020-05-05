using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Authorization;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthorizationService(IUserRepository userRepository, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<AuthorizationResultModel> AuthorizeAsync(LoginModel model)
        {
            // Check if user exist
            // verify password using password hasher
            // Get tokens using tokens service
            // return tokens
            return null;
        }
    }
}
