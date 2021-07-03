using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDemo.Entities;

namespace DapperDemo.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> FinAsync(long id);
        Task<List<Employee>> GetAll();
        Task<long> GetEmployeeCount();
    }
}