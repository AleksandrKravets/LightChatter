using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Contracts.Validators;
using Chatter.Application.DataTransferObjects.Account;
using Chatter.Application.DataTransferObjects.Authorization;
using Chatter.Application.DataTransferObjects.Users;
using Chatter.Application.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordValidator _passwordValidator;

        public AccountService(
            IUserRepository userRepository, 
            ITokenService tokenService, 
            IPasswordValidator passwordValidator)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordValidator = passwordValidator ?? throw new ArgumentNullException(nameof(passwordValidator));
        }

        public async Task<AuthenticationResult> RegisterAsync(RegistrationModel model)
        {
            var user = await _userRepository.GetAsync(model.Email, model.Nickname);

            if(user == null)
            {
                bool passwordValid = _passwordValidator.ValidatePassword(model.Password);

                if (passwordValid)
                {
                    var hashedPassword = SecurePasswordHasher.Hash(model.Password);

                    await _userRepository.CreateAsync(new CreateUserDto
                    {
                        Nickname = model.Nickname,
                        Email = model.Email,
                        HashedPassword = hashedPassword,
                    });

                    var createdUser = await _userRepository.GetUserByEmailAsync(model.Email);

                    var result = await _tokenService.GenerateAuthenticationResultForUserAsync(createdUser);

                    return result;
                }
            }

            return AuthenticationResult.Failed();
        }   
    }
}
