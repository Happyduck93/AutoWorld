using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace AutoLibrary.SqlConnectionData
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string sqlConnectionName)
        {
            //Get connectionString
            string connectionString = _config.GetConnectionString(sqlConnectionName);

            //With the connectionString, get connection
            //using: dispose connection(disposable) resource after the execution.  
            using IDbConnection connection = new SqlConnection(connectionString);
            //add nuget package: Dapper
            var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rows.ToList();
        }

        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string sqlConnectionName)
        {
            string connectionString = _config.GetConnectionString(sqlConnectionName);
            using IDbConnection connection = new SqlConnection(connectionString);

            //save data to sql database.
            return await connection.ExecuteAsync(storedProcedure,
                                                 parameters,
                                                 commandType: CommandType.StoredProcedure);
        }
    }
}
