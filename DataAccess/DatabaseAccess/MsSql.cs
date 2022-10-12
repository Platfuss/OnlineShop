using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using DataAccess.DatabaseAccess.Interfaces;

namespace DataAccess.DatabaseAccess
{
    public class MsSql : IDatabase
    {
        private readonly IConfiguration _config;

        public MsSql(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionID = "Default")

        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionID));

            return await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionID = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionID));

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
