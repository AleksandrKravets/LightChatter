using Chatter.Application.Contracts.Services;
using Chatter.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chatter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();

            //services.AddTransient<IAuthorizationService, AuthorizationService>();
            //services.AddTransient<ITokenService, TokenService>();
            //services.AddSingleton<ITokenFactory, TokenFactory>();
            //services.AddSingleton<IPasswordValidator, PasswordValidator>();

            return services;
        }
    }
}
