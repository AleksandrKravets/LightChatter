using System.Data;
using System.Data.SqlClient;

namespace Quantum.DAL.Infrastructure
{
    internal class SqlStoredProcedureCommandBuilder
    {
        private SqlCommand _command;

        public SqlStoredProcedureCommandBuilder()
        {
            _command = new SqlCommand();
        }

        public SqlStoredProcedureCommandBuilder WithProcedureName(string procedureName)
        {
            _command.CommandText = procedureName;
            return this;
        }

        public SqlStoredProcedureCommandBuilder WithConnection(SqlConnection connection)
        {
            _command.Connection = connection;
            return this;
        }

        public SqlStoredProcedureCommandBuilder WithParameters(params StoredProcedureParameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                var procedureParameter = new SqlParameter(parameter.ParameterName, parameter.ParameterValue);
                procedureParameter.Direction = parameter.ParameterDirection;
                _command.Parameters.Add(procedureParameter);
            }

            return this;
        }

        public SqlCommand Build()
        {
            _command.CommandType = CommandType.StoredProcedure;
            return _command;
        }
    }
}
