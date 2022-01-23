using System.Threading.Tasks;
using DapperDemo.Dto;
using DapperDemo.Models;

namespace DapperDemo.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task Create(EmployeeDto dto);
        Task Update(Employee employee, EmployeeDto dto);
        Task Remove(Employee employee);
    }
}