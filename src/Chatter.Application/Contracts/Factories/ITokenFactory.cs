using Chatter.Application.DataTransferObjects.Tokens;
using Chatter.Application.DataTransferObjects.Users;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Factories
{
    public interface ITokenFactory
    {
        Task<TokensModel> GetTokensAsync(UserModel user);
    }
}
