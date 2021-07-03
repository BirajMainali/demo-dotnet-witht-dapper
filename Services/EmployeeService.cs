using System.Threading.Tasks;
using System.Transactions;
using DapperDemo.Dto;
using DapperDemo.Entities;
using DapperDemo.Manager.Interface;
using DapperDemo.Services.Interfaces;

namespace DapperDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeService(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        public async Task Create(EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var employee = new Employee(dto.FirstName, dto.LastName, dto.Age, dto.Salary);
            await _employeeManager.Create(employee);
            tsc.Complete();
        }

        public async Task Update(Employee employee, EmployeeDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            employee.Update(dto.FirstName, dto.LastName, dto.Age, dto.Salary);
            await _employeeManager.Update(employee);
            tsc.Complete();
        }

        public async Task Remove(Employee employee)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await _employeeManager.Remove(employee.Id);
            tsc.Complete();
        }
    }
}