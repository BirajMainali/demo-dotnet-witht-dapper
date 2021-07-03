using System.Threading.Tasks;
using Dapper;
using DapperDemo.Entities;
using DapperDemo.Manager.Interface;
using DapperDemo.Providers.Interface;

namespace DapperDemo.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly ISqlConnectionProvider _connectionProvider;

        public EmployeeManager(ISqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
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