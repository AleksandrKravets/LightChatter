using Chatter.Application.DataTransferObjects.Tokens;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface ITokenRepository
    {
        Task<int> CreateAsync(RefreshTokenDto token);
        Task<RefreshTokenModel> GetTokenAsync(string token);
        Task<int> UseRefreshTokenAsync(string token);
    }
}