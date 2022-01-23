using System.Threading.Tasks;
using System.Transactions;
using DapperDemo.Dto;
using DapperDemo.Models;
using DapperDemo.Repositories.Interface;
using DapperDemo.Services.Interfaces;

namespace DapperDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task Create(EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var employee = new Employee(dto.FirstName, dto.LastName, dto.Age, dto.Salary);
            await _employeeRepo.Create(employee);
            tsc.Complete();
        }

        public async Task Update(Employee employee, EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            employee.Update(dto.FirstName, dto.LastName, dto.Age, dto.Salary);
            await _employeeRepo.Update(employee);
            tsc.Complete();
        }

        public async Task Remove(Employee employee)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await _employeeRepo.Remove(employee.Id);
            tsc.Complete();
        }
    }
}