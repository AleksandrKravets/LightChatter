using System.Threading.Tasks;

namespace Quantum.DAL.Infrastructure.Commands
{
    internal abstract class ExecuteWithResponseValueCommand<TResult> : ExecutorCommandBase
    {
        public ExecuteWithResponseValueCommand(StoredProcedure storedProcedure, string connectionString)
            : base(storedProcedure, connectionString)
        {
        }

        public async virtual Task<TResult> ExecuteAsync()
        {
            await PreExecution();
            TResult result = await ExecuteProcedureAsync();
            await PostExecution();
            return result;
        }

        protected abstract Task<TResult> ExecuteProcedureAsync();
    }
}
