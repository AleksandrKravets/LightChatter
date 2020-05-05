using Chatter.Application.DataTransferObjects.Users;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<bool> CheckIfUserExistsAsync(string email);
    }
}
