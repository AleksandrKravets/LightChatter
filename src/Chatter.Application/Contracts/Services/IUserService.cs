using Chatter.Application.DataTransferObjects.Users;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<UserModel> GetAsync(string email);
        Task<UserModel> GetAsync(long userId);
        Task<bool> CheckIfExistsAsync(string email);
    }
}
