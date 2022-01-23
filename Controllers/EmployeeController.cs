using System;
using System.Threading.Tasks;
using DapperDemo.Dto;
using DapperDemo.Repositories.Interface;
using DapperDemo.Services.Interfaces;
using DapperDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index() => View(await _employeeRepository.GetAll());

        [HttpGet]
        public IActionResult New() => View(new EmployeeVm());

        [HttpPost]
        public async Task<IActionResult> New(EmployeeVm vm)
        {
            try
            {
                if (!ModelState.IsValid) return View(vm);
                var dto = new EmployeeDto(vm.FirstName, vm.LastName, vm.Age, vm.Salary);
                await _employeeService.Create(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var employee = await _employeeRepository.FinAsync(id);
                var vm = new EmployeeVm
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Salary = employee.Salary
                };
                return View(vm);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, EmployeeVm vm)
        {
            try
            {
                var employee = await _employeeRepository.FinAsync(id);
                if (!ModelState.IsValid) return View(vm);
                var dto = new EmployeeDto(vm.FirstName, vm.LastName, vm.Age, vm.Salary);
                await _employeeService.Update(employee, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var employee = await _employeeRepository.FinAsync(id);
                await _employeeService.Remove(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}