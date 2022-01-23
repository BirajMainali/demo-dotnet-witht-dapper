using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDemo.Models;

namespace DapperDemo.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> FinAsync(long id);
        Task<List<Employee>> GetAll();
        Task<long> GetEmployeeCount();
        Task<int> Create(Employee employee);
        Task<int> Update(Employee employee);
        Task<int> Remove(long id);
    }
}