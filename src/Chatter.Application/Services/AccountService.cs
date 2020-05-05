using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Account;
using Chatter.Application.DataTransferObjects.Users;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Enums;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        // private readonly IPasswordValidator _passwordValidator;

        public AccountService(IUserRepository userRepository /*IPasswordValidator passwordValidator*/)
        {
            _userRepository = userRepository;
            //_passwordValidator = passwordValidator;
        }

        public Task RegisterAsync(RegistrationModel model)
        {
            // Check if user with such email and nickname doesnt exist
            // validate password using password validator
            // Hash user password
            // Create user
            // Return response model

            var hashedPassword = SecurePasswordHasher.Hash(model.Password);

            return _userRepository.CreateAsync(new CreateUserDto
            {
                Nickname = model.Nickname,
                Email = model.Email,
                HashedPassword = hashedPassword,
                RoleId = (int)UserRole.Member
            });
        }
    }
}
