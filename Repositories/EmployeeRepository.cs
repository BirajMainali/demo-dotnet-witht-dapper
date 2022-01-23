using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperDemo.Models;
using DapperDemo.Providers.Interface;
using DapperDemo.Repositories.Interface;

namespace DapperDemo.Repositories
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
        
        public async Task<int> Create(Employee employee)
        {
            await using var conn = _connectionProvider.GetConnection();
            const string query =
                @"insert into ""public"".""Employee""(""FirstName"", ""LastName"", ""Age"", ""Salary"") VALUES (@FirstName,@LastName,@Age,@Salary)";
            return await conn.ExecuteAsync(query, new
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Salary = employee.Salary
            });
        }

        public async Task<int> Update(Employee employee)
        {
            await using var conn = _connectionProvider.GetConnection();
            const string query =
                @"update ""Employee"" set ""FirstName""= @FirstName, ""LastName""=@LastName, ""Age"" = @Age, ""Salary"" = @Salary where ""Id"" = @id";
            return await conn.ExecuteAsync(query, new
            {
                id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Salary = employee.Salary
            });
        }

        public async Task<int> Remove(long id)
        {
            await using var conn = _connectionProvider.GetConnection();
            const string query = @"Delete  FROM ""Employee"" WHERE ""Id"" = @id";
            return await conn.ExecuteAsync(query, new
            {
                id = id
            });
        }
        
    }
}