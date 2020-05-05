using Chatter.Application.DataTransferObjects.Authorization;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResultModel> AuthorizeAsync(LoginModel model);
    }
}
