using Chatter.Application.DataTransferObjects.Users;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(CreateUserDto model);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel> GetAsync(long userId);
        Task<UserModel> GetAsync(string email, string nickname);
    }
}
