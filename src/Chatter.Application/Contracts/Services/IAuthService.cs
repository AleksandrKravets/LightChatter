using Chatter.Application.DataTransferObjects.Authorization;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IAuthService
    {
        Task<AuthenticationResult> LoginAsync(LoginModel model);
        Task<AuthenticationResult> RefreshTokensAsync(RefreshTokensModel model);
    }
}
