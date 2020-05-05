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

        public async Task<bool> CheckIfUserExistsAsync(string email)
        {
            return (await _userRepository.GetUserByEmail(email)) != null;   
        }
    }
}
