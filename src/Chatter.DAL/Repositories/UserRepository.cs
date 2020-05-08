using Chatter.Application.Contracts.Repositories;
using Chatter.Application.DataTransferObjects.Users;
using Chatter.DAL.StoredProcedures.Users;
using Quantum.DAL.Infrastructure;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public UserRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<UserModel> GetAsync(string email, string nickname)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<UserModel>(new SPGetUser
            {
                Email = email, 
                Nickname = nickname
            });
        }

        public Task<int> CreateAsync(CreateUserDto model)
        {
            return _procedureExecutor.ExecuteAsync(new SPCreateUser
            {
                Nickname = model.Nickname, 
                Email = model.Email, 
                HashedPassword = model.HashedPassword, 
            });
        }

        public Task<UserModel> GetUserByEmailAsync(string email)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<UserModel>(new SPGetUserByEmail 
            { 
                Email = email 
            });
        }

        public Task<UserModel> GetAsync(long userId)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<UserModel>(new SPGetUserById 
            { 
                Id = userId 
            });
        }
    }
}
