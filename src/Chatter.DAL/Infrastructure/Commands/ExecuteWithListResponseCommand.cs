using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quantum.DAL.Infrastructure.Commands
{
    internal class ExecuteWithListResponseCommand<TResult> : ExecutorCommandBase where TResult : class
    {
        public ExecuteWithListResponseCommand(StoredProcedure storedProcedure, string connectionString)
            : base(storedProcedure, connectionString)
        {
        }

        public async Task<ICollection<TResult>> ExecuteAsync()
        {
            await PreExecution();
            List<TResult> result = await ExecuteProcedureAsync();
            await PostExecution();
            return result;
        }

        protected async virtual Task<List<TResult>> ExecuteProcedureAsync()
        {
            using (var reader = await _command.ExecuteReaderAsync())
            {
                if (!reader.HasRows)
                    return null;

                var result = reader.ReadList<TResult>();
                reader.Close();
                return result;
            }
        }
    }
}
