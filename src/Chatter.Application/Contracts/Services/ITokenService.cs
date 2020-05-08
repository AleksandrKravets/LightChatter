using Chatter.Application.DataTransferObjects.Authorization;
using Chatter.Application.DataTransferObjects.Users;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface ITokenService
    {
        Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(UserModel model);
    }
}
