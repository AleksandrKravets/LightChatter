using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace Quantum.DAL.Infrastructure.Commands
{
    internal abstract class ExecutorCommandBase
    {
        protected SqlConnection _connection;
        protected SqlCommand _command;
        protected readonly StoredProcedure _storedProcedure;
        private readonly string _connectionString;

        protected ExecutorCommandBase(StoredProcedure storedProcedure, string connectionString)
        {
            _storedProcedure = storedProcedure;
            _connectionString = connectionString;
        }

        protected Task OpenConnectionAsync()
        {
            _connection = new SqlConnection(_connectionString);
            return _connection.OpenAsync();
        }

        protected ValueTask CloseConnectionAsync()
        {
            return _connection.DisposeAsync();
        }

        protected void BuildCommand()
        {
            var commandBuilder = new SqlStoredProcedureCommandBuilder();

            _command = commandBuilder
                .WithConnection(_connection)
                .WithProcedureName(_storedProcedure.GetProcedureName())
                .WithParameters(_storedProcedure.GetStoredProcedureParameters())
                .Build();
        }

        protected void FillProcedureWithOutParameters()
        {
            var fields = Reflector.GetStoredProcedureOutFields(_storedProcedure);

            foreach (var field in fields)
            {
                SetProcedureField(field);
            }
        }

        protected void FillProcedureWithReturnValue()
        {
            var field = Reflector.GetStoredProcedureReturnField(_storedProcedure);

            if (field != null)
                SetProcedureField(field);
        }

        private void SetProcedureField(FieldInfo field)
        {
            var value = Convert.ChangeType(_command.Parameters[$"{field.Name}"].Value, field.FieldType);
            _storedProcedure.SetFieldValue(field.Name, value);
        }

        protected virtual async Task PreExecution()
        {
            await OpenConnectionAsync();
            BuildCommand();
        }

        protected virtual async Task PostExecution()
        {
            await CloseConnectionAsync();
            FillProcedureWithOutParameters();
        }
    }
}
