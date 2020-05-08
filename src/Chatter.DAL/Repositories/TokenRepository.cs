using Chatter.Application.Contracts.Repositories;
using Chatter.Application.DataTransferObjects.Tokens;
using Chatter.DAL.StoredProcedures.Tokens;
using Quantum.DAL.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    internal class TokenRepository : ITokenRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public TokenRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor ?? throw new ArgumentNullException(nameof(procedureExecutor));
        }

        public Task<int> CreateAsync(RefreshTokenDto token)
        {
            return _procedureExecutor.ExecuteAsync(new SPCreateRefreshToken
            {
                UserId = token.UserId,
                Token = token.Token, 
                CreationDate = token.CreationDate, 
                ExpiryDate = token.ExpiryDate, 
                JwtId = token.JwtId
            });
        }

        public Task<RefreshTokenModel> GetTokenAsync(string token)
        {
            return _procedureExecutor.ExecuteWithObjectResponseAsync<RefreshTokenModel>(new SPGetToken 
            { 
                Token = token 
            });
        }

        public Task<int> UseRefreshTokenAsync(string token)
        {
            return _procedureExecutor.ExecuteAsync(new SPUseToken 
            { 
                Token = token 
            });
        }
    }
}
