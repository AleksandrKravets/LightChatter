using Chatter.Application.DataTransferObjects.Account;
using Chatter.Application.DataTransferObjects.Authorization;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResult> RegisterAsync(RegistrationModel model);
    }
}
