using Microsoft.Extensions.Options;
using Quantum.DAL.Infrastructure.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quantum.DAL.Infrastructure
{
    internal class StoredProcedureExecutor
    {
        private readonly string _connectionString;

        public StoredProcedureExecutor(IOptions<DatabaseSettings> settings)
        {
            _connectionString = settings.Value.ConnectionString;
        }

        public Task<ICollection<TResponse>> ExecuteWithListResponseAsync<TResponse>(StoredProcedure storedProcedure) where TResponse : class
        {
            return new ExecuteWithListResponseCommand<TResponse>(storedProcedure, _connectionString).ExecuteAsync();
        }

        public Task<TResponse> ExecuteWithObjectResponseAsync<TResponse>(StoredProcedure storedProcedure) where TResponse : class
        {
            return new ExecuteWithObjectResponseCommand<TResponse>(storedProcedure, _connectionString).ExecuteAsync();
        }

        public Task<int> ExecuteAsync(StoredProcedure storedProcedure)
        {
            return new ExecuteWithReturnValueCommand(storedProcedure, _connectionString).ExecuteAsync();
        }
    }
}
