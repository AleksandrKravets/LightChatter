using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Users;
using System;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository =
                userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public Task<UserModel> GetAsync(string email)
        {
            return _userRepository.GetUserByEmailAsync(email);   
        }

        public Task<UserModel> GetAsync(long userId)
        {
            return _userRepository.GetAsync(userId);
        }

        public async Task<bool> CheckIfExistsAsync(string email)
        {
            var user = await GetAsync(email);
            return user == null;
        }
    }
}
