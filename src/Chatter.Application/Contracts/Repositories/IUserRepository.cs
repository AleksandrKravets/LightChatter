using Chatter.Application.DataTransferObjects.Users;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(CreateUserDto model);
        Task<UserModel> GetUserByEmail(string email);
    }
}
