using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Quantum.DAL.Infrastructure;

namespace Chatter.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<StoredProcedureExecutor>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();

            return services;
        }
    }
}
