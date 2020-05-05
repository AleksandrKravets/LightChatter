using Chatter.Application.DataTransferObjects.Account;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IAccountService
    {
        Task RegisterAsync(RegistrationModel model);
    }
}
