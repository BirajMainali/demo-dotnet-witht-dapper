using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperDemo.Entities;
using DapperDemo.Providers.Interface;
using DapperDemo.Repository.Interface;

namespace DapperDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlConnectionProvider _connectionProvider;

        public EmployeeRepository(ISqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<Employee> FinAsync(long id)
        {
            await using var conn = _connectionProvider.GetConnection();
            const string query = @"SELECT * FROM ""Employee"" WHERE ""Id"" = @id";
            return await conn.QueryFirstOrDefaultAsync<Employee>(query, new
            {
                id = id,
            });
        }

        public async Task<List<Employee>> GetAll()
        {
            await using var conn = _connectionProvider.GetConnection();
            const string query = @"SELECT * FROM ""Employee""";
            return (await conn.QueryAsync<Employee>(query)).ToList();
        }

        public async Task<long> GetEmployeeCount()
        {
            await using var conn = _connectionProvider.GetConnection();
            const string query = @"SELECT count(*) FROM ""Employee""";
            return await conn.ExecuteScalarAsync<long>(query);
        }
    }
}